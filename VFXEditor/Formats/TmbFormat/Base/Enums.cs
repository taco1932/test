using System;

namespace VfxEditor.TmbFormat.Base {
    #region Flags

    [Flags]
    public enum C010Unk2Flags {
        Unknown_1A = 0x01, //cfxf_battle_camera1
        Unknown_1B = 0x02,
        Unknown_1C = 0x04,
        Unknown_1D = 0x08,
        Unknown_1E = 0x10,
        Unknown_1F = 0x20,
        Unknown_1G = 0x40,
        Unknown_1H_Unused = 0x80
    }
    
    [Flags]
    public enum C010Unk3Flags {
        Unknown_2A = 0x01,
        Unknown_2B_Unused = 0x02,
        Unknown_2C_Unused = 0x04,
        Unknown_2D = 0x08,
        Unknown_2E = 0x10,
        Unknown_2F = 0x20,
        Unknown_2G_Unused = 0x40,
        Unknown_2H_Unused = 0x80
    }

    [Flags]
    public enum C012Extra {
        Allow_Triggers = 0x01,
        Override_Battle_FX_Setting = 0x02,
        Unknown = 0x04,
        Test1 = 0x08,
        Test2 = 0x10,
        Test3 = 0x20
    }

    [Flags]
    public enum C053Flags {
        Stop_on_Movement = 0x01,
        Use_Bind_Position = 0x02, //originally overlap sounds
        Unused_1 = 0x04,
        Unused_2 = 0x08,
        Unused_3 = 0x10,
        Unused_4 = 0x20,
        Unused_5 = 0x40,
        Unused_6 = 0x80,
    }

    [Flags]
    public enum C063Flags {
        Use_Min_Max_Range = 0x01,
        Stop_On_Animation_End = 0x02,
        Use_Bind_ID = 0x04,
        Unknown_0 = 0x08,
        Unknown_1 = 0x10,
        Unknown_2 = 0x20,
        Unknown_3 = 0x40,
        Unknown_4 = 0x80,
    }

    [Flags]
    public enum ObjectFlags {
        Character = 0x01,
        Weapon = 0x02,
        OffHand = 0x04,
        Summon = 0x08,
        Unused_A = 0x10,
        Unused_B = 0x20,
        Unused_C = 0x40,
        Unused_D = 0x80,
    }

    [Flags]
    public enum C165PoseFlags {
        Freeze_and_State = 0x01,
        Freeze_and_Delay_State = 0x02,
        Unknown_3 = 0x04,
        Unknown_4 = 0x08,
        Unknown_5 = 0x10,
        Unknown_6 = 0x20,
        Unknown_7 = 0x40,
        Unknown_8 = 0x80,
    }

    #endregion
    #region Enums

    public enum BindUser {
        Disabled = -1,
        Default,
        Caster,
        Target,
    }

    public enum BindType {
        Disabled = -1,
        Character,
        Weapon,
        Offhand,
        Summon_or_Lemure,
        //Summon_or_Lemure_1 = 4,
    }

    public enum AtchState {
        State_1,
        State_0,
        State_2,
        State_3,
        State_4,
        State_5,
    }

    public enum ObjectControl {
        Weapon_or_Pet,
        Offhand,
        Summon_or_Lemure_0,
        Summon_or_Lemure_1,
    }

    public enum C043Type {
        Invalid,
        Remove_Attribute,
        Apply_Attribute,
        Use_Internal_ID, //consumables
        Dead_Pose_Unknown = 5,
        Use_Weapon_ID = 8
    }

    public enum PhysicsType {
        All,
        Equipment,
        j_ex_wing, //Meteion
        Weapons,
        Hair,
        j_mune,
        Unused
    }

    public enum FreezePositionType {
        Target_FixedDirection,
        Target_UserFacingDirection,
        Return,
        Test_1,
        Test_2
    }

    public enum AccessoryType {
        Earrings,
        Neck,
        Wrist,
        Right_Ring,
        Left_Ring
        //Earrrings = 5 (again)
    }

    public enum ObjectControlFinal {
        State_1,
        State_0,
        State_2,
        State_3,
        State_4,
        State_5,
        Original
    }

    public enum C187ObjectControl {
        Summon_0,
        Weapon,
        Offhand,
        Unused_1,
        Unused_2
    }

    public enum SummonId {
        Summon_0,
        Summon_1,
    }
    public enum C198AtchState {
        Default, //basically just state 1
        State_0,
        State_1,
        State_2,
        State_3,
        State_4,
        State_5,
    }

    public enum SubtitleType {
        BattleTalk_Window,
        Bordered_Plaintext,
        Test1,
        Test2,
        Test3,
        Test4
    }

    public enum C053Bank {
        //sort of just documenting how they correlate for now
        Invalid,
        Skill_Unknown,
        u2,
        u3,
        u4,
        u5,
        u6,
        u7,
        u8,
        u9,
        u10,
        u11,
        u12,
        AirMount_Half_Speed_Idle_or_MountDive,
        u14,
        AirMount_Full_Speed,
        u16,
        Auto_Attack_Move_or_AirMount_Walk,
        Weapon_Draw_or_AirMount_Run,
        Weapon_Sheathe_or_Mount_Move,
        Parry_or_Mount_Move,
        Block_or_Mount_Move,
        Weapon_Unknown,
        BTN_MIN_MainWeapon,
        Mount_Jump,
        u25,
        Unvoiced_Fall,
        Dead_Fall,
        Combat_Voice_Low_Freq,
        Fall_or_LandMount_Jump,
        Dead_Voice_or_Mount_Idle,
        Combat_Voice_High_Freq,
        u32,
        u33,
        u34,
        u35,
        u36,
        u37,
        u38,
        surprised,
        angry,
        furious,
        cheer,
        doze,
        fume,
        huh,
        chuckle,
        laugh,
        no,
        stretch,
        upset,
        yes,
        happy,
        UnkEmote1,
        UnkEmote2
        //55+ seem to be unused, but need to double check
    }
    #endregion
}