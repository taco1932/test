using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.AwtFormat {
    public class AwtManagerGroup : FileManagerGroup<AwtManager, AwtDocument, AwtFile, WorkspaceMetaBasic> {
        public AwtManagerGroup() : base( "Awt Editor", "Awt" ) { }

        protected override AwtManager GetNewManager() => new( this );
    }
}