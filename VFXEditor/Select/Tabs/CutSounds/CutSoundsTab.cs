using System.IO;
using System.Linq;

namespace VfxEditor.Select.Tabs.CutSounds {
    public class CutSoundsTab : SelectTab<CutSoundsRow> {
        public CutSoundsTab( SelectDialog dialog, string name ) : base( dialog, name, "CutSounds" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            var idx = 0;
            foreach( var line in File.ReadLines( SelectDataUtils.CommonScdPath ).Where( x => !string.IsNullOrEmpty( x ) ) ) {
                if( line.Contains( "sound/cut/" ) ) {
                    Items.Add( new CutSoundsRow( idx++, line, line.Replace( "sound/cut/", "" ).Replace( "senc_gn_", "" ).Replace( ".scd", "" ) ) );
                }

                if( line.Contains( "sound/nc/" ) ) {
                    Items.Add( new CutSoundsRow( idx++, line, line.Replace( "sound/nc/general_ex1/se_nc_", "" ).Replace( ".scd", "" ) ) );
                }
            }
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameMisc );
        }
    }
}