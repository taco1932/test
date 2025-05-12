using ImGuiNET;
using Dalamud.Interface.Utility.Raii;
using System.Collections.Generic;
using System.IO;
using VfxEditor.Parsing;
using VfxEditor.Ui.Interfaces;
using VfxEditor.Utils;
using VfxEditor.WtdFormat.Utils;
using System.Xml.Linq;
using SharpGLTF.Schema2;
using System;

namespace VfxEditor.Formats.WtdFormat.Entry {
    public class WtdEntry : IUiItem {
        public int Size => 0x18;
        public readonly ParsedUInt weaponId = new( "weaponId" );
        public readonly ParsedString Type = new( "Type" );

        public string WeaponType => WtdUtils.WeaponNames.TryGetValue( Type.Value, out var weaponName ) ? weaponName : "";

        public WtdEntry() { }

        public WtdEntry( BinaryReader reader ) : this()
        {
            weaponId.Value = reader.ReadUInt32();
            Type.Value = FileUtils.Reverse( FileUtils.ReadString( reader ) );
            Dalamud.Log( "," + weaponId.Value.ToString() + "," + Type.Value );
        }

        public void Write( BinaryWriter writer ) {
            FileUtils.WriteString( writer, FileUtils.Reverse( Type.Value ), true );
        }
        public void Draw() {
            weaponId.Draw();
            Type.Draw( 3, Type.Name, 0, ImGuiInputTextFlags.None );
        }

        public byte[] ToBytes()
        {
            var wtdWriter = new WtdWriter(0, 0);
            wtdWriter.WriteEntry( this );

            using var ms = new MemoryStream();
            using var writer = new BinaryWriter( ms );
            wtdWriter.WriteTo( writer );
            wtdWriter.Dispose();
            return ms.ToArray();
        }

        public void Log()
        {
            Dalamud.Log( $"weaponId: {weaponId.Value}" );
            Dalamud.Log( $"Type: {Type.Value}" );
        }
    }
}
