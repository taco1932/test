using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C152 : TmbEntry {
        public const string MAGIC = "C152";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x40;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedFloat4 Unk3 = new( "Unknown 3" );
        private readonly ParsedFloat4 Unk4 = new( "Unknown 4" );
        private readonly ParsedByte Unk5a = new( "Unknown 5a", value: 1 ); 
        private readonly ParsedByte Unk5b = new( "Unknown 5b", value: 1 );
        private readonly ParsedShort Unk5c = new( "Unknown 5c" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );


        public C152( TmbFile file ) : base( file ) { }

        public C152( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk2,
            Unk3,
            Unk4,
            Unk5a,
            Unk5b,
            Unk5c,
            Unk6,
            Unk7
        ];
    }
}
