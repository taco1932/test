using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C188 : TmbEntry {
        public const string MAGIC = "C188";
        public const string DISPLAY_NAME = "Invisibility";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x14;
        public override int ExtraSize => 0;

        private readonly ParsedInt InvisStatus = new( "Invisibility Status" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );

        public C188( TmbFile file ) : base( file ) { }

        public C188( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            InvisStatus,
            Unk2
        ];
    }
}
