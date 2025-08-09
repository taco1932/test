using Dalamud.Interface;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Bindings.ImGui;
using VfxEditor.AvfxFormat;
using VfxEditor.Select.Tabs.Actions;
using VfxEditor.Select.Tabs.Common;
using VfxEditor.Select.Tabs.Cutscenes;
using VfxEditor.Select.Tabs.Emotes;
using VfxEditor.Select.Tabs.Gimmick;
using VfxEditor.Select.Tabs.Housing;
using VfxEditor.Select.Tabs.Items;
using VfxEditor.Select.Tabs.JournalCutscene;
using VfxEditor.Select.Tabs.Mounts;
using VfxEditor.Select.Tabs.Npc;
using VfxEditor.Select.Tabs.Statuses;
using VfxEditor.Select.Tabs.Zone;
using VfxEditor.Spawn;
using VfxEditor.Utils;

namespace VfxEditor.Select.Formats {
    public class VfxSelectDialog : SelectDialog {
        public VfxSelectDialog( string id, AvfxManager manager, bool isSourceDialog ) : base( id, "avfx", manager, isSourceDialog ) {
            GameTabs.AddRange( [
                new ItemTabVfx( this, "Item" ),
                new ItemTabVfxAccessory( this, "Accessory"),
                new StatusTabVfx( this, "Status" ),
                new ActionTabVfx( this, "Action" ),
                new ActionTabVfxNonPlayer( this, "Non-Player Action" ),
                new EmoteTabVfx( this, "Emote" ),
                new ZoneTabVfx( this, "Zone" ),
                new GimmickTab( this, "Gimmick" ),
                new HousingTab( this, "Housing" ),
                new NpcTabVfx( this, "Npc" ),
                new MountTabVfx( this, "Mount" ),
                new CutsceneTab( this, "Cutscene" ),
                new JournalCutsceneTab( this, "Journal Cutscene" ),
                new CommonTabVfx( this, "Common" )
            ] );
        }

        public override bool CanPlay => true;
        private bool GroundSpawn = false;
        private bool SelfSpawn = false;
        private bool TargetSpawn = false;

        //seems to be only making the adjacent buttons enabled at the moment
        //tooltips would also be nice, but the font just shows up as cars or something, even if PushFont is changed in the if/else
        public override void PlayButton( string path )
        {

            using var font = ImRaii.PushFont( UiBuilder.IconFont );

            if( TargetSpawn || GroundSpawn )
            {
                UiUtils.DisabledButton( FontAwesomeIcon.Walking.ToIconString(), false );
            }
            else if( VfxSpawn.IsActive )
            {
                SelfSpawn = true;
                if( ImGui.Button( FontAwesomeIcon.Pause.ToIconString() ) ) VfxSpawn.Clear();
            }
            else
            {
                SelfSpawn = false;
                if( ImGui.Button( FontAwesomeIcon.Walking.ToIconString() ) ) VfxSpawn.OnSelf( path, false );
            }
            ImGui.SameLine();
        }

        public override void SpawnTargetButton( string path ) {

            using var font = ImRaii.PushFont( UiBuilder.IconFont );

            if( SelfSpawn || GroundSpawn ) {
                UiUtils.DisabledButton( FontAwesomeIcon.Crosshairs.ToIconString(), false);
            }
            else if( VfxSpawn.IsActive ) {
                TargetSpawn = true;
                if( ImGui.Button( FontAwesomeIcon.Pause.ToIconString() ) ) VfxSpawn.Clear();
            }
            else {
                TargetSpawn = false;
                if( ImGui.Button( FontAwesomeIcon.Crosshairs.ToIconString() ) ) VfxSpawn.OnTarget( path, false );
            }
            ImGui.SameLine();
        }

        public override void SpawnGroundButton( string path ) {

            using var font = ImRaii.PushFont( UiBuilder.IconFont );

            if( SelfSpawn || TargetSpawn ) {
                UiUtils.DisabledButton( FontAwesomeIcon.ArrowDownLong.ToIconString(), false);
            }
            else if( VfxSpawn.IsActive ) {
                GroundSpawn = true;
                if( ImGui.Button( FontAwesomeIcon.Pause.ToIconString() ) ) VfxSpawn.Clear();
            }
            else {
                GroundSpawn = false;
                if( ImGui.Button( FontAwesomeIcon.ArrowDownLong.ToIconString() ) ) VfxSpawn.OnGround( path, false );
            }
        }

        public override void PlayPopupItems( string path ) {
            ImGui.Separator();
            if( ImGui.Selectable( "Spawn" ) ) VfxSpawn.OnSelf( path, false );
        }
    }
}