using System;
using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    [Flags]
    public enum PoseFlags {
        Freeze_and_State = 0x01,
        Freeze_and_Delay_State = 0x02,
        Unknown_3 = 0x04,
        Unknown_4 = 0x08,
        Unknown_5 = 0x10,
        Unknown_6 = 0x20,
        Unknown_7 = 0x40,
        Unknown_8 = 0x80,
    }
    public class C165 : TmbEntry {
        public const string MAGIC = "C165";
        public const string DISPLAY_NAME = "Freeze Pose [CUTB]";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x30;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedBool Unk2 = new( "Unknown 2" );
        private readonly ParsedEnum<PoseFlags> Unk3 = new( "Unknown 3" ); //does stuff at low values, but vanilla has it as an enum, I think?
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedFloat Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6", value: 0xFF );
        private readonly TmbOffsetFloat3 Unk7 = new( "Unknown 7" ); //pointer, but I'm not sure if it's a single value set or a gigantic block
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );


        public C165( TmbFile file ) : base( file ) { }

        public C165( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8,
            Unk9
        ];
    }
}
