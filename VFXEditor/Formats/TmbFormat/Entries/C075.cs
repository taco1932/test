using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C075 : TmbEntry {
        public const string MAGIC = "C075";
        public const string DISPLAY_NAME = "Terrain VFX";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x40;
        public override int ExtraSize => 4 * ( 3 + 3 + 3 + 4 );

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Shape = new( "Shape" );
        private readonly TmbOffsetFloat3 Scale = new( "Scale", defaultValue: new( 1 ) );
        private readonly TmbOffsetAngle3 Rotation = new( "Rotation" );
        private readonly TmbOffsetFloat3 Position = new( "Position" );
        private readonly TmbOffsetFloat4 RGBA = new( "RGBA", defaultValue: new( 1 ) );
        private readonly ParsedInt Unk3 = new( "Unused 1" );
        private readonly ParsedInt Unk4 = new( "Unused 2" );

        public C075( TmbFile file ) : base( file ) { }

        public C075( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            Shape,
            Scale,
            Rotation,
            Position,
            RGBA,
            Unk3,
            Unk4
        ];
    }
}
