using System.Collections.Generic;

namespace VfxEditor.AtchFormat.Utils {

    public class AtchUtils {
        public static readonly Dictionary<string, string> WeaponNames = new() {
            { "2ax", "Axe (MRD/WAR)" },
            { "2bk", "Book (ACN/SMN/SCH)" },
            { "2bw", "Bow (ARC/BRD)" },
            // { "2bs", "" }, //1703
            { "2ff", "Nouliths (SGE)" },
            { "2gb", "Gunblade (GNB)" },
            { "2gl", "Globe (AST)" },
            { "2gn", "Gun (MCH)" },
            { "2km", "Scythe (RPR)" },
            { "2kt", "Katana (SAM)" },
            { "2kz", "Scythe" }, //2813
            { "2rp", "Rapier (RDM)" },
            { "2sp", "Spear (LNC/DRG)" },
            { "2st", "Staff (CNJ/WHM / THM/BLM)" },
            { "2sw", "Greatsword (DRK)" },
            { "aai", "Alembic, Alt. Inversed (ALC)" },
            { "aal", "Alembic, Alternate (ALC)" },
            { "aar", "Hammer, Alternate (ARM)" },
            { "abl", "Hammer, Alternate (BSM)" },
            { "aco", "Fry Pan, Alternate (CUL)" },
            { "agl", "Mallet, Alternate (GSM)" },
            { "ali", "Alembic, Inversed (ALC)" },
            { "alm", "Alembic (ALC)" },
            { "alt", "Knife, Alternate (LTW)" },
            { "ase", "Needle, Alternate (WVR)" },
            { "atr", "n_throw Summons" },
            { "avt", "Avatar (RPR)" },
            { "awo", "Saw, Alternate (CRP)" },
            { "bag", "Aetherotransformer (MCH)" },
            // { "bec", "" },
            // { "bgo", "" },
            { "bl2", "Double Blade, Off-Hand (VPR)" },
            { "bld", "Blade, Main Hand (VPR)"},
            { "bll", "Single Blade, Off-Hand (VPR)" },
            { "brs", "Brush (PCT)" },
            // { "bsl", "" },
            { "chk", "Chakram (DNC)" },
            { "ckt", "Stylus" }, //9208, Calyx
            // { "clb", "" },
            { "clg", "Fist Weapon, Unique (PGL/MNK)" },
            { "cls", "Fist Weapon, Alternate (PGL/MNK)" },
            { "clw", "Fist Weapon (PGL/MNK)" },
            // { "cmp", "" }, //1970
            { "col", "Control Switch (Left)" },
            { "cor", "Control Switch (Right)" },
            { "cos", "Control Seat" },
            { "crd", "Deck (AST)" },
            { "crr", "Carry Item / Card (AST)" },
            { "crt", "Cart" }, //9086
            { "csl", "Chisel (CRP)" },
            { "csr", "Crafter Off-Hand, Held" },
            // { "cut", "" }, //9991
            { "dgr", "Dagger (ROG/NIN)" },
            { "dge", "Dagger" }, //1811, 1861
            { "drm", "Drum (Performance)" },
            // { "dur", "" }, //1517
            { "ebz", "Diadem Cannon" },
            // { "egp", "" }, //9802
            { "elg", "Electric Guitar (Performance)" },
            { "fcb", "Fry Egg / Eat Chicken (Emote)" },
            { "fch", "Fishing Chair" },
            { "fdr", "Consumable" }, //food and drink, but also includes sundering sword
            { "fha", "Gig (FSH)" },
            { "fl2", "Flute (Performance)" },
            // { "flc", "" }, //1956
            { "flt", "Flute (BRD Combat)" },
            { "frg", "Frog Summon (NIN)" },
            { "fry", "Knife (LTW) / Fry Pan (CUL)" },
            { "fsb", "Bell" },
            { "fsh", "Rod (FSH)" },
            { "fsw", "Greatsword (Esteem)" },
            { "fud", "Brush (Emote)" }, //JP: fude
            { "gdb", "Knapsack" },
            { "gdh", "Emote Summon (Hand)" },
            { "gdl", "Emote Summon (Left Hand)" },
            { "gdp", "Pelupack" },
            { "gdr", "Emote Summon (Right Hand)" },
            { "gdt", "NPC Transforms" },
            // { "gdu", "" }, //9216
            { "gdw", "Turtle Shell" },
            { "gsl", "Wrench" },
            { "gsr", "Opera Glasses" }, //also 1909, no model
            { "gun", "Gun" },
            // { "hab", "" }, //1973
            // { "hbg", "" }, //9209
            // { "hel", "" },
            { "hmm", "Hammer (BSM/ARM)" },
            { "hrp", "Harp (BRD)" },
            { "htc", "Hatchet (BTN)" },
            // { "ipu", "" }, //9091
            { "ksh", "Katana Sheath (SAM)" },
            { "let", "Letter" },
            { "lfd", "Loporitt Paintbrush" },
            { "lpr", "Ear Wiggle (Emote)" },
            // { "map", "" }, //1969
            { "mlt", "Mallet (GSM)" },
            { "mmc", "Quad-Cannons (MCH)" },
            // { "mot", "" }, //9992
            { "mrb", "Mortar (ALC)" },
            { "mrh", "Pestle (ALC)" },
            { "msg", "Shotgun (MCH)" },
            { "mwp", "Summoned Tool (MCH) / Cosmic Tool" },
            { "ndl", "Needle, Off-Hand (WVR)" },
            { "nf2", "Wasshoi Fan" },
            { "nik", "Metal Cup" }, //9055
            // { "njd", "" }, //1935
            { "nmf", "Namazu Fan" },
            { "nph", "Sledgehammer (MIN)" },
            { "orb", "Focus (RDM)" },
            // { "oum", "" }, //9801
            { "pen", "Quill (ACN/SCH/SMN)" },
            { "pic", "Pick (MIN)" },
            { "plt", "Palette (PCT)" },
            { "pra", "Parachute" },
            { "prc", "Camera (Emote)" },
            { "prf", "Awl (LTW)" },
            { "pri", "Prishe" }, //9207
            { "qvr", "Quiver (BRD)" },
            // { "rap", "" },
            { "rbt", "Rabbit (NIN)" },
            { "rec", "Cart" }, //9202
            { "rgk", "Katana (Gosetsu)" },
            { "rgs", "Katana Sheath (Gosetsu)" },
            { "rod", "Rod (BLU)" },
            { "rop", "Rope" },
            { "rp1", "Hammer (PCT)" },
            { "saw", "Saw (CRP)" },
            { "sbt", "Blow Bubbles / Pen (Emote)" },
            { "sca", "Aetheric Analyzer" },
            { "sci", "Scissors" },
            { "sen", "Folding Fan" },
            // { "sht", "" },
            { "sic", "Sickle (BTN)" },
            { "sld", "Shield (GLD/PLD / CNJ / THM)" },
            { "stf", "Wand (CNJ / THM)" },
            { "stv", "Furnace (ALC)" },
            { "swd", "Sword (GLD/PLD)" },
            { "sxs", "Greatsword (FFXVI)" },
            { "sxw", "Phoenix Wings (FFXVI)" },
            { "syl", "Reference Book (Emote)" }, //and 1976, no model
            { "syr", "Shovel / Scythe" },
            { "syu", "Shuriken (NIN)" },
            { "syw", "Job Summons (Dawntrail)" },
            { "tan", "Tongue" },
            { "tbl", "Crafter Tables/Surfaces" },
            { "tcs", "Teacup (Emote)" },
            { "tgn", "Nail (GSM)" },
            { "tmb", "Needle, Main Hand (WVR)" },
            { "tms", "Tomestone / Bouquet (Emote)" },
            { "trm", "Trumpet (Performance)" },
            { "trr", "Limit Break Summon (SCH)" },
            { "trw", "Rock" }, //1401
            { "tsl", "Mug/Cup (Emote)" },
            { "ulw", "Wings (White)" },
            { "uni", "Unicorn" },
            { "vln", "Violin (BRD)" },
            { "wcr", "Wheelchair" },
            { "wdm", "Tankard (Emote)" },
            { "whl", "Wheel (WVR)" },
            { "wng", "Wings (Gold)" },
            { "yfl", "NiER Flight Unit" },
            { "ypd", "NiER Pod (Raid)" },
            { "yt2", "NiER Swords, 9S" },
            { "ytc", "NiER Swords, 2B" },
            { "ytk", "Tongs (BSM)" },
        };
    }
}
