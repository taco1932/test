using Dalamud.Bindings.ImGui;
using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using VfxEditor.Formats.TmbFormat.Track;
using static VfxEditor.Interop.ResourceLoader;

namespace VfxEditor.Ui.Tools {
    public unsafe class LuaTab {
        private ulong ObjectId = 0;
        private static bool LogChanges = false;
        private int PoolStart = 0;
        private int PoolEnd = 2400;

        private class LuaValues
        {
            required public bool Enabled = true;
            required public uint LastValue = 0;
        };
        private static Dictionary<int, Dictionary<int, LuaValues>> IndLog = new Dictionary<int, Dictionary<int, LuaValues>>();

        public void Draw() {
            using var _ = ImRaii.PushId( "Lua" );

            var manager = Marshal.ReadIntPtr( Plugin.ResourceLoader.LuaManager );
            if( manager == IntPtr.Zero ) return;

            var objectAddress = IntPtr.Zero;
            var objectName = "";

            foreach( var item in Dalamud.Objects ) {
                if( item.GameObjectId == ObjectId ) {
                    objectAddress = item.Address;
                    objectName = GetObjectName( item );
                    break;
                }
            }

            if( objectAddress == 0 ) {
                ObjectId = 0; // couldn't find object, reset
                objectName = "[NONE]";

                // Try to reset back to player character
                if( Plugin.PlayerObject != null && Plugin.PlayerObject.Address != IntPtr.Zero ) {
                    ObjectId = Plugin.PlayerObject.GameObjectId;
                    objectAddress = Plugin.PlayerObject.Address;
                    objectName = GetObjectName( Plugin.PlayerObject );
                }
            }

            ImGui.TextDisabled( $"Pools: 0x{manager:X8}" );
            if( ImGui.IsItemClicked() ) ImGui.SetClipboardText( $"{manager:X8}" );

            ImGui.SameLine();
            ImGui.TextDisabled( $"Dynamic: 0x{Plugin.ResourceLoader.LuaActorVariables:X8}" );

            ImGui.SameLine();
            ImGui.PushItemWidth( 300 );
            ImGui.Checkbox( "Log Changes", ref LogChanges );
            ImGui.PopItemWidth();

            ImGui.SameLine();
            ImGui.PushItemWidth( 200 );
            ImGui.InputInt( "Start Offset", ref PoolStart );
            ImGui.PopItemWidth();
            ImGui.SameLine();
            ImGui.PushItemWidth( 200 );
            ImGui.InputInt( "End Offset", ref PoolEnd );
            ImGui.PopItemWidth();

            if( ImGui.IsItemClicked() ) ImGui.SetClipboardText( $"{Plugin.ResourceLoader.LuaActorVariables:X8}" );

            DrawCombo( objectName );

            using var tabBar = ImRaii.TabBar( "Tabs", ImGuiTabBarFlags.NoCloseWithMiddleMouseButton );
            if( !tabBar ) return;

            foreach( var pool in LuaPool.Pools ) {
                using var tab = ImRaii.TabItem( $"Pool {pool.Id}" );
                if( tab ) DrawPool( pool, manager, objectAddress, ref IndLog, PoolStart, ref PoolEnd);
            }
        }

        private void DrawCombo( string objectName ) {
            using var combo = ImRaii.Combo( "##Combo", objectName );
            if( !combo ) return;

            foreach( var item in Dalamud.Objects ) {
                if( item.ObjectKind != ObjectKind.Pc &&
                    item.ObjectKind != ObjectKind.Mount &&
                    item.ObjectKind != ObjectKind.EventNpc &&
                    item.ObjectKind != ObjectKind.Companion &&
                    item.ObjectKind != ObjectKind.Retainer &&
                    item.ObjectKind != ObjectKind.Ornament &&
                    item.ObjectKind != ObjectKind.Cutscene &&
                    item.ObjectKind != ObjectKind.BattleNpc ) continue;
                if( item.GameObjectId == 0xE0000000 ) continue;

                var name = GetObjectName( item );
                if( ImGui.Selectable( $"{name}##{item.GameObjectId}", item.GameObjectId == ObjectId ) ) {
                    ObjectId = item.GameObjectId;
                }
            }
        }

