using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System.Collections.Generic;
using System.IO;
using VfxEditor.CutbFormat.Ctrls;
using VfxEditor.Parsing;
using VfxEditor.Ui.Interfaces;
using VfxEditor.CutbFormat.Utils;

namespace VfxEditor.CutbFormat.Ctrls {
    public class CtrlData : IUiItem {
        public readonly CutbFile File;

        public readonly ParsedUInt Unk1 = new( "Unknown 1", size: 4 );
        public readonly ParsedUInt Unk2 = new( "Unknown 2", size: 4 );
        public readonly ParsedUInt Unk3 = new( "Unknown 3", size: 4 );
        public readonly ParsedUInt Unk4 = new( "Unknown 4", size: 4 );
        private readonly uint TempRowCount = 0;

        public readonly List<CtrlRow> Rows = [];

        public int Size => 0x10 + ( 0x18 * Rows.Count );

        public CommandManager Command => File.Command;

        // 24 bytes x count

        public CtrlData( CutbReader reader, CutbFile file ) {
            File = file;
            reader.ReadInt32(); // Magic, blank, not retained
            TempRowCount = reader.ReadUInt32();
            Unk1.Read( reader );
            Unk2.Read( reader );
            Unk3.Read( reader );
            Unk4.Read( reader );
            ReadRows( reader );
        }

        public void ReadRows( CutbReader reader ) {
            for( var i = 0; i < TempRowCount; i++ ) Rows.Add( new CtrlRow( reader ) );
        }

        public void Write( BinaryWriter writer ) {
            Parsed.ForEach( x => x.Write( writer ) );
            writer.Write( Rows.Count );
        }

        public void WriteRows( BinaryWriter writer ) => Rows.ForEach( x => x.Write( writer ) );

        public void Draw() {
            //ADD BUTTONS TO REMOVE OR ADD ENTRIES!
            Rows.ForEach( x => x.Draw() );

        }
    }
}
