using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C004 : TmbEntry {
        public const string MAGIC = "C004";
        public const string DISPLAY_NAME = "----Cutscene Camera [TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x90;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly TmbOffsetString CamName = new( "Camera Name" );
        private readonly ParsedFloat Unk5 = new( "Unknown 5" );
        private readonly ParsedFloat Unk6 = new( "Unknown 6" );
        private readonly ParsedIntByte4 Unk7 = new( "Set 1" ); //sets always FF FF FF FF (XYZW?)
        private readonly ParsedInt Unk8 = new( "Bind Point 1" ); //points always 71
        private readonly ParsedIntByte4 Unk9 = new( "Set 2" );
        private readonly ParsedInt Unk10 = new( "Bind Point 2" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );
        private readonly ParsedIntByte4 Unk13 = new( "Set 3" );
        private readonly ParsedInt Unk14 = new( "Bind Point 3" );
        private readonly ParsedIntByte4 Unk15 = new( "Set 4" );
        private readonly ParsedInt Unk16 = new( "Bind Point 4" );
        private readonly ParsedInt Unk17 = new( "Unknown 17" );
        private readonly ParsedIntByte4 Unk18 = new( "Set 5" );
        private readonly ParsedInt Unk19 = new( "Bind Point 5" );
        private readonly ParsedIntByte4 Unk20 = new( "Set 6" );
        private readonly ParsedInt Unk21 = new( "Bind Point 6" );
        private readonly ParsedInt Unk22 = new( "Unknown 22" );
        private readonly ParsedInt Unk23 = new( "Unknown 23" ); //1
        private readonly ParsedIntByte4 Unk24 = new( "Set 7" );
        private readonly ParsedInt Unk25 = new( "Bind Point 7" );
        private readonly ParsedIntByte4 Unk26 = new( "Set 8" );
        private readonly ParsedInt Unk27 = new( "Bind Point 8" );
        private readonly ParsedInt Unk28 = new( "Unknown 28" );
        private readonly ParsedInt Unk29 = new( "Unknown 29" );
        private readonly ParsedInt Unk30 = new( "Unknown 30" );
        private readonly ParsedInt Unk31 = new( "Unknown 31" );
        private readonly ParsedInt Unk32 = new( "Unknown 32" );
        private readonly ParsedInt Unk33 = new( "Unknown 33" );


        public C004( TmbFile file ) : base( file ) { }

        public C004( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            CamName,
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
            Unk24,
            Unk25,
            Unk26,
            Unk27,
            Unk28,
            Unk29,
            Unk30,
            Unk31,
            Unk32,
            Unk33,
        ];
    }
}
