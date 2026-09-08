using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C233 : TmbEntry {
        public const string MAGIC = "C233";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x2C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" ); //0, 1
        private readonly ParsedInt Unk4 = new( "Unknown 4" ); //1, 10, 19
        private readonly ParsedInt Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );
        private readonly ParsedInt Unk8 = new( "Unknown 8" );


        public C233( TmbFile file ) : base( file ) { }

        public C233( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8
        ];
    }
}
