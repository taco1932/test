using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxParticleDataModel : AvfxDataWithParameters {
        public readonly AvfxInt ModelNumberRandomValue = new( "Model Number Random", "MNRv" );
        public readonly AvfxEnum<RandomType> ModelNumberRandomType = new( "Model Number Random Type", "MNRt" );
        public readonly AvfxInt ModelNumberRandomInterval = new( "Model Number Random Interval", "MNRi" );
        public readonly AvfxEnum<FresnelType> FresnelType = new( "Fresnel Type", "FrsT" );
        public readonly AvfxEnum<DirectionalLightType> DirectionalLightType = new( "Directional Light Type", "DLT" );
        public readonly AvfxEnum<PointLightType> PointLightType = new( "Point Light Type", "PLT" );
        public readonly AvfxBool IsLighting = new( "Is Lighting", "bLgt" );
        public readonly AvfxBool IsMorph = new( "Is Morph", "bShp" );
        public AvfxIntList ModelIdx = new( "Model Index", "MdNo", value: -1 );
        public readonly AvfxCurve1Axis AnimationNumber = new( "Animation Number", "NoAn" );
        public readonly AvfxCurve1Axis Morph = new( "Morph", "Moph" );
        public readonly AvfxCurve1Axis FresnelCurve = new( "Fresnel Curve", "FrC" );
        public readonly AvfxCurve1Axis FresnelCurveRandom = new( "Fresnel Curve Random", "FrCR" );
        public readonly AvfxCurve3Axis FresnelRotation = new( "Fresnel Rotation", "FrRt", CurveType.Angle );
        public readonly AvfxCurveColor ColorBegin = new( name: "Color Begin", "ColB" );
        public readonly AvfxCurveColor ColorEnd = new( name: "Color End", "ColE" );

        public readonly AvfxNodeSelectList<AvfxModel> ModelSelect;

        public AvfxParticleDataModel( AvfxParticle particle ) : base() {
            Parsed = [
                ModelNumberRandomValue,
                ModelNumberRandomType,
                ModelNumberRandomInterval,
                FresnelType,
                DirectionalLightType,
                PointLightType,
                IsLighting,
                IsMorph,
                ModelIdx,
                AnimationNumber,
                Morph,
                FresnelCurve,
                FresnelCurveRandom,
                FresnelRotation,
                ColorBegin,
                ColorEnd
            ];

            ParameterTab.Add( ModelSelect = new AvfxNodeSelectList<AvfxModel>( particle, "Model", particle.NodeGroups.Models, ModelIdx, 8 ) );
            ParameterTab.Add( ModelNumberRandomValue );
            ParameterTab.Add( ModelNumberRandomType );
            ParameterTab.Add( ModelNumberRandomInterval );
            ParameterTab.Add( FresnelType );
            ParameterTab.Add( DirectionalLightType );
            ParameterTab.Add( PointLightType );
            ParameterTab.Add( IsLighting );
            ParameterTab.Add( IsMorph );

            Tabs.Add( Morph );
            Tabs.Add( FresnelCurve );
            Tabs.Add( FresnelCurveRandom );
            Tabs.Add( FresnelRotation );
            Tabs.Add( ColorBegin );
            Tabs.Add( ColorEnd );
            Tabs.Add( AnimationNumber );
        }

        public override void Enable() => ModelSelect.Enable();

        public override void Disable() => ModelSelect.Disable();
    }
}
