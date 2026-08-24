using System.IO;

namespace VfxEditor.Formats.ObsbFormat.Headers {
    public class ObsbHeader {
        public int Magic;
        public int FileSize; //includes headers
        public int Unk1; //1. enabled or total headers or something
        public ObsbHeader( BinaryReader reader ) {
            Magic = reader.ReadInt32();
            FileSize = reader.ReadInt32();
            Unk1 = reader.ReadInt32();
        }

        public void Write( BinaryWriter writer ) {
            writer.Write( Magic );
            writer.Write( FileSize );
            writer.Write( Unk1 );
        }
    }
}
