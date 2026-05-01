using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Utils;
using VfxEditor.CutbFormat.Utils;

namespace VfxEditor.CutbFormat {
    public class CutbOffsetString : ParsedString {
        public CutbOffsetString( string name, List<ParsedStringIcon> icons, bool forceLower ) : base( name, icons, forceLower ) { }

        public CutbOffsetString( string name ) : base( name ) { }

        public override void Read( ParsingReader reader ) {
            if( reader is CutbReader CutbReader ) {
                Value = CutbReader.ReadOffsetString();
            }
        }

        public override void Write( ParsingWriter writer ) {
            if( writer is CutbWriter CutbWriter ) {
                CutbWriter.WriteOffsetString( Value );
            }
        }
    }
}
