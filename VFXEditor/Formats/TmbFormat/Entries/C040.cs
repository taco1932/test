using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C040 : TmbEntry {
        public const string MAGIC = "C040";
        public const string DISPLAY_NAME = "----Cutscene Animation [TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x24;
        public override int ExtraSize => 0;

        private readonly ParsedBool Unk1 = new( "Enabled?" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly TmbOffsetString Path = new( "Path" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );

        public C040( TmbFile file ) : base( file ) { }

        public C040( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Path,
            Unk3,
            Unk4,
            Unk5
        ];
    }
}
