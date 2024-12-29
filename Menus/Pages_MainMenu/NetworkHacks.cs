using System;
using MelonLoader;
using neeko.Config;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using VRC;

namespace neeko.Menus.Pages_MainMenu
{
    internal class NetworkHacks : Main_Menu
    {
        internal static void NetworkHacksMenu(UiManager _uiManager)
        {
            _networkhacks = _uiManager.QMMenu.AddCategoryPage("Network Hacks", null);
            _networkhacks.AddCategory("Fake FPS/Ping Settings");
            ReMenuCategory category = _networkhacks.GetCategory("Fake FPS/Ping Settings");
            category.AddToggle("Fake Ping", "Fake Ping", delegate (bool s)
            {
                Main_Menu.FakePingToggle(s);
            });
            category.AddToggle("Fake FPS", "Fake FPS", delegate (bool s)
            {
                Main_Menu.FakeFPSToggle(s);
            });
            category.AddToggle("Fake Fluctuate", "Fake Fluctuate", delegate (bool s)
            {
                Main_Menu.FakePingFPSFluctuateToggle(s);
            }); 
            category.AddButton("Range (1+)", "Range (1+)", delegate
            {
                MelonPreferences_Entry<int> fluctuateRange = ConfManager.fluctuateRange;
                int value = fluctuateRange.Value;
                fluctuateRange.Value = value + 1;
                MelonPreferences.Save();
            }, null);
            category.AddButton("Range (1-)", "Range (1-)", delegate
            {
                MelonPreferences_Entry<int> fluctuateRange = ConfManager.fluctuateRange;
                int value = fluctuateRange.Value;
                fluctuateRange.Value = value - 1;
                MelonPreferences.Save();
            }, null);
            category.AddButton("FPS ++", "FPS ++", delegate
            {
                MelonPreferences_Entry<float> fakeFPS = ConfManager.fakeFPS;
                float value = fakeFPS.Value;
                fakeFPS.Value = value + 1f;
                MelonPreferences.Save();
            }, null);
            category.AddButton("FPS --", "FPS --", delegate
            {
                MelonPreferences_Entry<float> fakeFPS = ConfManager.fakeFPS;
                float value = fakeFPS.Value;
                fakeFPS.Value = value - 1f;
                MelonPreferences.Save();
            }, null);
            category.AddButton("Ping ++", "Ping ++", delegate
            {
                MelonPreferences_Entry<int> fakePing = ConfManager.fakePing;
                int value = fakePing.Value;
                fakePing.Value = value + 1;
                MelonPreferences.Save();
            }, null);
            category.AddButton("Ping --", "Ping --", delegate
            {
                MelonPreferences_Entry<int> fakePing = ConfManager.fakePing;
                int value = fakePing.Value;
                fakePing.Value = value - 1;
                MelonPreferences.Save();
            }, null);
            NetworkHacks._networkhacks.AddCategory("Anti Settings");
            ReMenuCategory category2 = NetworkHacks._networkhacks.GetCategory("Anti Settings");
            category2.AddToggle("Block Udon", "Block Udon", new Action<bool>(Main_Menu.AntiUdonToggle), ConfManager.antiUdon.Value);
            category2.AddToggle("Block RPC", "Block RPC", new Action<bool>(Main_Menu.AntiRPCToggle), ConfManager.antiRPC.Value);
            category2.AddToggle("Block Invalid RPC", "Block Invalid RPC", new Action<bool>(Main_Menu.AntiInvalidRPCToggle), ConfManager.antiInvalidRPC.Value);
            category2.AddToggle("Block TP-RPC SDK2", "Block TP-RPC SDK2", new Action<bool>(Main_Menu.AntiTPRPCToggle), ConfManager.antiTPRPC.Value);
            category2.AddToggle("Block World Triggers SDK2", "Block World Triggers SDK2", new Action<bool>(Main_Menu.BlockWorldTriggersToggle), ConfManager.blockWorldTriggers.Value);
            NetworkHacks._networkhacks.AddCategory("Logger Settings");
            ReMenuCategory category3 = NetworkHacks._networkhacks.GetCategory("Logger Settings");
            category3.AddToggle("Udon Logger", "Udon Logger", new Action<bool>(Main_Menu.UdonLoggerToggle), ConfManager.udonLogger.Value);
            category3.AddToggle("RPC Logger", "RPC Logger", new Action<bool>(Main_Menu.RPCLoggerToggle), ConfManager.rpcLogger.Value);
            category3.AddToggle("Avatar Logger", "Avatar Logger", new Action<bool>(Main_Menu.AvatarLoggerToggle), ConfManager.avatarLogging.Value);
            category3.AddToggle("Player Join/Leave Logger", "Player Join/Leave Logger", new Action<bool>(Main_Menu.PlayerLoggerToggle), ConfManager.playerLogger.Value);
        }

        // Token: 0x04000099 RID: 153
        private static ReCategoryPage _networkhacks;
    }
}
