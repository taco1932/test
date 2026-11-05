using VfxEditor.Parsing.Bool;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.UldFormat.Component.Node.Data.Component {
    public class NumericInputNodeData : UldNodeComponentData {
        public NumericInputNodeData() : base() {
            Parsed.AddRange( [
                new ParsedInt( "Value" ),
                new ParsedInt( "Max" ),
                new ParsedInt( "Min" ),
                new ParsedInt( "Add" ),
                new ParsedUInt( "End Letter ID" ), //from Lumina
                new ParsedByteBool( "Comma" ),
                //new ParsedReserve( 3 ),
                new ParsedSByte( "Reserve 1" ),
                new ParsedSByte( "Reserve 2" ),
                new ParsedSByte( "Reserve 3" ),
            ] );
        }
    }
}
