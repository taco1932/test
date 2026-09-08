using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C133 : TmbEntry {
        public const string MAGIC = "C133";
        public const string DISPLAY_NAME = "----[TESTING] (SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" ); //2, 4, 5
        private readonly ParsedInt Unk4 = new( "Unknown 4" ); //48

        public C133( TmbFile file ) : base( file ) { }

        public C133( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4
        ];
    }
}
