using System.IO;

namespace VfxEditor.Formats.ObsbFormat.Headers {
    public class EnvsHeader {
        public int Magic; //ENVS
        public int HeaderSize; //0x18
        public int Unk1; //4
        public int Unk2; //16
        public int TotalEntries;
        public int FooterPosition; //this to EOF


        //putting this here, but it's not part of the header
        public int EntryData; //to start of groups
        public int Unk3; //1
        public int Unk4; //2

        /*
        then the entries start
        offset to group end, offset + 4, 0x01, entry #

        idk what this value pertains to exactly, but it's always EOF - value = 21
        this to final offsets, maybe?

        then the groups start
        there seem to be three patterns. could be more, but leave it at these

        pattern 1:
        0x0C, 0x01, 0x1D
        3x int + float

        pattern 2:
        0x0C, 0x02, 0x1D, 0x08
        4x int + float

        extra data pattern:
        bgcommon/env/obset/ex5_obset/obset_ocn_o6/obset_o6_btl/obset_o6b1_eff1.obsb
        0x18, 0x01, 0x1D, 0x18, 0x0B, 0x23
        int + float + 2x short
        and then offsets to sub-groups
        first sub-group starts with 00 00 00 00. rest of them skip this
        0x08, hex colour or CRC?, float, float
        and the final offset jumps to the usual pattern 1 (or 2, probably)

        ints can sometimes present as two shorts
        xx 00 01 00

        end of each group:
        offset from entry x2 (seem to always match each other). EOF - 1

        final buffer: 12 + 1
        */

        public EnvsHeader( BinaryReader reader ) {
            Magic = reader.ReadInt32();
            HeaderSize = reader.ReadInt32();
            Unk1 = reader.ReadInt32();
            Unk2 = reader.ReadInt32();
            TotalEntries = reader.ReadInt32();
            FooterPosition = reader.ReadInt32();
        }

        public void Write( BinaryWriter writer ) {
            writer.Write( Magic );
            writer.Write( HeaderSize );
            writer.Write( Unk1 );
            writer.Write( Unk2 );
            writer.Write( TotalEntries );
            writer.Write( FooterPosition );
        }
    }
}
