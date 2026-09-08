using System;
using System.Collections.Generic;
using Dalamud.Bindings.ImGui;
using VfxEditor.Parsing;
using VfxEditor.ScdFormat;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    [Flags]
    public enum SoundFlags {
        Stop_on_Movement = 0x01,
        Use_Bind_Position = 0x02, //originally overlap sounds
        Unused_1 = 0x04,
        Unused_2 = 0x08,
        Unused_3 = 0x10,
        Unused_4 = 0x20,
        Unused_5 = 0x40,
        Unused_6 = 0x80,
    }

    public class C053 : TmbEntry {
        public const string MAGIC = "C053";
        public const string DISPLAY_NAME = "Voiceline";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Type 1" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedShort BindId = new( "Bind Id" );
        private readonly ParsedShort SoundId = new( "Sound Id" );
        private readonly ParsedShort Unk3 = new( "Type 2" );
        private readonly ParsedFlag<SoundFlags> Flags = new( "Flags", size: 2 );

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

        public override void DrawBody()
        {
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
