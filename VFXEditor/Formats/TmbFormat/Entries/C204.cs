using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C204 : TmbEntry {
        public const string MAGIC = "C204";
        public const string DISPLAY_NAME = "Shroud Transform";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedBool Hide = new( "Hide Transform" );
        private readonly ParsedInt Unk4 = new( "Unused" );

        public C204( TmbFile file ) : base( file ) { }

        public C204( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Hide,
            Unk4
        ];
    }
}
