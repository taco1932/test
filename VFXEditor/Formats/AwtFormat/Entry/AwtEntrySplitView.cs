using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System.Collections.Generic;
using VfxEditor.Ui.Components.SplitViews;

namespace VfxEditor.Formats.AwtFormat.Entry {
    public class AwtEntrySplitView : CommandSplitView<AwtEntry> {
        public AwtEntrySplitView( List<AwtEntry> items ) : base( "Entry", items, false, null, () => new() ) { }

        protected override bool DrawLeftItem( AwtEntry item, int idx ) {
            using var _ = ImRaii.PushId( idx );

            var itemID = item.ItemID;
            
            if( ImGui.Selectable( $"{itemID.Value.ToString()}", item == Selected, ImGuiSelectableFlags.SpanAllColumns ) ) {
                Selected = item;
            }

            return false;
        }

        protected override void DrawControls()
        {
            base.DrawControls();
        }
    }
}
