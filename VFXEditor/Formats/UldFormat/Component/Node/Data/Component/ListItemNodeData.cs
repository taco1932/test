using VfxEditor.Parsing.Bool;
using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.UldFormat.Component.Node.Data.Component {
    public class ListItemNodeData : UldNodeComponentData {
        public ListItemNodeData() : base() {
            Parsed.AddRange( [
                new ParsedByteBool( "Toggle" ),
                new ParsedSByte( "Reserve 1" ),
                new ParsedSByte( "Reserve 2" ),
                new ParsedSByte( "Reserve 3" ),
                //new ParsedReserve( 3 ),
            ] );
        }
    }
}
