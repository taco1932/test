using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C151 : TmbEntry {
        public const string MAGIC = "C151";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt TMFC = new( "F-Curve ID" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" ); //0 or 1
        private readonly ParsedInt Unk5 = new( "Unknown 5" ); //0


        public C151( TmbFile file ) : base( file ) { }

        public C151( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk2,
            TMFC,
            Unk4,
            Unk5,
        ];
    }
}
