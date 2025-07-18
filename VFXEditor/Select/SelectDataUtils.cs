using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using VfxEditor.Select.Data;

namespace VfxEditor.Select {
    public partial class SelectDataUtils {
        public static string BnpcPath => Path.Combine( Plugin.RootLocation, "Files", "bnpc.json" );
        public static string NpcFilesPath => Path.Combine( Plugin.RootLocation, "Files", "npc_files.json" );
        public static string CommonVfxPath => Path.Combine( Plugin.RootLocation, "Files", "common_vfx" );
        public static string CommonTmbPath => Path.Combine( Plugin.RootLocation, "Files", "common_tmb" );
        public static string ExtraTmbPath => Path.Combine( Plugin.RootLocation, "Files", "extraskills_tmb" );
        public static string CommonUldPath => Path.Combine( Plugin.RootLocation, "Files", "common_uld" );
        public static string CommonShpkPath => Path.Combine( Plugin.RootLocation, "Files", "common_shpk" );
        public static string CommonShcdPath => Path.Combine( Plugin.RootLocation, "Files", "common_shcd" );
        public static string CommonRacialPath => Path.Combine( Plugin.RootLocation, "Files", "common_racial" );
        public static string CommonPapPath => Path.Combine( Plugin.RootLocation, "Files", "common_pap" );

        [GeneratedRegex( "\\u0000([a-zA-Z0-9\\/_]*?)\\.avfx", RegexOptions.Compiled )]
        private static partial Regex AvfxRegexPattern();
        public static readonly Regex AvfxRegex = AvfxRegexPattern();

        [GeneratedRegex( "\\u0000([a-zA-Z0-9\\/_]*?)\\.scd", RegexOptions.Compiled )]
        private static partial Regex ScdRegexPattern();
        public static readonly Regex ScdRegex = ScdRegexPattern();

        [GeneratedRegex( "\\u0000([a-zA-Z0-9\\/_]*?)\\.sgb", RegexOptions.Compiled )]
        private static partial Regex SgbRegexPattern();
        public static readonly Regex SgbRegex = SgbRegexPattern();

        // https://github.com/imchillin/CMTool/blob/master/ConceptMatrix/Views/SpecialControl.xaml.cs#L365

        public static readonly List<RacialData> CharacterRaces = [
            new RacialData( "Midlander M", "c0101", 0 ),
            new RacialData( "Midlander F","c0201", 1 ),
            new RacialData( "Highlander M", "c0301", 2 ),
            new RacialData( "Highlander F", "c0401", 3 ),
            new RacialData( "Elezen M", "c0501", 4 ),
            new RacialData( "Elezen F", "c0601", 5 ),
            new RacialData( "Miqo'te M", "c0701", 12 ),
            new RacialData( "Miqo'te F", "c0801", 13 ),
            new RacialData( "Roegadyn M", "c0901", 16 ),
            new RacialData( "Roegadyn F", "c1001", 17 ),
            new RacialData( "Lalafell M", "c1101",8 ),
            new RacialData( "Lalafell F", "c1201", 9 ),
            new RacialData( "Au Ra M", "c1301", 20 ),
            new RacialData( "Au Ra F", "c1401", 21 ),
            new RacialData( "Hrothgar M", "c1501", 24 ),
            new RacialData( "Hrothgar F", "c1601", 25 ),
            new RacialData( "Viera M", "c1701", 28 ),
            new RacialData( "Viera F", "c1801", 29 )
        ];

        public static readonly Dictionary<string, string> JobAnimationIds = new() {
            { "Warrior", "bt_2ax_emp" },
            { "Paladin", "bt_swd_sld" },
            { "Gunbreaker", "bt_2gb_emp" },
            { "Dark Knight", "bt_2sw_emp" },
            { "Astrologian", "bt_2gl_emp" },
            { "Sage", "bt_2ff_emp" },
            { "Scholar", "bt_2bk_emp" },
            { "White Mage", "bt_stf_sld" },
            { "Machinist", "bt_2gn_emp" },
            { "Dancer", "bt_chk_chk" },
            { "Bard", "bt_2bw_emp" },
            { "Samurai", "bt_2kt_emp" },
            { "Dragoon", "bt_2sp_emp" },
            { "Monk", "bt_clw_clw" },
            { "Ninja", "bt_dgr_dgr" },
            { "Reaper", "bt_2km_emp" },
            { "Red Mage", "bt_2rp_emp" },
            { "Black Mage", "bt_jst_sld" },
            { "Summoner", "bt_2bk_emp" },
            { "Blue Mage", "bt_rod_emp" },
            { "Pictomancer", "bt_brs_plt" },
            { "Viper", "bt_bld_bld" },
        };

        public static readonly Dictionary<string, string> JobMovementOverride = new() {
            { "Black Mage", "bt_stf_sld" },
            { "Ninja", "bt_nin_nin" },
        };

        public static readonly Dictionary<string, string> JobDrawOverride = new() {
            { "Black Mage", "bt_stf_sld" }
        };

        public static readonly Dictionary<string, string> JobAutoOverride = new() {
            { "Black Mage", "bt_stf_sld" }
        };

        public static readonly int MaxChangePoses = 6;

        public static Dictionary<string, string> FileExistsFilter( Dictionary<string, string> dict ) => dict.Where( x => Dalamud.DataManager.FileExists( x.Value ) ).ToDictionary( x => x.Key, x => x.Value );

        public static string GetSkeletonPath( string skeletonId, string path ) => $"chara/human/{skeletonId}/animation/a0001/{path}";

        public static Dictionary<string, string> GetAllSkeletonPaths( string path ) {
            if( string.IsNullOrEmpty( path ) ) return [];
            return CharacterRaces.ToDictionary( x => x.Name, x => GetSkeletonPath( x.Id, path ) );
        }
    }
}
