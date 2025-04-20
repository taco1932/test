using System.Collections.Generic;

namespace VfxEditor.TmbFormat.Root {
    public class LuaPool {
        public readonly int Id;
        public readonly int Size;
        public readonly Dictionary<int, string> Names;

        public LuaPool( int id, int maxSize, Dictionary<int, string> names ) {
            Id = id;
            Size = maxSize;
            Names = names;
        }

        // >128 is non-player-specific. here for documentation, but otherwise may not be useful
        public static readonly LuaPool Pool1 = new( 1, 2400, new() {
            { 0x00, "[CUTSCENE] Game Language" },
            { 0x01, "[CUTSCENE] Caption Language" },
            { 0x02, "[CUTSCENE] Voice Language" },
            { 0x03, "[CUTSCENE] Skeleton ID" },
            { 0x04, "[CUTSCENE] Starting Town" },
            { 0x09, "[CUTSCENE] Quest Progression" },
            { 0x0E, "[CUTSCENE] Dialog Choice" },
            { 0x10, "[CUTSCENE] Legacy Player" },
            { 0x12, "[CUTSCENE] Class/Job" },
            { 0x13, "Is Player Character" },
            { 0x1B, "[CUTSCENE] Gender" },
            { 0x23, "[CUTSCENE] Is Gatherer" },
            { 0x24, "[CUTSCENE] Is Crafter" },
            { 0x25, "Is Mount" },
            { 0x26, "Mounted" },
            { 0x27, "Swimming" },
            { 0x28, "Underwater" },
            { 0x29, "Class/Job" },
            { 0x33, "Mount ID" },
            { 0x34, "Character State" },
            { 0x39, "GPose" },
            { 0x3C, "Skeleton ID" },
            { 0x3D, "Mount Flying" },
            { 0x80, "(Combat-Related)" },
            { 0x81, "(Combat-Related)" },
            { 0x82, "(Combat-Related)" },
            { 0x83, "(Combat-Related)" },
            { 0x84, "(Combat-Related)" },
            { 0x85, "(Combat-Related)" },
            { 0x86, "(Combat-Related)" },
            { 0x87, "(Combat-Related)" },
            { 0x88, "(Combat-Related)" },
            { 0x89, "(Combat-Related)" },
            { 0xEA, "Mouse Drag" },
            { 0xEB, "Window Focus" },
            { 0xEC, "Mouse Hover / Cursor Type" },
            { 0x19C, "Cursor Type" },
            { 0x19D, "Cursor Pos. X" },
            { 0x19E, "Cursor Pos. Y" },
            { 0x19F, "[Cursor Outside Window]" },
            { 0x1A0, "Cursor Type" },
            { 0x1A1, "Cursor Pos. X" },
            { 0x1A2, "Cursor Pos. Y" },
            { 0x1A3, "[Cursor Outside Window]" },
            { 0x1A4, "Cursor Type" },
            { 0x1A5, "Cursor Pos. X" },
            { 0x1A6, "Cursor Pos. Y" },
            { 0x1A7, "[Cursor Outside Window]" },
            { 0x1A8, "Cursor Type" },
            { 0x1A9, "Cursor Pos. X" },
            { 0x1AA, "Cursor Pos. Y" },
            { 0x1AB, "Cursor Outside Window" },
            { 0x1AC, "Cursor Type" },
            { 0x1AD, "Cursor Pos. X" },
            { 0x1AE, "Cursor Pos. Y" },
            { 0x1AF, "[Cursor Outside Window]" },
            { 0x1B0, "Cursor Type" },
            { 0x1B1, "Cursor Pos. X" },
            { 0x1B2, "Cursor Pos. Y" },
            { 0x1B3, "[Cursor Outside Window]" },
            { 0x1B4, "Cursor Type" },
            { 0x1B5, "Cursor Pos. X" },
            { 0x1B6, "Cursor Pos. Y" },
            { 0x1B7, "[Cursor Outside Window]" },
            { 0x1B8, "Cursor Type" },
            { 0x1B9, "Cursor Pos. X" },
            { 0x1BA, "Cursor Pos. Y" },
            { 0x1BB, "[Cursor Outside Window]" },
            { 0x1BD, "(Counts down from 7 to 0)" },
            { 0x1BF, "Cursor Type (again)" },
            { 0x1C0, "(Continually shifts values)" },
            { 0x95EF, "[something]" }, //38383
            { 0x962F, "[something]" }, //38447
            { 0x963F, "[something]" }, //38463
        } );

        public static readonly LuaPool Pool2 = new( 2, 64, [] ); //larger than this will repeat pool 1 data at 0x80

        public static readonly LuaPool Pool3 = new( 3, 32, [] ); //larger than this will repeat pool 1 data at 0x80

        public static List<LuaPool> Pools => [
            Pool1,
            Pool2,
            Pool3,
        ];
    }
}
