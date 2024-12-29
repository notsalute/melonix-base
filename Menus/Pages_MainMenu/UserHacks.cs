using System;
using neeko.PlayerHacks;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using UnityEngine;
using VRC.SDKBase;

namespace neeko.Menus.Pages_MainMenu
{
    internal class UserHacks : Main_Menu
    {
        internal static void UserHacksMenu(UiManager _uiManager)
        {
            UserHacks._playerHacks = _uiManager.QMMenu.AddCategoryPage("Player Hacks", null);
            UserHacks._playerHacks.AddCategory("Player Hacks Toggles");
            ReMenuCategory category = UserHacks._playerHacks.GetCategory("Player Hacks Toggles");
            category.AddToggle("JetPack", "JetPack", new Action<bool>(Main_Menu.ToggleJetPack), false);
            category.AddToggle("ESP", "Player ESP", new Action<bool>(Main_Menu.ToggleESP), false);
            category.AddToggle("Self Hide", "Self Hide", new Action<bool>(Main_Menu.ToggleSelfHide), false);
            category.AddToggle("Fly", "Fly", new Action<bool>(Main_Menu.ToggleFly), false);
            category.AddToggle("Speed", "Speed", new Action<bool>(Main_Menu.ToggleSpeed), false);
            UserHacks._playerHacks.AddCategory("Player Hacks Buttons");
            ReMenuCategory category2 = UserHacks._playerHacks.GetCategory("Player Hacks Buttons");
            category2.AddButton("Force Jump", "Force jump", delegate
            {
                Networking.LocalPlayer.SetJumpImpulse(3f);
            }, null);
            category2.AddButton("Print Position", "Print Position", delegate
            {
                Vector3 position = Networking.LocalPlayer.GetPosition();
                NeekoLog.Msg(string.Concat(new string[]
                {
                    "Current position: X:",
                    position.x.ToString(),
                    " Y:",
                    position.y.ToString(),
                    " Z:",
                    position.z.ToString()
                }), "UserAction", ConsoleColor.DarkMagenta);
            }, null);
            UserHacks._playerHacks.AddCategory("Fly Control");
            ReMenuCategory category3 = UserHacks._playerHacks.GetCategory("Fly Control");
            category3.AddButton("Speed ++(1)", "Speed ++(1)", delegate
            {
                FlyHack.updateFlySpeed(1f);
            }, null);
            category3.AddButton("Speed --(1)", "Speed --(1)", delegate
            {
                FlyHack.updateFlySpeed(-1f);
            }, null);
            category3.AddButton("Reset", "Reset", new Action(FlyHack.resetFlySpeed), null);
            UserHacks._playerHacks.AddCategory("Walking Speed Control");
            ReMenuCategory category4 = UserHacks._playerHacks.GetCategory("Walking Speed Control");
            category4.AddButton("Speed ++(.5)", "Speed ++(.5)", delegate
            {
                SpeedHack.updateSpeed(0.5f);
            }, null);
            category4.AddButton("Speed --(.5)", "Speed --(.5)", delegate
            {
                SpeedHack.updateSpeed(-0.5f);
            }, null);
            category4.AddButton("Reset", "Reset", new Action(SpeedHack.resetSpeed), null);
        }
        private static ReCategoryPage _playerHacks;
    }
}
