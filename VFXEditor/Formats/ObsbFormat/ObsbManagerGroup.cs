using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.ObsbFormat {
    public class ObsbManagerGroup : FileManagerGroup<ObsbManager, ObsbDocument, ObsbFile, WorkspaceMetaBasic> {
        public ObsbManagerGroup() : base( "Obsb Editor", "Obsb" ) { }

        protected override ObsbManager GetNewManager() => new( this );
    }
}