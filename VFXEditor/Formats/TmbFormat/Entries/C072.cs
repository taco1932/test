using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C072 : TmbEntry {
        public const string MAGIC = "C072";
        public const string DISPLAY_NAME = "----[TESTING, WIP] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x24;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly TmbOffsetAngle3 Unk3 = new( "Unknown 3" ); //probably
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );
        private readonly TmbOffsetFloat4 Unk6 = new( "Unknown 6" ); //a guess right now

        public C072( TmbFile file ) : base( file ) { }

        public C072( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
            Unk6
        ];
    }
}
