using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C118 : TmbEntry {
        public const string MAGIC = "C118";
        public const string DISPLAY_NAME = "Animation Transition";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt TransitionTime = new( "Transition Time", value: 1 );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedByte Unk3a = new( "Unknown 3a" );
        private readonly ParsedByte Unk3b = new( "Unknown 3b" );
        private readonly ParsedByte Unk3c = new( "Unknown 3c" );
        private readonly ParsedByte Unk3d = new( "Unknown 3d" );

        public C118( TmbFile file ) : base( file ) { }

        public C118( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            TransitionTime,
            Unk2,
            Unk3a,
            Unk3b,
            Unk3c,
            Unk3d
        ];
    }
}
