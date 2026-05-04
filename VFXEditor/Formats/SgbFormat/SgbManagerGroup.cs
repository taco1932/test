using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.SgbFormat {
    public class SgbManagerGroup : FileManagerGroup<SgbManager, SgbDocument, SgbFile, WorkspaceMetaBasic> {
        public SgbManagerGroup() : base( "Sgb Editor", "Sgb" ) { }

        protected override SgbManager GetNewManager() => new( this );
    }
}