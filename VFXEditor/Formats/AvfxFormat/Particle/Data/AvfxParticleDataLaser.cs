using VFXEditor.Formats.AvfxFormat.Curve;
namespace VfxEditor.AvfxFormat {
    public class AvfxParticleDataLaser : AvfxData {
        public readonly AvfxCurve1Axis Length = new( "Length", "Len" );
        public readonly AvfxCurve1Axis Width = new( "Width", "Wdt" );
        public readonly AvfxCurve1Axis WidthRandom = new( "Width Random", "WdtR" );

        public AvfxParticleDataLaser() : base() {
            Parsed = [
                Length,
                Width,
                WidthRandom
            ];

            Tabs.Add( Width );
            Tabs.Add( Length );
            Tabs.Add( WidthRandom );
        }
    }
}
