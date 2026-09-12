using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Base;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C094 : TmbEntry {
        public const string MAGIC = "C094";
        public const string DISPLAY_NAME = "Invisibility";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => ExtraData ? 0x14 : 0;

        private bool ExtraData = true;

        private readonly ParsedInt FadeTime = new( "Duration" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedFloat StartVisibility = new( "Start Visibility" );
        private readonly ParsedFloat EndVisibility = new( "End Visibility" );

        // these are parsed separately
        private readonly ParsedBool EnableFilter = new( "Enable Filter" );
        private readonly ParsedFlag<ObjectFlags> ObjectFlags = new( "Filter" );
        private readonly ParsedInt Unk4 = new( "Unknown 5" );
        private readonly ParsedInt Unk5 = new( "Unknown 6" );
        private readonly ParsedInt Unk6 = new( "Unknown 7" );

        // Unk2 = 1, Unk3 = 8 -> ExtraSize = 0x14

        public C094( TmbFile file ) : base( file ) { }

        public C094( TmbFile file, TmbReader reader ) : base( file, reader ) {
            ExtraData = reader.ReadAtOffset( ( binaryReader ) => {
                EnableFilter.Read( binaryReader );
                ObjectFlags.Read( binaryReader );
                Unk4.Read( binaryReader );
                Unk5.Read( binaryReader );
                Unk6.Read( binaryReader );
            } );
        }

        protected override List<ParsedBase> GetParsed() => [
            FadeTime,
            CRC,
            StartVisibility,
            EndVisibility
        ];

        public override void Write( TmbWriter writer ) {
            base.Write( writer );

            writer.WriteExtra( ( binaryWriter ) => {
                EnableFilter.Write( binaryWriter );
                ObjectFlags.Write( binaryWriter );
                Unk4.Write( binaryWriter );
                Unk5.Write( binaryWriter );
                Unk6.Write( binaryWriter );
            }, ExtraData );
        }

        public override void DrawBody() {
            base.DrawBody();

            ImGui.Checkbox( "Extra Data", ref ExtraData );
            if( ExtraData ) {
                EnableFilter.Draw();

                using( var disabled = ImRaii.Disabled( !EnableFilter.Value ) )
                using( var indent = ImRaii.PushIndent() ) {
                    ObjectFlags.Draw();
                    ImGui.TextDisabled( $"Value: {ObjectFlags.IntValue}" );
                }

                Unk4.Draw();
                Unk5.Draw();
                Unk6.Draw();
            }
        }
    }
}
