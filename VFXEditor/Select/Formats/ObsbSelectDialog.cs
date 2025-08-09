using VfxEditor.Formats.ObsbFormat;
using VfxEditor.Select.Tabs.Common;

namespace VfxEditor.Select.Formats {
    public class ObsbSelectDialog : SelectDialog {
        public ObsbSelectDialog( string id, ObsbManager manager, bool isSourceDialog ) : base( id, "obsb", manager, isSourceDialog ) {
            GameTabs.AddRange( [
                new CommonTabObsb( this, "Common" )
            ] );
        }
    }
}