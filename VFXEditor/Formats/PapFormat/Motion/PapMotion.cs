using Dalamud.Bindings.ImGui;
using FFXIVClientStructs.Havok.Animation.Animation;
using FFXIVClientStructs.Havok.Animation.Playback;
using FFXIVClientStructs.Havok.Animation.Playback.Control;
using FFXIVClientStructs.Havok.Animation.Rig;
using FFXIVClientStructs.Havok.Common.Base.Container.String;
using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using VfxEditor.Formats.PapFormat.Motion.Preview;
using VfxEditor.Interop.Havok;
using VfxEditor.Parsing.Enums;
using VfxEditor.Parsing.String;

namespace VfxEditor.Formats.PapFormat.Motion {
    // https://github.com/soulsmods/DSMapStudio/blob/360245a095eb5db9dc821a213bc41b2b3ff3db0d/HKX2/Autogen/hkaInterleavedUncompressedAnimation.cs#L7
    // https://github.com/soulsmods/DSMapStudio/blob/360245a095eb5db9dc821a213bc41b2b3ff3db0d/HKX2/Autogen/hkaPredictiveCompressedAnimation.cs
    // https://github.com/soulsmods/DSMapStudio/blob/360245a095eb5db9dc821a213bc41b2b3ff3db0d/HKX2/Autogen/hkaQuantizedAnimation.cs
    // https://github.com/soulsmods/DSMapStudio/blob/360245a095eb5db9dc821a213bc41b2b3ff3db0d/HKX2/Autogen/hkaSplineCompressedAnimation.cs
    // https://github.com/soulsmods/DSMapStudio/blob/360245a095eb5db9dc821a213bc41b2b3ff3db0d/HKX2/Autogen/hkaInterleavedUncompressedAnimation.cs
    // https://github.com/0ceal0t/BlenderAssist/blob/main/BlenderAssist/pack_anim.cpp#L141

    public enum BlendHintTypes : int {
        Normal = 0x0,
        AdditiveDeprecated = 0x1,
        Additive = 0x2,
    }

    public unsafe class PapMotion {
        public readonly PapFile File;
        public readonly hkaAnimatedSkeleton* AnimatedSkeleton;
        public readonly hkaAnimationControl* AnimationControl;
        public hkaAnimationBinding* Binding => AnimationControl->Binding.ptr;
        public hkaAnimation* Animation => Binding->Animation.ptr;
        public hkaSkeleton* Skeleton => AnimatedSkeleton->Skeleton;

        public float Time => AnimationControl->LocalTime;
        public float Duration => Animation->Duration;
        public int TotalFrames => Math.Max( 1, ( int )MathF.Round( Duration * 30f ) + 1 );

        private readonly ParsedString OriginalSkeletonName = new( "Original Skeleton Name" );
        private readonly ParsedEnum<BlendHintTypes> BlendHint = new( "Blend Hint" );
        private readonly PapMotionPreview Preview;

        public PapMotion( PapFile file, HavokData bones, hkaAnimationBinding* binding ) {
            File = file;
            AnimatedSkeleton = ( hkaAnimatedSkeleton* )Marshal.AllocHGlobal( Marshal.SizeOf<hkaAnimatedSkeleton>() );
            AnimationControl = ( hkaAnimationControl* )Marshal.AllocHGlobal( Marshal.SizeOf<hkaAnimationControl>() );

            AnimationControl->Ctor1( binding );
            AnimatedSkeleton->Ctor1( bones.AnimationContainer->Skeletons[0].ptr );
            AnimatedSkeleton->addAnimationControl( AnimationControl );

            OriginalSkeletonName.Value = Binding->OriginalSkeletonName.String;
            BlendHint.Value = ( BlendHintTypes )Binding->BlendHint.Value;

            Preview = file.IsMaterial ? new PapMotionMaterial( file, this ) : new PapMotionSkeleton( file, this );
        }

        public void DrawPreview( int idx ) => Preview.Draw( idx );

