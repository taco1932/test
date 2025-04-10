using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C113 : TmbEntry {
        public const string MAGIC = "C113";
        public const string DISPLAY_NAME = "----VFX Colour [TESTING] (SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x24;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly TmbOffsetFloat4 RGBA = new( "Colour" );

        public C113( TmbFile file ) : base( file ) { }

        public C113( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk1,
            RGBA
        ];
    }
}
