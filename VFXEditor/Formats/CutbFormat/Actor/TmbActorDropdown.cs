using System.Collections.Generic;
using System.Numerics;
using VfxEditor.Data.Command.ListCommands;
using VfxEditor.CutbFormat.Entries;
using VfxEditor.Ui.Components;

namespace VfxEditor.CutbFormat.Actor {
    public class CutbActorDropdown : Dropdown<Tmac> {
        private readonly CutbFile File;

        public CutbActorDropdown( CutbFile file ) : base( "Actor", file.Actors ) {
            File = file;
        }

        public override string GetText( Tmac item, int idx ) => $"Actor {idx}";

        protected override bool DoColor( Tmac item, out Vector4 color ) => CutbEntry.DoColor( item.MaxDanger, out color );

        protected override void DrawControls() => DrawNewDeleteControls( OnNew, OnDelete );

        private void OnNew() {
            var newActor = new Tmac( File );
            var commands = new List<ICommand> {
                new ListAddCommand<Tmac>( Items, newActor ),
                new ListAddCommand<Tmac>( File.HeaderTmal.Actors, newActor )
            };
            CommandManager.Add( new CompoundCommand( commands, File.RefreshIds ) );
        }

        private void OnDelete( Tmac item ) {
            var commands = new List<ICommand> {
                new ListRemoveCommand<Tmac>( Items, item ),
                new ListRemoveCommand<Tmac>( File.HeaderTmal.Actors, item )
            };
            item.DeleteChildren( commands, File );
            CommandManager.Add( new CompoundCommand( commands, File.RefreshIds ) );
        }

        protected override void DrawSelected() => Selected.Draw();
    }
}
