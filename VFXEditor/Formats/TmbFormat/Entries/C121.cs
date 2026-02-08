using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C121 : TmbEntry {
        public const string MAGIC = "C121";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedByte Unk3a = new( "Unknown 3a" );
        private readonly ParsedByte Unk3b = new( "Unknown 3b" );
        private readonly ParsedShort Unk3c = new( "Unknown 3c" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );


        public C121( TmbFile file ) : base( file ) { }

        public C121( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3a,
            Unk3b,
            Unk3c,
            Unk4,
        ];
    }
}
