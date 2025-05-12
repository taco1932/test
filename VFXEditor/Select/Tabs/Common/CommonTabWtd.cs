namespace VfxEditor.Select.Tabs.Common {
    public class CommonTabWtd : SelectTab<CommonRow> {
        public CommonTabWtd( SelectDialog dialog, string name ) : base( dialog, name, "Common-Wtd" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            Items.Add( new CommonRow( 0, "chara/xls/weapontype/attach.wtd", "attach", 0 ) );
            Items.Add( new CommonRow( 0, "chara/xls/weapontype/motion.wtd", "motion", 0 ) );
            Items.Add( new CommonRow( 0, "chara/xls/weapontype/se.wtd", "SoundEffects??", 0 ) );
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameUi );
        }
    }
}
