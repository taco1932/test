using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C037 : TmbEntry {
        public const string MAGIC = "C037";
        public const string DISPLAY_NAME = "----[TESTING, WIP] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x78;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedIntByte4 Unk4 = new( "Unknown 4" );
        private readonly ParsedIntByte4 Unk5 = new( "Unknown 5" );
        private readonly ParsedIntByte4 Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );
        private readonly ParsedFloat Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );
        private readonly ParsedFloat Unk13 = new( "Unknown 13" );
        private readonly ParsedFloat Unk14 = new( "Unknown 14" );
        private readonly ParsedFloat Unk15 = new( "Unknown 15" );
        private readonly ParsedFloat Unk16 = new( "Unknown 16" );
        private readonly ParsedFloat Unk17 = new( "Unknown 17" );
        private readonly ParsedFloat Unk18 = new( "Unknown 18" );
        private readonly ParsedFloat Unk19 = new( "Unknown 19" );
        private readonly ParsedFloat Unk20 = new( "Unknown 20" );
        private readonly ParsedFloat Unk21 = new( "Unknown 21" );
        private readonly ParsedInt Unk22 = new( "Unknown 22" );
        private readonly ParsedInt Unk23 = new( "Unknown 23" );
        private readonly TmbOffsetFloat4 Unk24 = new( "Unknown 24" ); //placeholder. 76 bytes offset
        private readonly ParsedInt Unk25 = new( "Unknown 25" );
        private readonly ParsedFloat Unk26 = new( "Unknown 26" );
        private readonly ParsedFloat Unk27 = new( "Unknown 27" );

        public C037( TmbFile file ) : base( file ) { }

        public C037( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8,
            Unk9,
            Unk10,
            Unk11,
            Unk12,
            Unk13,
            Unk14,
            Unk15,
            Unk16,
            Unk17,
            Unk18,
            Unk19,
            Unk20,
            Unk21,
            Unk22,
            Unk23,
            Unk24,
            Unk25,
            Unk26,
            Unk27
        ];
    }
}
