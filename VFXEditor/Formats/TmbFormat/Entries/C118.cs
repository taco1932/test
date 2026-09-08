using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public enum PhysicsType {
        All = 0,
        Equipment = 1,
        j_ex_wing, //Meteion
        Weapons,
        Hair,
        j_mune,
        Unused
    }
    public class C118 : TmbEntry {
        public const string MAGIC = "C118";
        public const string DISPLAY_NAME = "Disable Physics"; //PhysicsOff
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x18;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedEnum<PhysicsType> Type = new( "Type", size: 2 );
        private readonly ParsedShort Unk3 = new( "Unknown 3", value: 1 );

        public C118( TmbFile file ) : base( file ) { }

        public C118( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Type,
            Unk3
        ];
    }
}
