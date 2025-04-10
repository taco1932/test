using Dalamud.Interface.Utility.Raii;
using System.IO;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat.Sound.Data {
    public class SoundExtra {
        public readonly ParsedByte Version = new( "Version" );
        private readonly ParsedByte Reserve1 = new( "Reserve 1" );
        private ushort Size = 0x10;
        public readonly ParsedInt PlayTimeLength = new( "Play Time Length" );
        private readonly ParsedReserve Reserve2 = new( 2 * 4 );

        public void Read( BinaryReader reader ) {
            Version.Read( reader );
            Reserve1.Read( reader );
            Size = reader.ReadUInt16();
            PlayTimeLength.Read( reader );
            Reserve2.Read( reader );
        }

        public void Write( BinaryWriter writer ) {
            Version.Write( writer );
            Reserve1.Write( writer );
            writer.Write( Size );
            PlayTimeLength.Write( writer );
            Reserve2.Write( writer );
        }

        public void Draw() {
            using var _ = ImRaii.PushId( "Extra" );

            Version.Draw();
            Reserve1.Draw(); //test
            PlayTimeLength.Draw();
            Reserve2.Draw();
        }
    }
}
