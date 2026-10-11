using System.Collections.Generic;
using Dalamud.Interface;
using VfxEditor.Parsing;
using VfxEditor.Parsing.Int;
using VfxEditor.Spawn;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C049 : TmbEntry {
        public const string MAGIC = "C049";
        public const string DISPLAY_NAME = "----Ground VFX [TESTING] (CUTB)";
        //seems to spawn at map origin?
        //accompanied by C085
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x34;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedInt Unk3 = new( "Duration?" );
        private readonly TmbOffsetString Path = new( "Path", [
            new() {
                Icon = () => VfxSpawn.IsActive ? FontAwesomeIcon.Times : FontAwesomeIcon.Eye,
                Remove = false,
                Action = path => {
                    if( VfxSpawn.IsActive ) VfxSpawn.Clear();
                    else VfxSpawn.OnSelf( path, false );
                }
            }
        ], false );
        private readonly ParsedIntByte4 Unk5 = new( "Unknown 5", value: 0xFF ); //0xFFFFFFFF
        private readonly ParsedInt Unk6 = new( "Unknown 6" ); //allows -1 if Unk8 is >0
        private readonly ParsedIntByte4 Unk7 = new( "Unknown 7", value: 0xFF ); //0xFFFFFFFF
        private readonly ParsedInt Unk8 = new( "Unknown 8" ); //can't be -1 for spawn
        private readonly ParsedInt Unk9 = new( "Unused 1" );
        private readonly ParsedInt Unk10 = new( "Unused 2" );


        public C049( TmbFile file ) : base( file ) { }

        public C049( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            Unk3,
            Path,
            Unk5,
            Unk6,
            Unk7,
            Unk8,
            Unk9,
            Unk10
        ];
    }
}
