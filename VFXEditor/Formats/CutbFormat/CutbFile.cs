using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VfxEditor.CutbFormat.Actor;
using VfxEditor.CutbFormat.Entries;
using VfxEditor.CutbFormat.Tmfcs;
using VfxEditor.CutbFormat.Ctrls;
using VfxEditor.CutbFormat.Utils;
using VfxEditor.FileManager;
using VfxEditor.TmbFormat;
using VfxEditor.Ui.Components.SplitViews;
using VfxEditor.Utils;

// Rework based on https://github.com/AsgardXIV/XAT
namespace VfxEditor.CutbFormat {
    public class CutbFile : FileManagerFile {
        public readonly Ctrl HeaderCtrl;
        public readonly Ctis HeaderCtis;
        public readonly Ctds HeaderCtds;
        public readonly Ctal HeaderCtal;
        public readonly Ctcb HeaderCtcb;
        public readonly Ctpa HeaderCtpa;

        public readonly List<Ctex> Ctexs = [];
        public readonly List<Cttl> Timelines = [];
        public readonly List<CutbEntry> AllEntries = [];

        public readonly CutbActorDropdown ActorsDropdown;
        public readonly TmfcDropdown TmfcDropdown;

        private CutbEntry DraggingEntry = null;

        private readonly List<Tmtr> UnusedTracks;
        private readonly UiSplitView<Tmtr> UnusedTrackView;

        public CutbFile( BinaryReader binaryReader, bool verify ) : this( binaryReader, null, verify ) { }

        public CutbFile( BinaryReader binaryReader, CommandManager manager, bool verify ) : base( manager ) {
            ActorsDropdown = new( this );
            TmfcDropdown = new( this );

            var startPos = binaryReader.BaseStream.Position;
            var reader = new CutbReader( binaryReader );

            reader.ReadInt32(); // CUTB
            var size = reader.ReadInt32();
            var numEntries = reader.ReadInt32(); // entry count (not including CUTB)
            HeaderCtrl = new Ctrl( this, reader );
            HeaderCtis = new Ctis( this, reader );
            HeaderCtds = new Ctds( this, reader );

            for( var i = 0; i < numEntries - 3 ; i++ ) {
                reader.ParseItem( this, Ctexs, Timelines, AllEntries, ref Verified );
            }

            HeaderTmal.PickActors( reader );
            Actors.ForEach( x => x.PickTracks( reader ) );
            AllTracks.ForEach( x => x.PickEntries( reader ) );

            RefreshIds();

            if( verify ) Verified = FileUtils.Verify( binaryReader, ToBytes() );

            binaryReader.BaseStream.Position = startPos + size;

            UnusedTracks = [.. AllTracks.Where( x => !Actors.Any( a => a.Tracks.Contains( x ) ) )];
            UnusedTrackView = new( "Track", UnusedTracks, false );
        }

        public override void Write( BinaryWriter writer ) {
            var startPos = writer.BaseStream.Position;
            FileUtils.WriteString( writer, "TMLB" );
            writer.Write( 0 ); // placeholder for size

            RefreshIds();

            var timelineCount = Actors.Count + Actors.Sum( x => x.Tracks.Count ) + AllTracks.Sum( x => x.Entries.Count );

            var items = new List<CutbItem> { HeaderTmdh };
            if( HeaderTmpp.IsAssigned ) items.Add( HeaderTmpp );
            items.Add( HeaderTmal );
            items.AddRange( Actors );
            items.AddRange( AllTracks );
            items.AddRange( AllEntries );

            var itemLength = items.Sum( x => x.Size );
            var extraLength = items.Sum( x => x.ExtraSize );
            var timelineLength = timelineCount * sizeof( short );
            var CutbWriter = new CutbWriter( itemLength, extraLength, timelineLength );

            writer.Write( items.Count );
            foreach( var item in items ) {
                CutbWriter.StartPosition = CutbWriter.Position;
                item.Write( CutbWriter );
            }

            CutbWriter.WriteTo( writer );
            CutbWriter.Dispose();

            // Fill in size placeholder
            var endPos = writer.BaseStream.Position;
            writer.BaseStream.Position = startPos + 4;
            writer.Write( ( int )( endPos - startPos ) );
            writer.BaseStream.Position = endPos;
        }

