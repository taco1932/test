using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public enum ObjectControlPosition {
        State_1 = 0,
        State_0 = 1,
        State_2 = 2,
        State_3 = 3,
        State_4 = 4,
        State_5 = 5,
    }

    public enum ObjectControl {
        Weapon_or_Pet = 0,
        Offhand = 1,
        Summon_or_Lemure = 2,
    }
    public class C014 : TmbEntry {
        public const string MAGIC = "C014";
        public const string DISPLAY_NAME = "Weapon Position";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled", size: 2);
        private readonly ParsedShort Unk1 = new( "Unknown 1");
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedEnum<ObjectControlPosition> ObjectPosition = new( "Object ATCH Position" );
        private readonly ParsedEnum<ObjectControl> ObjectControl = new( "Object Control" );

        public C014( TmbFile file ) : base( file ) { }

        public C014( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unk1,
            Unk2,
            ObjectPosition,
            ObjectControl
        ];
    }
}
