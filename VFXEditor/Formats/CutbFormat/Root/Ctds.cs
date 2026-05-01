using System.Collections.Generic;
using VfxEditor.CutbFormat;
using VfxEditor.CutbFormat.Ctrls;
using VfxEditor.CutbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.Ui.Components.SplitViews;
using VfxEditor.Utils;

namespace VfxEditor.CutbFormat {
    public class Ctds : CutbItem
    {
        public const string MAGIC = "CTDS";
        public const string DISPLAY_NAME = "Unknown";
        public override string Magic => MAGIC;

        public readonly ParsedInt RowSize;
        public readonly ParsedByte Unk1 = new( "Unknown 1" );
        public readonly ParsedByte Unk2 = new( "Unknown 2" );
        public readonly ParsedByte Unk3 = new( "Unknown 3" );
        public readonly ParsedByte Unk4 = new( "Unknown 4" );
        public readonly ParsedString Path = new( "Length" );

        public int size;
        public int dataOffset;
        public int dataSize;

        public override int Size => size;
        public override int DataOffset => dataOffset;
        public override int DataSize => dataSize;


        public Ctds( CutbFile file, CutbReader reader ) : base( file, reader ) {
            var curpos = reader.GetReadPosition();
            reader.ReadInt32(); // Magic, CTdS not retained
            size = reader.ReadInt32(); // Size
            dataOffset = reader.ReadInt32(); //start position of data within file, offset from start of entry.
            dataSize = reader.ReadInt32(); // Data length
            reader.OffsetReadPosition( dataOffset - Size );
            RowSize.Read( reader );
            Unk1.Read( reader );
            Unk2.Read( reader );
            Unk3.Read( reader );
            Unk4.Read( reader );
            Path.Read( reader );
            reader.UpdateReadPosition( curpos + Size );
        }

        public override void Write( TmbWriter writer ) {
            base.Write( writer );
            Unk1.Write( writer );
            Length.Write( writer );
            Unk3.Write( writer );
        }

        public void Draw() {
            Unk1.Draw();
            Length.Draw();
            Unk3.Draw();
        }
    }
}
