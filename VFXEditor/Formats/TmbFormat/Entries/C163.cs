using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C163 : TmbEntry {
        public const string MAGIC = "C163";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB) [scheduler crash]";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt Unk2 = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3", value: 1 );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );

        //cut\ex1\skyadv\skyadv00110\skyadv00110.cutb
        //cut\ex1\heavnb\heavnb10410\heavnb10410.cutb

        public C163( TmbFile file ) : base( file ) { }

        public C163( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
        ];
    }
}
