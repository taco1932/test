using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Formats.ObsbFormat.Headers;

namespace VfxEditor.Formats.ObsbFormat { 

    public class ObsbFile : FileManagerFile {

        private readonly ObsbHeader ObsbHeader;
        private readonly EnvsHeader EnvsHeader;
        //private readonly ObsbEntrySplitView EntryView;

        public unsafe ObsbFile( BinaryReader reader ) : base()
        {
            ObsbHeader = new( reader );
            EnvsHeader = new( reader );
            
            //WIP
        }

        public override void Write( BinaryWriter writer ) {
            ObsbHeader.Write( writer );
            EnvsHeader.Write( writer );

            //WIP
        }

        public override void Draw() {
            //EntryView.Draw();
        }
    }
}
