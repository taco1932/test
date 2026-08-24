using System.IO;
using System.Linq;

namespace VfxEditor.Select.Tabs.EventSounds {
    public class EventSoundsTab : SelectTab<EventSoundsRow> {
        public EventSoundsTab( SelectDialog dialog, string name ) : base( dialog, name, "EventSounds" ) { }

        // ===== LOADING =====

        public override void LoadData() {
            var idx = 0;
            foreach( var line in File.ReadLines( SelectDataUtils.CommonScdPath ).Where( x => !string.IsNullOrEmpty( x ) ) ) {
                if( line.Contains( "sound/event/" ) ) {
                    Items.Add( new EventSoundsRow( idx++, line, line.Replace( "sound/event/", "" ).Replace( ".scd", "" ) ) );
                }
            }
        }

        // ===== DRAWING ======

        protected override void DrawSelected() {
            Dialog.DrawPaths( Selected.Path, Selected.Name, SelectResultType.GameMisc );
        }
    }
}