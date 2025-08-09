using VfxEditor.FileManager;
using VfxEditor.Select.Formats;
using VfxEditor.Utils;

namespace VfxEditor.Formats.ObsbFormat {
    public unsafe class ObsbManager : FileManager<ObsbDocument, ObsbFile, WorkspaceMetaBasic> {
        public ObsbManager() : base( "Obsb Editor", "Obsb" ) {
            SourceSelect = new AwtSelectDialog( "Obsb Select [LOADED]", this, true );
            ReplaceSelect = new AwtSelectDialog( "Obsb Select [REPLACED]", this, false );
        }

        protected override ObsbDocument GetNewDocument() => new( this, NewWriteLocation );

        protected override ObsbDocument GetWorkspaceDocument( WorkspaceMetaBasic data, string localPath ) => new( this, NewWriteLocation, localPath, data );
    }
}