using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C171 : TmbEntry {
        public const string MAGIC = "C171";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x58; //chonky
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3", value: 0xFF );
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 1 );
        private readonly ParsedInt Unk5 = new( "Unknown 5", value: 2 );
        private readonly ParsedInt Unk6 = new( "Offset floats (a lot)" ); //offset?
        //2,709 floats???
        private readonly ParsedInt Unk7 = new( "Unknown 7" ); //241, 301
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        private readonly ParsedInt Unk10 = new( "Offset floats (a lot more)" ); //offset?
        //902 floats at this offset
        private readonly ParsedInt Unk11 = new( "Unknown 11" ); //482, 602
        private readonly ParsedInt Unk12 = new( "Unknown 12", value: 1 );
        private readonly ParsedInt Unk13 = new( "Unknown 13" );
        private readonly ParsedInt Unk14 = new( "Unknown 14" );
        private readonly ParsedInt Unk15 = new( "Unknown 15" );
        private readonly ParsedInt Unk16 = new( "Unknown 16" );
        private readonly ParsedInt Unk17 = new( "Unknown 17" );
        private readonly ParsedInt Unk18 = new( "Unknown 18" );
        private readonly ParsedInt Unk19 = new( "Unknown 19" );


        public C171( TmbFile file ) : base( file ) { }

        public C171( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
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
            Unk19
        ];
    }
}
