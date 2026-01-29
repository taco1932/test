using System.IO;
using VfxEditor.Parsing.Utils;
using VfxEditor.Utils;

namespace VfxEditor.WtdFormat.Utils {
    public class WtdReader : ParsingReader {
        public long StartPosition;

        public WtdReader( BinaryReader reader ) : base( reader ) { }

        public void UpdateStartPosition()
        {
            StartPosition = Reader.BaseStream.Position;
        }

        public string ReadType() {  
            return FileUtils.Reverse( Reader.ReadString() );
        }

    }
}
