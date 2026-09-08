using System.Collections.Generic;
using Dalamud.Bindings.ImGui;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C011 : TmbEntry {
        public const string MAGIC = "C011";
        public const string DISPLAY_NAME = "Fly Text";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x14;
        public override int ExtraSize => 0;

        private readonly ParsedInt Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );

        public C011( TmbFile file ) : base( file ) { }

        public C011( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC
        ];

        public override void DrawBody()
        {
            DrawHeader();
            Enabled.Draw();
            ImGui.SameLine();
            ImGui.TextDisabled( $"Value: {Enabled.Value}" );
            CRC.Draw();
        }
    }
}
