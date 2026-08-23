using VfxEditor.Formats.MtrlFormat;
using VfxEditor.Select.Tabs.Character;
using VfxEditor.Select.Tabs.Items;
using VfxEditor.Select.Tabs.Mounts;
using VfxEditor.Select.Tabs.Npc;

namespace VfxEditor.Select.Formats {
    public class MtrlSelectDialog : SelectDialog {
        public MtrlSelectDialog( string id, MtrlManager manager, bool isSourceDialog ) : base( id, "mtrl", manager, isSourceDialog ) {
            GameTabs.AddRange( [
                new ItemTabMtrl( this, "Item" ),
                new CharacterTabMtrl( this, "Character" ),
                new NpcTabMtrl( this, "NPC" ),
                new MountTabMtrl( this, "Mount", "", "" ),
            ] );
        }
    }
}