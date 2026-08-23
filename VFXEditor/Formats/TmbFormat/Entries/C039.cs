using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C039 : TmbEntry {
        public const string MAGIC = "C039";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x30;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedIntByte4 Unk3 = new( "Unknown 3" ); //0x 01 0x
        private readonly ParsedIntByte4 Unk4 = new( "Unknown 4" ); //1x 00 00 FF
        private readonly ParsedInt Unk5 = new( "Unknown 5" ); //0, 1
        private readonly ParsedFloat2 Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );
        private readonly ParsedInt Unk8 = new( "Unknown 8", value: 2 );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );

        public C039( TmbFile file ) : base( file ) { }

        public C039( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
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
