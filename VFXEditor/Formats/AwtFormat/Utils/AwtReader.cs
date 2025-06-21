using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using VfxEditor.Formats.AwtFormat.Entry;
using VfxEditor.Parsing.Utils;
using VfxEditor.Utils;

namespace VfxEditor.AwtFormat.Utils {
    public class AwtReader : ParsingReader {
        public long StartPosition;

        public AwtReader( BinaryReader reader ) : base( reader ) { }

        public void UpdateStartPosition()
        {
            StartPosition = Reader.BaseStream.Position;
        }

        public string ReadType() {  
            return FileUtils.Reverse( Reader.ReadString() );
        }

    }
}
