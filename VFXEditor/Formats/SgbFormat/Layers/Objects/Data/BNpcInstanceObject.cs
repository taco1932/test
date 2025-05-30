using System.IO;

namespace VfxEditor.Formats.SgbFormat.Layers.Objects.Data {
    public class BNpcInstanceObject : SgbObject {
        public BNpcInstanceObject( LayerEntryType type ) : base( type ) { }

        public BNpcInstanceObject( LayerEntryType type, BinaryReader reader ) : this( type ) {
            Read( reader );
        }

        protected override void DrawBody() {

        }

        protected override void ReadBody( BinaryReader reader, long startPos ) {

        }
    }
}