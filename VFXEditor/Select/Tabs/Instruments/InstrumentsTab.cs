using System.IO;
using System.Linq;

namespace VfxEditor.Select.Tabs.Instruments {
    public class InstrumentsTab : SelectTab<InstrumentsRow> {
        public InstrumentsTab( SelectDialog dialog, string name ) : base( dialog, name, "Instruments" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            var idx = 0;
            foreach( var line in File.ReadLines( SelectDataUtils.CommonScdPath ).Where( x => !string.IsNullOrEmpty( x ) ) ) {
                if( line.Contains( "sound/instruments/" ) ) {
                    Items.Add( new InstrumentsRow( idx++, line, line.Replace( "sound/instruments/", "" ).Replace( ".scd", "" ) ) );
                }
            }
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameMisc );
        }
    }
}