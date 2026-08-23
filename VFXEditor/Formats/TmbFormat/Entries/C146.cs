using System.Collections.Generic;
using VfxEditor.Parsing;
using VfxEditor.TmbFormat.Utils;

namespace VfxEditor.TmbFormat.Entries {
    public enum AccessoryType {
        Earrings = 0,
        Neck = 1,
        Wrist,
        Right_Ring,
        Left_Ring
        //Earrrings = 5 (again)
        
    }
    public class C146 : TmbEntry {
        public const string MAGIC = "C146";
        public const string DISPLAY_NAME = "Apply Accessory ----[TESTING] (CUTB)";
        public override string DisplayName => DISPLAY_NAME;
        public override string Magic => MAGIC;

        public override int Size => 0x28;
        public override int ExtraSize => 0;

        private readonly ParsedBool Enabled = new( "Enabled" );
        private readonly ParsedInt CRC = new( "CRC" );
        private readonly ParsedEnum<AccessoryType> Type = new( "Accessory Type" );
        private readonly ParsedShort AccId = new( "Accessory ID" ); //aXXXX, 0 sets to "Nothing"
        private readonly ParsedShort Variant = new( "Variant ID" );
        private readonly ParsedInt Color = new( "Colour ID" ); //to do: check how this is referenced (through glamourer). only changes the secondary colour, not primary
        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );


        public C146( TmbFile file ) : base( file ) { }

        public C146( TmbFile file, TmbReader reader ) : base( file, reader ) { }

        protected override List<ParsedBase> GetParsed() => [
            Enabled,
            CRC,
            Type,
            AccId,
            Variant,
            Color,
            Unk1,
            Unk2,
        ];
    }
}
