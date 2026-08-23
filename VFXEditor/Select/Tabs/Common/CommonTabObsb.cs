using System.IO;
using System.Linq;

namespace VfxEditor.Select.Tabs.Common {
    public class CommonTabObsb : SelectTab<CommonRow> {
        public CommonTabObsb( SelectDialog dialog, string name ) : base( dialog, name, "Common-Obsb" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            var idx = 0;
            foreach( var line in File.ReadLines( SelectDataUtils.CommonObsbPath ).Where( x => !string.IsNullOrEmpty( x ) ) ) {
                Items.Add( new CommonRow( idx++, line, line.Replace( ".obsb", "" ).Replace( "bgcommon/env/obset/", "" ), 0 ) );
            }
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameUi );
        }
    }
}
