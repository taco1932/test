using System.IO;
using VfxEditor.Parsing;
using VfxEditor.Ui.Interfaces;
using VfxEditor.AwtFormat.Utils;

namespace VfxEditor.Formats.AwtFormat.Entry {
    public class AwtEntry : IUiItem {
        public static int Size => 0x08;

        public readonly ParsedShort ItemID = new( "Index" );
        public readonly ParsedShort Type = new( "Type" );
        public readonly ParsedByte Unknown1 = new( "Value1" );
        public readonly ParsedByte Unknown2 = new( "Value2" );
        public readonly ParsedByte Unknown3 = new( "Value3" );
        public readonly ParsedByte Unknown4 = new( "Value4" );

        public AwtEntry() { }

        public AwtEntry( BinaryReader reader ) : this()
        {
            ItemID.Value = reader.ReadUInt16();
            Type.Value = reader.ReadUInt16();
            Unknown1.Value = reader.ReadByte();
            Unknown2.Value = reader.ReadByte();
            Unknown3.Value = reader.ReadByte();
            Unknown4.Value = reader.ReadByte();
            //Dalamud.Log(ItemID.Value.ToString() + "," + Type.Value );
        }

        public void Write( BinaryWriter writer )
        {
            ItemID.Write( writer );
            Type.Write( writer );
            Unknown1.Write( writer );
            Unknown2.Write( writer );
            Unknown3.Write( writer );
            Unknown4.Write( writer );
        }
        public void Draw() {
            ItemID.Draw();
            Type.Draw();
            Unknown1.Draw();
            Unknown2.Draw();
            Unknown3.Draw();
            Unknown4.Draw();
        }

        public byte[] ToBytes()
        {
            var wtdWriter = new AwtWriter(0, 0);
            wtdWriter.WriteEntry( this );

            using var ms = new MemoryStream();
            using var writer = new BinaryWriter( ms );
            wtdWriter.WriteTo( writer );
            wtdWriter.Dispose();
            return ms.ToArray();
        }

        public void Log()
        {
            Dalamud.Log( $"weaponId: {ItemID.Value}" );
            Dalamud.Log( $"Type: {Type.Value}" );
        }
    }
}
