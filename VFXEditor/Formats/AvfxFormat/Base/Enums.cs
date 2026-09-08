using System;

namespace VfxEditor.AvfxFormat {
    public class Enums {
        [Flags]
        public enum DrawLayer {
            Screen = 0,
            BaseUpper = 1,
            Base = 2,
            BaseLower = 3,
            InWater = 4,
            BeforeCloud = 5,
            BehindCloud = 6,
            BeforeSky = 7,
            PostUI = 8,
            PrevUI = 9,
            FitWater = 10,
            Max = 11,
            Test1 = 12,
            Test2 = 13,
            Test3 = 14,
            Test4 = 15,
        }
        public enum DirectionalLightSource {
            None = 0,
            InLocal = 1,
            InGame = 2,
            Max = 3
        }
        public enum DrawOrder {
            Default = 0,
            Reverse = 1,
            Depth = 2,
            Max = 3
        }
        public enum PointLightSouce {
            None = 0,
            CreateTimeBG = 1,
            AlwaysBG = 2,
            LocalVFX = 3,
            GlobalVFX = 4,
            Max = 5
        }
        /*
         * PARTICLE
         */
        public enum ParticleType {
            Parameter = 0,
            Powder = 1,
            Windmill = 2,
            Line = 3,
            Laser = 4,
            Model = 5,
            Polyline = 6,
            Reserve0 = 7,
            Quad = 8,
            Polygon = 9,
            Decal = 10,
            DecalRing = 11,
            Disc = 12,
            LightModel = 13,
            ModelSkin = 14,
            Dissolve = 15,
        }
        public enum RotationDirectionBase {
            X = 0,
            Y = 1,
            Z = 2,
            MoveDirection = 3,
            BillboardAxisY = 4,
            ScreenBillboard = 5,
            CameraBillboard = 6,
            MoveDirectionBillboard = 7,
            CameraBillboardAxisY = 8,
            TreeBillboard = 9,
            None = 10
        }
        public enum RotationOrder {
            XYZ = 0,
            YZX = 1,
            ZXY = 2,
            XZY = 3,
            YXZ = 4,
            ZYX = 5
        }
        public enum CoordComputeOrder {
            Scale_Rot_Translate = 0,
            Translate_Scale_Rot = 1,
            Rot_Translate_Scale = 2,
            Translate_Rot_Scale = 3,
            Scale_Translate_Rot = 4,
            Rot_Scale_Translate = 5
        }
        public enum DrawMode {
            Blend = 0,
            Multiply = 1,
            Add = 2,
            Subtract = 3,
            Screen = 4,
            Reverse = 5,
            Min = 6,
            Max = 7,
            Opacity = 8,
            Unknown_Multiply_9 = 9,
            Unknown_Add_10 = 10,
            Unknown_Subtract_11 = 11,
            Unknown_Screen_12 = 12,
        }
        public enum CullingType {
            None = 0,
            Front = 1,
            Back = 2,
            Double = 3,
            Max = 4
        }
        public enum EnvLight {
            Chara = 0,
            Background = 1,
            Max = 2
        }
        public enum DirLight {
            Directional = 0,
            EnvSet = 1,
            Max = 2
        }
        public enum UvPrecision {
            High = 0,
            Medium = 1,
            Low = 2,
            Max = 3
        }
        public enum DepthOffsetType {
            Legacy = 0,
            FixedIntervalNDC = 1
        }
        public enum ClipBasePoint
        {
            Camera = 0,
            Caster = 1
        }
        public enum RandomType {
            FirstPlusMinus = 0,
            FirstPlus = 1,
            FirstMinus = 2,
            AlwaysPlusMinus = 3,
            AlwaysPlus = 4,
            AlwaysMinus = 5
        }
        public enum TextureCalculateUV {
            ByParameter = 0,
            ByPixelPosition = 1
        }
        public enum DirectionalLightType {
            Lambert = 0,
            HalfLambert = 1,
            Ex = 2
        }
        public enum LineCreateType {
            AxisOrder = 0,
            PositionHistory = 1
        }
        public enum NotBillboardBaseAxisType {
            X = 0,
            Y = 1,
            Z = 2
        }
        public enum FresnelType {
            None = 0,
            Camera = 1,
            AnyAxis = 2,
            AnyAxisWithWorldRotation = 3,
            Test1 = 4,
            Test2 = 5,
            Test3 = 6,
            Test4 = 7
        }
        public enum PointLightType {
            Lambert = 0,
            HalfLambert = 1,
            Area = 2,
            Ex = 3,
            Test1 = 4,
            Test2 = 5
        }
        public enum TextureFilterType {
            Disable = 0,
            Enable = 1,
            High = 2,
            VeryHigh = 3,
            VeryVeryHigh = 4
        }
        public enum TextureBorderType {
            Repeat = 0,
            Clamp = 1,
            Mirror = 2
        }
        public enum TextureCalculateColor {
            Multiply = 0,
            Add = 1,
            Subtract = 2,
            Max = 3,
            Min = 4,
            Unknown = 5, //none
            Test1 = 6,
            Test2 = 7
        }
        public enum TextureCalculateAlpha {
            Multiply = 0,
            Max = 1,
            Min = 2,
            None = 3
        }
        /* Emitter */
        public enum EmitterType {
            Point = 0,
            Cone = 1,
            ConeModel = 2,
            SphereModel = 3,
            CylinderModel = 4,
            Model = 5,
            Unknown = 6 //DNE?
        }
        public enum GenerateMethod {
            RandomToVertex = 0,
            OrderToVertex = 1,
            RandomOnVertex = 2,
            OrderOnVertex = 3,
            RandomToVertexWithoutSingularPoint = 4,
            OrderToVertexWithoutSingularPoint = 5,
            RandomOnVertexWithoutSingularPoint = 6,
            OrderOnVertexWithoutSingularPoint = 7,
            Test1 = 8,
            Test2 = 9
        }
        public enum WindmillUVType {
            Default = 0,
            Mirror = 1,
            Test1 = 2,
            Test2 = 3,
        }

