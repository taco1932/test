using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C048 : TmbEntry {
        public const string MAGIC = "C048";
        public const string DISPLAY_NAME = "----Cutscene Text Box [TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x40;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1);
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3", value: 1 );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedByte Unk5a = new( "Unknown 5a", value: 1 );
        private readonly ParsedByte Unk5b = new( "Unknown 5b", value: 1 );
        private readonly ParsedByte Unk5c = new( "Unknown 5c" );
        private readonly ParsedByte Unk5d = new( "Unknown 5d" );
        private readonly ParsedIntColor Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7 (some CRC?)" );
        private readonly ParsedInt Unk8 = new( "Unknown 8", value: 7 );
        private readonly TmbOffsetString Unk9 = new( "Text ID" );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );
        private readonly ParsedInt Unk13 = new( "Unknown 13" );
        


        public C048( TmbFile file ) : base( file ) { }

        public C048( TmbFile file, TmbReader reader ) : base( file, reader ) { }

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
            Unk12,
            Unk13
        ];
    }
}
