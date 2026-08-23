using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C162 : TmbEntry {
        public const string MAGIC = "C162";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x78;
        public override int ExtraSize => 0; //

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
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
        private readonly ParsedFloat3 Unk13 = new( "Unknown 13" );
        private readonly ParsedFloat3 Unk14 = new( "Unknown 14" );
        private readonly ParsedFloat3 Unk15 = new( "Unknown 15" );
        private readonly ParsedInt Unk16 = new( "Unknown 16", value: 1 );
        private readonly ParsedInt Unk17 = new( "Unknown 17", value: 2 );
        private readonly TmbOffsetFloat4 Unk18 = new( "Unknown 18" ); //placeholder for footer data
        private readonly ParsedInt Unk19 = new( "Unknown 19", value: 2 );
        private readonly ParsedFloat2 Unk20 = new( "Unknown 20" );



        public C162( TmbFile file ) : base( file ) { }

        public C162( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
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
        ];
    }
}
