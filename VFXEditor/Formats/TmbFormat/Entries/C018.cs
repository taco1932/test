using System.Collections.Generic;
using VfxEditor.Formats.TmbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Angles;
using VfxEditor.Parsing.Float;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.TmbFormat.Entries {
    public class C018 : TmbEntry {
        public const string MAGIC = "C018";
        public const string DISPLAY_NAME = "----[TESTING] (SGB/CUTB) [scheduler crash]";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x38;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Enabled?" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedFloat3 Unk3 = new( "Position?" );
        private readonly ParsedDegrees3 Unk4 = new( "Rotation?" ); //radians
        private readonly ParsedFloat3 Unk5 = new( "Scale?" );

        public C018( TmbFile file ) : base( file ) { }

        public C018( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4,
            Unk5,
        ];
    }
}
