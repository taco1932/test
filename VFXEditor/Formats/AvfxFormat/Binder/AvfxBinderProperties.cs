using System.Collections.Generic;
using System.IO;
using VfxEditor.Formats.AvfxFormat.Binder;
using VfxEditor.Ui.Interfaces;
using static VfxEditor.AvfxFormat.Enums;

namespace VfxEditor.AvfxFormat {
    public class AvfxBinderProperties : AvfxOptional {
        public readonly string Name;

        public readonly AvfxEnum<BindPoint> BindPointType = new( "Bind Point Type", "BPT" );
        public readonly AvfxEnum<BindTargetPoint> BindTargetPointType = new( "Bind Target Point Type", "BPTP", value: BindTargetPoint.ByName );
        public readonly AvfxBinderPropertiesName BinderName = new();
        public readonly AvfxInt BindPointId = new( "Bind Point Id", "BPID", value: 3 );
        public readonly AvfxInt GenerateDelay = new( "Generate Delay", "GenD" );
        public readonly AvfxInt CoordUpdateFrame = new( "Coord Update Frame", "CoUF", value: -1 );
        public readonly AvfxBool RingEnable = new( "Ring Enabled", "bRng" );
        public readonly AvfxInt RingProgressTime = new( "Ring Progress Time", "RnPT", value: 1 );
        public readonly AvfxFloat RingPositionX = new( "Ring Position X", "RnPX" );
        public readonly AvfxFloat RingPositionY = new( "Ring Position Y", "RnPY" );
        public readonly AvfxFloat RingPositionZ = new( "Ring Position Z", "RnPZ" );
        public readonly AvfxFloat RingRadius = new( "Ring Radius", "RnRd" );
        public readonly AvfxInt BCT = new( "BCT", "BCT" );
        public readonly AvfxCurve3Axis Position = new( "Position", "Pos", locked: true );

        private readonly List<AvfxBase> Parsed;

        private readonly UiDisplayList Parameters;
        private readonly List<INamedUiItem> DisplayTabs;

        private static readonly Dictionary<int, string> BinderIds = new() {
            { 0, "n_root" },
            { 1, "Head" },
            { 3, "Left hand weapon / SGE: first noulith front" },
            { 4, "Right hand weapon / SGE: first noulith middle" },
            { 5, "Weapon binder (main) / SGE: first noulith back" },
            { 6, "Right shoulder" },
            { 7, "Left shoulder" },
            { 8, "Right forearm" },
            { 9, "Left forearm" },
            { 10, "Right calves" },
            { 11, "Left calves" },
            { 16, "Front of character" },
            { 25, "Head, front left" },
            { 26, "Head, front middle" },
            { 27, "Head, front right" },
            { 28, "Cervical" },
            { 29, "Center of the character, static n_root" },
            { 30, "Center of the character, n_hara" },
            { 31, "Waist, j_kosi" },
            { 32, "Right hand" },
            { 33, "Left hand" },
            { 34, "Right foot" },
            { 35, "Left foot" },
            { 36, "Back-right foot, quadrupedal" },
            { 37, "Front-right foot, quadrupedal" },
            { 42, "Above character, static n_root" },
            { 43, "Head (near right eye)" },
            { 44, "Head (near left eye )" },
            { 77, "Right-hand weapon, n_buki_r" },
            { 78, "Left-hand weapon. n_buki_l" },
            { 108, "SGE: third noulith front / RPR avatar: neck" },
            { 109, "SGE: third noulith back / RPR avatar: spine" },
            { 110, "SGE: second noulith front / RPR avatar: left hand" },
            { 111, "SGE: second noulith back / RPR avatar: face" },
            { 112, "SGE: fourth noulith front / RPR avatar: n_root" },
            { 113, "SGE: fourth noulith back" },
        };

        public AvfxBinderProperties( string name, string avfxName ) : base( avfxName ) {
            Name = name;

            Parsed = [
                BindPointType,
                BindTargetPointType,
                BinderName,
                BindPointId,
                GenerateDelay,
                CoordUpdateFrame,
                RingEnable,
                RingProgressTime,
                RingPositionX,
                RingPositionY,
                RingPositionZ,
                RingRadius,
                BCT,
                Position
            ];
            BinderName.SetAssigned( false );
            Position.SetAssigned( true );

            DisplayTabs = [
                ( Parameters = new UiDisplayList( "Parameters" ) ),
                Position
            ];

            Parameters.AddRange( [
                BindPointType,
                BindTargetPointType,
                BinderName,
                new UiIntCombo( "Bind Point Id", BindPointId, BinderIds ),
                GenerateDelay,
                CoordUpdateFrame,
                RingEnable,
                RingProgressTime,
                new UiFloat3( "Ring Position", RingPositionX, RingPositionY, RingPositionZ ),
                RingRadius,
                BCT
            ] );
        }

        public override void ReadContents( BinaryReader reader, int size ) => ReadNested( reader, Parsed, size );

        public override void WriteContents( BinaryWriter writer ) => WriteNested( writer, Parsed );

        protected override IEnumerable<AvfxBase> GetChildren() {
            foreach( var item in Parsed ) yield return item;
        }
        
        public override void DrawBody() {
            DrawNamedItems( DisplayTabs );
        }

        public override string GetDefaultText() => Name;
    }
}
