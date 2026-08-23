using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.ObsbFormat {
    public class ObsbDocument : FileManagerBasicDocument<ObsbFile> {
        public override string Id => "Obsb";
        public override string Extension => "obsb";

        public ObsbDocument( ObsbManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public ObsbDocument( ObsbManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : base( manager, writeLocation, localPath, data ) { }

        protected override ObsbFile FileFromReader( BinaryReader reader, bool verify ) => new( reader );
    }
}
