using ImGuiNET;
using Dalamud.Interface.Utility.Raii;
using System.Collections.Generic;
using VfxEditor.Ui.Components.SplitViews;
using Dalamud.Interface;
using VfxEditor.FileBrowser;
using System;
using VfxEditor.WtdFormat.Utils;

namespace VfxEditor.Formats.WtdFormat.Entry {
    public class WtdEntrySplitView : CommandSplitView<WtdEntry> {
        public WtdEntrySplitView( List<WtdEntry> items ) : base( "Entry", items, false, null, () => new() ) { }

        protected override bool DrawLeftItem( WtdEntry item, int idx ) {
            using var _ = ImRaii.PushId( idx );

            var weaponId = item.weaponId;
            
            if( ImGui.Selectable( $"{weaponId.Value.ToString()}", item == Selected, ImGuiSelectableFlags.SpanAllColumns ) ) {
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
