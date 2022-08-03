using ImGuiNET;
using System.Collections.Generic;
using VFXEditor.AVFXLib;
using VFXEditor.AVFXLib.Curve;
using VFXEditor.Helper;

namespace VFXEditor.AVFX.VFX {
    public class UICurve2Axis : UIAssignableItem {
        public readonly AVFXCurve2Axis Curve;
        public readonly string Name;
        public readonly bool Locked;
        public readonly UICombo<AxisConnect> AxisConnectSelect;
        public readonly UICombo<RandomType> AxisConnectRandomSelect;
        public readonly UICurve X;
        public readonly UICurve Y;
        private readonly List<UICurve> Curves;

        public UICurve2Axis( AVFXCurve2Axis curve, string name, bool locked = false ) {
            Curve = curve;
            Name = name;
            Locked = locked;

            AxisConnectSelect = new UICombo<AxisConnect>( "Axis Connect", Curve.AxisConnectType );
            AxisConnectRandomSelect = new UICombo<RandomType>( "Axis Connect Random", Curve.AxisConnectRandomType );

            Curves = new() {
                ( X = new UICurve( Curve.X, "X" ) ),
                ( Y = new UICurve( Curve.Y, "Y" ) ),
                new UICurve( Curve.RX, "Random X" ),
                new UICurve( Curve.RY, "Random Y" )
            };
        }

        public override void DrawUnassigned( string parentId ) {
            if( ImGui.SmallButton( "+ " + Name + parentId ) ) {
                AVFXBase.RecurseAssigned( Curve, true );
            }
        }

        public override void DrawAssigned( string parentId ) {
            var id = parentId + "/" + Name;
            if( !Locked ) {
                if( UIHelper.RemoveButton( "Delete " + Name + id, small: true ) ) {
                    Curve.SetAssigned( false );
                    return;
                }
            }

            UICurve.DrawUnassignedCurves( Curves, id );

            AxisConnectSelect.DrawInline( id );
            AxisConnectRandomSelect.DrawInline( id );
            ImGui.SetCursorPosY( ImGui.GetCursorPosY() + 5 );

            UICurve.DrawAssignedCurves( Curves, id );
        }

        public override string GetDefaultText() => Name;

        public override bool IsAssigned() => Curve.IsAssigned();
    }
}
