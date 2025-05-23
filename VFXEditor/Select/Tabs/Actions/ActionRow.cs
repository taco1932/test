using Lumina.Excel.Sheets;
using VfxEditor.Select.Base;

namespace VfxEditor.Select.Tabs.Actions {
    public class ActionRow : ISelectItemWithIcon {
        public readonly string Name;
        public readonly int RowId;
        public readonly ushort Icon;

        public readonly string StartTmbPath;
        public readonly string EndTmbPath;
        public readonly string HitTmbPath;
        public readonly string WeaponTmbPath;

        public readonly string CastVfxPath;
        public readonly string StartVfxPath;

        public readonly bool StartMotion;
        public readonly bool EndMotion;
        public readonly bool HitMotion;

        public ActionRow( Action action ) {
            Name = action.Name.ToString();
            RowId = ( int )action.RowId;
            Icon = action.Icon;

            StartVfxPath = ToVfxPath( action.AnimationStart.ValueNullable?.VFX.ValueNullable?.Location.ToString() );
            CastVfxPath = ToVfxPath( action.VFX.ValueNullable?.VFX.ValueNullable?.Location.ToString() );

            var start = action.AnimationStart.ValueNullable?.Name.ValueNullable;
            var end = action.AnimationEnd.ValueNullable;
            var hit = action.ActionTimelineHit.ValueNullable;

            StartTmbPath = ToTmbPath( start?.Key.ToString() );
            EndTmbPath = ToTmbPath( end?.Key.ToString() );
            HitTmbPath = ToTmbPath( hit?.Key.ToString() );
            WeaponTmbPath = ToTmbPath( action.AnimationEnd.ValueNullable?.WeaponTimeline.ValueNullable?.File.ToString() );

            StartMotion = start?.IsMotionCanceledByMoving ?? false;
            EndMotion = end?.IsMotionCanceledByMoving ?? false;
            HitMotion = hit?.IsMotionCanceledByMoving ?? false;
        }

        public string GetName() => Name;

        public uint GetIconId() => Icon;

        //public static string ToTmbPath( string key ) => ( string.IsNullOrEmpty( key ) || key.Contains( "[SKL_ID]" ) ) ? string.Empty : $"chara/action/{key}.tmb";
        public static string ToTmbPath( string key ) => string.IsNullOrEmpty( key ) ? string.Empty : $"chara/action/{key}.tmb";
        public static string ToVfxPath( string key ) => string.IsNullOrEmpty( key ) ? string.Empty : $"vfx/common/eff/{key}.avfx";
    }
}