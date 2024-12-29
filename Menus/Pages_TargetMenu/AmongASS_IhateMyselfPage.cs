using System;
using neeko.GameWorlds;
using neeko.ResourceManager;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;

namespace neeko.Menus.Pages_TargetMenu
{
    internal class AmongASS_IhateMyselfPage : Target_Menu
    {
        internal static void AmongASS_IhateMyselfPageMenu(UiManager _uiManager)
        {
            IButtonPage targetMenu = _uiManager.TargetMenu;
            targetMenu.AddMenuPage("Among Ass Hacks Menu", "Among Ass Hacks Menu", Resources.gameAmongASSIcon);
            ReMenuPage menuPage = targetMenu.GetMenuPage("Among Ass Hacks Menu");
            menuPage.AddButton("Kill Player", "Kill Player", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncKill");
                }
            }, null);
            menuPage.AddButton("Set Crew", "Set Crew", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncAssignB");
                }
            }, null);
            menuPage.AddButton("Set Imposter", "Set Imposter", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncAssignM");
                }
            }, null);
        }
        private static ReCategoryPage _murder4Hacks;
    }
}
