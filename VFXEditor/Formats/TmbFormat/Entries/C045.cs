using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C045 : TmbEntry {
        public const string MAGIC = "C045";
        public const string DISPLAY_NAME = "----Cutscene Subtitles? [TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly TmbOffsetString Unk3 = new( "Subtitle Path" ); //TEXT_MAFST009_00449_700750_GAIUS

        public C045( TmbFile file ) : base( file ) { }

        public C045( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3
        ];
    }
}
