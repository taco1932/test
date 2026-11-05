using System;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Flag;
using VfxEditor.Parsing.Float;
using VfxEditor.Parsing.Int;
using VfxEditor.Parsing.Reserve;

namespace VfxEditor.Formats.ScdFormat.Layout.Data {
    [Flags]
    public enum PointEnvironmentFlags {
        PointEnvFlag_Test_x01 = 0x01,
        PointEnvFlag_Test_x02 = 0x02,
        PointEnvFlag_Test_x04 = 0x04,
        PointEnvFlag_Test_x08 = 0x08,
        PointEnvFlag_Test_x10 = 0x10,
        PointEnvFlag_Test_x20 = 0x20,
        Use_Env_Filter_Depth = 0x40,
        Is_FireWorks = 0x80
    }

    [Flags]
    public enum PointFlags {
        PointFlag_Test_x01 = 0x01,
        PointFlag_Test_x02 = 0x02,
        PointFlag_Test_x04 = 0x04,
        PointFlag_Test_x08 = 0x08,
        PointFlag_Test_x10 = 0x10,
        PointFlag_Test_x20 = 0x20,
        Is_Reverb_Object = 0x40,
        Is_Whiz_Generate = 0x80
    }

    public class LayoutPointData : ScdLayoutData {
        public readonly ParsedFloat4 Position = new( "Position" );
        public readonly ParsedFloat MaxRange = new( "Max Range" );
        public readonly ParsedFloat MinRange = new( "Min Range" );
        public readonly ParsedFloat2 Height = new( "Height" );
        public readonly ParsedFloat RangeVolume = new( "Range Volume" );
        public readonly ParsedFloat Volume = new( "Volume" );
        public readonly ParsedFloat Pitch = new( "Pitch" );
        public readonly ParsedFloat ReverbFac = new( "Reverb FAC" );
        public readonly ParsedFloat DopplerFac = new( "Doppler FAC" );
        public readonly ParsedFloat CenterFac = new( "Center FAC" );
        public readonly ParsedFloat InteriorFac = new( "Interior FAC" );
        public readonly ParsedFloat Direction = new( "Direction" );
        public readonly ParsedFloat NearFadeStart = new( "Near Fade Start" );
        public readonly ParsedFloat NearFadeEnd = new( "Near Fade End" );
        public readonly ParsedFloat FarDelayFac = new( "Far Delay FAC" );
        public readonly ParsedFlag<PointEnvironmentFlags> Environment = new( "Environment", size: 1 );
        public readonly ParsedFlag<PointFlags> Flag = new( "Flag", size: 1 );
        public readonly ParsedShort Reserved1 = new( "Reserve 1" );
        public readonly ParsedFloat LowerLimit = new( "Lower Limit" );
        public readonly ParsedShort FadeInTime = new( "Fade In Time" );
        public readonly ParsedShort FadeOutTime = new( "Fade Out Time" );
        public readonly ParsedFloat ConvergenceFac = new( "Convergence FAC" );
        public readonly ParsedInt Reserved2 = new( "Reserve 2" );

        public LayoutPointData() {
            Parsed = [
                Position,
                MaxRange,
                MinRange,
                Height,
                RangeVolume,
                Volume,
                Pitch,
                ReverbFac,
                DopplerFac,
                CenterFac,
                InteriorFac,
                Direction,
                NearFadeStart,
                NearFadeEnd,
                FarDelayFac,
                Environment,
                Flag,
                Reserved1,
                LowerLimit,
                FadeInTime,
                FadeOutTime,
                ConvergenceFac,
                Reserved2
            ];
        }
    }
}
