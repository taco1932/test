using Dalamud.Interface;
using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.Spawn;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {

    public enum BindUser {
        Disabled = -1,
        Default = 0,
        Caster = 1,
        Target = 2,
    }
    public enum BindType {
        Disabled = -1,
        Character = 0,
        Weapon = 1,
        Offhand = 2,
        Summon_or_Lemure = 3,
    }

    public class C173 : TmbEntry {
        public const string MAGIC = "C173";
        public const string DISPLAY_NAME = "VFX";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x44;
        public override int ExtraSize => 0;

        private readonly ParsedInt Enabled = new( "Enabled/Loop Status", value: 1 );
        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly TmbOffsetString Path = new( "Path", [
            new() {
                Icon = () => VfxSpawn.IsActive ? FontAwesomeIcon.Times : FontAwesomeIcon.Eye,
                Remove = false,
                Action = ( string path ) => {
                    if( VfxSpawn.IsActive ) VfxSpawn.Clear();
                    else VfxSpawn.OnSelf( path, false );
                }
            }
        ], false );
        //private readonly ParsedShort BindPoint1 = new( "Bind Point 1" );
        private readonly ParsedEnum<BindUser> BindPoint1 = new( "Bind Point 1", size: 1 );
        private readonly ParsedEnum<BindType> BindPoint1Type = new( "Bind Point 1 Type", size: 1 );
        //private readonly ParsedInt Unk2 = new( "Unknown 2", size: 2 );
        private readonly ParsedShort BindPoint2 = new( "Bind Point 2" );
        private readonly ParsedInt Visibility = new( "Visibility" ); 
        private readonly ParsedInt Unk4 = new( "Unknown 4" );
        private readonly ParsedInt Unk5 = new( "Unknown 5" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );
        private readonly ParsedInt Unk7 = new( "Unknown 7" );
        private readonly ParsedInt Unk8 = new( "Unknown 8" );
        private readonly ParsedInt Unk9 = new( "Unknown 9" );
        private readonly ParsedInt Unk10 = new( "Unknown 10" );
        private readonly ParsedInt Unk11 = new( "Unknown 11" );
        private readonly ParsedInt Unk12 = new( "Unknown 12" );

        public C173( TmbFile file ) : base( file ) { }

        public C173( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unk1,
            Path,
            BindPoint1,
            BindPoint1Type,
            //Unk2,
            BindPoint2,
            Visibility,
            Unk4,
            Unk5,
            Unk6,
            Unk7,
            Unk8,
            Unk9,
            Unk10,
            Unk11,
            Unk12
        ];
    }
}
