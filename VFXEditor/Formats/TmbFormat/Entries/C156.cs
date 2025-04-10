using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C156 : TmbEntry {
        public const string MAGIC = "C156";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x74;
        public override int ExtraSize => 0;

        private readonly ParsedBool Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt TmfcId = new( "F-Curve ID" );
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 1 );
        private readonly ParsedInt Unk5 = new( "Unknown 5", value: 71 );
        private readonly ParsedIntColor Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7", value: 71 );
        private readonly ParsedIntColor Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9", value: 71 );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedFloat Unk12 = new( "Unknown 12" );
        private readonly ParsedFloat Unk13 = new( "Unknown 13" );
        private readonly ParsedFloat Unk14 = new( "Unknown 14" );
        private readonly ParsedFloat Unk15 = new( "Unknown 15" );
        private readonly ParsedFloat Unk16 = new( "Unknown 16" );
        private readonly ParsedFloat Unk17 = new( "Unknown 17" );
        private readonly ParsedFloat Unk18 = new( "Unknown 18" );
        private readonly ParsedFloat Unk19 = new( "Unknown 19" );
        private readonly ParsedFloat Unk20 = new( "Unknown 20" );
        private readonly ParsedFloat Unk21 = new( "Unknown 21" );
        private readonly ParsedFloat Unk22 = new( "Unknown 22" );
        private readonly ParsedByte Unk23a = new( "Unknown 23a" );
        private readonly ParsedByte Unk23b = new( "Unknown 23b", value: 3 );
        private readonly ParsedShort Unk23c = new( "Unknown 23c" );
        private readonly ParsedFloat Unk24 = new( "Unknown 24" );
        private readonly ParsedFloat Unk25 = new( "Unknown 25" );
        private readonly ParsedFloat Unk26 = new( "Unknown 26" );



        public C156( TmbFile file ) : base( file ) { }

        public C156( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            TmfcId,
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
            Unk23a,
            Unk23b,
            Unk23c,
            Unk24,
            Unk25,
            Unk26
        ];
    }
}
