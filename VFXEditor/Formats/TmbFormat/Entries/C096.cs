using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C096 : TmbEntry {
        public const string MAGIC = "C096";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x24;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedIntByte4 Unk3 = new( "Unknown 3" );
        private readonly ParsedFloat Unk4 = new( "Unknown 4" );
        private readonly ParsedFloat Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );

        public C096( TmbFile file ) : base( file ) { }

        public C096( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
            Unk6
        ];
    }
}
