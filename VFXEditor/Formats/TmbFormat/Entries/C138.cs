using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C138 : TmbEntry {
        public const string MAGIC = "C138";
        public const string DISPLAY_NAME = "----[TESTING] (SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x44;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5a = new( "Unknown 5a" );
        private readonly ParsedInt Unk5b = new( "Unknown 5b" );
        private readonly ParsedInt Unk5c = new( "Unknown 5c" );
        private readonly ParsedInt Unk5d = new( "Unknown 5d" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedShort Unk12a = new( "Unknown 12a" );
        private readonly ParsedShort Unk12b = new( "Unknown 12b" );
        private readonly ParsedShort Unk13a = new( "Unknown 13a" );
        private readonly ParsedShort Unk13b = new( "Unknown 13b" );
        private readonly ParsedShort Unk14a = new( "Unknown 14a" );
        private readonly ParsedShort Unk14b = new( "Unknown 14b" );

        //bg/ex1/02_dra_d2/shared/for_bg/sgbg_d2a0_ab_coa00.sgb

        public C138( TmbFile file ) : base( file ) { }

        public C138( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5a,
            Unk5b,
            Unk5c,
            Unk5d,
            Unk6,
            Unk7,
            Unk8,
            Unk9,
            Unk10,
            Unk11,
            Unk12a,
            Unk12b,
            Unk13a,
            Unk13b,
            Unk14a,
            Unk14b
        ];
    }
}
