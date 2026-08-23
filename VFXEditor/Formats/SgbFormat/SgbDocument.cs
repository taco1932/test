using Dalamud.Bindings.ImGui;
using System.IO;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.Formats.SgbFormat {
    public class SgbDocument : FileManagerBasicDocument<SgbFile> {
        public override string Id => "Sgb";
        public override string Extension => "sgb";

        public SgbDocument( SgbManager manager, string writeLocation ) : base( manager, writeLocation ) { }

        public SgbDocument( SgbManager manager, string writeLocation, string localPath, WorkspaceMetaBasic data ) : base( manager, writeLocation, localPath, data ) { }

        protected override SgbFile FileFromReader( BinaryReader reader, bool verify ) => new( reader, verify );

        protected override void DrawBody() {
            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 5 );
            DrawAnimationWarningSGB();
            base.DrawBody();
        }
    }
}