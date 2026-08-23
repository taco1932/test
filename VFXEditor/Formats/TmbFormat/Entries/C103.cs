using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C103 : TmbEntry {
        public const string MAGIC = "C103";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x30;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedIntByte4 Unk3 = new( "Unknown 3" ); //00 06 6A 34
        private readonly ParsedIntByte4 Unk4 = new( "Unknown 4" ); //B0 9D 11 00
        private readonly ParsedInt Unk5 = new( "Unknown 5" ); //0, 4
        private readonly ParsedInt Unk6 = new( "Unknown 6" ); //2, 3
        private readonly ParsedInt Unk7 = new( "Unknown 7" ); //0, 2
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );

        public C103( TmbFile file ) : base( file ) { }

        public C103( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
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
