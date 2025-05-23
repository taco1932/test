using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public class C197 : TmbEntry {
        public const string MAGIC = "C197";
        public const string DISPLAY_NAME = "Voiceline";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x24;
        public override int ExtraSize => 0;

        private readonly ParsedInt FadeTime = new( "Fade Time" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );
        private readonly ParsedInt VoicelineNumber = new( "Voiceline Number" );
        private readonly ParsedInt BindPointID = new( "Bind Point ID" );
        private readonly ParsedInt SpeakID = new( "Speak TMB ID" );
        private readonly ParsedInt Unk6 = new( "Unknown 6" );

        public C197( TmbFile file ) : base( file ) { }

        public C197( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            FadeTime,
            Unk2,
            VoicelineNumber,
            BindPointID,
            SpeakID,
            Unk6
        ];
    }
}
