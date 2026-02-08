using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C148 : TmbEntry {
        public const string MAGIC = "C148";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedShort Unk3a = new( "Unknown 3a" ); //1 or 3
        private readonly ParsedShort Unk3b = new( "Unknown 3b" ); //0 or 1


        public C148( TmbFile file ) : base( file ) { }

        public C148( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3a,
            Unk3b,
        ];
    }
}
