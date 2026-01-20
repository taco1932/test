using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C200 : TmbEntry {
        public const string MAGIC = "C200";
        public const string DISPLAY_NAME = "Credits Screen";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" ); //9
        //cut\ex3\luckta\luckta04050\luckta04050.cutb
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );


        public C200( TmbFile file ) : base( file ) { }

        public C200( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            Unk2,
            Unk3,
            Unk4,
            Unk5,
        ];
    }
}
