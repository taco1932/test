using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C071 : TmbEntry {
        public const string MAGIC = "C071";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedShort Unk3a = new( "Unknown 3a" ); //5, 11
        private readonly ParsedShort Unk3b = new( "Unknown 3b" ); //3000
        private readonly ParsedFloat Unk4 = new( "Unknown 4" ); //0.1
        private readonly ParsedInt Unk5 = new( "Unknown 5" );

        public C071( TmbFile file ) : base( file ) { }

        public C071( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3a,
            Unk3b,
            Unk4,
            Unk5
        ];
    }
}
