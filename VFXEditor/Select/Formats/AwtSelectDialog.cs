using VfxEditor.Formats.AwtFormat;
using VfxEditor.Select.Tabs.Common;

namespace VfxEditor.Select.Formats {
    public class AwtSelectDialog : SelectDialog {
        public AwtSelectDialog( string id, AwtManager manager, bool isSourceDialog ) : base( id, "awt", manager, isSourceDialog ) {
            GameTabs.AddRange( [
                new CommonTabAwt( this, "Common" )
            ] );
        }
    }
}