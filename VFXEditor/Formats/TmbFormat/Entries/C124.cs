using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C124 : TmbEntry {
        public const string MAGIC = "C124";
        public const string DISPLAY_NAME = "Targetable Status";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;
        public override DangerLevel Danger => DangerLevel.Red;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Enabled = new( "Enabled", value: 1 );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt TargetStatus = new( "Targetable" );

        public C124( TmbFile file ) : base( file ) { }

        public C124( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unk2,
            TargetStatus
        ];
    }
}
