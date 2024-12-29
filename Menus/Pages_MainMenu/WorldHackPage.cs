using System;
using neeko.Config;
using neeko.WorldHacks;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using VRC.Core;

namespace neeko.Menus.Pages_MainMenu
{
    internal class WorldHackPage : Main_Menu
    {
        internal static void WorldHacksMenu(UiManager _uiManager)
        {
            WorldHackPage._worldHacks = _uiManager.QMMenu.AddCategoryPage("World Hacks", null);
            WorldHackPage._worldHacks.AddCategory("World Hacks Toggles");
            ReMenuCategory category = WorldHackPage._worldHacks.GetCategory("World Hacks Toggles");

            category.AddToggle("Item ESP", "Item ESP", new Action<bool>(Main_Menu.ToggleItemESP), false);
            category.AddToggle("Trigger ESP", "Trigger ESP", new Action<bool>(Main_Menu.ToggleTriggerESP), false);
            category.AddToggle("Udon ESP", "Udon ESP", new Action<bool>(Main_Menu.ToggleUdonESP), false);
            category.AddToggle("Disable Pickups", "Disable Pickups", new Action<bool>(Main_Menu.DisablePickups), false);
            category.AddToggle("Items Not Pickable", "Items Not Pickable", new Action<bool>(Main_Menu.ItemNotPickable), false);
            category.AddToggle("HeadLight", "HeadLight", new Action<bool>(Main_Menu.HeadLightToggle), false);
            WorldHackPage._worldHacks.AddCategory("World Hacks Buttons");
            ReMenuCategory category2 = WorldHackPage._worldHacks.GetCategory("World Hacks Buttons");
            category2.AddButton("Respawn Pickups", "Respawn Pickups", new Action(Pickups.respawnAllObjects), null);
            category2.AddButton("Force Pickups", "Force Pickups", new Action(Pickups.forcePickup), null);
            category2.AddButton("Print WorldInfo", "Print WorldInfo", delegate
            {
                ApiWorld field_Internal_Static_ApiWorld_ = RoomManager.field_Internal_Static_ApiWorld_0;
                ApiWorldInstance field_Internal_Static_ApiWorldInstance_ = RoomManager.prop_ApiWorldInstance_1;
                NeekoLog.Msg(string.Concat(new string[]
                {
                    field_Internal_Static_ApiWorld_.name,
                    " By:",
                    field_Internal_Static_ApiWorld_.authorName,
                    " Type:(",
                    field_Internal_Static_ApiWorldInstance_.type.ToString(),
                    ") - ",
                    field_Internal_Static_ApiWorldInstance_.location
                }), "UserAction", ConsoleColor.DarkMagenta);
            }, null);
            category2.AddButton("Delete Portals", "Delete Portals", delegate
            {
                NeekoLog.Msg("You have removed " + Portals.removePortals().ToString() + " portal/s.", "UserAction", ConsoleColor.DarkMagenta);
            }, null);
            category2.AddButton("Download WCA", "Download WCA", delegate
            {
                if (RoomManager.field_Internal_Static_ApiWorld_0.assetUrl != null)
                {
                    NeekoLog.Msg("World: " + RoomManager.field_Internal_Static_ApiWorld_0.name + " Asset url : " + RoomManager.field_Internal_Static_ApiWorld_0.assetUrl, "UserAction", ConsoleColor.DarkMagenta);
                }
            }, null);
            WorldHackPage._worldHacks.AddCategory("HeadLight Settings");
            ReMenuCategory category3 = WorldHackPage._worldHacks.GetCategory("HeadLight Settings");
            category3.AddButton("Power ++(.25)", "Power ++(.25)", delegate
            {
                if (ConfManager.headLightPower.Value > 5f)
                {
                    return;
                }
                HeadLightLocal.updateHeadLightValue(0.25f, 0);
            }, null);
            category3.AddButton("Power --(.25)", "Power --(.25)", delegate
            {
                if (ConfManager.headLightPower.Value < 0f)
                {
                    return;
                }
                HeadLightLocal.updateHeadLightValue(-0.25f, 0);
            }, null);
            category3.AddButton("Range ++(1)", "Range ++(1)", delegate
            {
                if (ConfManager.headLightRange.Value > 20)
                {
                    return;
                }
                HeadLightLocal.updateHeadLightValue(0f, 1);
            }, null);
            category3.AddButton("Range --(1)", "Range --(1)", delegate
            {
                if (ConfManager.headLightRange.Value < 0)
                {
                    return;
                }
                HeadLightLocal.updateHeadLightValue(0f, -1);
            }, null);
        }
        private static ReCategoryPage _worldHacks;
    }
}
