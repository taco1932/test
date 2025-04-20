using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {

    public enum ObjectControlFinal {
        State_1 = 0,
        State_0 = 1,
        State_2 = 2,
        State_3 = 3,
        State_4 = 4,
        State_5 = 5,
        Original = 6,
    }

    public class C174 : TmbEntry {
        public const string MAGIC = "C174";
        public const string DISPLAY_NAME = "Object Control";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedEnum<AtchState> InitialPosition = new( "Initial ATCH State" );
        private readonly ParsedEnum<ObjectControl> ObjectControl = new( "Object Control" );
        private readonly ParsedEnum<ObjectControlFinal> FinalPosition = new( "Final ATCH State" );
        private readonly ParsedInt PositionDelay = new( "Position Delay" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );

        public C174( TmbFile file ) : base( file ) { }

        public C174( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            Unk2,
            InitialPosition,
            ObjectControl,
            FinalPosition,
            PositionDelay,
            Unk6
        ];
    }
}
