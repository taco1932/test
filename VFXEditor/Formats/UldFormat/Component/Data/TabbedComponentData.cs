using VfxEditor.Parsing;

namespace VfxEditor.UldFormat.Component.Data {
    public class TabbedComponentData : UldGenericData {
        public TabbedComponentData() {
            Parsed.AddRange( [
                new ParsedUInt( "Text Node ID" ),
                new ParsedUInt( "Unknown Node Id 2" ),
                new ParsedUInt( "Unknown Node Id 3" ),
                new ParsedUInt( "Unknown Node Id 4" ),
            ] );
        }
    }
}
