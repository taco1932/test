using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C196 : TmbEntry {
        public const string MAGIC = "C196";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB) [scheduler crash]";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x38;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3", value: 1 );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedFloat Unk5 = new( "Unknown 5", value: 1.5f ); //2.0f
        private readonly ParsedInt Unk6 = new( "Unknown 6", value: 10 );
        private readonly ParsedInt Unk7 = new( "Unknown 7", value: 10 );
        private readonly ParsedInt Unk8 = new( "Unknown 8", value: 10 );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );


        public C196( TmbFile file ) : base( file ) { }

        public C196( TmbFile file, TmbReader reader ) : base( file, reader ) { }

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
            Unk11
        ];
    }
}
