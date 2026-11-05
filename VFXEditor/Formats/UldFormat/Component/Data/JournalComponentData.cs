using VfxEditor.Parsing.Int;

namespace VfxEditor.Formats.UldFormat.Component.Data {
    public class JournalComponentData : UldGenericData {
        public JournalComponentData() {
            AddUnknown( 38, "Unknown Node Id" ); //added six, TBD if this varies

            Parsed.AddRange( [
                new ParsedUInt( "Item Margin", size: 2 ),
                new ParsedUInt( "Basic Margin", size: 2 ),
                new ParsedUInt( "Unknown Margin", size: 2 ),
                new ParsedSByte( "Reserve 1" ),
                new ParsedSByte( "Reserve 2" ),
                //new ParsedReserve( size: 2 ) //Padding
            ] );
        }
    }
}
