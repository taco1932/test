using System.Collections.Generic;
using System.Linq;

namespace VfxEditor.Select.Tabs.Npc {
    public class NpcTabMtrl : NpcTab {
        public NpcTabMtrl( SelectDialog dialog, string name ) : base( dialog, name ) { }

        protected override void GetLoadedFiles( NpcFilesStruct files, out List<string> loaded ) {
            loaded = Selected.IsMonster ?
                [Selected.GetMtrlPath( "", "" )] :
                [.. new List<string>() {
                    Selected.GetMtrlPath( "_a", "met_a" ),
                    Selected.GetMtrlPath( "_b", "met_b" ),
                    Selected.GetMtrlPath( "_c", "met_c" ),
                    Selected.GetMtrlPath( "_a", "glv_a" ),
                    Selected.GetMtrlPath( "_b", "glv_b" ),
                    Selected.GetMtrlPath( "_c", "glv_c" ),
                    Selected.GetMtrlPath( "_a", "dwn_a" ),
                    Selected.GetMtrlPath( "_b", "dwn_b" ),
                    Selected.GetMtrlPath( "_c", "dwn_c" ),
                    Selected.GetMtrlPath( "_a", "sho_a" ),
                    Selected.GetMtrlPath( "_b", "sho_b" ),
                    Selected.GetMtrlPath( "_c", "sho_c" ),
                    Selected.GetMtrlPath( "_d", "sho_d" ),
                    Selected.GetMtrlPath( "_a", "top_a" ),
                    Selected.GetMtrlPath( "_b", "top_b" ),
                    Selected.GetMtrlPath( "_c", "top_c" ),
                    //this is really bad and doesn't work, so please fix this
                }.Where( Dalamud.DataManager.FileExists )];
        }
    }
}
