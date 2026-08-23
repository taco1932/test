using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using VfxEditor.Parsing;
using VfxEditor.Ui.Interfaces;

namespace VfxEditor.Formats.ObsbFormat.Entry {
    public class ObsbEntryState : IUiItem {
        public readonly ParsedString Bone = new( "Bone" );
        public readonly ParsedFloat Scale = new( "Scale" );
        public readonly ParsedFloat3 Offset = new( "Offset" );
        public readonly ParsedRadians3 Rotation = new( "Rotation" );

        public ObsbEntryState( BinaryReader reader )
        {
            var stringPos = reader.ReadUInt32();
            var savePos = reader.BaseStream.Position;

            // Read string
            reader.BaseStream.Position = stringPos;
            Bone.Read( reader );

            // Reset
            reader.BaseStream.Position = savePos;
            Scale.Read( reader );
            Offset.Read( reader );
            Rotation.Read( reader );
        }

        public ObsbEntryState( string bone, int scale, Vector3 offset, Vector3 rotation)
        {
            Bone.Value = bone;
            Scale.Value = BitConverter.Int32BitsToSingle(scale);
            Offset.Value = offset;
            Rotation.Value = rotation;
        }

        public void Write( BinaryWriter writer, int stringStartPos, BinaryWriter stringWriter, Dictionary<string, int> stringPos ) {
            if( !stringPos.TryGetValue( Bone.Value, out var value ) ) {
                value =  stringStartPos + ( int )stringWriter.BaseStream.Position;
                // Name not written yet
                stringPos[Bone.Value] = value;
                Bone.Write( stringWriter );
            }

            writer.Write( value );
            Scale.Write( writer );
            Offset.Write( writer );
            Rotation.Write( writer );
        }

        public void Draw() {
            Bone.Draw();
            Scale.Draw();
            Offset.Draw();
            Rotation.Draw();
        }
    }
}
