using System.Collections.Generic;
using Dalamud.Interface.Utility.Raii;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Base;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C043 : TmbEntry {
        public const string MAGIC = "C043";
        public const string DISPLAY_NAME = "Summon Weapon";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => 0;

        private readonly ParsedInt Duration = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedEnum<C043Type> Type = new( "Summon Type" );
        private readonly ParsedShort WeaponId = new( "Weapon ID" );
        private readonly ParsedShort BodyId = new( "Body ID" );
        private readonly ParsedShort VariantId = new( "Variant ID" );
        private readonly ParsedShort Unk1 = new( "Unknown 1" );

        public C043( TmbFile file ) : base( file ) { }

        public C043( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Duration,
            CRC,
            Type,
            WeaponId,
            BodyId,
            VariantId,
            Unk1
        ];

        public override void DrawBody() {
            DrawHeader();
            CRC.Draw();
            Type.Draw();

            using( var disabled = ImRaii.Disabled( Type.Value != C043Type.Use_Weapon_ID ) ) {
                WeaponId.Draw();
                BodyId.Draw();
                VariantId.Draw();
            }

            Unk1.Draw();
        }
    }
}
