using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C145 : TmbEntry {
        public const string MAGIC = "C145";
        public const string DISPLAY_NAME = "Set e0001 ----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Set EQP to e0001", value: 1 );
        //this is all this does. I can't get it to work with any other value.
        //cut\ffxiv\chocmn\chocmn00010\chocmn00010.cutb


        public C145( TmbFile file ) : base( file ) { }

        public C145( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
        ];
    }
}
