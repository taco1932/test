using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C020 : TmbEntry {
        public const string MAGIC = "C020";
        public const string DISPLAY_NAME = "----LVB call? [TESTING, WIP] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x6C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled?" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly TmbOffsetString Unk3 = new( "Path" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        private readonly ParsedFloat Unk10 = new( "Unknown 10" );
        private readonly ParsedInt4 Unk11 = new( "Unknown 11" );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );
        private readonly ParsedInt Unk13 = new( "Unknown 13" );
        private readonly ParsedInt Unk14 = new( "Unknown 14" );
        private readonly ParsedInt Unk15 = new( "Unknown 15" );
        private readonly ParsedInt Unk16 = new( "Unknown 16" );
        private readonly ParsedInt Unk17 = new( "Unknown 17" );
        private readonly ParsedInt Unk18 = new( "Unknown 18" );
        private readonly ParsedInt Unk19 = new( "Unknown 19" );
        private readonly ParsedInt Unk20 = new( "Unknown 20" );
        private readonly TmbOffsetFloat4 Unk21 = new( "Unknown 21" ); //placeholder
        private readonly ParsedInt Unk22 = new( "Unknown 22" );
        private readonly ParsedInt Unk23 = new( "Unknown 23" );
        private readonly ParsedInt Unk24 = new( "Unknown 24" );

        public C020( TmbFile file ) : base( file ) { }

        public C020( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8,
            Unk9,
            Unk10,
            Unk11,
            Unk12,
            Unk13,
            Unk14,
            Unk15,
            Unk16,
            Unk17,
            Unk18,
            Unk19,
            Unk20,
            Unk21,
            Unk22,
            Unk23,
            Unk24
        ];
    }
}
