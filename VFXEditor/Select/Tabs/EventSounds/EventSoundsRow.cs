using VfxEditor.Select.Base;

namespace VfxEditor.Select.Tabs.EventSounds {
    public class EventSoundsRow : ISelectItem {
        public readonly string Name;
        public readonly string Path;
        public readonly int RowId;

        public EventSoundsRow( int rowId, string path, string name ) {
            RowId = rowId;
            Path = path;
            Name = name;
        }

        public string GetName() => Name;
    }
}