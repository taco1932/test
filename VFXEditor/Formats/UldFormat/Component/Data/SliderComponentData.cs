using VfxEditor.Parsing;

namespace VfxEditor.UldFormat.Component.Data {
    public class SliderComponentData : UldGenericData {
        public SliderComponentData() {
            Parsed.AddRange( [
                new ParsedUInt( "NineGrid Node ID" ),
                new ParsedUInt( "Unknown Node Id 2" ),
                new ParsedUInt( "Text Node ID" ),
                new ParsedUInt( "Unknown Node Id 4" ),
                new ParsedByteBool( "Is Vertical" ),
                new ParsedUInt( "Left Offset", size: 1 ),
                new ParsedUInt( "Right Offset", size: 1),
                new ParsedInt( "Padding", size: 1)
            ] );
        }
    }
}
