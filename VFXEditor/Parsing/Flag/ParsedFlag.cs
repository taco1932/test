using ImGuiNET;
using System;
using System.IO;

namespace VfxEditor.Parsing {
    public class ParsedFlag<T> : ParsedSimpleBase<T> where T : Enum {
        private readonly int Size;

        public int IntValue => ( int )( object )Value;

        public ParsedFlag( string name, T value, int size = 4 ) : base( name, value ) {
            Size = size;
        }

        public ParsedFlag( string name, int size = 4 ) : base( name ) {
            Size = size;
        }

        public override void Read( BinaryReader reader ) => Read( reader, 0 );

        public override void Read( BinaryReader reader, int size ) {
            var intValue = Size switch {
                4 => reader.ReadInt32(),
                2 => reader.ReadInt16(),
                1 => reader.ReadByte(),
                _ => reader.ReadByte()
            };
            Value = ( T )( object )intValue;
        }

        public override void Write( BinaryWriter writer ) {
            var intValue = Value == null ? -1 : IntValue;
            if( Size == 4 ) writer.Write( intValue );
            else if( Size == 2 ) writer.Write( ( short )intValue );
            else writer.Write( ( byte )intValue );
        }

        protected override void DrawBody() {
            var options = ( T[] )Enum.GetValues( typeof( T ) );
            foreach( var option in options ) {
                var intOption = ( int )( object )option;
                if( intOption == 0 ) continue;

                var hasFlag = HasFlag( option );
                if( ImGui.Checkbox( $"{option}", ref hasFlag ) ) {
                    var intValue = IntValue;
                    if( hasFlag ) intValue |= intOption;
                    else intValue &= ~intOption;

                    SetValue( ( T )( object )intValue );
                }
            }
        }

        public bool HasFlag( T option ) => Value.HasFlag( option );
    }
}