        public void DrawHavok() {
            ImGui.TextDisabled( $"{Animation->Type}" );
            OriginalSkeletonName.Draw();
            BlendHint.Draw();
        }

        public void UpdateHavok( HashSet<nint> handles ) {
            var nameHandle = Marshal.StringToHGlobalAnsi( OriginalSkeletonName.Value );
            handles.Add( nameHandle );
            var namePtr = new hkStringPtr {
                StringAndFlag = ( byte* )nameHandle
            };
            Binding->OriginalSkeletonName = namePtr;
            Binding->BlendHint.Storage = ( sbyte )BlendHint.Value;
        }

        // An empty TransformTrackToBoneIndices / FloatTrackToFloatSlotIndices means Havok maps track i directly to bone / slot i

        public short[] GetTransformTrackBones() {
            var mapping = Binding->TransformTrackToBoneIndices;
            if( mapping.Length > 0 ) return [.. HavokData.ToList( mapping )];
            return [.. Enumerable.Range( 0, Animation->NumberOfTransformTracks ).Select( x => ( short )x )];
        }

        public short[] GetFloatTrackSlots() {
            var mapping = Binding->FloatTrackToFloatSlotIndices;
            if( mapping.Length > 0 ) return [.. HavokData.ToList( mapping )];
            return [.. Enumerable.Range( 0, Animation->NumberOfFloatTracks ).Select( x => ( short )x )];
        }

        public HashSet<int> GetUnanimatedBones() {
            var animatedBones = new HashSet<int>();

            foreach( var idx in GetTransformTrackBones() ) animatedBones.Add( idx );

            var unanimatedBones = new HashSet<int>();
            for( var i = 0; i < Skeleton->Bones.Length; i++ ) {
                if( !animatedBones.Contains( i ) ) unanimatedBones.Add( i );
            }
            return unanimatedBones;
        }

        public bool HasMismatchedSkeleton() {
            var numBones = Skeleton->Bones.Length;
            if( GetTransformTrackBones().Any( idx => idx >= numBones ) ) return true;
            var numFloats = Skeleton->FloatSlots.Length;
            if( GetFloatTrackSlots().Any( idx => idx >= numFloats ) ) return true;
            return false;
        }

        private hkArray<short>? OriginalBoneIndices;
        private hkArray<short>? OriginalFloatIndices;

        public void ClampTrackIndices( HashSet<nint> handles ) {
            var numBones = Skeleton->Bones.Length;
            var numFloats = Skeleton->FloatSlots.Length;

            OriginalBoneIndices = null;
            OriginalFloatIndices = null;

            var bones = GetTransformTrackBones();
            if( bones.Any( idx => idx >= numBones ) ) {
                OriginalBoneIndices = Binding->TransformTrackToBoneIndices;
                Binding->TransformTrackToBoneIndices = HavokData.CreateArray( handles, Binding->TransformTrackToBoneIndices,
                    [.. bones.Select( idx => idx < 0 || idx >= numBones ? ( short )-1 : idx )] );
            }

            var floats = GetFloatTrackSlots();
            if( floats.Any( idx => idx >= numFloats ) ) {
                OriginalFloatIndices = Binding->FloatTrackToFloatSlotIndices;
                Binding->FloatTrackToFloatSlotIndices = HavokData.CreateArray( handles, Binding->FloatTrackToFloatSlotIndices,
                    [.. floats.Select( idx => idx < 0 || idx >= numFloats ? ( short )-1 : idx )] );
            }
        }

        public void UnclampTrackIndices() {
            if( OriginalBoneIndices is hkArray<short> bones ) Binding->TransformTrackToBoneIndices = bones;
            if( OriginalFloatIndices is hkArray<short> floats ) Binding->FloatTrackToFloatSlotIndices = floats;
            OriginalBoneIndices = null;
            OriginalFloatIndices = null;
        }

        public void Dispose() {
            AnimatedSkeleton->removeAnimationControl( AnimationControl );
            Marshal.FreeHGlobal( ( nint )AnimatedSkeleton );
            Marshal.FreeHGlobal( ( nint )AnimationControl );
        }
    }
}