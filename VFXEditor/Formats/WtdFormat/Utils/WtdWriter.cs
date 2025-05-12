using System;
using System.IO;
using System.Numerics;
using VfxEditor.Formats.WtdFormat.Entry;
using VfxEditor.Parsing.Utils;
using VfxEditor.Utils;

namespace VfxEditor.WtdFormat.Utils {
    public class WtdWriter : ParsingWriter {
        public int BodySize;
        public int StateSize;

        public long StartPosition;
        public readonly BinaryWriter StateWriter;

        public readonly MemoryStream StateMs;

        public WtdWriter( int bodySize, int stateSize ) : base() {
            BodySize = bodySize;
            StateSize = stateSize;

            StateMs = new();
            StateWriter = new( StateMs );
        }

        public override void Dispose()
        {
            base.Dispose();
            StateWriter.Close();
            StateMs.Close();
        }

        public void WriteEntry( WtdEntry entry )
        {
            Writer.Write( entry.weaponId.Value );
            Writer.Write( FileUtils.Reverse( entry.Type.Value ));
        }


        public override void WriteTo( BinaryWriter writer )
        {
            base.WriteTo( writer );
            writer.Write( StateMs.ToArray() );
        }
    }
}
