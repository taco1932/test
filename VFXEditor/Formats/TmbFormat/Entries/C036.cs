using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C036 : TmbEntry {
        public const string MAGIC = "C036";
        public const string DISPLAY_NAME = "noclip ----[TESTING] (CUTB)"; //does a very bad thing by locking axis position and allowing no clip
        //not fixable by redraw or reversed values so far
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;
        public override DangerLevel Danger => DangerLevel.Red;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedIntByte4 Unk3 = new( "Unknown 3" ); //00 01 00 00 will no clip
        private readonly ParsedInt Unk4 = new( "Unknown 4" );

        public C036( TmbFile file ) : base( file ) { }

        public C036( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4
        ];
    }
}