        public override void Draw() {
            var maxDanger = AllEntries.Count == 0 ? DangerLevel.None : AllEntries.Max( x => x.Danger );
            if( maxDanger == DangerLevel.DontAddRemove ) DontAddRemoveWarning();
            else if( maxDanger == DangerLevel.Detectable || Tmfcs.Count > 0 ) DetectableWarning();

            using var tabBar = ImRaii.TabBar( "Tabs", ImGuiTabBarFlags.NoCloseWithMiddleMouseButton );
            if( !tabBar ) return;

            DrawParameters();

            using( var tab = ImRaii.TabItem( "Actors" ) ) {
                if( tab ) ActorsDropdown.Draw();
            }

            using( var tab = ImRaii.TabItem( "F-Curves" ) ) {
                if( tab ) TmfcDropdown.Draw();
            }

            DrawUnused();
        }

        private void DrawParameters() {
            using var tabItem = ImRaii.TabItem( "Parameters" );
            if( !tabItem ) return;

            HeaderTmdh.Draw();
            HeaderTmpp.Draw();
        }

        private void DrawUnused() {
            if( UnusedTracks.Count == 0 ) return;

            using var tabItem = ImRaii.TabItem( "Unused" );
            if( !tabItem ) return;

            ImGui.TextDisabled( "These are leftover tracks which are never actually triggered, and are only useful for research purposes" );
            ImGui.Separator();
            UnusedTrackView.Draw();
        }

        public void RefreshIds() {
            short id = 2;
            foreach( var actor in Actors ) actor.Id = id++;
            foreach( var track in AllTracks ) track.Id = id++;
            foreach( var entry in AllEntries ) entry.Id = id++;
        }

        public void StartDragging( CutbEntry entry ) {
            ImGui.SetDragDropPayload( "Cutb_ENTRY", null, 0 );
            DraggingEntry = entry;
        }

        public unsafe void StopDragging( Tmtr destination ) {
            if( DraggingEntry == null ) return;
            var payload = ImGui.AcceptDragDropPayload( "Cutb_ENTRY" );
            if( payload.Handle == null ) return;

            var commands = new List<ICommand>();
            foreach( var track in AllTracks ) {
                track.DeleteEntry( commands, DraggingEntry ); // will add to command
            }
            destination.AddEntry( commands, DraggingEntry );
            CommandManager.Add( new CompoundCommand( commands, RefreshIds ) );

            DraggingEntry = null;
        }

        // ===============

        public static CutbFile FromPapEmbedded( string path, CommandManager manager ) {
            if( !File.Exists( path ) ) return null;
            using BinaryReader br = new( File.Open( path, FileMode.Open ) );
            return new CutbFile( br, manager, true );
        }

        public static void DetectableWarning() {
            ImGui.PushStyleColor( ImGuiCol.Text, UiUtils.RED_COLOR );
            ImGui.TextWrapped( "Changes to this file are potentially detectable" );
            ImGui.PopStyleColor();
            ImGui.SameLine();
            if( ImGui.SmallButton( "Guide" ) ) UiUtils.OpenUrl( "https://github.com/0ceal0t/Dalamud-VFXEditor/wiki/Notes-on-TMFC" );
        }

        public static void GenericWarning() {
            ImGui.PushStyleColor( ImGuiCol.Text, UiUtils.RED_COLOR );
            ImGui.TextWrapped( "Please don't do anything stupid with this" );
            ImGui.PopStyleColor();
        }

        public static void DontAddRemoveWarning() {
            ImGui.PushStyleColor( ImGuiCol.Text, UiUtils.RED_COLOR );
            ImGui.TextWrapped( "Don't add or remove entries in this file" );
            ImGui.PopStyleColor();
        }
    }
}
