using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.UldFormat.Component.Data {
    public class HoldButtonComponentData : UldGenericData {
        public HoldButtonComponentData() {
            Parsed.AddRange( [
                new ParsedUInt( "Text Node ID" ),
                new ParsedUInt( "NineGrid Node ID (unknown)" ),
                new ParsedUInt( "Container Node ID (overlay)" ),
                new ParsedUInt( "Image Node ID (overlay)" ),
            ] );
        }
    }
}
