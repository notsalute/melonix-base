using System;
using System.Linq;
using System.Reflection;
using ExitGames.Client.Photon;
using HarmonyLib;
using neeko.Menus.Pages_MainMenu;
using neeko.Menus;
using neeko.Wrappers;
using UnityEngine;
using VRC.Networking;
using VRC.SDKBase;

namespace neeko.Network
{
    public class Patches
    {
        internal static void initPatches(HarmonyLib.Harmony instance)
        {
            NeekoLog.Msg("Initializing Patches...", "Ini", ConsoleColor.Green);
            try
            {
                instance.Patch(AccessTools.Property(typeof(Time), "smoothDeltaTime").GetMethod, null, NetworkHelper.GetLocalPatch<FakeFPS>("Frame"), null, null, null);
                NeekoLog.Msg("SmoothDeltaTime Hooked", "Hooks", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing Hook SmoothDeltaTime\n{ex.Message}", "Ini", ConsoleColor.Green); ;
            }
            try
            {
                instance.Patch(typeof(VRC_EventHandler).GetMethod("InternalTriggerEvent"), NetworkHelper.GetLocalPatch<TriggerWorld>("OnTriggerWorld"), null, null, null, null);
                NeekoLog.Msg("VRC_EventHandler Hooked", "Hooks", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing Hook VRC_EventHandler\n{ex.Message}", "Ini", ConsoleColor.Green); ;
            }
            try
            {
                instance.Patch(typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), NetworkHelper.GetLocalPatch<Udon>("OnUdon"), null, null, null, null);
                NeekoLog.Msg("UdonSync Hooked", "Hooks", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing Hook UdonSync\n{ex.Message}", "Ini", ConsoleColor.Green); ;
            }
            try
            {
                instance.Patch(typeof(VRC_EventDispatcherRFC).GetMethod("Method_Public_Boolean_Player_VrcEvent_VrcBroadcastType_0"), NetworkHelper.GetLocalPatch<RPC>("onRPC"), null, null, null, null);
                NeekoLog.Msg("VRC_EventDispatcherRFC Hooked", "Hooks", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing Hook VRC_EventDispatcherRFC\n{ex.Message}", "Ini", ConsoleColor.Green); ;
            }
            try
            {
                instance.Patch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_PDM_1"), NetworkHelper.GetLocalPatch<PlayerEvent>("OnLeaveEvent"), null, null, null, null);
                instance.Patch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_PDM_0"), NetworkHelper.GetLocalPatch<PlayerEvent>("OnJoinEvent"), null, null, null, null);
                NeekoLog.Msg("NetworkManager Hooked", "Hooks", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing Hook NetworkManager\n{ex.Message}", "Ini", ConsoleColor.Green); ;
            }
            instance.Patch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_PDM_1"), NetworkHelper.GetLocalPatch<PlayerEvent>("OnLeaveEvent"), null, null, null, null);
            (from m in typeof(VRCPlayer).GetMethods()
             where m.Name.StartsWith("Method_Private_Void_GameObject_VRC_AvatarDescriptor_")
             select m).ToList<MethodInfo>().ForEach(delegate (MethodInfo m)
             {
                 instance.Patch(typeof(VRCPlayer).GetMethod(m.Name), NetworkHelper.GetLocalPatch<AvatarLoaded>("OnAvaLoaded"), null, null, null, null);
             });
        }
    }
}
