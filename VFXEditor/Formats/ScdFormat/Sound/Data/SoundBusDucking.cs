using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System.IO;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat.Sound.Data {
    public class SoundBusDucking {
        private byte Size = 0x10;
        public readonly ParsedByte Number = new( "Number" );
        private readonly ParsedByteBool ExtraEnabled = new( "Enable Extra Data");
        private readonly ParsedByte Unknown1 = new( "Number Amount?" );
        public readonly ParsedInt FadeTime = new( "Fade Time" );
        public readonly ParsedFloat Volume = new( "Volume" );
        private readonly ParsedSByte ExtraNum1 = new( "Sub-Number 1" );
        private readonly ParsedSByte ExtraNum2 = new( "Sub-Number 2" );
        private readonly ParsedSByte ExtraNum3 = new( "Sub-Number 3" );
        private readonly ParsedSByte ExtraNum4 = new( "Sub-Number 4" );

        //sound/zingle/zingle_lvup_each5.scd
        //sound/zingle/zingle_fgs_02.scd

        public void Read( BinaryReader reader ) {
            Size = reader.ReadByte();
            Number.Read( reader );
            ExtraEnabled.Read( reader );
            Unknown1.Read( reader );
            FadeTime.Read( reader );
            Volume.Read( reader );
            ExtraNum1.Read( reader );
            ExtraNum2.Read( reader );
            ExtraNum3.Read( reader );
            ExtraNum4.Read( reader );
        }

        public void Write( BinaryWriter writer ) {
            writer.Write( Size );
            Number.Write( writer );
            ExtraEnabled.Write( writer );
            Unknown1.Write( writer );
            FadeTime.Write( writer );
            Volume.Write( writer );
            ExtraNum1.Write( writer );
            ExtraNum2.Write( writer );
            ExtraNum3.Write( writer );
            ExtraNum4.Write( writer );
        }

        public void Draw() {
            using var _ = ImRaii.PushId( "BusDucking" );

            Number.Draw();
            FadeTime.Draw();
            Volume.Draw();
            ImGui.NewLine();
            ImGui.Separator();
            ImGui.NewLine();
            ExtraEnabled.Draw();
            //to do: disable if extra data unchecked
            ExtraNum1.Draw();
            ExtraNum2.Draw();
            ExtraNum3.Draw();
            ExtraNum4.Draw();
        }
    }
}
