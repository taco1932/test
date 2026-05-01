using System.Numerics;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Utils;
using VfxEditor.CutbFormat.Utils;

namespace VfxEditor.CutbFormat {
    public class CutbOffsetFloat4 : ParsedFloat4 {
        public CutbOffsetFloat4( string name, Vector4 defaultValue ) : base( name, defaultValue ) { }

        public CutbOffsetFloat4( string name ) : base( name ) { }

        public override void Read( ParsingReader reader ) {
            if( reader is CutbReader CutbReader ) {
                Value = CutbReader.ReadOffsetVector4();
            }
        }

        public override void Write( ParsingWriter writer ) {
            if( writer is CutbWriter CutbWriter ) {
                CutbWriter.WriteExtraVector4( Value );
            }
        }
    }
}
