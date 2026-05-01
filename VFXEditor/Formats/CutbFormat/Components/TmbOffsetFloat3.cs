using System.Numerics;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Utils;
using VfxEditor.CutbFormat.Utils;

namespace VfxEditor.CutbFormat {
    public class CutbOffsetAngle3 : ParsedRadians3 {
        public CutbOffsetAngle3( string name, Vector3 defaultValue ) : base( name, defaultValue ) { }

        public CutbOffsetAngle3( string name ) : base( name ) { }

        public override void Read( ParsingReader reader ) {
            if( reader is CutbReader CutbReader ) {
                Value = CutbReader.ReadOffsetVector3();
            }
        }

        public override void Write( ParsingWriter writer ) {
            if( writer is CutbWriter CutbWriter ) {
                CutbWriter.WriteExtraVector3( Value );
            }
        }
    }
}
