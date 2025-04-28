using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxEmitterDataModel : AvfxDataWithParameters {
        public readonly AvfxInt ModelIdx = new( "Model Index", "MdNo", value: -1 );
        public readonly AvfxEnum<RotationOrder> RotationOrderType = new( "Rotation Order", "ROT" );
        public readonly AvfxEnum<GenerateMethod> GenerateMethodType = new( "Generate Method", "GeMT" );
        public readonly AvfxCurve1Axis AX = new( "Angle X", "AnX", CurveType.Angle );
        public readonly AvfxCurve1Axis AY = new( "Angle Y", "AnY", CurveType.Angle );
        public readonly AvfxCurve1Axis AZ = new( "Angle Z", "AnZ", CurveType.Angle );
        public readonly AvfxCurve1Axis AXR = new( "[TEST] Angle X Random", "AnXR", CurveType.Angle );
        public readonly AvfxCurve1Axis AYR = new( "[TEST] Angle Y Random", "AnYR", CurveType.Angle );
        public readonly AvfxCurve1Axis AZR = new( "[TEST] Angle Z Random", "AnZR", CurveType.Angle );
        public readonly AvfxCurve1Axis InjectionSpeed = new( "Injection Speed", "IjS" );
        public readonly AvfxCurve1Axis InjectionSpeedRandom = new( "Injection Speed Random", "IjSR" );
        public readonly AvfxCurve1Axis InjectionAngle = new( "[TEST] Injection Angle", "IjA" );
        public readonly AvfxCurve1Axis InjectionAngleRandom = new( "[TEST] Injection Angle Random", "IjAR" );

        public readonly AvfxNodeSelect<AvfxModel> ModelSelect;

        public AvfxEmitterDataModel( AvfxEmitter emitter ) : base() {
            Parsed = [
                ModelIdx,
                RotationOrderType,
                GenerateMethodType,
                AX,
                AY,
                AZ,
                AXR,
                AYR,
                AZR,
                InjectionSpeed,
                InjectionSpeedRandom,
                InjectionAngle,
                InjectionAngleRandom
            ];

            ParameterTab.Add( ModelSelect = new AvfxNodeSelect<AvfxModel>( emitter, "Model", emitter.NodeGroups.Models, ModelIdx ) );
            ParameterTab.Add( RotationOrderType );
            ParameterTab.Add( GenerateMethodType );

            Tabs.Add( AX );
            Tabs.Add( AY );
            Tabs.Add( AZ );
            Tabs.Add( AXR );
            Tabs.Add( AYR );
            Tabs.Add( AZR );
            Tabs.Add( InjectionSpeed );
            Tabs.Add( InjectionSpeedRandom );
            Tabs.Add( InjectionAngle );
            Tabs.Add( InjectionAngleRandom );
        }

        public override void Enable() {
            ModelSelect.Enable();
        }

        public override void Disable() {
            ModelSelect.Disable();
        }
    }
}