        public enum CreateTimeOptions {
            Emitter_Animation = 0,
            Create_Settings = 1,
            Unknown1 = 2,
            Test1 = 3,
            Test2 = 4
        }
        public enum ParentInfluenceCoordOptions {
            InitialPosition = 0,
            // Uses the initial position regardless. Options control always
            InitialPosition_WithOptions = 1,
            AllAlways = 2,
            AllInitial = 3,
            AllAlways_NoPosition = 4,
            AllInitial_NoPosition = 5,
            None = 6,
            WithOptions_NoPosition = 7,
            Unknown = 8,
            Unknown_NoPosition = 9,
            Test1 = 10,
            Test2 = 11,
            Test3 = 12,
            Test4 = 13,
        }

        public enum ParentInfluenceColorOptions {
            None = 0,
            Initial = 1,
            Always = 2,
            Test1 = 3,
            Test2 = 4,
            Test3 = 5,
            Test4 = 6
        }
        /* BINDERS */
        public enum BinderRotation {
            Standard = 0,
            Billboard = 1,
            BillboardAxisY = 2,
            LookAtCamera = 3,
            CameraBillboardAxisY = 4,
            Test1 = 5,
            Test2 = 6,
            Test3 = 7,
            Test4 = 8
        }
        public enum BinderType {
            Point = 0,
            Linear = 1,
            Spline = 2,
            Camera = 3,
            LinearAdjust = 4,
        }
        public enum BindPoint {
            Caster = 0,
            Target = 1,
            Test1 = 2,
            Test2 = 3,
            Test3 = 4,
            Test4 = 5
        }
        public enum BindTargetPoint {
            Origin = 0,
            FitGround = 1,
            DamageCircle = 2,
            ByName = 3,
            Test1 = 4,
            Test2 = 5,
        }
        /* EFFECTOR */
        public enum EffectorType {
            PointLight = 0,
            DirectionalLight = 1,
            Reserve1 = 2,
            ChromaticAberration = 3,
            GaussianBlur = 4,
            DirectionalBlur = 5,
            CameraQuake_Variable = 6, //case 6 in source code is blank, leads right into case 9
            RadialBlur = 7,
            BlackHole = 8, //case 8 exists and has a table, but unsure what it's doing
            CameraQuake = 9
        }
        public enum PointLightAttenuation {
            Linear = 0,
            Quadratic = 1,
            Cubic = 2,
            Max = 3
        }
        /* CURVE */
        public enum CurveBehavior {
            Const = 0,
            Repeat = 1,
            Add = 2,
            None = -1 // NOTE: so far only seen with CrC
        }
        public enum KeyType {
            Spline = 0,
            Linear = 1,
            Step = 2
        }
        public enum AxisConnect2 {
            None = 0,
            X_Y = 1,
            Y_X = 2
        }
        public enum AxisConnect3
        {
            None = 0,
            X_YZ = 1,
            X_Y = 2,
            X_Z = 3,
            Y_XZ = 4,
            Y_X = 5,
            Y_Z = 6,
            Z_XY = 7,
            Z_X = 8,
            Z_Y = 9
        }

        public enum DissolveShape {
            Auto = 0,
            Rectangular_Prism = 1,
            Sphere = 2,
            Cylinder = 3,
            Test1 = 4,
            Test2 = 5,
            Test3 = 6,
        }

        [Flags]
        public enum AuraFilter
        {
            Character = 0x01,
            Weapon = 0x02,
            Off_Hand = 0x04,
            Summon = 0x08,
            BG_Object = 0x10,
            Test1 = 0x20, //seems to disable character aura
            Test2 = 0x40,
            Test3 = 0x80
        }
    }
}
