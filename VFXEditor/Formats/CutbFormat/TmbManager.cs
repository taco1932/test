using VfxEditor.FileManager;
using VfxEditor.Select;
using VfxEditor.Select.Formats;
using VfxEditor.Spawn;
using VfxEditor.Utils;

namespace VfxEditor.CutbFormat {
    public partial class CutbManager : FileManager<CutbDocument, CutbFile, WorkspaceMetaBasic> {
        public CutbManager() : base( "Cutb Editor", "Cutb" ) {
            SourceSelect = new CutbSelectDialog( "Cutb Select [LOADED]", this, true );
            ReplaceSelect = new CutbSelectDialog( "Cutb Select [REPLACED]", this, false );
        }

        public override void SetReplace( SelectResult result ) {
            base.SetReplace( result );
            if( ActiveDocument != null ) ActiveDocument.AnimationId = CutbSpawn.GetIdFromCutbPath( result.Path );
        }

        protected override CutbDocument GetNewDocument() => new( this, NewWriteLocation );

        protected override CutbDocument GetWorkspaceDocument( WorkspaceMetaBasic data, string localPath ) => new( this, NewWriteLocation, localPath, data );
    }
}
