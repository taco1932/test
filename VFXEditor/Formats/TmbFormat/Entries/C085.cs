using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C085 : TmbEntry {
        public const string MAGIC = "C085";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly TmbOffsetString Unk3 = new( "Path (VFX or camera?)" );
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 1 );
        private readonly ParsedInt Unk5 = new( "Unknown 5" ); // 1 or 4


        public C085( TmbFile file ) : base( file ) { }

        public C085( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3
        ];
    }
}
