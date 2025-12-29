using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C199 : TmbEntry {
        public const string MAGIC = "C199"; //ghidra
        public const string DISPLAY_NAME = "Freeze Object";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x24; //seems to not complain
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt BindPointID = new( "Bind Point ID" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedEnum<SummonWeaponObjectControl> ObjectControl = new( "Object Control" );
        private readonly ParsedInt Unk3 = new( "Unknown 3" );


        public C199( TmbFile file ) : base( file ) { }

        public C199( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unk1,
            BindPointID,
            Unk2,
            ObjectControl,
            Unk3,
        ];
    }
}
