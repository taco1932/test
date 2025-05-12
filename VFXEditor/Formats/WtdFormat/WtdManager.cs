using VfxEditor.FileManager;
using VfxEditor.Select.Formats;
using VfxEditor.Utils;

namespace VfxEditor.Formats.WtdFormat {
    public unsafe class WtdManager : FileManager<WtdDocument, WtdFile, WorkspaceMetaBasic> {
        public WtdManager() : base( "Wtd Editor", "Wtd" ) {
            SourceSelect = new WtdSelectDialog( "Wtd Select [LOADED]", this, true );
            ReplaceSelect = new WtdSelectDialog( "Wtd Select [REPLACED]", this, false );
        }

        protected override WtdDocument GetNewDocument() => new( this, NewWriteLocation );

        protected override WtdDocument GetWorkspaceDocument( WorkspaceMetaBasic data, string localPath ) => new( this, NewWriteLocation, localPath, data );
    }
}