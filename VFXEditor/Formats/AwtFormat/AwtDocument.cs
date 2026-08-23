using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.AwtFormat {
    public class AwtDocument : FileManagerBasicDocument<AwtFile> {
        public override string Id => "Awt";
        public override string Extension => "awt";

        public AwtDocument( AwtManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public AwtDocument( AwtManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : base( manager, writeLocation, localPath, data ) { }

        protected override AwtFile FileFromReader( BinaryReader reader, bool verify ) => new( reader );
    }
}
