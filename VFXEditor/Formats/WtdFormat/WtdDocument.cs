using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.WtdFormat {
    public class WtdDocument : FileManagerBasicDocument<WtdFile> {
        public override string Id => "Wtd";
        public override string Extension => "wtd";

        public WtdDocument( WtdManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public WtdDocument( WtdManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : base( manager, writeLocation, localPath, data ) { }

        protected override WtdFile FileFromReader( BinaryReader reader, bool verify ) => new( reader );
    }
}
