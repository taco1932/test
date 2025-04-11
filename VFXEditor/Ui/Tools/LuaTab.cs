using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Utility.Raii;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using VfxEditor.TmbFormat.Root;
using VfxEditor.Ui.NodeGraphViewer.Utils;
using static VfxEditor.Interop.ResourceLoader;

namespace VfxEditor.Ui.Tools {
    public unsafe class LuaTab {
        private ulong ObjectId = 0;
        private static bool LogChanges = false;
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
            if( ImGui.Checkbox( "Log Changes", ref LogChanges ));
            
            if( ImGui.IsItemClicked() ) ImGui.SetClipboardText( $"{Plugin.ResourceLoader.LuaActorVariables:X8}" );

            DrawCombo( objectName );

            using var tabBar = ImRaii.TabBar( "Tabs", ImGuiTabBarFlags.NoCloseWithMiddleMouseButton );
            if( !tabBar ) return;

            foreach( var pool in LuaPool.Pools ) {
                using var tab = ImRaii.TabItem( $"Pool {pool.Id}" );
                if( tab ) DrawPool( pool, manager, objectAddress, ref IndLog);
            }
        }

        private void DrawCombo( string objectName ) {
            using var combo = ImRaii.Combo( "##Combo", objectName );
            if( !combo ) return;

            foreach( var item in Dalamud.Objects ) {
                if( item.ObjectKind != ObjectKind.Player &&
                    item.ObjectKind != ObjectKind.MountType &&
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

        private static void DrawPool( LuaPool pool, IntPtr manager, IntPtr objectAddress, ref Dictionary<int, Dictionary<int, LuaValues>> IndLog ) {
            using var _ = ImRaii.PushId( pool.Id );
            if (IndLog.ContainsKey(pool.Id) == false)
            { 
                IndLog.Add( pool.Id, new Dictionary<int, LuaValues>());
            };

            using var child = ImRaii.Child( "Child", new Vector2( -1 ), false );

            using var table = ImRaii.Table( "Table", 5, ImGuiTableFlags.RowBg );
            if( !table ) return;

            ImGui.TableSetupColumn( "Index", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Name", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Current Value", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Hex", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableSetupColumn( "Monitor", ImGuiTableColumnFlags.WidthStretch );
            ImGui.TableHeadersRow();

            for( var i = 0; i < pool.Size; i++ ) {
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
            if( objectAddress == IntPtr.Zero ) return Plugin.ResourceLoader.GetLuaVariable( manager, value );

            return value switch {
                //throwing a bunch of junk values at the wall
                0x10000000 or
                0x10000001 or
                0x10000002 or
                0x10000003 or
                0x10000004 or
                0x10000005 or
                0x10000006 or
                0x10000007 or
                0x10000008 or
                0x10000009 or
                0x1000000A or
                0x1000000B or
                0x1000000C or
                0x1000000D or
                0x1000000E or
                0x1000000F or
                0x10000010 or
                0x10000011 or
                0x10000012 or
                0x10000013 or
                0x10000014 or
                0x10000015 or
                0x10000016 or
                0x10000017 or
                0x10000018 or
                0x10000019 or
                0x1000001A or
                0x1000001B or
                0x1000001C or
                0x1000001D or
                0x1000001E or
                0x1000001F or
                0x10000020 or
                0x10000021 or
                0x10000022 or
                0x10000023 or
                0x10000024 or
                0x10000025 or
                0x10000026 or
                0x10000027 or
                0x10000028 or
                0x10000029 or
                0x1000002A or
                0x1000002B or
                0x1000002C or
                0x1000002D or
                0x1000002E or
                0x1000002F or
                0x10000030 or
                0x10000031 or
                0x10000032 or
                0x10000033 or
                0x10000034 or
                0x10000035 or
                0x10000036 or
                0x10000037 or
                0x10000038 or
                0x10000039 or
                0x1000003A or
                0x1000003B or
                0x1000003C or
                0x1000003D or
                /*
                0x1000003E or
                0x1000003F or
                0x10000040 or
                0x10000041 or
                0x10000042 or
                0x10000043 or
                0x10000044 or
                0x10000045 or
                0x10000046 or
                0x10000047 or
                0x10000048 or
                0x10000049 or
                0x1000004A or
                0x1000004B or
                0x1000004C or
                0x1000004D or
                0x1000004E or
                0x1000004F or
                0x10000050 or
                0x10000051 or
                0x10000052 or
                0x10000053 or
                0x10000054 or
                0x10000055 or
                0x10000056 or
                0x10000057 or
                0x10000058 or
                0x10000059 or
                0x1000005A or
                0x1000005B or
                0x1000005C or
                0x1000005D or
                0x1000005E or
                0x1000005F or
                0x10000060 or
                0x10000061 or
                0x10000062 or
                0x10000063 or
                0x10000064 or
                0x10000065 or
                0x10000066 or
                0x10000067 or
                0x10000068 or
                0x10000069 or
                0x1000006A or
                0x1000006B or
                0x1000006C or
                0x1000006D or
                0x1000006E or
                0x1000006F or
                0x10000070 or
                0x10000071 or
                0x10000072 or
                0x10000073 or
                0x10000074 or
                0x10000075 or
                0x10000076 or
                0x10000077 or
                0x10000078 or
                0x10000079 or
                0x1000007A or
                0x1000007B or
                0x1000007C or
                0x1000007D or
                0x1000007E or
                0x1000007F or
                0x10000080 or
                0x10000081 or
                0x10000082 or
                0x10000083 or
                0x10000084 or
                0x10000085 or
                0x10000086 or
                0x10000087 or
                0x10000088 or
                0x10000089 or
                0x1000008A or
                0x1000008B or
                0x1000008C or
                0x1000008D or
                0x1000008E or
                0x1000008F or
                0x10000090 or
                0x10000091 or
                0x10000092 or
                0x10000093 or
                0x10000094 or
                0x10000095 or
                0x10000096 or
                0x10000097 or
                0x10000098 or
                0x10000099 or
                0x1000009A or
                0x1000009B or
                0x1000009C or
                0x1000009D or
                0x1000009E or
                0x1000009F or
                0x100000A0 or
                0x100000A1 or
                0x100000A2 or
                0x100000A3 or
                0x100000A4 or
                0x100000A5 or
                0x100000A6 or
                0x100000A7 or
                0x100000A8 or
                0x100000A9 or
                0x100000AA or
                0x100000AB or
                0x100000AC or
                0x100000AD or
                0x100000AE or
                0x100000AF or
                0x100000B0 or
                0x100000B1 or
                0x100000B2 or
                0x100000B3 or
                0x100000B4 or
                0x100000B5 or
                0x100000B6 or
                0x100000B7 or
                0x100000B8 or
                0x100000B9 or
                0x100000BA or
                0x100000BB or
                0x100000BC or
                0x100000BD or
                0x100000BE or
                0x100000BF or
                0x100000C0 or
                0x100000C1 or
                0x100000C2 or
                0x100000C3 or
                0x100000C4 or
                0x100000C5 or
                0x100000C6 or
                0x100000C7 or
                0x100000C8 or
                0x100000C9 or
                0x100000CA or
                0x100000CB or
                0x100000CC or
                0x100000CD or
                0x100000CE or
                0x100000CF or
                0x100000D0 or
                0x100000D1 or
                0x100000D2 or
                0x100000D3 or
                0x100000D4 or
                0x100000D5 or
                0x100000D6 or
                0x100000D7 or
                0x100000D8 or
                0x100000D9 or
                0x100000DA or
                0x100000DB or
                0x100000DC or
                0x100000DD or
                0x100000DE or
                0x100000DF or
                0x100000E0 or
                0x100000E1 or
                0x100000E2 or
                0x100000E3 or
                0x100000E4 or
                0x100000E5 or
                0x100000E6 or
                0x100000E7 or
                0x100000E8 or
                0x100000E9 or
                */
                0x100000EA or
                0x100000EB or
                0x100000EC or
                0x100000ED or
                0x100000EE or
                0x100000EF or
                0x100000F0 or
                0x100000F1 or
                0x100000F2 or
                0x100000F3 or
                0x100000F4 or
                0x100000F5 or
                0x100000F6 or
                0x100000F7 or
                0x100000F8 or
                0x100000F9 or
                0x100000FA or
                0x100000FB or
                0x100000FC or
                0x100000FD or
                0x100000FE or
                0x100000FF or
                0x10000100 or
                0x10000101 or
                0x10000102 or
                0x10000103 or
                0x10000104 or
                0x10000105 or
                0x10000106 or
                0x10000107 or
                0x10000108 or
                0x10000109 or
                0x1000010A or
                0x1000010B or
                0x1000010C or
                0x1000010D or
                0x1000010E or
                0x1000010F or
                0x10000110 or
                0x10000111 or
                0x10000112 or
                0x10000113 or
                0x10000114 or
                0x10000115 or
                0x10000116 or
                0x10000117 or
                0x10000118 or
                0x10000119 or
                0x1000011A or
                0x1000011B or
                0x1000011C or
                0x1000011D or
                0x1000011E or
                0x1000011F or
                0x10000120 or
                0x10000121 or
                0x10000122 or
                0x10000123 or
                0x10000124 or
                0x10000125 or
                0x10000126 or
                0x10000127 or
                0x10000128 or
                0x10000129 or
                0x1000012A or
                0x1000012B or
                0x1000012C or
                0x1000012D or
                0x1000012E or
                0x1000012F or
                0x10001B99 or
                0x10001C99 or
                0x10001D99 or
                0x10001E99 or
                0x10001F99 or
                0x10002099 or
                0x10005A6E or
                0x1000A3EE or
                0x1000A3FE
                => GetActorVariableValue( value, manager, objectAddress ),
                _ => Plugin.ResourceLoader.GetLuaVariable( manager, value )
            };
        }

        private static uint GetActorVariableValue( uint value, IntPtr manager, IntPtr objectAddress ) {
            var pos = Plugin.ResourceLoader.LuaActorVariables;

            for( var i = 0; i < 30; i++ ) {
                var posValue = Marshal.ReadIntPtr( pos );
                if( posValue == value ) {
                    var funcLocation = Marshal.ReadIntPtr( pos + 8 );
                    var actorFunc = Marshal.GetDelegateForFunctionPointer<LuaActorVariableDelegate>( funcLocation );
                    return actorFunc( objectAddress );
                }
                pos += 8;
            }
            //Dalamud.Log("[LUACHANGE] ");
            return Plugin.ResourceLoader.GetLuaVariable( manager, value );
        }
    }
}
