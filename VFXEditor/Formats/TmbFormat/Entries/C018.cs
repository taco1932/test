using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C018 : TmbEntry {
        public const string MAGIC = "C018";
        public const string DISPLAY_NAME = "----MDL Placement [TESTING] (SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x38;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled?", size: 2);
        private readonly ParsedShort Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" ); //pointer for string?
        private readonly ParsedFloat Unk3 = new( "Unknown 3" );
        private readonly ParsedFloat Unk4 = new( "Unknown 4" );
        private readonly ParsedFloat Unk5 = new( "Unknown 5" );
        private readonly ParsedFloat Unk6 = new( "Unknown 6" );
        private readonly ParsedFloat Unk7 = new( "Unknown 7" );
        private readonly ParsedFloat Unk8 = new( "Unknown 8" );
        private readonly ParsedFloat Unk9 = new( "Unknown 9" );
        private readonly ParsedFloat Unk10 = new( "Unknown 10" );
        private readonly ParsedFloat Unk11 = new( "Unknown 11" );

        public C018( TmbFile file ) : base( file ) { }

        public C018( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
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
            Unk11
        ];
    }
}
