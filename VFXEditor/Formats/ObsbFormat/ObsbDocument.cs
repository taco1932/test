using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.ObsbFormat {
    public class ObsbDocument : FileManagerDocument<ObsbFile, WorkspaceMetaBasic> {
        public override string Id => "Obsb";
        public override string Extension => "obsb";

        public ObsbDocument( ObsbManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public ObsbDocument( ObsbManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : this( manager, writeLocation ) {
            LoadWorkspace( localPath, data.RelativeLocation, data.Name, data.Source, data.Replace, data.Disabled );
        }

        protected override ObsbFile FileFromReader( BinaryReader reader, bool verify ) => new( reader );

        public override WorkspaceMetaBasic GetWorkspaceMeta( string newPath ) => new() {
            Name = Name,
            RelativeLocation = newPath,
            Replace = Replace,
            Source = Source,
            Disabled = Disabled
        };
    }
}
