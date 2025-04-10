using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C084 : TmbEntry {
        public const string MAGIC = "C084";
        public const string DISPLAY_NAME = "";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;
        public override DangerLevel Danger => DangerLevel.Yellow;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled" );
        private readonly ParsedInt Unk2 = new( "ID?" );
        private readonly ParsedInt Unk3 = new( "Target Type?", value: 13);

        public C084( TmbFile file ) : base( file ) { }

        public C084( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3
        ];
    }
}
