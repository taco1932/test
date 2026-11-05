using System.Collections.Generic;
using VfxEditor.Formats.TmbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Bool;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.TmbFormat.Entries {
    public class C208 : TmbEntry {
        public const string MAGIC = "C208";
        public const string DISPLAY_NAME = "Retain Results UI----[TESTING] (CUTB)";
        //read: take precendence over C210's removal once
        //when (C209) + C210 called again, C208 is ignored
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt RefId = new( "Reference ID" ); //checks for first instance of C209 with the relevant ID
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );

        public C208( TmbFile file ) : base( file ) { }

        public C208( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            RefId,
            Unk3,
            Unk4
        ];
    }
}
