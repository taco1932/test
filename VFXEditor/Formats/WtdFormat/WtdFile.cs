using FFXIVClientStructs.FFXIV.Client.Game.Character;
using Dalamud.Bindings.ImGui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using VfxEditor.FileManager;
using VfxEditor.Formats.WtdFormat.Entry;
using VfxEditor.Utils;

namespace VfxEditor.Formats.WtdFormat {
    // https://github.com/Ottermandias/Penumbra.GameData/blob/main/Files/WtdFile.cs

    public class WtdFile : FileManagerFile {

        public const int BitFieldSize = 32;

        public readonly ushort NumStates;
        public readonly List<WtdEntry> Entries = [];
        private readonly WtdEntrySplitView EntryView;

        public unsafe WtdFile( BinaryReader reader ) : base() {
            Verified = VerifiedStatus.UNSUPPORTED; // verifying these is fucked. The format is pretty simple though, so it's not a big deal

            var unkdata = reader.ReadUInt16();
            var numEntries = reader.ReadUInt16();

            for( var i = 0; i < numEntries; i++ )
            {
                Entries.Add( new( reader ) );
            }

            EntryView = new( Entries );
        }

        public override void Write( BinaryWriter writer ) {
            //this is definitely incorrect but fuck it
            writer.Write( ( ushort )1d );
            writer.Write( ( ushort )Entries.Count );
            
            //string WRITE
            //Entries.ForEach( x => x.Write( writer ) );

            foreach( var (entry, i) in Entries.WithIndex() )
            {
                writer.Write( Entries[i].weaponId.Value ); 
                Entries[i].Write(writer);
            }
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
