using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C071 : TmbEntry {
        public const string MAGIC = "C071";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedBool Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedByte Unk3a = new( "Unknown 3a" ); //unsure if rotation
        private readonly ParsedByte Unk3b = new( "Unknown 3b" );
        private readonly ParsedByte Unk3c = new( "Unknown 3c", value: 232 );
        private readonly ParsedByte Unk3d = new( "Unknown 3d", value: 3 );
        private readonly ParsedFloat Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );

        public C071( TmbFile file ) : base( file ) { }

        public C071( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3a,
            Unk3b,
            Unk3c,
            Unk3d,
            Unk4,
            Unk5
        ];
    }
}
