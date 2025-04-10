using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {

    public enum SubtitleType {
        BattleTalk_Window = 0,
        Bordered_Plaintext = 1,
    }

    public class C216 : TmbEntry {
        public const string MAGIC = "C216";
        public const string DISPLAY_NAME = "Subtitles";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x30;
        public override int ExtraSize => 0;

        public readonly ParsedBool Enabled = new( "Enabled" );
        public readonly ParsedInt Unknown2 = new( "Unknown 2" );
        public readonly ParsedEnum<SubtitleType> Type = new( "Subtitle Type" );
        public readonly ParsedInt TextID = new( "Subtitle Text ID" );
        public readonly ParsedInt SpeakerID = new( "Speaker ID" );
        public readonly ParsedFloat Duration = new( "Duration" );
        public readonly ParsedInt Unknown7 = new( "Unknown 7" );
        public readonly ParsedInt Unknown8 = new( "Unknown 8" );
        public readonly ParsedInt Unknown9 = new( "Unknown 9" );

        public C216( TmbFile file ) : base( file ) { }

        public C216( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            Unknown2,
            Type,
            TextID,
            SpeakerID,
            Duration,
            Unknown7,
            Unknown8,
            Unknown9
        ];
    }
}
