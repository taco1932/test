using System.Collections.Generic;
using VfxEditor.Formats.TmbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.TmbFormat.Entries {
    public class C210 : TmbEntry {
        public const string MAGIC = "C210";
        public const string DISPLAY_NAME = "Remove Results UI----[TESTING] (CUTB)";
        //basically removes C209 early
        //can be intercepted by C209 once
        //reenables mouse click/drag, but not always?
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt RefId = new( "Reference ID" ); //checks running C209 and disables the matching ID
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
            RefId,
            Unk4,
            Unk5,
        ];
    }
}
