using System;
using System.IO;
using System.Numerics;
using VfxEditor.Formats.ObsbFormat.Entry;
using VfxEditor.Parsing.Utils;
using VfxEditor.Utils;

namespace VfxEditor.ObsbFormat.Utils {
    public class ObsbWriter : ParsingWriter {
        public int BodySize;
        public int StateSize;

        public long StartPosition;
        public readonly BinaryWriter StateWriter;

        public readonly MemoryStream StateMs;

        public ObsbWriter( int bodySize, int stateSize ) : base() {
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

        public void WriteEntry( ObsbEntry entry )
        {
            Writer.Write( entry.ItemID.Value );
            Writer.Write( entry.Type.Value );
            Writer.Write( entry.Unknown1.Value );
            Writer.Write( entry.Unknown2.Value );
            Writer.Write( entry.Unknown3.Value );
            Writer.Write( entry.Unknown4.Value );
        }


        public override void WriteTo( BinaryWriter writer )
        {
            base.WriteTo( writer );
            writer.Write( StateMs.ToArray() );
        }
    }
}
