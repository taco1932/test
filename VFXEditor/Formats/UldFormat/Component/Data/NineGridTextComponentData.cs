using VfxEditor.Parsing;

namespace VfxEditor.UldFormat.Component.Data {
    public class NineGridTextComponentData : UldGenericData {
        public NineGridTextComponentData() {
            Parsed.AddRange( [
                new ParsedUInt( "Text Node ID" ),
                new ParsedUInt( "Unknown Node Id 2" ),
            ] );
        }
    }
}
