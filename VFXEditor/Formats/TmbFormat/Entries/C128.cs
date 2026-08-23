using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C128 : TmbEntry {
        public const string MAGIC = "C128";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly TmbOffsetAngle3 Unk3 = new( "Unknown 3" ); //placeholder. this points to eight bytes of what I assume to be hex colour data
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 1 ); //0, 1
        private readonly ParsedInt Unk5 = new( "Unknown 5" );


        public C128( TmbFile file ) : base( file ) { }

        public C128( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4,
            Unk5,
        ];
    }
}
