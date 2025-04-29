using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxEmitterDataConeModel : AvfxDataWithParameters {
        public readonly AvfxEnum<RotationOrder> RotationOrderType = new( "Rotation Order", "ROT" );
        public readonly AvfxEnum<GenerateMethod> GenerateMethodType = new( "Generate Method", "GeMT" );
        public readonly AvfxInt DivideX = new( "Divide X", "DivX" );
        public readonly AvfxInt DivideY = new( "Divide Y", "DivY" );
        //public readonly AvfxInt DivideZ = new( "[TEST] Divide Z", "DivZ" );
        public readonly AvfxCurve1Axis AX = new( "Angle X", "AnX", CurveType.Angle );
        public readonly AvfxCurve1Axis AY = new( "Angle Y", "AnY", CurveType.Angle );
        public readonly AvfxCurve1Axis AZ = new( "Angle Z", "AnZ", CurveType.Angle );
        public readonly AvfxCurve1Axis AXR = new( "Angle X Random", "AnXR", CurveType.Angle );
        public readonly AvfxCurve1Axis AYR = new( "Angle Y Random", "AnYR", CurveType.Angle );
        public readonly AvfxCurve1Axis AZR = new( "[TEST] Angle Z Random", "AnZR", CurveType.Angle );
        //public readonly AvfxCurve1Axis InnerSize = new( "[TEST] Inner Size", "InS" );
        //public readonly AvfxCurve1Axis InnerSizeRandom = new( "[TEST] Inner Size Random", "InSR" );
        //public readonly AvfxCurve1Axis OuterSize = new( "[TEST] Outer Size", "OuS" );
        //public readonly AvfxCurve1Axis OuterSizeRandom = new( "[TEST] Outer Size Random", "OuSR" );
        //public readonly AvfxCurve1Axis Length = new( "[TEST] Length", "Len" );
        //public readonly AvfxCurve1Axis LengthRandom = new( "[TEST] Length Random", "LenR" );
        public readonly AvfxCurve1Axis Radius = new( "Radius", "Rad" );
        public readonly AvfxCurve1Axis RadiusRandom = new( "[TEST] Radius Random", "RadR" );
        public readonly AvfxCurve1Axis InjectionSpeed = new( "Injection Speed", "IjS" );
        public readonly AvfxCurve1Axis InjectionSpeedRandom = new( "Injection Speed Random", "IjSR" );
        public readonly AvfxCurve1Axis InjectionAngle = new( "Injection Angle", "IjA", CurveType.Angle );
        public readonly AvfxCurve1Axis InjectionAngleRandom = new( "Injection Angle Random", "IjAR", CurveType.Angle );

        public AvfxEmitterDataConeModel() : base() {
            Parsed = [
                RotationOrderType,
                GenerateMethodType,
                DivideX,
                DivideY,
                //DivideZ,//
                AX,
                AY,
                AZ,
                AXR,
                AYR,
                AZR,//
                //InnerSize,
                //InnerSizeRandom,
                //OuterSize,
                //OuterSizeRandom,
                //Length,
                //LengthRandom,
                Radius,
                RadiusRandom,//
                InjectionSpeed,
                InjectionSpeedRandom,
                InjectionAngle,
                InjectionAngleRandom
            ];

            ParameterTab.Add( RotationOrderType );
            ParameterTab.Add( GenerateMethodType );
            ParameterTab.Add( DivideX );
            ParameterTab.Add( DivideY );
            //ParameterTab.Add( DivideZ );//

            Tabs.Add( AX );
            Tabs.Add( AY );
            Tabs.Add( AZ );
            Tabs.Add( AXR );
            Tabs.Add( AYR );
            Tabs.Add( AZR );//
            //Tabs.Add( InnerSize );
            //Tabs.Add( InnerSizeRandom );
            //Tabs.Add( OuterSize );
            //Tabs.Add( OuterSizeRandom );
            //Tabs.Add( Length );
            //Tabs.Add( LengthRandom );//
            Tabs.Add( Radius );
            Tabs.Add( RadiusRandom );//
            Tabs.Add( InjectionSpeed );
            Tabs.Add( InjectionSpeedRandom );
            Tabs.Add( InjectionAngle );
            Tabs.Add( InjectionAngleRandom );
        }
    }
}
