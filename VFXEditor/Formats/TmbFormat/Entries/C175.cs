using System.Collections.Generic;
using Dalamud.Interface.Utility.Raii;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Base;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C175 : TmbEntry {
        public const string MAGIC = "C175";
        public const string DISPLAY_NAME = "Object Scaling";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedEnum<AtchState> InitialState = new( "Initial ATCH State" );
        private readonly ParsedEnum<ObjectControl> ObjectControl = new( "Object Control" );
        private readonly ParsedEnum<AtchState> FinalState = new( "Final ATCH State" );
        private readonly ParsedBool InitialNoDelay = new( "Use Initial Only" );
        private readonly ParsedInt Unk7 = new( "Unused" );

        public C175( TmbFile file ) : base( file ) { }

        public C175( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            InitialState,
            ObjectControl,
            FinalState,
            InitialNoDelay,
            Unk7
        ];

        public override void DrawBody() {
            DrawHeader();
            using ( var disabled = ImRaii.Disabled( InitialNoDelay.Value == true ) ) {
                Duration.Draw();
            }
            CRC.Draw();
            InitialNoDelay.Draw();
            ObjectControl.Draw();
            InitialState.Draw();
            FinalState.Draw();
            Unk7.Draw();
        }
    }
}
