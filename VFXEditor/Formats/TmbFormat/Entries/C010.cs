using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    [Flags]
    public enum C010Unk2Flags {
        Unknown_1A = 0x01, //cfxf_battle_camera1
        Unknown_1B = 0x02,
        Unknown_1C = 0x04,
        Unknown_1D = 0x08,
        Unknown_1E = 0x10,
        Unknown_1F = 0x20,
        Unknown_1G = 0x40,
        Unknown_1H_Unused = 0x80
    }
    [Flags]
    public enum C010Unk3Flags {
        Unknown_2A = 0x01,
        Unknown_2B_Unused = 0x02,
        Unknown_2C_Unused = 0x04,
        Unknown_2D = 0x08,
        Unknown_2E = 0x10,
        Unknown_2F = 0x20,
        Unknown_2G_Unused = 0x40,
        Unknown_2H_Unused = 0x80
    }


    public class C010 : TmbEntry {
        public const string MAGIC = "C010";
        public const string DISPLAY_NAME = "Animation";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedBool TimeControl = new( "Time Control Enabled", size: 1 );
        private readonly ParsedFlag<C010Unk2Flags> Unk3 = new ( "Unknown 3", size: 2 ); //vanilla up to 0x40
        //seen in CUTB
        //it's breaking blends and allowing weapon draw during standing looped emotes
        //probably less of a short and more of byte + unused
        private readonly ParsedFlag<C010Unk3Flags> Unk4 = new ( "Unknown 4", size: 1 ); //vanilla up to 0x20, but realistically none are used together
        private readonly ParsedFloat AnimationStart = new( "Animation Start Frame" );
        private readonly ParsedFloat AnimationEnd = new( "Animation End Frame" );
        private readonly TmbOffsetString Path = new( "Path" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );

        public C010( TmbFile file ) : base( file ) { }

        public C010( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            TimeControl,
            Unk3,
            Unk4,
            AnimationStart,
            AnimationEnd,
            Path,
            Unk2
        ];

        public override void DrawBody() {
            DrawHeader();
            CRC.Draw();
            Path.Draw();
            Unk2.Draw();
            TimeControl.Draw();

            using( var disabled = ImRaii.Disabled( TimeControl.Value == false ) ) {
                Duration.Draw();
                AnimationStart.Draw();
                AnimationEnd.Draw();
            }
            
            ImGui.Columns( 2 );
            Unk3.Draw();
            ImGui.TextDisabled( $"Value: {Unk3.IntValue}" );
            ImGui.NextColumn();
            Unk4.Draw();
            ImGui.TextDisabled( $"Value: {Unk4.IntValue}" );
            ImGui.Columns( 1 );
        }
    }
}
