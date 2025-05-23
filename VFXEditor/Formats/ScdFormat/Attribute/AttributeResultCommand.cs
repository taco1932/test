using System.IO;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat {
    public enum SelfCommand {
        None,
        FadeIn,
        ChgPriority,
        FreezePan,
        Stay,
        ChgPan,
        BanRear,
        NoPlay,
        ChgDepth,
        MonoSpeaker,
        ChgVolume,
        ChgBusNo,
        ChgBusVolume
    }

    public enum TargetCommand {
        None,
        Stop,
        ChgPriority,
        FadeOut,
        ChgPitch,
        PriorityStop,
        ChgPan,
        ChgVolume,
        OldStop,
        BanRear,
        ChgDepth,
        ChgBusNo,
        LowExternalIdOldStop,
        MinVolumeStop
    }

    public class AttributeResultCommand {
        public readonly ParsedEnum<SelfCommand> SelfCommandSelect = new( "Result Select Command", size: 1 );
        public readonly ParsedEnum<TargetCommand> TargetCommandSelect = new( "Result Target Command", size: 1 );
        public readonly ParsedReserve Reserved1 = new( 2 );
        public readonly ParsedInt SelfArgument = new( "Result Self Argument" );
        public readonly ParsedInt TargetArgument = new( "Result Target Argument" );

        public AttributeResultCommand() { }

        public void Read( BinaryReader reader ) {
            SelfCommandSelect.Read( reader );
            TargetCommandSelect.Read( reader );
            Reserved1.Read( reader );
            SelfArgument.Read( reader );
            TargetArgument.Read( reader );
        }

        public void Write( BinaryWriter writer ) {
            SelfCommandSelect.Write( writer );
            TargetCommandSelect.Write( writer );
            Reserved1.Write( writer );
            SelfArgument.Write( writer );
            TargetArgument.Write( writer );
        }

        public void Draw() {
            SelfCommandSelect.Draw();
            TargetCommandSelect.Draw();
            Reserved1.Draw(); //test
            SelfArgument.Draw();
            TargetArgument.Draw();
        }
    }
}
