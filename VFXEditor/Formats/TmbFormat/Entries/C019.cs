using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C019 : TmbEntry {
        public const string MAGIC = "C019";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB/SGB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled?", size: 2);
        private readonly ParsedShort Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedByteBool Unk3 = new( "Unknown 3" );
        private readonly ParsedByteBool Unk4 = new( "Unknown 4" );
        private readonly ParsedShort Unk5 = new( "Unknown 5" );

        public C019( TmbFile file ) : base( file ) { }

        public C019( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5
        ];
    }
}
