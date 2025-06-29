using System.Collections.Generic;
using System.IO;
using VfxEditor.AvfxFormat.Particle.Texture;
using VFXEditor.Formats.AvfxFormat.Curve;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxParticleTextureColor1 : AvfxParticleAttribute {
        public readonly AvfxBool Enabled = new( "Enabled", "bEna" );
        public readonly AvfxBool ColorToAlpha = new( "Color To Alpha", "bC2A" );
        public readonly AvfxBool UseScreenCopy = new( "Use Screen Copy", "bUSC" );
        public readonly AvfxBool PreviousFrameCopy = new( "Previous Frame Copy", "bPFC" );
        public readonly AvfxInt UvSetIdx = new( "UV Set Index", "UvSN" );
        public readonly AvfxEnum<TextureFilterType> TextureFilter = new( "Texture Filter", "TFT" );
        public readonly AvfxEnum<TextureBorderType> TextureBorderU = new( "Texture Border U", "TBUT" );
        public readonly AvfxEnum<TextureBorderType> TextureBorderV = new( "Texture Border V", "TBVT" );
        public readonly AvfxEnum<TextureCalculateColor> TextureCalculateColor = new( "Calculate Color", "TCCT" );
        public readonly AvfxEnum<TextureCalculateAlpha> TextureCalculateAlpha = new( "Calculate Alpha", "TCAT" );
        public readonly AvfxInt TextureIdx = new( "Texture Index", "TxNo", value: -1 );
        public readonly AvfxInt UOS = new ( "UOS", "bUOS" );
        public readonly AvfxIntList MaskTextureIdx = new( "Mask Index", "TLst", value: -1 );
        public readonly AvfxCurve1Axis TexN = new( "TexN", "TxN" );
        public readonly AvfxCurve1Axis TexNRandom = new( "TexN Random", "TxNR" );

        private readonly List<AvfxBase> Parsed;

        public AvfxParticleTextureColor1( AvfxParticle particle ) : base( "TC1", particle ) {
            InitNodeSelects();
            Display.Add( new TextureNodeSelectDraw( NodeSelects ) );

            Parsed = [
                Enabled,
                ColorToAlpha,
                UseScreenCopy,
                PreviousFrameCopy,
                UvSetIdx,
                TextureFilter,
                TextureBorderU,
                TextureBorderV,
                TextureCalculateColor,
                TextureCalculateAlpha,
                TextureIdx,
                UOS,
                MaskTextureIdx,
                TexN,
                TexNRandom
            ];

            Display.Add( Enabled );
            Display.Add( ColorToAlpha );
            Display.Add( UseScreenCopy );
            Display.Add( PreviousFrameCopy );
            Display.Add( UvSetIdx );
            Display.Add( TextureFilter );
            Display.Add( TextureBorderU );
            Display.Add( TextureBorderV );
            Display.Add( TextureCalculateColor );
            Display.Add( TextureCalculateAlpha );
            Display.Add( TextureIdx );
            Display.Add( UOS );
            Display.Add( MaskTextureIdx );
            DisplayTabs.Add( TexN );
            DisplayTabs.Add( TexNRandom );
        }

        public override void ReadContents( BinaryReader reader, int size ) {
            ReadNested( reader, Parsed, size );
            EnableAllSelectors();
        }

        public override void WriteContents( BinaryWriter writer ) => WriteNested( writer, Parsed );

        protected override IEnumerable<AvfxBase> GetChildren() {
            foreach( var item in Parsed ) yield return item;
        }

        public override void DrawBody() {
            DrawNamedItems( DisplayTabs );
        }

        public override string GetDefaultText() => "Texture Color 1";

        public override List<AvfxNodeSelect> GetNodeSelects() => [
            new AvfxNodeSelectList<AvfxTexture>( Particle, "Mask Texture", Particle.NodeGroups.Textures, MaskTextureIdx, 256 )
        ];
    }
}
