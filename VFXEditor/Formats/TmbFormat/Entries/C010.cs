using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    [Flags]
    public enum AnimationFlags {
        Time_Control_Enabled = 0x01,
        Unknown_2 = 0x02,
        Unknown_3 = 0x04,
        Unknown_4 = 0x08,
        Unknown_5 = 0x10,
        Unknown_6 = 0x20,
        Unknown_7 = 0x40,
        Unknown_8 = 0x80
    }

    public class C010 : TmbEntry {
        public const string MAGIC = "C010";
        public const string DISPLAY_NAME = "Animation";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk1 = new( "CRC" );
        private readonly ParsedFlag<AnimationFlags> Flags = new( "Flags", size: 1 ); //never seen beyond 1
        private readonly ParsedByte Unk3 = new ( "Unknown 3 [after flags]" ); //1-6. probably an enum
        //seen in CUTB
        //it's breaking blends and allowing weapon draw during standing looped emotes
        private readonly ParsedByte Unk4 = new ( "Unknown 4 [after flags]" ); //0
        private readonly ParsedByte Unk5 = new ( "Unknown 5 [after flags]" ); //8
        private readonly ParsedFloat AnimationStart = new( "Animation Start Frame" );
        private readonly ParsedFloat AnimationEnd = new( "Animation End Frame" );
        private readonly TmbOffsetString Path = new( "Path" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );

        public C010( TmbFile file ) : base( file ) { }

        public C010( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk1,
            Flags,
            Unk3,
            Unk4,
            Unk5,
            AnimationStart,
            AnimationEnd,
            Path,
            Unk2
        ];

        public override void DrawBody() {
            DrawHeader();
            Unk1.Draw();
            Flags.Draw();

            using( var disabled = ImRaii.Disabled( !Flags.HasFlag( AnimationFlags.Time_Control_Enabled ) ) ) {
                Duration.Draw();
                AnimationStart.Draw();
                AnimationEnd.Draw();
            }

            Path.Draw();
            Unk2.Draw();
            Unk3.Draw();
            Unk4.Draw();
            Unk5.Draw();
        }
    }
}
