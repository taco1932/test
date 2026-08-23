using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C164 : TmbEntry {
        public const string MAGIC = "C164";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt Unk2 = new( "CRC" );
        private readonly TmbOffsetString Path = new( "Path", null, true ); //atr_attach
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );

        //cut\ex1\banall\banall13010\banall13010.cutb
        //cut\ex1\jobrel\jobrel10410\jobrel10410.cutb

        public C164( TmbFile file ) : base( file ) { }

        public C164( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Path,
            Unk4,
            Unk5,
        ];
    }
}
