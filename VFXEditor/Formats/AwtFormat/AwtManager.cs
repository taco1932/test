using VfxEditor.FileManager;
using VfxEditor.Select.Formats;
using VfxEditor.Utils;

namespace VfxEditor.Formats.AwtFormat {
    public unsafe class AwtManager : FileManager<AwtDocument, AwtFile, WorkspaceMetaBasic> {
        public AwtManager() : base( "Awt Editor", "Awt" ) {
            SourceSelect = new AwtSelectDialog( "Awt Select [LOADED]", this, true );
            ReplaceSelect = new AwtSelectDialog( "Awt Select [REPLACED]", this, false );
        }

        protected override AwtDocument GetNewDocument() => new( this, NewWriteLocation );

        protected override AwtDocument GetWorkspaceDocument( WorkspaceMetaBasic data, string localPath ) => new( this, NewWriteLocation, localPath, data );
    }
}