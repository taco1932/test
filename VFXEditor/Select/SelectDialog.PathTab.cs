using Dalamud.Interface;
using Dalamud.Interface.Utility.Raii;
using ImGuiNET;
using System.IO;
using System.Linq;
using System.Numerics;
using VfxEditor.FileBrowser;
using VfxEditor.Utils;
using System.Collections.Generic;

namespace VfxEditor.Select {
    public partial class SelectDialog {
        private void DrawPaths() {
            using var _ = ImRaii.PushId( "Paths" );

            using var tabItem = ImRaii.TabItem( "Paths" );
            if( !tabItem ) return;

            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 2 );

            ImGui.Text( "Game Path" );
            using( var __ = ImRaii.PushId( "Game" ) )
            using( var style = ImRaii.PushStyle( ImGuiStyleVar.ItemSpacing, ImGui.GetStyle().ItemInnerSpacing ) ) {
                ImGui.InputTextWithHint( "##Path", $"vfx/common/eff/wp_astro1h.{Extensions[0]}", ref GamePathInput, 255 );

                ImGui.SameLine();
                if( ImGui.Button( "SELECT" ) ) SelectGamePath( GamePathInput );
            }

            if( ShowLocal ) {
                ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 5 );

                ImGui.Text( "Local Path" );
                using var style = ImRaii.PushStyle( ImGuiStyleVar.ItemSpacing, ImGui.GetStyle().ItemInnerSpacing );
                using var __ = ImRaii.PushId( "Local" );

                ImGui.SetNextItemWidth( UiUtils.GetOffsetInputSize( UiUtils.GetPaddedIconSize( FontAwesomeIcon.FolderOpen ) ) );
                ImGui.InputTextWithHint( "##Path", $"C:\\Users\\me\\Desktop\\custom.{Extensions[0]}", ref LocalPathInput, 255 );

                ImGui.SameLine();
                using( var font = ImRaii.PushFont( UiBuilder.IconFont ) ) {
                    if( ImGui.Button( FontAwesomeIcon.FolderOpen.ToIconString() ) ) {
                        FileBrowserManager.OpenFileDialog( "Select a File", "Files{" + string.Join( ",", Extensions.Select( e => $".{e}" ) ) + "},.*", ( bool ok, string res ) => {
                            if( !ok ) return;
                            Invoke( new SelectResult( SelectResultType.Local, res, "[LOCAL] " + res, res ) );
                        } );
                    }
                }

                ImGui.SameLine();
                if( ImGui.Button( "SELECT" ) && Path.IsPathRooted( LocalPathInput ) && File.Exists( LocalPathInput ) ) {
                    Invoke( new SelectResult( SelectResultType.Local, LocalPathInput, "[LOCAL] " + LocalPathInput, LocalPathInput ) );
                    LocalPathInput = "";
                }
            }

            // =======================

            if( !Plugin.Configuration.SelectDialogLogOpen ) {
                ImGui.SetCursorPosY( ImGui.GetCursorPosY() + ImGui.GetContentRegionAvail().Y - UiUtils.AngleUpDownSize );
            }
            else {
                ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 20 );
            }

            if( UiUtils.DrawAngleUpDown( ref Plugin.Configuration.SelectDialogLogOpen ) ) Plugin.Configuration.Save();
            if( !Plugin.Configuration.SelectDialogLogOpen ) return;

            if( ImGui.Checkbox( "Log all files", ref Plugin.Configuration.LogAllFiles ) ) Plugin.Configuration.Save();

            ImGui.SameLine();
            ImGui.PushItemWidth( 300 );
            if( ImGui.Button( "Load Scanned Paths" ) )
            {
                LoggedFiles.Clear();
                Plugin.Configuration.LogAllFiles = false;
                Plugin.Configuration.Save();
                foreach(string item in VfxEditor.Select.SelectTab.ScannedPaths )
                {
                    LoggedFiles.Add( item );
                }
                SelectGamePaths( VfxEditor.Select.SelectTab.ScannedPaths );
                VfxEditor.FileManager.FileManager.flaggedpaths.Clear();
            }

            using var disabled = ImRaii.Disabled( LoggedFiles.Count == 0 && !Plugin.Configuration.LogAllFiles );

            ImGui.SameLine();
            using( var style = ImRaii.PushStyle( ImGuiStyleVar.ItemSpacing, ImGui.GetStyle().ItemInnerSpacing ) ) {
                ImGui.InputTextWithHint( "##Search", "Search", ref LoggedFilesSearch, 255 );

                ImGui.SameLine();
                using var font = ImRaii.PushFont( UiBuilder.IconFont );
                if( UiUtils.RemoveButton( FontAwesomeIcon.Trash.ToIconString() ) ) LoggedFiles.Clear();
            }


            using var windowPadding = ImRaii.PushStyle( ImGuiStyleVar.WindowPadding, new Vector2( 0, 0 ) );
            using var child = ImRaii.Child( "Child", new Vector2( -1, -1 ), true );

            var searched = LoggedFiles
                .Where( x => Extensions.Any( x.EndsWith ) && ( string.IsNullOrEmpty( LoggedFilesSearch ) || x.Contains( LoggedFilesSearch, System.StringComparison.CurrentCultureIgnoreCase ) ) )
                .ToList();

            var itemHeight = ImGui.GetTextLineHeight() + ImGui.GetStyle().ItemSpacing.Y;
            SelectUiUtils.DisplayVisible( searched.Count, itemHeight, out var preItems, out var showItems, out var postItems );
            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + preItems * itemHeight );

            if( ImGui.BeginTable( "Table", 1, ImGuiTableFlags.RowBg ) ) {
                ImGui.TableSetupColumn( "##Column", ImGuiTableColumnFlags.WidthStretch );

                var idx = 0;
                foreach( var file in searched ) {
                    if( idx < preItems || idx > ( preItems + showItems ) ) { idx++; continue; }

                    ImGui.TableNextColumn();
                    ImGui.SetCursorPosX( ImGui.GetCursorPosX() + 4 );
                    ImGui.Selectable( $"{file}##{idx}" );
                    if( ImGui.IsMouseDoubleClicked( ImGuiMouseButton.Left ) && ImGui.IsItemHovered() ) SelectGamePath( file );

                    idx++;
                }

                ImGui.EndTable();
            }

            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + postItems * itemHeight );
        }

        private void SelectGamePath( string path ) {
            var cleanedPath = path.Trim().Replace( "\\", "/" );
            if( !ShowLocal || Dalamud.DataManager.FileExists( cleanedPath ) ) {
                Invoke( new SelectResult( SelectResultType.GamePath, cleanedPath, "[GAME] " + cleanedPath, cleanedPath ) );
                GamePathInput = "";
            }
        }
        private void SelectGamePaths( List<string> Paths)
        {
            foreach( var path in Paths )
            {
                SelectGamePath( path );

            }
        }
    }
}
