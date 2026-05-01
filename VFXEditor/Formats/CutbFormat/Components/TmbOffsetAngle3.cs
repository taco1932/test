using System.Numerics;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Utils;
using VfxEditor.CutbFormat.Utils;

namespace VfxEditor.CutbFormat {
    public class CutbOffsetFloat3 : ParsedFloat3 {
        public CutbOffsetFloat3( string name, Vector3 defaultValue ) : base( name, defaultValue ) { }

        public CutbOffsetFloat3( string name ) : base( name ) { }

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
