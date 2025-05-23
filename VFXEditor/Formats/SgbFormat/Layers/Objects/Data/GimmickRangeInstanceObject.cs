using System.IO;

namespace VfxEditor.Formats.SgbFormat.Layers.Objects.Data {
    public class GimmickRangeInstanceObject : SgbObject {
        public GimmickRangeInstanceObject( LayerEntryType type ) : base( type ) { }

        public GimmickRangeInstanceObject( LayerEntryType type, BinaryReader reader ) : this( type ) {
            Read( reader );
        }

        protected override void DrawBody() {

        }

        protected override void ReadBody( BinaryReader reader, long startPos ) {

        }
    }
}