namespace VfxEditor.Select.Tabs.Common {
    public class CommonTabObsb : SelectTab<CommonRow> {
        public CommonTabObsb( SelectDialog dialog, string name ) : base( dialog, name, "Common-Obsb" ) { }

        // ===== LOADING =====

        public override void LoadData() {
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameUi );
        }
    }
}
