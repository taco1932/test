using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.WtdFormat {
    public class WtdManagerGroup : FileManagerGroup<WtdManager, WtdDocument, WtdFile, WorkspaceMetaBasic> {
        public WtdManagerGroup() : base( "Wtd Editor", "Wtd" ) { }

        protected override WtdManager GetNewManager() => new( this );
    }
}