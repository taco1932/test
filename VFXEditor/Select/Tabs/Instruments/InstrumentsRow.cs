using VfxEditor.Select.Base;

namespace VfxEditor.Select.Tabs.Instruments {
    public class InstrumentsRow : ISelectItem {
        public readonly string Name;
        public readonly string Path;
        public readonly int RowId;

        public InstrumentsRow( int rowId, string path, string name ) {
            RowId = rowId;
            Path = path;
            Name = name;
        }

        public string GetName() => Name;
    }
}