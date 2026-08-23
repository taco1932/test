namespace VfxEditor.Select.Tabs.Common {
    public class CommonTabAtch : SelectTab<CommonRow> {
        public CommonTabAtch( SelectDialog dialog, string name ) : base( dialog, name, "Common-Atch" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            Items.AddRange( [
                new( 0, "chara/xls/attachoffset/c0104.atch", "Midllander M (Child)", 0 ),
                new( 1, "chara/xls/attachoffset/c0204.atch", "Midlander F (Child)", 0 ),
                new( 2, "chara/xls/attachoffset/c0504.atch", "Elezen M (Child)", 0 ),
                new( 3, "chara/xls/attachoffset/c0604.atch", "Elezen F (Child)", 0 ),
                new( 4, "chara/xls/attachoffset/c0804.atch", "Miqo'te F (Child)", 0 ),
                new( 5, "chara/xls/attachoffset/c1304.atch", "Au Ra M (Child)", 0 ),
                new( 5, "chara/xls/attachoffset/c1404.atch", "Au Ra F (Child)", 0 ),
                new( 6, "chara/xls/attachoffset/c9104.atch", "A-Ruhn-Senna", 0 ),
                new( 7, "chara/xls/attachoffset/c9204.atch", "Raya-O-Senna", 0 ),
            ] );
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameUi );
        }
    }
}