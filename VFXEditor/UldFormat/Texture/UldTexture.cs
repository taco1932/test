using System;
using System.Collections.Generic;
using System.IO;
using VfxEditor.Parsing;
using VfxEditor.Ui.Components;

namespace VfxEditor.UldFormat.Texture {
    public class UldTexture : ISimpleUiBase {
        public readonly ParsedUInt Id = new( "Id" );
        public readonly ParsedString Path = new( "Path", maxSize: 44 );

        private readonly ParsedUInt Unk1 = new( "Unknown 1" );
        private readonly ParsedUInt Unk2 = new( "Unknown 2" );

        private string LastValue = "";

        public UldTexture() { }

        public UldTexture( BinaryReader reader, char minorVersion ) {
            Id.Read( reader );
            Path.Read( reader );
            Path.Pad( reader, 44 );
            Unk1.Read( reader );
            if( minorVersion == '1' ) Unk2.Read( reader );
            else Unk2.Value = 0;

            LastValue = Path.Value;
            Plugin.TextureManager.LoadPreviewTexture( Path.Value );
        }

        public string LoadTex() {
            var currentPathValue = Path.Value;
            if( currentPathValue != LastValue ) {
                LastValue = currentPathValue;
                Plugin.TextureManager.LoadPreviewTexture( currentPathValue );
            }
            return currentPathValue;
        }

        public void Write( BinaryWriter writer, char minorVersion ) {
            Id.Write( writer );
            Path.Write( writer );
            Path.Pad( writer, 44 );
            Unk1.Write( writer );
            if( minorVersion == '1' ) Unk2.Write( writer );
        }

        public void Draw( string id ) {
            Id.Draw( id, CommandManager.Uld );
            Path.Draw( id, CommandManager.Uld );
            Plugin.TextureManager.DrawTexture( LoadTex(), id );

            Unk1.Draw( id, CommandManager.Uld );
            Unk2.Draw( id, CommandManager.Uld );
        }

    }
}
