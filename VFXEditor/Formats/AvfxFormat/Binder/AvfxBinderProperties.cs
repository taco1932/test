using System.Collections.Generic;
using System.IO;
using VfxEditor.Formats.AvfxFormat.Binder;
using VfxEditor.Ui.Interfaces;
using VFXEditor.Formats.AvfxFormat.Curve;
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
            { 0, "[null]" },
            { 1, "Face, j_kao" },
            { 3, "Left hand weapon / SGE: first noulith front" },
            { 4, "Right hand weapon / SGE: first noulith middle" },
            { 5, "Weapon binder (main) / SGE: first noulith back" },
            { 6, "Right shoulder, j_sako_r" },
            { 7, "Left shoulder, j_sako_l" },
            { 8, "Right forearm, j_ude_b_r" },
            { 9, "Left forearm, j_ude_b_l" },
            { 10, "Right calves, j_asi_c_r" },
            { 11, "Left calves, j_asi_c_l" },
            { 16, "n_root, front of character" },
            { 25, "Head, front left" },
            { 26, "Head, front middle" },
            { 27, "Head, front right" },
            { 28, "Cervical, j_sebo_c" },
            { 29, "n_root, waist offset #1" },
            { 30, "Center of character, n_hara" },
            { 31, "Waist, j_kosi" },
            { 32, "Right hand, j_te_r" },
            { 33, "Left hand, j_te_l" },
            { 34, "Right foot, j_asi_d_r" },
            { 35, "Left foot, j_asi_d_l" },
            { 36, "Back-right foot, quadrupedal" },
            { 37, "Front-right foot, quadrupedal" },
            { 42, "n_root, above character" },
            { 43, "Head (near right eye)" },
            { 44, "Head (near left eye )" },
            //most n_root placements differ per race or are unused. these are accurate for c1501 only
            /*
            { 45, "n_root, above head" },
            { 46, "n_root, centre offset #2" },
            { 47, "n_root, centre offset #3" },
            { 48, "n_root, stomach" },
            { 49, "n_root, upper chest" },
            { 50, "n_root, crotch" },
            { 51, "n_root, shoulders front" },
            { 52, "n_root, front of chest" },
            { 53, "n_root, front of neck" },
            { 54, "n_root, front of stomach" },
            { 55, "n_root, front of crotch" },
            { 62, "n_root, weapon on back" },
            { 63, "n_root, lower chest" },
            { 64, "n_root, clavicles" },
            { 66, "n_root, back" },
            { 67, "n_root, upper legs" },
            { 68, "n_root, under chest" },
            { 70, "n_root, behind neck" },
            { 76, "n_root, neck" },
            { 81, "n_root, back of neck" },
            { 97, "n_root, above character offset #1" },
            { 98, "n_root, above character offset #2" },
            */
            { 65, "n_nameplate" },
            { 71, "True origin, n_root" },
            { 77, "Right-hand weapon, n_buki_r" },
            { 78, "Left-hand weapon. n_buki_l" },
            { 79, "n_mount #1" },
            { 89, "n_mount #2" },
            { 90, "n_mount #3" },
            { 91, "n_mount #4" },
            { 99, "n_mount #5" },
            { 100, "n_mount #6" },
            { 101, "n_mount #7" },
            { 102, "n_mount #8" },
            { 107, "n_throw" },
            { 108, "SGE: third noulith front / RPR avatar: neck" },
            { 109, "SGE: third noulith back / RPR avatar: spine" },
            { 110, "SGE: second noulith front / RPR avatar: left hand" },
            { 111, "SGE: second noulith back / RPR avatar: face" },
            { 112, "SGE: fourth noulith front / RPR avatar: n_root" },
            { 113, "SGE: fourth noulith back" },
            { 159, "Head, rotated left (except Roe, Hroth, Au Ra)" },
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
