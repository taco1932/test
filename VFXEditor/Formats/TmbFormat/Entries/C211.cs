using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C211 : TmbEntry {
        public const string MAGIC = "C211";
        public const string DISPLAY_NAME = "Lock Facing Direction";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unused 1" );
        private readonly ParsedInt Unk4 = new( "Unused 2" );

        public C211( TmbFile file ) : base( file ) { }

        public C211( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Unk3,
            Unk4
        ];
    }
}
