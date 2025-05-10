using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxEffectorUnknown1 : AvfxDataWithParameters {
        public readonly AvfxCurve1Axis Length = new( "Length", "Len" );
        public readonly AvfxCurve1Axis Strength = new( "Strength", "Str" );
        public readonly AvfxCurve1Axis AStrength = new( "Alpha Strength?", "AStr" );
        public readonly AvfxCurve1Axis Angle = new( "Angle", "Ang" );
        public readonly AvfxFloat FadeStartDistance = new( "Fade Start Distance", "FSDc" );
        public readonly AvfxFloat FadeEndDistance = new( "Fade End Distance", "FEDc" );
        public readonly AvfxEnum<ClipBasePoint> FadeBasePointType = new( "Fade Base Point", "FaBP" );
        public readonly AvfxBool bOS = new( "bOS", "bOS" ); //guessing w/ decompile


        public AvfxEffectorUnknown1() : base() {
            Parsed = [
                Length,
                Strength,
                AStrength,
                Angle,
                FadeStartDistance,
                FadeEndDistance,
                FadeBasePointType,
                bOS
            ];

            ParameterTab.Add( FadeStartDistance );
            ParameterTab.Add( FadeEndDistance );
            ParameterTab.Add( FadeBasePointType );
            ParameterTab.Add( bOS );

            Tabs.Add( Length );
            Tabs.Add( Strength );
            Tabs.Add( AStrength );
            Tabs.Add( Angle );

        }
    }
}
