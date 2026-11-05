using System.Collections.Generic;
using VfxEditor.Formats.TmbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.TmbFormat.Entries {
    public class C201 : TmbEntry {
        public const string MAGIC = "C201";
        public const string DISPLAY_NAME = "Remove Credits Screen";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt RefId = new( "Credits ID" ); //checks for running C200 with the given ID and cancels it early


        public C201( TmbFile file ) : base( file ) { }

        public C201( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            RefId,
        ];
    }
}
