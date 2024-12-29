using System;
using MelonLoader;
using neeko.Config;
using neeko.Menus.Pages_MainMenu;
using neeko.PlayerHacks;
using neeko.WorldHacks;
using neeko.Wrappers;
using ReMod.Core.Managers;
using VRC;
using VRC.Core;
using VRC.UI;

namespace neeko.Menus
{
    internal class Main_Menu
    {
        public static void InitMainMenu(UiManager UIManager)
        {
            Main_Menu._uiManager = UIManager;
            NeekoLog.Msg("Initializing Main Menu...", "Ini", ConsoleColor.Green);
            try
            {
                LaunchPad_Menu.InitLaunchPadMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing LaunchPadMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                Target_Menu.InitMainMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing Target_Menu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                UserHacks.UserHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing UserHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                WorldHackPage.WorldHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing WorldHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                NetworkHacks.NetworkHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing NetworkHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                GameWorldHacks.GameWorldHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing GameWorldHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                ItemManipulator.ManipulatorHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing ManipulatorHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                InstaceHistory.InstaceHistoryHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing InstaceHistoryHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                LastSeenAvatars.LastSeenAvatarsHacksMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing LastSeenAvatarsHacksMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            _uiManager.QMMenu.AddSpacer(null); _uiManager.QMMenu.AddSpacer(null);
            _uiManager.QMMenu.AddSpacer(null); _uiManager.QMMenu.AddSpacer(null);
            _uiManager.QMMenu.AddSpacer(null); _uiManager.QMMenu.AddSpacer(null);
            _uiManager.QMMenu.AddSpacer(null);
            try
            {
                ModSettings.ModSettingsMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing ModSettingsMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            try
            {
                ContributorsPage.ContributorsMenu(Main_Menu._uiManager);
            }
            catch (Exception ex)
            {
                NeekoLog.Msg($"Error while initializing ContributorsMenu\n{ex.Message}", "Ini", ConsoleColor.Red);
            }
            NeekoLog.Msg("Neeko Initialized.", "Ini", ConsoleColor.Green);
        }
        internal static void ToggleSelfHide(bool value)
        {
            SelfHide.SelfHideEnabled = value;
            SelfHide.selfhidePlayer();
        }
        internal static void ToggleESP(bool value)
        {
            if (!PlayerESP.PlayerESPEnabled || value)
            {
                if (!PlayerESP.PlayerESPEnabled && value)
                {
                    PlayerESP.PlayerESPEnabled = true;
                }
            }
            else
            {
                PlayerESP.PlayerESPEnabled = false;
            }
            PlayerESP.espmethod();
        }
        internal static void ToggleItemESP(bool value)
        {
            Pickups.ItemESPEnabled = !Pickups.ItemESPEnabled;
            Pickups.itemESP();
        }
        public static void ChangeAvatar(string avatar_id)
        {
            PageAvatar.Method_Public_Static_Void_ApiAvatar_String_0(new ApiAvatar
            {
                id = avatar_id
            }, "AvatarMenu");
        }
        internal static void ToggleSpeed(bool value)
        {
            if (!SpeedHack.SpeedEnabled || value)
            {
                if (!SpeedHack.SpeedEnabled && value)
                {
                    SpeedHack.SpeedEnabled = true;
                }
            }
            else
            {
                SpeedHack.SpeedEnabled = false;
            }
            SpeedHack.setSpeedToggle();
        }
        internal static void ToggleJetPack(bool value)
        {
            FlyHack.jetPackEnabled = value;
        }
        internal static void DisablePickups(bool value)
        {
            Pickups.disablePickupsEnabled = value;
            Pickups.disablePickups();
        }
        internal static void UdonNetworkTargetToggle(bool value)
        {
            ItemManipulator.udonNetworkTarget = ((VRC.Udon.Common.Interfaces.NetworkEventTarget)(value ? 0 : 1));
        }
        internal static void ItemNotPickable(bool value)
        {
            Pickups.itemsAreNotPickableEnabled = value;
            Pickups.itemsAreNotPickable();
        }
        internal static void HeadLightToggle(bool value)
        {
            HeadLightLocal.HeadLightLocalEnabled = value;
            HeadLightLocal.headLight();
        }
        internal static void ToggleFly(bool value)
        {
            if (!FlyHack.flyEnabled || value)
            {
                if (!FlyHack.flyEnabled && value)
                {
                    FlyHack.flyEnabled = true;
                    return;
                }
            }
            else
            {
                FlyHack.flyEnabled = false;
            }
        }
        internal static void ToggleTriggerESP(bool value)
        {
            Pickups.TriggerESPEnabled = value;
            Pickups.triggerESP();
        }
        internal static void ToggleUdonESP(bool value)
        {
            Pickups.UdonESPEnabled = value;
            Pickups.udonESP();
        }
        internal static void FakePingToggle(bool value)
        {
            ConfManager.fakePingEnabled.Value = value;
            MelonPreferences.Save();
        }
        internal static void FakeFPSToggle(bool value)
        {
            ConfManager.fakeFPSEnabled.Value = value;
            MelonPreferences.Save();
        }
        internal static void FakePingFPSFluctuateToggle(bool value)
        {
            ConfManager.ping_FPSFluctuate.Value = value;
            MelonPreferences.Save();
        }
        internal static void UdonLoggerToggle(bool value)
        {
            ConfManager.udonLogger.Value = value;
            MelonPreferences.Save();
        }
        internal static void AvatarLoggerToggle(bool value)
        {
            ConfManager.avatarLogging.Value = value;
            MelonPreferences.Save();
        }
        internal static void PlayerLoggerToggle(bool value)
        {
            ConfManager.playerLogger.Value = value;
            MelonPreferences.Save();
        }
        internal static void RPCLoggerToggle(bool value)
        {
            ConfManager.rpcLogger.Value = value;
            MelonPreferences.Save();
        }
        internal static void AntiUdonToggle(bool value)
        {
            ConfManager.antiUdon.Value = value;
            MelonPreferences.Save();
        }
        internal static void AntiTPRPCToggle(bool value)
        {
            ConfManager.antiTPRPC.Value = value;
            MelonPreferences.Save();
        }
        internal static void AntiInvalidRPCToggle(bool value)
        {
            ConfManager.antiInvalidRPC.Value = value;
            MelonPreferences.Save();
        }
        internal static void AntiRPCToggle(bool value)
        {
            ConfManager.antiRPC.Value = value;
            MelonPreferences.Save();
        }
        internal static void BlockWorldTriggersToggle(bool value)
        {
            ConfManager.blockWorldTriggers.Value = value;
            MelonPreferences.Save();
        }
        internal static void ToggleCustomLaunchPadImage(bool value)
        {
            ConfManager.allowCustomBackGround.Value = value;
            MelonPreferences.Save();
        }
        internal static void ToggleShowLaunchPadButtons(bool value)
        {
            ConfManager.showLaunchPadButtons.Value = value;
            MelonPreferences.Save();
        }
        internal static void setNamePlateUpdateTime(int secounds)
        {
            ConfManager.namePlateUpdateTime.Value = secounds;
            MelonPreferences.Save();
        }
        private static UiManager _uiManager;
    }
}