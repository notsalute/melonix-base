using neeko.Config;
using neeko.Wrappers;
using ReMod.Core.UI.QuickMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReMod;
using ReMod.Core.Managers;

namespace neeko.Menus
{
    internal class LaunchPad_Menu : Main_Menu
    {
        private static UiManager _uiManager;
        public static void InitLaunchPadMenu(UiManager UIManager)
        {
            LaunchPad_Menu._uiManager = UIManager;
            NeekoLog.Msg("Initializing LaunchPad Menu...", "Ini", ConsoleColor.Green);
            IButtonPage launchPad = LaunchPad_Menu._uiManager.LaunchPad;
            if (!ConfManager.showLaunchPadButtons.Value)
            {
                return;
            }
            launchPad.AddToggle("Fly", "Fly", new Action<bool>(Main_Menu.ToggleFly), false);
            //launchPad.AddToggle("JetPack", "JetPack", new Action<bool>(Main_Menu.ToggleJetPack), false);
            launchPad.AddToggle("Speed", "Speed", new Action<bool>(Main_Menu.ToggleSpeed), false);
            launchPad.AddToggle("ESP", "Player ESP", new Action<bool>(Main_Menu.ToggleESP), false);
        }
    }
}
