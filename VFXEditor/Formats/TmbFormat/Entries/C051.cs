using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C051 : TmbEntry {
        public const string MAGIC = "C051";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x64;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedIntByte4 Unk4 = new( "Set 1" );
        private readonly ParsedInt Unk5 = new( "Bind Point 1" );
        private readonly ParsedIntByte4 Unk6 = new( "Set 2" );
        private readonly ParsedInt Unk7 = new( "Bind Point 2" );
        private readonly ParsedIntByte4 Unk8 = new( "Set 3" );
        private readonly ParsedInt Unk9 = new( "Bind Point 3" );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );
        private readonly ParsedInt Unk13 = new( "Unknown 13" );
        private readonly ParsedInt Unk14 = new( "Unknown 14" );
        private readonly ParsedInt Unk15 = new( "Unknown 15" );
        private readonly ParsedInt Unk16 = new( "Unknown 16" );
        private readonly ParsedInt Unk17 = new( "Unknown 17" );
        private readonly ParsedInt Unk18 = new( "Unknown 18" );
        private readonly ParsedInt Unk19 = new( "Unknown 19" );
        private readonly ParsedInt Unk20 = new( "Unknown 20" );
        private readonly ParsedInt Unk21 = new( "Unknown 21" );
        private readonly ParsedInt Unk22 = new( "Unknown 22" );

        public C051( TmbFile file ) : base( file ) { }

        public C051( TmbFile file, TmbReader reader ) : base( file, reader ) { }

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
            Unk22
        ];
    }
}
