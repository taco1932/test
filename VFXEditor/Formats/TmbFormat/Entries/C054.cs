using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C054 : TmbEntry {
        public const string MAGIC = "C054";
        public const string DISPLAY_NAME = "----[TESTING, WIP] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly TmbOffsetFloat4 Unk3 = new( "Unknown 3" ); //placeholder. they're not quite floats, and the size of the data is a bit ambiguous
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 1 );

        public C054( TmbFile file ) : base( file ) { }

        public C054( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4
        ];
    }
}
