using Dalamud.Bindings.ImGui;

namespace VfxEditor.Select.Tabs.Emotes {
    public class EmoteTabScd : EmoteTab<ParsedPaths> {
        public EmoteTabScd( SelectDialog dialog, string name ) : base( dialog, name ) { }

        public override void LoadSelection( EmoteRow item, out ParsedPaths loaded ) => ParsedPaths.ReadFile( item.VfxPapFiles, SelectDataUtils.ScdRegex, out loaded );

        protected override void DrawSelected() {
            ImGui.TextDisabled( Selected.Command );

            Dialog.DrawPaths( Loaded.Paths, Selected.Name, SelectResultType.GameEmote );
        }
    }
}