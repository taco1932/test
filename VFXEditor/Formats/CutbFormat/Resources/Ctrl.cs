using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using SharpDX.Direct2D1;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VfxEditor.CutbFormat.Ctrls;
using VfxEditor.CutbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Entries;
using VfxEditor.TmbFormat.Tmfcs;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Ui.Components.SplitViews;
using static FFXIVClientStructs.Havok.Animation.Animation.hkaAnimation;

namespace VfxEditor.CutbFormat.Ctrls {
    public class Ctrl : CutbItem {
        public const string MAGIC = "CTRL";
        public const string DISPLAY_NAME = "Resource Load";
        public override string Magic => MAGIC;

        public readonly CtrlData Data;
        public readonly List<CtrlRow> Rows = [];
        private readonly UiSplitView<CtrlRow> DataSplitView;

        public int size;
        public int dataOffset;
        public int dataSize;

        public override int Size => size;
        public override int DataOffset => dataOffset;
        public override int DataSize => dataSize;

        public Ctrl( CutbFile file ) : base( file ) { }

        public Ctrl( CutbFile file, CutbReader reader ) : base( file, reader ) {
            var curpos = reader.GetReadPosition();
            reader.ReadInt32(); // Magic, CTRL, not retained
            size = reader.ReadInt32(); // Size
            dataOffset = reader.ReadInt32(); //start position of data within file, offset from start of entry.
            dataSize = reader.ReadInt32(); // Data length
            reader.OffsetReadPosition(dataOffset - Size );
            Data = new CtrlData( reader, file );
            DataSplitView = new( "Entry", Rows, false );
            reader.UpdateReadPosition(curpos + Size);
        }

        protected override List<ParsedBase> GetParsed() => [];

        public override void Write( CutbWriter writer ) {
            base.Write( writer );

            var offset = writer.WriteExtra( ( BinaryWriter bw ) => {
                foreach( var data in Data ) data.Write( bw );

                foreach( var data in Data ) data.WriteRows( bw );
            }, modifyOffset: 4 );

            writer.Write( Data.Count );
            Unk1.Write( writer );
            writer.Write( offset + ExtraSize );
            Unk2.Write( writer );
        }

        public override void DrawBody() {
            base.DrawBody();

            Unk1.Draw();
            Unk2.Draw();

            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 2 );
            ImGui.Separator();
            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 2 );

            using var _ = ImRaii.PushId( "Data" );
            DataSplitView.Draw();
        }
    }
}
