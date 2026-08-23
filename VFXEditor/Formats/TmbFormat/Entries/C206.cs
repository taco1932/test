using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C206 : TmbEntry {
        public const string MAGIC = "C206";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB) [scheduler crash]";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedIntByte4 Unk4 = new( "Unknown 4" ); //01 01
        private readonly ParsedInt Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" ); //0, 1025, 1185
        private readonly ParsedInt Unk7 = new( "Unknown 7" );


        public C206( TmbFile file ) : base( file ) { }

        public C206( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7
        ];
    }
}
