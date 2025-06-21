namespace VfxEditor.Select.Tabs.Common {
    public class CommonTabAwt : SelectTab<CommonRow> {
        public CommonTabAwt( SelectDialog dialog, string name ) : base( dialog, name, "Common-Awt" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            Items.Add( new CommonRow( 0, "chara/xls/animation/animation_work_table-demihuman.awt", "Demihuman", 0 ) );
            Items.Add( new CommonRow( 0, "chara/xls/animation/animation_work_table-human.awt", "Human", 0 ) );
            Items.Add( new CommonRow( 0, "chara/xls/animation/animation_work_table-monster.awt", "Monster", 0 ) );
            Items.Add( new CommonRow( 0, "chara/xls/animation/animation_work_table-weapon.awt", "Weapon", 0 ) );
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameUi );
        }
    }
}