        private static string GetObjectName( IGameObject item ) {
            var name = item.Name.ToString();
            if( !string.IsNullOrEmpty( name ) ) return name;
            return $"[0x{item.GameObjectId:X4}]";
        }

        private static void DrawPool( LuaPool pool, IntPtr manager, IntPtr objectAddress, ref Dictionary<int, Dictionary<int, LuaValues>> IndLog, int PoolStart, ref int PoolEnd ) {
            using var _ = ImRaii.PushId( pool.Id );
            if (IndLog.ContainsKey(pool.Id) == false)
            { 
                IndLog.Add( pool.Id, new Dictionary<int, LuaValues>());
            };

            using var child = ImRaii.Child( "Child", new Vector2( -1 ), false );

            using var table = ImRaii.Table( "Table", 4, ImGuiTableFlags.RowBg | ImGuiTableFlags.NoSavedSettings );
            if( !table ) return;

            ImGui.TableSetupColumn( "Index", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Name", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Current Value", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Hex", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Monitor", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableHeadersRow();

            if ((PoolEnd - PoolStart ) > 50000 ) 
                { 
                    PoolEnd = PoolStart + 50000;
                };
            for( var i = PoolStart; i < PoolEnd; i++ ) {
                ImGui.TableNextRow();

                ImGui.TableNextColumn();
                ImGui.TextDisabled( $"[0x{i:X2}]  {i}" );

                var value = ( ( uint )pool.Id << 28 ) | ( ( uint )i );
                var varValue = GetVariableValue( value, manager, objectAddress );

                if( IndLog[pool.Id].ContainsKey(i) == false )
                {
                    IndLog[pool.Id].Add( i, new LuaValues() { Enabled = true , LastValue = varValue});
                    //Dalamud.Log("created value" + pool.Id.ToString() + "|" + i.ToString() + "|" + varValue.ToString() );
                };

                ImGui.TableNextColumn();
                ImGui.Text( pool.Names.TryGetValue( i, out var name ) ? name : "" );

                ImGui.TableNextColumn();
                ImGui.Text( $"{varValue}" );

                ImGui.TableNextColumn();
                ImGui.Text( $"0x{varValue:X4}" );

                ImGui.TableNextColumn();
                ImGui.Checkbox( "Log " + pool.Id.ToString() + "|" + i.ToString(), ref IndLog[pool.Id][i].Enabled);

                if (LogChanges && IndLog[pool.Id][i].Enabled && IndLog[pool.Id][i].LastValue != varValue )  {
                    Dalamud.Log( "[LuaLogging]Value " + pool.Id.ToString() + " || " + i.ToString() + " has changed from " + IndLog[pool.Id][i].LastValue.ToString() + " to " + varValue.ToString() );
                    IndLog[pool.Id][i].LastValue = varValue;
                }
                ;
            }
        }

        // 48 89 5C 24 ? 48 89 74 24 ? 57 48 83 EC 20 44 8B 0D ? ? ? ? 48 8B F9 65 48 8B 04 25 ? ? ? ? 49 8B F0

        private static uint GetVariableValue( uint value, IntPtr manager, IntPtr objectAddress ) {
            if( objectAddress != IntPtr.Zero && TryGetActorVariableGetter( value, out var getter ) ) {
                var actorFunc = Marshal.GetDelegateForFunctionPointer<LuaActorVariableDelegate>( getter );
                return actorFunc( objectAddress );
            }

            return Plugin.ResourceLoader.GetLuaVariable( manager, value );
        }

        private static bool TryGetActorVariableGetter( uint value, out IntPtr getter ) {
            getter = IntPtr.Zero;

            var table = Plugin.ResourceLoader.LuaActorVariables;
            if( table == IntPtr.Zero ) return false;

            for( var i = 0; i < Plugin.ResourceLoader.LuaActorVariableCount; i++ ) {
                var entry = table + i * LuaActorVariableStride;
                if( ( uint )Marshal.ReadInt32( entry ) != value ) continue;

                getter = Marshal.ReadIntPtr( entry + 8 );
                return getter != IntPtr.Zero;
            }
            //Dalamud.Log("[LUACHANGE] ");
            //return Plugin.ResourceLoader.GetLuaVariable( manager, value );
            return false;
        }
    }
}
