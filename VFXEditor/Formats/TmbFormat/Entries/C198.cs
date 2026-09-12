using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Base;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C198 : TmbEntry {
        public const string MAGIC = "C198";
        public const string DISPLAY_NAME = "Lemure";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk2 = new( "Unused 1" );
        private readonly ParsedInt Unk3 = new( "Unused 2" );

        private readonly ParsedEnum<SummonId> SummonId = new ( "Summon ID", size: 1 );
        private readonly ParsedEnum<C198AtchState> AtchState = new ( "ATCH State", size: 1 );
        //private readonly ParsedIntByte4 BindPoint = new( "Bind Point" );
        //ID, ATCH state + 1, [unused], [unused]
        private readonly ParsedShort Unk4 = new ( "Unused 3" );
        private readonly ParsedShort ModelId = new( "Model ID" );
        private readonly ParsedShort BodyId = new( "Body ID" );
        private readonly ParsedInt Variant = new( "Variant" );

        public C198( TmbFile file ) : base( file ) { }

        public C198( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Unk2,
            Unk3,
            SummonId,
            AtchState,
            Unk4,
            ModelId,
            BodyId,
            Variant
        ];
    }
}
