using FFXIVClientStructs.FFXIV.Client.Game.Character;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using VfxEditor.FileManager;
using VfxEditor.Formats.AwtFormat.Entry;
using VfxEditor.Utils;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.Formats.AwtFormat {
    // https://github.com/Ottermandias/Penumbra.GameData/blob/main/Files/AwtFile.cs

    public class AwtFile : FileManagerFile {

        public const int BitFieldSize = 32;

        private readonly short Version1;
        private readonly short Version2;
        private readonly uint Unk1;
        public readonly ushort NumStates;
        public readonly List<AwtEntry> Entries = [];
        private readonly AwtEntrySplitView EntryView;

        public unsafe AwtFile( BinaryReader reader ) : base()
        {
            reader.ReadInt32(); // magic 00617774
            Version1 = reader.ReadInt16();
            Version2 = reader.ReadInt16();
            var numEntries = reader.ReadUInt32();
            Unk1 = reader.ReadUInt32();

            for( var i = 0; i < numEntries+1; i++ )
            {
                Entries.Add( new( reader ) );
            }

            EntryView = new( Entries );
        }

        public override void Write( BinaryWriter writer ) {
            FileUtils.WriteMagic( writer, "awt" );
            writer.Write( ( ushort )Version1 );
            writer.Write( ( ushort )Version2 );
            writer.Write( ( ulong )Entries.Count-1 );
            foreach( var AWTEntry in Entries ) AWTEntry.Write( writer );
        }

        public override void Draw() {
            DrawCurrentWeapons();

            ImGui.Separator();

            EntryView.Draw();
        }

        private unsafe void DrawCurrentWeapons() {
            if( Dalamud.ClientState == null || Plugin.PlayerObject == null ) return;

            var weapons = new List<string>();
            // https://github.com/aers/FFXIVClientStructs/blob/2c388216cb52d4b6c4dbdedb735e1b343d56a846/FFXIVClientStructs/FFXIV/Client/Game/Character/Character.cs#L78C20-L78C23
            var dataStart = ( nint )Unsafe.AsPointer( ref ( ( Character* )Plugin.PlayerObject.Address )->DrawData ) + 0x20;

            for( var i = 0; i < 3; i++ ) {
                var data = dataStart + ( DrawObjectData.Size * i );
                if( Marshal.ReadInt64( data + 8 ) == 0 || Marshal.ReadInt64( data + 16 ) == 0 || Marshal.ReadInt32( data + 32 ) == 0 ) continue;

                var nameArr = Marshal.PtrToStringAnsi( data + 32 ).ToCharArray();
                Array.Reverse( nameArr );
                weapons.Add( new string( nameArr ) );
            }

            if( weapons.Count == 0 ) return;

            ImGui.Separator();

            ImGui.TextDisabled( $"Current Weapons: {weapons.Aggregate( ( x, y ) => x + " | " + y )}" );
        }
    }
}
