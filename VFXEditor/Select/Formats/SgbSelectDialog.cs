using VfxEditor.Formats.SgbFormat;
using VfxEditor.Select.Tabs.Housing;

namespace VfxEditor.Select.Formats {
    public class SgbSelectDialog : SelectDialog {
        public SgbSelectDialog( string id, SgbManager manager, bool isSourceDialog ) : base( id, "sgb", manager, isSourceDialog ) {
            GameTabs.AddRange( [
                new HousingSGBTab ( this, "Housing" )
            ]);
        }
    }
}