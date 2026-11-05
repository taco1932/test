using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using System.Linq;
using VfxEditor.AtchFormat.Utils;
using VfxEditor.FileBrowser;
using VfxEditor.Interop.Penumbra.Meta;
using VfxEditor.Ui.Components.SplitViews;

namespace VfxEditor.Formats.AtchFormat.Entry {
    public class AtchEntrySplitView : CommandSplitView<AtchEntry> {
        private readonly AtchFile File;

        public AtchEntrySplitView( AtchFile file, List<AtchEntry> items ) : base( "Entry", items, false, null, () => new() ) {
            File = file;
        }

        protected override bool DrawLeftItem( AtchEntry item, int idx ) {
            using var _ = ImRaii.PushId( idx );

            var code = item.Name.Value;
            var weaponName = item.WeaponName;

            ImGui.TextDisabled( code );
            ImGui.SameLine( 35 );
            if( ImGui.Selectable( $"{weaponName}##{code}", item == Selected, ImGuiSelectableFlags.SpanAllColumns ) ) {
                Selected = item;
            }

            return false;
        }

        protected override void DrawSelected() {
            using var _ = ImRaii.PushId( Items.IndexOf( Selected ) );
            var states = PenumbraMetaWriter
                .GetUpdatedStates( File.Vanilla?.Entries, Selected, File.SeenNames, 0 )
                .Select( x => x.State )
                .ToList();
            Selected.Draw( states );
        }

        protected override void DrawControls()
        {
            base.DrawControls();

            ImGui.SameLine();
            using( var font = ImRaii.PushFont( UiBuilder.IconFont ) )
            if( ImGui.Button( FontAwesomeIcon.Upload.ToIconString() ) )
            {
                FileBrowserManager.OpenFileDialog( "Select a File", "ATCH entry{.atchentry},.*", ( bool ok, string res ) => {
                    if( !ok ) return;
                    try
                    {
                        var entry = AtchReader.Import( System.IO.File.ReadAllBytes( res ) );
                        int index = Items.FindIndex( x => x.Name.Value == entry.Name.Value);
                        if( index != -1 ) {
                            Items.RemoveAt( index );
                            Items.Add( entry );
                            Dalamud.OkNotification( $"Atch Entry {entry.Name.Value} replaced" );
                        } else {
                            Items.Add( entry );
                            Dalamud.OkNotification( $"Atch Entry {entry.Name.Value} imported" );
                        }
                        Items.Sort( ( x, y ) => { return x.Name.Value.CompareTo(y.Name.Value); } );
                    }
                    catch( Exception e )
                    {
                        Dalamud.Error( e, "Could not import data" );
                    }
                } );
            }

            ImGui.SameLine();
            using var disabled = ImRaii.Disabled( Selected == null );
            using( var font = ImRaii.PushFont( UiBuilder.IconFont ) )
            if( ImGui.Button( FontAwesomeIcon.Save.ToIconString() ) )
            {
                FileBrowserManager.SaveFileDialog( "Select a Save Location", ".atchentry,.*", "ExportedAtchEntry", "atchentry", ( ok, res ) => {
                    if( ok ) System.IO.File.WriteAllBytes( res, Selected.ToBytes() );
                } );
            }
        }
    }
}
