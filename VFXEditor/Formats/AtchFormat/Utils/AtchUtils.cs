using System.Collections.Generic;

namespace VfxEditor.AtchFormat.Utils {

    public class AtchUtils {
        public static readonly Dictionary<string, string> WeaponNames = new() {
            { "2ax", "WAR greataxe" },
            { "2bk", "SCH codex / SMN grimoire" },
            { "2bw", "BRD bow" },
            { "2ff", "SGE nouliths" }, //can show up twice if it's called as a summon
            { "2gb", "GNB gunblade" },
            { "2gl", "AST planisphere" },
            { "2gn", "MCH gun" },
            { "2km", "RPR scythe" },
            { "2kt", "SAM katana" },
            // { "2kz", "" }, // new
            { "2rp", "RDM rapier" },
            { "2sp", "DRG spear" },
            { "2st", "WHM/BLM staff" },
            { "2sw", "DRK greatsword" },
            { "aai", "" },
            { "aal", "" },
            { "aar", "" },
            { "abl", "" },
            { "aco", "" },
            { "agl", "" },
            { "ali", "ALC alembic" },
            { "alm", "" },
            { "alt", "" },
            { "ase", "" },
            { "atr", "n_throw summons (some)" }, //MCH LB, /magictrick dove
            { "avt", "RPR shroud" }, //list is all n_throw
            { "awo", "" },
            { "bag", "MCH aetherotransformer" },
            { "bl2", "VPR off-hand" },
            { "bld", "VPR main hand" },
            { "bll", "" }, //VPR?
            { "brs", "PCT brush" },
            { "chk", "DNC chakrams" },
            // { "clb", "" }, // DNE
            { "clg", "" },
            { "cls", "" },
            { "clw", "MNK fists" },
            // { "col", "" },
            // { "cor", "" },
            // { "cos", "" },
            { "crd", "" },
            { "crr", "AST card" },
            // { "crt", "" },
            { "csl", "CRP chisel" },
            { "csr", "Crafting off-hand (held)" }, //CRP/LTW hammer / CUL knife / ARM pliers / BSM file / GSM/WVR [hidden]
            { "dgr", "NIN daggers" },
            { "drm", "BRD drum [performance]" },
            { "ebz", "Diadem cannon" },
            // { "egp", "" },
            { "elg", "BRD electric guitar [performance]" },
            { "fcb", "/fryegg" },
            // { "fch", "" },
            { "fdr", "Consumable & /sundering sword" }, //food and drink, but why the sword
            { "fha", "FSH gig" },
            { "fl2", "BRD flute [performance]" },
            // { "flc", "" }, // new
            { "flt", "BRD flute [combat]" },
            { "frg", "NIN frog summon" },
            { "fry", "LTW knife / CUL pan" },
            // { "fsb", "" }, // new
            { "fsh", "FSH rod" },
            { "fsw", "" },
            { "fud", "Mop/brush" }, // paint[colour] + sigmascape v2
            // { "gdb", "" },
            { "gdh", "Emote summon (hand)" }, //water, allsaintscharm, littleladiesdance, uchiwasshoi
            { "gdl", "Emote summon (left hand)" }, //sweep, balloons
            { "gdr", "Emote summon (right hand)" }, //tomescroll, shakedrink
            // { "gdt", "" },
            // { "gdw", "" },
            { "gsl", "MCH wrench" },
            { "gsr", "" }, // Diadem cannon?
            // { "gun", "" },
            // { "hel", "" },
            { "hmm", "BSM/ARM hammer" },
            { "hrp", "BRD harp" },
            { "htc", "BTN hatchet" },
            { "ksh", "SAM katana sheath" },
            // { "let", "" },
            { "lpr", "Loporitt ears (/earwiggle)" },
            { "mlt", "GSM mallet" },
            { "mmc", "MCH quad cannons" }, //full metal field
            { "mrb", "ALC mortar" }, //硏槽
            { "mrh", "ALC disk" }, //藥碾子
            { "msg", "MCH shotgun" },
            { "mwp", "MCH cannon" },
            { "ndl", "WVR needle" },
            { "nik", "[Nier pod?]" }, // Linked to Nier pod, maybe Nikana or something
            // { "njd", "" }, // new
            { "nph", "MIN sledgehammer" }, //btn?
            { "orb", "RDM focus" },
            // { "oum", "" },
            { "pen", "SCH/SMN quill" },
            { "pic", "MIN pick" },
            { "plt", "PCT palette" },
            // { "pra", "" },
            { "prc", "Camera (/photograph)" }, //1952
            { "prf", "LTW awl" },
            { "qvr", "BRD quiver" },
            // { "rap", "" },
            { "rbt", "NIN rabbit" },
            // { "rec", "" }, // new
            { "rod", "BLU rod" },
            // { "rop", "" },
            { "rp1", "PCT hammer" },
            { "saw", "CRP saw" },
            { "sbt", "/blowbubbles," }, //, 1955 (quill+notebook)
            // { "sht", "" },
            { "sic", "BTN sickle" },
            { "sld", "PLD/CNJ shield" },
            { "stf", "CNJ one-hand" },
            { "stv", "ALC stove" },
            { "swd", "PLD sword" },
            // { "sxs", "" }, // new
            // { "sxw", "" }, // new
            { "syl", "School book (/reference)" },
            // { "syr", "" },
            { "syu", "NIN shuriken" },
            { "syw", "PCT LB spriggan / SCH faerie summon" }, //1943, 1947
            // { "tan", "" },
            { "tbl", "Crafting tables/surfaces" }, //incl CUL stove
            { "tcs", "Teacup (/tea)" },
            { "tgn", "GSM nail" },
            { "tmb", "WVR frame" },
            { "tms", "Bouquet (/bouquet) / tomestone (/visage)" }, //1949, 1944
            { "trm", "BRD trumpet [performance]" },
            { "trr", "SCH LB summon" }, //9101
            { "trw", "" }, //n_throw?
            // { "tsl", "" }, // new
            // { "ulw", "" }, // new, 7.3
            // { "uni", "" }, // new
            { "vln", "BRD violin" }, //radiant finale
            { "wdm", "Tankard (/toast)" },
            { "whl", "" },
            // { "wng", "" },
            { "ypd", "NiER pod" }, //specifically for the raid instances
            { "ytk", "ARM pliers" },
        };
    }
}
