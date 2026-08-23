using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C019 : TmbEntry {
        public const string MAGIC = "C019";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB/SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled?", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedIntByte4 Unk3 = new( "Unknown 3" );

        public C019( TmbFile file ) : base( file ) { }

        public C019( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3
        ];
    }
}
