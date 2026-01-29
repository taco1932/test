using System.IO;
using VfxEditor.Parsing.Utils;
using VfxEditor.Utils;

namespace VfxEditor.ObsbFormat.Utils {
    public class ObsbReader : ParsingReader {
        public long StartPosition;

        public ObsbReader( BinaryReader reader ) : base( reader ) { }

        public void UpdateStartPosition()
        {
            StartPosition = Reader.BaseStream.Position;
        }

        public string ReadType() {  
            return FileUtils.Reverse( Reader.ReadString() );
        }

    }
}
