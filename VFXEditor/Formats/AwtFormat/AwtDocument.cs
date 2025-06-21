using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.AwtFormat {
    public class AwtDocument : FileManagerDocument<AwtFile, WorkspaceMetaBasic> {
        public override string Id => "Awt";
        public override string Extension => "awt";

        public AwtDocument( AwtManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public AwtDocument( AwtManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : this( manager, writeLocation ) {
            LoadWorkspace( localPath, data.RelativeLocation, data.Name, data.Source, data.Replace, data.Disabled );
        }

        protected override AwtFile FileFromReader( BinaryReader reader, bool verify ) => new( reader );

        public override WorkspaceMetaBasic GetWorkspaceMeta( string newPath ) => new() {
            Name = Name,
            RelativeLocation = newPath,
            Replace = Replace,
            Source = Source,
            Disabled = Disabled
        };
    }
}
