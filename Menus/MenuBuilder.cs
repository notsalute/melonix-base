using System;
using neeko.Config;
using neeko.Wrappers;
using ReMod.Core.Managers;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace neeko.Menus
{
    public class MenuBuilder
    {
        internal static UiManager _uiManager;
        internal static void MenuStart()
        {
            NeekoLog.Msg("Initializing UI...", "Ini", ConsoleColor.Green);
            _uiManager = new UiManager("Neeko#9879", null, true, true);
            //_uiManager.QMMenu.AddButton("Neeko mod", "1.0.1.4", 25);
            Main_Menu.InitMainMenu(_uiManager);
            //Target_Menu.InitMainMenu(_uiManager);
            //LaunchPad_Menu.InitLaunchPadMenu(_uiManager);
        }
    }
}
