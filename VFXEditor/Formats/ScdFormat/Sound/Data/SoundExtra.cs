using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System;
using System.IO;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat.Sound.Data {
    [Flags]
    public enum SoundExtraFilter {
        Unknown_2 = 0x01,
        DualShock_A = 0x02, //dualsense/shock4 vibration + speaker. louder/stronger than x04 and x08. some cases this won't occur?
        Controller_Sound_Only = 0x04, //mutes sound in game and uses a softer vibration. can affect how it sounds. also adds an extra sound on system sounds?
        DualShock_B = 0x08, //dualsense/shock4 soft(er) vibration + speaker, set to always trigger on anything. fishing + some zingles (gs_ride_countdown) = x08 + x02
        Unknown_3 = 0x10, //weapon swing/hit
        Use_High_Shelf_Filter = 0x20, //modifies the sound a bit sometimes. damps frequency. ranged skills. melee is x20 + x10
        Unknown_4 = 0x40,
        Unknown_5 = 0x80 //randomwind
    }
    public class SoundExtra {
        public readonly ParsedByte Version = new( "Version" );
        private readonly ParsedByte Unknown1 = new( "Reserve 1" ); //Reserve 1
        private ushort Size = 0x10;
        public readonly ParsedInt PlayTimeLength = new( "Play Time Length" );
        //private readonly ParsedReserve Reserve2 = new( 2 * 4 );

        private readonly ParsedFlag<SoundExtraFilter> SoundFilter = new( "Sound Filter" );
        private readonly ParsedFloat Unknown6 = new( "Unknown 6" ); //0.0 or 999.0

        public void Read( BinaryReader reader ) {
            Version.Read( reader );
            Unknown1.Read( reader );
            Size = reader.ReadUInt16();
            PlayTimeLength.Read( reader );
            SoundFilter.Read( reader );
            Unknown6.Read( reader );
        }

        public void Write( BinaryWriter writer ) {
            Version.Write( writer );
            Unknown1.Write( writer );
            writer.Write( Size );
            PlayTimeLength.Write( writer );
            SoundFilter.Write( writer );
            Unknown6.Write( writer );
        }

        public void Draw() {
            using var _ = ImRaii.PushId( "Extra" );

            Version.Draw();
            Unknown1.Draw();
            PlayTimeLength.Draw();
            SoundFilter.Draw();
            ImGui.TextDisabled( $"Value: {SoundFilter.IntValue}" );
            Unknown6.Draw();
        }
    }
}
