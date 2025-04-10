using System.IO;
using System.Linq;

namespace VfxEditor.Select.Tabs.Common {
    public class ExtraSkillsTmb : SelectTab<CommonRow> {
        public ExtraSkillsTmb ( SelectDialog dialog, string name ) : base( dialog, name, "ExtraSkills-Tmb" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            var idx = 0;
            foreach( var line in File.ReadLines( SelectDataUtils.ExtraTmbPath ).Where( x => !string.IsNullOrEmpty( x ) ) ) {
                Items.Add( new CommonRow( idx++, line, line.Replace( "chara/action/", "" ).Replace( ".tmb", "" ), 0 ) );
            }
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameMisc );
        }
    }
}