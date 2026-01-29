using System.IO;
using VfxEditor.Formats.AwtFormat.Entry;
using VfxEditor.Parsing.Utils;

namespace VfxEditor.AwtFormat.Utils {
    public class AwtWriter : ParsingWriter {
        public int BodySize;
        public int StateSize;

        public long StartPosition;
        public readonly BinaryWriter StateWriter;

        public readonly MemoryStream StateMs;

        public AwtWriter( int bodySize, int stateSize ) : base() {
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

        public void WriteEntry( AwtEntry entry )
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
