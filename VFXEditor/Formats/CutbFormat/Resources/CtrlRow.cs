using System.IO;
using VfxEditor.Parsing;
using VfxEditor.Ui.Interfaces;
using VfxEditor.CutbFormat;
using VfxEditor.CutbFormat.Utils;

namespace VfxEditor.CutbFormat.Ctrls {
    public class CtrlRow : IUiItem  {
        public readonly CutbOffsetString Path = new( "Path" );
        public readonly ParsedInt Priority = new( "Load Priority" );

        public CtrlRow( CutbReader reader ) {
            reader.UpdateStartPosition();
            Path.Read( reader );
            Priority.Read( reader );
        }

        public void Write( BinaryWriter writer ) {
            Unk1.Write( writer );
            Time.Write( writer );
            Unk2.Write( writer );
            Unk3.Write( writer );
            Unk4.Write( writer );
            Unk5.Write( writer );
        }

        public void Draw() {
            Path.Draw();
            Priority.Draw();
        }
    }
}
