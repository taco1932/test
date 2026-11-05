using System.Collections.Generic;
using VfxEditor.Formats.TmbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Bool;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.TmbFormat.Entries {
    public class C143 : TmbEntry {
        public const string MAGIC = "C143";
        public const string DISPLAY_NAME = "Fishing Sound";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt BankID = new( "Sound Bank ID" );

        public C143( TmbFile file ) : base( file ) { }

        public C143( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            BankID
        ];
    }
}
