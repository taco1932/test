using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxEffectorBlackHole : AvfxDataWithParameters {

        //E8 ?? ?? ?? ?? 44 8B 44 24 ?? 41 B9 ?? ?? ?? ?? 48 89 43

        //public readonly AvfxCurve1Axis _ = new( "", "" );

        public AvfxEffectorBlackHole() : base()
        {
            Parsed = [
                //parameters
            ];
            //ParameterTab.Add();
            //Tabs.Add();
        }
    }
}
