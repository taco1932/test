using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.UldFormat.Component.Node.Data.Component {
    public class HoldButtonNodeData : UldGenericData {
        public HoldButtonNodeData() {
            Parsed.AddRange( [
                new ParsedInt( "Unknown 1a", size: 1 ),
                new ParsedInt( "Unknown 1b", size: 1 ),
                new ParsedInt( "Unknown 1c", size: 1 ),
                new ParsedInt( "Unknown 1d", size: 1 ),
                new ParsedInt( "Unknown 2", size: 2 ),
                new ParsedInt( "Unknown 3", size: 2 ),
                new ParsedInt( "Unknown 4" ),
                new ParsedUInt( "Unknown 5", size: 1 ),
                new ParsedUInt( "Unknown 6", size: 1 ),
                new ParsedInt( "Unknown 7", size: 2 ),
            ] );
        }
    }
}
