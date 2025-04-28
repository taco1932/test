using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxEmitterDataSphereModel : AvfxDataWithParameters {
        public readonly AvfxEnum<RotationOrder> RotationOrderType = new( "Rotation Order", "ROT" );
        public readonly AvfxEnum<GenerateMethod> GenerateMethodType = new( "Generate Method", "GeMT" );
        public readonly AvfxInt DivideX = new( "Divide X", "DivX", value: 1 );
        public readonly AvfxInt DivideY = new( "Divide Y", "DivY", value: 1 );
        public readonly AvfxInt DivideZ = new( "Divide Z", "DivZ", value: 1 );
        public readonly AvfxCurve1Axis Radius = new( "Radius", "Rads" );
        public readonly AvfxCurve1Axis AX = new( "[TEST] Angle X", "AnX", CurveType.Angle );
        public readonly AvfxCurve1Axis AY = new( "Angle Y", "AnY", CurveType.Angle );
        public readonly AvfxCurve1Axis AZ = new( "Angle Z", "AnZ", CurveType.Angle );
        public readonly AvfxCurve1Axis AXR = new( "Angle X Random", "AnXR", CurveType.Angle );
        public readonly AvfxCurve1Axis AYR = new( "Angle Y Random", "AnYR", CurveType.Angle );
        public readonly AvfxCurve1Axis AZR = new( "Angle Z Random", "AnZR", CurveType.Angle );
        public readonly AvfxCurve1Axis InjectionSpeed = new( "Injection Speed", "IjS" );
        public readonly AvfxCurve1Axis InjectionSpeedRandom = new( "Injection Speed Random", "IjSR" );

        public AvfxEmitterDataSphereModel() : base() {
            Parsed = [
                RotationOrderType,
                GenerateMethodType,
                DivideX,
                DivideY,
                DivideZ,//
                Radius,
                AX,//
                AY,
                AZ,
                AXR,
                AYR,
                AZR,
                InjectionSpeed,
                InjectionSpeedRandom
            ];

            ParameterTab.Add( RotationOrderType );
            ParameterTab.Add( GenerateMethodType );
            ParameterTab.Add( DivideX );
            ParameterTab.Add( DivideY );
            ParameterTab.Add( DivideZ );

            Tabs.Add( Radius );
            Tabs.Add( AX );//
            Tabs.Add( AY );
            Tabs.Add( AZ );
            Tabs.Add( AXR );
            Tabs.Add( AYR );
            Tabs.Add( AZR );
            Tabs.Add( InjectionSpeed );
            Tabs.Add( InjectionSpeedRandom );
        }
    }
}
