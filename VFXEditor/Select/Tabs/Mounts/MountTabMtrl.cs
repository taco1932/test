namespace VfxEditor.Select.Tabs.Mounts {
    public class MountTabMtrl : MountTab<object> {
        private readonly string MonSuffix, DemiSuffix;

        public MountTabMtrl ( SelectDialog dialog, string name, string monsuffix, string demisuffix ) : base( dialog, name ) {
            MonSuffix = monsuffix;
            DemiSuffix = demisuffix;
        }

        public override void LoadSelection( MountRow item, out object loaded ) { loaded = new(); }

        protected override void DrawSelected() {
            var path = Selected.GetMtrlPath( MonSuffix, DemiSuffix );
            if( Dalamud.DataManager.FileExists( path ) ) {
                Dialog.DrawPaths( path, Selected.Name, SelectResultType.GameMount );
            }
        }
    }
}
