using VfxEditor.Formats.WtdFormat;
using VfxEditor.Select.Tabs.Common;

namespace VfxEditor.Select.Formats {
    public class WtdSelectDialog : SelectDialog {
        public WtdSelectDialog( string id, WtdManager manager, bool isSourceDialog ) : base( id, "atch", manager, isSourceDialog ) {
            GameTabs.AddRange( [
                new CommonTabWtd( this, "Common" )
            ] );
        }
    }
}