using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Base;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C187 : TmbEntry {
        public const string MAGIC = "C187";
        public const string DISPLAY_NAME = "Sub-Mesh Removal";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedShort Part = new( "Part ID" ); //1-3, outlier 11. requires atr_ string
        private readonly ParsedBool Reverse = new( "Reverse", size: 2 ); //C187 removes, so reverse would retain the part
        private readonly ParsedEnum<C187ObjectControl> ObjectControl = new( "Object Control", size: 2 ); //0-2
        private readonly ParsedByteBool Unk3 = new( "Unknown 3" ); //reverse + this seem to function like neither are active. reverse + this + no delay will keep the part
        private readonly ParsedByteBool NoDelay = new( "No Delay" ); //uses duration as delay with Unk1's reverse, but then also hides the part
        //otherwise, this alone doesn't do anything
        private readonly ParsedInt Unk5 = new( "Unused" );

        public C187( TmbFile file ) : base( file ) { }

        public C187( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Part,
            Reverse,
            ObjectControl,
            Unk3,
            NoDelay,
            Unk5
        ];
    }
}
