using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C011 : TmbEntry {
        public const string MAGIC = "C011";
        public const string DISPLAY_NAME = "Fly Text";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x14;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );

        public C011( TmbFile file ) : base( file ) { }

        public C011( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2
        ];
    }
}
