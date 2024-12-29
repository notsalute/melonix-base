using System;
using neeko.Config;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace neeko.Menus.Pages_MainMenu
{
    internal class ModSettings : Main_Menu
    {
        public static void ModSettingsMenu(UiManager UIManager)
        {
            ReCategoryPage reCategoryPage = UIManager.QMMenu.AddCategoryPage("Mod Settings", null);
            reCategoryPage.AddCategory("Mod Settings");
            ReMenuCategory category = reCategoryPage.GetCategory("Mod Settings");
            category.AddToggle("LaunchPadImg (Restart)", "CustomLaunchPadImage", new Action<bool>(Main_Menu.ToggleCustomLaunchPadImage), ConfManager.allowCustomBackGround.Value);
            category.AddToggle("LaunchPadBtns (Restart)", "ShowLaunchPadButtons", new Action<bool>(Main_Menu.ToggleShowLaunchPadButtons), ConfManager.showLaunchPadButtons.Value);
            category.AddButton("Clear Avatar Last Seen History", "Clear Avatar last seen history", new Action(AvatarLoggerHandler.Clear), null);
            category.AddButton("Clear Instance History", "Clear Avatar last seen history", new Action(WorldLoggerHandler.Clear), null);
            category.AddButton("Force Neeko RPC Notify", "Force Neeko RPC Notify", new Action(Player_Wrapper.NotifyOthersUsing), null);
            reCategoryPage.AddCategory("NamePlate Update (Default 2s)");
            ReMenuCategory category2 = reCategoryPage.GetCategory("NamePlate Update (Default 2s)");
            category2.AddButton("Every 1s", "Every 1s", delegate
            {
                Main_Menu.setNamePlateUpdateTime(1);
            }, null);
            category2.AddButton("Every 2s", "Every 2s", delegate
            {
                Main_Menu.setNamePlateUpdateTime(2);
            }, null);
            category2.AddButton("Every 3s", "Every 3s", delegate
            {
                Main_Menu.setNamePlateUpdateTime(3);
            }, null);
            category2.AddButton("Every 4s", "Every 4s", delegate
            {
                Main_Menu.setNamePlateUpdateTime(4);
            }, null);
        }
        private static UiManager _uiManager;
    }
}
