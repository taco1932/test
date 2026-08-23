using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C235 : TmbEntry {
        public const string MAGIC = "C235";
        public const string DISPLAY_NAME = "----[TESTING] (SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled" );
        private readonly ParsedInt Unk2 = new( "CRC" );
        private readonly TmbOffsetString Path = new( "Path", null, true ); //cbbm_atk1
        private readonly ParsedInt Unk4 = new( "Unknown 4" );


        public C235( TmbFile file ) : base( file ) { }

        public C235( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Path,
            Unk4,
        ];
    }
}
