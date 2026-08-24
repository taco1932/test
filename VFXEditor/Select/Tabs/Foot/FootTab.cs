using System.IO;
using System.Linq;

namespace VfxEditor.Select.Tabs.Foot {
    public class FootTab : SelectTab<FootRow> {
        public FootTab( SelectDialog dialog, string name ) : base( dialog, name, "Foot" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            var idx = 0;
            foreach( var line in File.ReadLines( SelectDataUtils.CommonScdPath ).Where( x => !string.IsNullOrEmpty( x ) ) ) {
                if( line.Contains( "sound/foot/dev/" ) ) {
                    Items.Add( new FootRow( idx++, line, line.Replace( "sound/foot/", "" ).Replace( ".scd", "" ) ) );
                }

                if( line.Contains( "sound/foot/foot/" ) ) {
                    Items.Add( new FootRow( idx++, line, line.Replace( "sound/foot/foot/fs_", "" ).Replace( ".scd", "" ) ) );
                }
            }
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameMisc );
        }
    }
}