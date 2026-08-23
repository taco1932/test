using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C214 : TmbEntry {
        public const string MAGIC = "C214";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB) [scheduler crash]";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x30;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" ); //141, 162, 195. some secondary duration?
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 2 ); //0-2
        private readonly ParsedIntByte4 Unk5 = new( "Unknown 5" ); //00 00 01 00. first one may be a bind point (usually 0, saw one 71)
        private readonly ParsedIntByte4 Unk6 = new( "Unknown 6" ); //00 01 00 00. rarely 00 02 00 00
        private readonly ParsedFloat Unk7 = new( "Unknown 7", value: 0.5f ); //always this
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        //code seems to get applied retroactively. exists in a couple ARR files and EX1-EX3


        public C214( TmbFile file ) : base( file ) { }

        public C214( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8,
            Unk9
        ];
    }
}
