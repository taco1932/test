using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C207 : TmbEntry {
        public const string MAGIC = "C207";
        public const string DISPLAY_NAME = "Lightning";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x2C;
        public override int ExtraSize => 4 * (4 + 3);

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly TmbOffsetFloat4 RGBA = new( "Colour" );
        private readonly TmbOffsetFloat3 Loc = new( "Translation" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" ); //0
        private readonly ParsedInt Unk6 = new( "Unknown 6" ); //0


        public C207( TmbFile file ) : base( file ) { }

        public C207( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            RGBA,
            Loc,
            Unk5,
            Unk6
        ];
    }
}
