using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C176 : TmbEntry {
        public const string MAGIC = "C176";
        public const string DISPLAY_NAME = "Camera-Based Position Change";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;
        public override DangerLevel Danger => DangerLevel.Detectable;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt TmfcId = new( "F-Curve ID" );
        private readonly ParsedByte Unk4 = new( "Unknown 4" );
        private readonly ParsedByte Unk425 = new( "Unknown 4.25" );
        private readonly ParsedShort Unk45 = new( "Unknown 4.5");
        private readonly ParsedInt Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );

        public C176( TmbFile file ) : base( file ) { }

        public C176( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk2,
            TmfcId,
            Unk4,
            Unk425,
            Unk45,
            Unk5,
            Unk6,
            Unk7,
        ];
    }
}
