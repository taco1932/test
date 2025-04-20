using FFXIVClientStructs.FFXIV.Client.Game.Character;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using VfxEditor.FileManager;
using VfxEditor.Formats.AtchFormat.Entry;
using VfxEditor.Utils;

namespace VfxEditor.Formats.AtchFormat {
    // https://github.com/Ottermandias/Penumbra.GameData/blob/main/Files/AtchFile.cs

    public class AtchFile : FileManagerFile {
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
            { "tms", "Bouquet (/bouquet) / tomestone (non-emote)" }, //1949, 1944
            { "trm", "BRD trumpet [performance]" },
            { "trr", "SCH LB summon" }, //9101
            { "trw", "" }, //n_throw?
            // { "tsl", "" }, // new
            // { "uni", "" }, // new
            { "vln", "BRD violin" }, //radiant finale
            { "wdm", "Tankard (/toast)" },
            { "whl", "" },
            // { "wng", "" },
            // { "ypd", "" },
            { "ytk", "ARM pliers" },
        };

        public const int BitFieldSize = 32;

        public readonly ushort NumStates;
        public readonly List<AtchEntry> Entries = [];
        private readonly AtchEntrySplitView EntryView;

        public unsafe AtchFile( BinaryReader reader ) : base() {
            Verified = VerifiedStatus.UNSUPPORTED; // verifying these is fucked. The format is pretty simple though, so it's not a big deal

            var numEntries = reader.ReadUInt16();
            NumStates = reader.ReadUInt16();

            for( var i = 0; i < numEntries; i++ ) {
                Entries.Add( new( reader ) );
            }

            var bitfield = stackalloc ulong[BitFieldSize / 8];
            for( var i = 0; i < BitFieldSize / 8; ++i )
                bitfield[i] = reader.ReadUInt64();

            for( var i = 0; i < numEntries; ++i ) {
                var bitIdx = i & 0x3F;
                var ulongIdx = i >> 6;
                Entries[i].Accessory.Value = ( ( bitfield[ulongIdx] >> bitIdx ) & 1 ) == 1;
            }

            Entries.ForEach( x => x.ReadBody( reader, NumStates ) );
            EntryView = new( Entries );
        }

        public override void Write( BinaryWriter writer ) {
            writer.Write( ( ushort )Entries.Count );
            writer.Write( NumStates );

            Entries.ForEach( x => x.Write( writer ) );

            Span<byte> bitfield = stackalloc byte[BitFieldSize];
            foreach( var (entry, i) in Entries.WithIndex() ) {
                var bitIdx = i & 0x7;
                var byteIdx = i >> 3;
                if( Entries[i].Accessory.Value )
                    bitfield[byteIdx] |= ( byte )( 1 << bitIdx );
            }

            writer.Write( bitfield );

            var stringStartPos = 2 + 2 + ( 4 * Entries.Count ) + BitFieldSize + ( 32 * Entries.Count * NumStates );
            using var stringMs = new MemoryStream();
            using var stringWriter = new BinaryWriter( stringMs );
            var stringPos = new Dictionary<string, int>();

            Entries.ForEach( x => x.WriteBody( writer, stringStartPos, stringWriter, stringPos ) );

            writer.Write( stringMs.ToArray() );
        }

        public override void Draw() {
            DrawCurrentWeapons();

            ImGui.Separator();

            EntryView.Draw();
        }

        private unsafe void DrawCurrentWeapons() {
            if( Dalamud.ClientState == null || Plugin.PlayerObject == null ) return;

            var weapons = new List<string>();
            // https://github.com/aers/FFXIVClientStructs/blob/2c388216cb52d4b6c4dbdedb735e1b343d56a846/FFXIVClientStructs/FFXIV/Client/Game/Character/Character.cs#L78C20-L78C23
            var dataStart = ( nint )Unsafe.AsPointer( ref ( ( Character* )Plugin.PlayerObject.Address )->DrawData ) + 0x20;

            for( var i = 0; i < 3; i++ ) {
                var data = dataStart + ( DrawObjectData.Size * i );
                if( Marshal.ReadInt64( data + 8 ) == 0 || Marshal.ReadInt64( data + 16 ) == 0 || Marshal.ReadInt32( data + 32 ) == 0 ) continue;

                var nameArr = Marshal.PtrToStringAnsi( data + 32 ).ToCharArray();
                Array.Reverse( nameArr );
                weapons.Add( new string( nameArr ) );
            }

            if( weapons.Count == 0 ) return;

            ImGui.Separator();

            ImGui.TextDisabled( $"Current Weapons: {weapons.Aggregate( ( x, y ) => x + " | " + y )}" );
        }
    }
}
