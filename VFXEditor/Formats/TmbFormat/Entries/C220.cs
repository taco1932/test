using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {

    public class C220 : TmbEntry {
        public const string MAGIC = "C220";
        public const string DISPLAY_NAME = "----[TESTING [WILL CRASH]] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x30;
        public override int ExtraSize => 0;

        public readonly ParsedInt Unk1 = new( "Unknown 1" );
        public readonly ParsedInt Unk2 = new( "Unknown 2" );
        public readonly ParsedByte Unk3a = new( "Unknown 3a", value: 1 );
        public readonly ParsedByte Unk3b = new( "Unknown 3b" );
        public readonly ParsedShort Unk4 = new( "Unknown 4", value: 6 ); //also 5 and 4
        public readonly ParsedByte Unk5a = new( "Unknown 5a", value: 29 );
        public readonly ParsedByte Unk5b = new( "Unknown 5b" );
        public readonly ParsedByte Unk5c = new( "Unknown 5c" );
        public readonly ParsedByte Unk5d = new( "Unknown 5d", value: 0xFF );
        public readonly ParsedInt Unk6 = new( "Unknown 6", value: 1 );
        public readonly ParsedInt Unk7 = new( "Unknown 7" );
        public readonly ParsedInt Unk8 = new( "Unknown 8" );
        public readonly ParsedInt Unk9 = new( "Unknown 9" );
        public readonly ParsedInt Unk10 = new( "Unknown 10" );

        public C220( TmbFile file ) : base( file ) { }

        public C220( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3a,
            Unk3b,
            Unk4,
            Unk5a,
            Unk5b,
            Unk5c,
            Unk5d,
            Unk6,
            Unk7,
            Unk8,
            Unk9,
            Unk10
        ];
    }
}
