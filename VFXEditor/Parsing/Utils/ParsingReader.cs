using System;
using System.IO;
using VfxEditor.Utils;

namespace VfxEditor.Parsing.Utils {
    public class ParsingReader {
        public readonly BinaryReader Reader;
        public long StartPosition;

        public ParsingReader( BinaryReader reader ) {
            Reader = reader;
        }

        public void UpdateStartPosition() {
            StartPosition = Reader.BaseStream.Position;
        }

        public void UpdateReadPosition( long position ) {
            Reader.BaseStream.Position = position;
        }
        public void OffsetReadPosition( long offset ) {
            var CurPos = Reader.BaseStream.Position;
            var OffsetPos = CurPos + offset;
            if (OffsetPos > Reader.BaseStream.Length) {
                return;
            }
            Reader.BaseStream.Position = OffsetPos;
        }

        public long GetReadPosition()
        {
            long ret = Reader.BaseStream.Position;
            return ret;
        }

        public int ReadInt32() => Reader.ReadInt32();
        public short ReadInt16() => Reader.ReadInt16();
        public UInt32 ReadUInt32() => Reader.ReadUInt32();
        public byte ReadByte() => Reader.ReadByte();
        public float ReadSingle() => Reader.ReadSingle();
        public string ReadString( int size ) => FileUtils.ReadString( Reader, size );
    }
}
