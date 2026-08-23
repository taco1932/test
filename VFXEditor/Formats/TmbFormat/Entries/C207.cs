using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C207 : TmbEntry {
        public const string MAGIC = "C207";
        //without offsets, seems to cause flickering of local lighting and changes colour of particles (like breath and snow)
        //with offsets, animation freezes
        public const string DISPLAY_NAME = "???";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x2C;
        public override int ExtraSize => 4 * (4 + 3);

        private readonly ParsedInt Unk1 = new( "Enabled?", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly TmbOffsetFloat4 Unk3 = new( "Unknown 3" );
        private readonly ParsedInt Unk4 = new( "Unknown 4", value: 4 );
        private readonly TmbOffsetFloat3 Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6", value: 3 );
        private readonly ParsedInt Unk7 = new( "Unknown 7" ); //0
        private readonly ParsedInt Unk8 = new( "Unknown 8" ); //0


        public C207( TmbFile file ) : base( file ) { }

        public C207( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            Unk3,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8
        ];
    }
}
