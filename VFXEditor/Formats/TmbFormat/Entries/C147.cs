using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C147 : TmbEntry {
        public const string MAGIC = "C147";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" ); //enabled?
        private readonly ParsedByte Unk3a = new( "Unknown 3a", value: 1 );
        private readonly ParsedByte Unk3b = new( "Unknown 3b", value: 1 );
        private readonly ParsedShort Unk3c = new( "Unknown 3c" ); //0
        private readonly ParsedIntByte4 Unk4 = new( "Unknown 4" ); //[4, 7, 8, 9] 00 00 FF
        private readonly ParsedInt WeaponID = new( "Weapon ID" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" ); //0
        private readonly ParsedInt Unk7 = new( "Unknown 7" ); //0


        public C147( TmbFile file ) : base( file ) { }

        public C147( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3a,
            Unk3b,
            Unk3c,
            Unk4,
            WeaponID,
            Unk6,
            Unk7,
        ];
    }
}
