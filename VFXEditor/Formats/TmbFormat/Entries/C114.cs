using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C114 : TmbEntry {
        public const string MAGIC = "C114";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedIntColor Unk5 = new( "Unknown 5" );
        //private readonly ParsedByte Unk5 = new( "Unknown 5" );
        //private readonly ParsedByte Unk6 = new( "Unknown 6" );
        //private readonly ParsedShort Unk7 = new( "Unknown 7" );
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedFloat Unk9 = new( "Unknown 9" );

        public C114( TmbFile file ) : base( file ) { }

        public C114( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
           //Unk6,
           //Unk7,
            Unk8,
            Unk9
        ];
    }
}
