using Dalamud.Bindings.ImGui;
using VfxEditor.Parsing;
using VfxEditor.CutbFormat.Utils;
using VfxEditor.Utils;

namespace VfxEditor.CutbFormat {
    public abstract class CutbItem {
        public readonly CutbFile File;

        public abstract string Magic { get; }
        public abstract int Size { get; }
        public abstract int DataOffset { get; }
        public abstract int DataSize { get; }

        public CommandManager Command => File.Command;

        public CutbItem( CutbFile file ) {
            File = file;
        }

        public CutbItem( CutbFile file, CutbReader reader ) : this( file ) {
            reader.UpdateStartPosition();
            reader.ReadString( 4 ); // magic
            reader.ReadInt32(); // size
            reader.ReadInt32(); // DataOffset
            reader.ReadInt32(); // DataSize
        }

        public virtual void Write( CutbWriter writer ) {
            FileUtils.WriteString( writer.Writer, Magic );
            writer.Write( Size );
            writer.Write( DataOffset ); // May need to be updated
            writer.Write( DataSize ); // May need to be updated
        }
    }

    public abstract class CutbItemWithId : CutbItem {
        public short Id;

        public CutbItemWithId( CutbFile file ) : base( file ) {
            Id = 0;
        }

        public CutbItemWithId( CutbFile file, CutbReader reader ) : base( file, reader ) {
            Id = reader.ReadInt16();
        }

        public override void Write( CutbWriter writer ) {
            base.Write( writer );
            writer.Write( Id );
        }
    }

    public abstract class CutbItemWithTime : CutbItemWithId {
        public ParsedShort Time = new( "Time" );

        public CutbItemWithTime( CutbFile file ) : base( file ) { }

        public CutbItemWithTime( CutbFile file, CutbReader reader ) : base( file, reader ) {
            Time.Read( reader.Reader );
        }

        public override void Write( CutbWriter writer ) {
            base.Write( writer );
            Time.Write( writer.Writer );
        }

        protected void DrawHeader() {
            Time.Draw();
            ImGui.SameLine();
            ImGui.TextDisabled( $"[ ID: {Id} ]" );
        }
    }
}
