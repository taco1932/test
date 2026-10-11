using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C016 : TmbEntry {
        public const string MAGIC = "C016";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB/SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk2 = new( "Unknown 2", value: 1 );
        private readonly ParsedIntByte4 Unk3 = new( "Unknown 3", value: 256 ); //01 01, 02 00
        private readonly ParsedInt Unk4 = new( "Unknown 4" );

        public C016( TmbFile file ) : base( file ) { }

        public C016( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Unk2,
            Unk3,
            Unk4
        ];
    }
}
