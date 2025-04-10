using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C187 : TmbEntry {
        public const string MAGIC = "C187";
        public const string DISPLAY_NAME = "Summoned Weapon Part Removal";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Part = new( "Part", value: 4 );
        private readonly ParsedByte Unk4a = new( "Unknown 4a" );
        private readonly ParsedByte Unk4b = new( "Unknown 4b" );
        private readonly ParsedByte Unk4c = new( "Unknown 4c" );
        private readonly ParsedByte Unk4d = new( "Unknown 4d" );
        private readonly ParsedInt Unk5 = new( "Unknown 5", value: 1 );

        public C187( TmbFile file ) : base( file ) { }

        public C187( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk2,
            Part,
            Unk4a,
            Unk4b,
            Unk4c,
            Unk4d,
            Unk5
        ];
    }
}
