using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxParticleDataPowder : AvfxDataWithParameters {
        public readonly AvfxBool bMV = new( "Use Character Movement", "bMV" );
        public readonly AvfxBool bLoc = new( "Use Character Location", "bLoc" );
        public readonly AvfxBool IsLightning = new( "Use Lighting", "bLgt" );
        public readonly AvfxEnum<DirectionalLightType> DirectionalLightType = new( "Directional Light Type", "LgtT" );
        public readonly AvfxFloat CenterOffset = new( "Center Offset", "CnOf" );

        public AvfxParticleDataPowder() : base() {
            Parsed = [
                bMV,
                bLoc,
                IsLightning,
                DirectionalLightType,
                CenterOffset
            ];

            ParameterTab.Add( bMV );
            ParameterTab.Add( bLoc );
            ParameterTab.Add( DirectionalLightType );
            ParameterTab.Add( IsLightning );
            ParameterTab.Add( CenterOffset );
        }
    }
}
