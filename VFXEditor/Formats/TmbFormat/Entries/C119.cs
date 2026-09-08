using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C119 : TmbEntry {
        public const string MAGIC = "C119";
        public const string DISPLAY_NAME = "Apply PLD Set ----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedBool ApplySet = new( "Apply Set" );
        //e0042 set + Curtana + Holy Shield
        //only seems to respond as a bool


        public C119( TmbFile file ) : base( file ) { }

        public C119( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            ApplySet,
        ];
    }
}
