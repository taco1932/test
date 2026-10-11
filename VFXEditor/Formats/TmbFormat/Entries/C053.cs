using System.Collections.Generic;
using Dalamud.Bindings.ImGui;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Base;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C053 : TmbEntry {
        public const string MAGIC = "C053";
        public const string DISPLAY_NAME = "SoundSE";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Type 1" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedShort BindId = new( "Bind ID" );
        private readonly ParsedShort SoundId = new( "Sound ID" );
        private readonly ParsedShort Unk3 = new( "Type 2" );
        private readonly ParsedFlag<C053Flags> Flags = new( "Flags", size: 2 );

        public C053( TmbFile file ) : base( file ) { }

        public C053( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
            BindId,
            SoundId,
            Unk3,
            Flags,
        ];

        public override void DrawBody() {
            DrawHeader();
            Unk1.Draw();
            CRC.Draw();
            BindId.Draw();
            SoundId.Draw();
            Unk3.Draw();
            Flags.Draw();
            ImGui.TextDisabled( $"Value: {Flags.IntValue}" );
        }
    }
}
