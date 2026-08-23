using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C210 : TmbEntry {
        public const string MAGIC = "C210";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Unknown 3", value: 2 );
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );

        //cut\ffxiv\cntemj\cntemj06210\cntemj06210.cutb
        //cut\ffxiv\cntfgs\cntfgs00040\cntfgs00040.cutb
        //cut\ffxiv\pvpmks\pvpmks06010\pvpmks06010.cutb
        //cut\ffxiv\pvpmks\pvpmks07510\pvpmks07510.cutb


        public C210( TmbFile file ) : base( file ) { }

        public C210( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4,
            Unk5,
        ];
    }
}
