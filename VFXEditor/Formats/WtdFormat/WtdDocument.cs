using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.WtdFormat {
    public class WtdDocument : FileManagerDocument<WtdFile, WorkspaceMetaBasic> {
        public override string Id => "Wtd";
        public override string Extension => "wtd";

        public WtdDocument( WtdManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public WtdDocument( WtdManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : this( manager, writeLocation ) {
            LoadWorkspace( localPath, data.RelativeLocation, data.Name, data.Source, data.Replace, data.Disabled );
        }

        protected override WtdFile FileFromReader( BinaryReader reader, bool verify ) => new( reader );

        public override WorkspaceMetaBasic GetWorkspaceMeta( string newPath ) => new() {
            Name = Name,
            RelativeLocation = newPath,
            Replace = Replace,
            Source = Source,
            Disabled = Disabled
        };
    }
}
