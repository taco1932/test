using System.Collections.Generic;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C085 : TmbEntry {
        public const string MAGIC = "C085";
        public const string DISPLAY_NAME = "----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x20;
        public override int ExtraSize => ExtraData ? 0x14 : 0;
        private bool ExtraData = true;

        private readonly ParsedInt Unk1 = new( "Unknown 1", value: 1 );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedBool Unk4 = new( "Enable Filter?", value: true );
        private readonly ParsedInt Unk5 = new( "Unknown 5" ); //1-4

        //separate
        private readonly ParsedIntByte4 FilterSet1 = new( "Filter Set 1" );


        public C085( TmbFile file ) : base( file ) { }

        public C085( TmbFile file, TmbReader reader ) : base( file, reader ) {
            ExtraData = reader.ReadAtOffset( FilterSet1.Read );
        }

        protected override List<ParsedBase> GetParsed() => [
            Unk1,
            CRC,
        ];

        public override void Write( TmbWriter writer ) {
            base.Write( writer );

            writer.WriteExtra( FilterSet1.Write, ExtraData );

            Unk4.Write( writer );
            Unk5.Write( writer );
        }

        public override void DrawBody() {
            base.DrawBody();

            ImGui.Checkbox( "Extra Data", ref ExtraData );
            if( ExtraData ) {
                Unk4.Draw();

                using( var disabled = ImRaii.Disabled( !Unk4.Value ) )
                using( var indent = ImRaii.PushIndent() ) {
                    FilterSet1.Draw();
                }
            }
            Unk5.Draw();
        }
    }
}
