using VfxEditor.Select.Base;

namespace VfxEditor.Select.Tabs.CutSounds {
    public class CutSoundsRow : ISelectItem {
        public readonly string Name;
        public readonly string Path;
        public readonly int RowId;

        public CutSoundsRow( int rowId, string path, string name ) {
            RowId = rowId;
            Path = path;
            Name = name;
        }

        public string GetName() => Name;
    }
}