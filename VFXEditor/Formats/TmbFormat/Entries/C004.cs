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

        public override int Size => 0x68;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt TmfcId = new( "F-Curve ID" );
        private readonly TmbOffsetString CamName = new( "Camera Name" );
        private readonly ParsedFloat Unk5 = new( "Unknown 5" ); //0.1
        private readonly ParsedFloat Unk6 = new( "Unknown 6" ); //1000
        private readonly ParsedIntByte4 Unk7 = new( "Set 1" ); //each set is almost always FF FF FF FF (XYZW?). [09 00 00 FF]
        private readonly ParsedInt Bind1 = new( "Bind Point 1", value: 71 ); //bind always 71
        private readonly ParsedIntByte4 Unk9 = new( "Set 2" );
        private readonly ParsedInt Bind2 = new( "Bind Point 2", value: 71 );
        private readonly ParsedInt Unk11 = new( "Unknown 11", value: 1 );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );
        private readonly ParsedIntByte4 Unk13 = new( "Set 3" );
        private readonly ParsedInt Bind3 = new( "Bind Point 3", value: 71 );
        private readonly ParsedIntByte4 Unk15 = new( "Set 4" );
        private readonly ParsedInt Bind4 = new( "Bind Point 4", value: 71 );
        private readonly ParsedInt Unk17 = new( "Unknown 17" );
        private readonly ParsedIntByte4 Unk18 = new( "Set 5" );
        private readonly ParsedInt Bind5 = new( "Bind Point 5", value: 71 );
        private readonly ParsedIntByte4 Unk20 = new( "Set 6" );
        private readonly ParsedInt Bind6 = new( "Bind Point 6", value: 71 );
        private readonly ParsedInt Unk22 = new( "Unknown 22" );
        private readonly ParsedInt Unk23 = new( "Unknown 23", value: 1 );

        public C004( TmbFile file ) : base( file ) { }

        public C004( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            TmfcId,
            CamName,
            Unk5,
            Unk6,
            Unk7,
            Bind1,
            Unk9,
            Bind2,
            Unk11,
            Unk12,
            Unk13,
            Bind3,
            Unk15,
            Bind4,
            Unk17,
            Unk18,
            Bind5,
            Unk20,
            Bind6,
            Unk22,
            Unk23,
        ];
    }
}
