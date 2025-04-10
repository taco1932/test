using Dalamud.Interface.Utility.Raii;
using System.IO;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat.Sound.Data {
    public class SoundAtomos {
        public readonly ParsedByte Version = new( "Version" );
        private readonly ParsedByte Reserve1 = new( "Reserve 1" );
        private ushort Size = 0x10;
        public readonly ParsedShort MinPeople = new( "Minimum Number of People" );
        public readonly ParsedShort MaxPeople = new( "Maximum Number of People" );
        private readonly ParsedReserve Reserve2 = new( 2 * 4 );

        public void Read( BinaryReader reader ) {
            Version.Read( reader );
            Reserve1.Read( reader );
            Size = reader.ReadUInt16();
            MinPeople.Read( reader );
            MaxPeople.Read( reader );
            Reserve2.Read( reader );
        }

        public void Write( BinaryWriter writer ) {
            Version.Write( writer );
            Reserve1.Write( writer );
            writer.Write( Size );
            MinPeople.Write( writer );
            MaxPeople.Write( writer );
            Reserve2.Write( writer );
        }

        public void Draw() {
            using var _ = ImRaii.PushId( "Atomos" );

            Version.Draw();
            Reserve1.Draw(); //test
            MinPeople.Draw();
            MaxPeople.Draw();
            Reserve2.Draw(); //test
        }
    }
}
