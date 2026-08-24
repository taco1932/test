using VfxEditor.Select.Base;

namespace VfxEditor.Select.Tabs.Foot {
    public class FootRow : ISelectItem {
        public readonly string Name;
        public readonly string Path;
        public readonly int RowId;

        public FootRow( int rowId, string path, string name ) {
            RowId = rowId;
            Path = path;
            Name = name;
        }

        public string GetName() => Name;
    }
}