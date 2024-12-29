using System;
using neeko.GameWorlds;
using neeko.ResourceManager;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;

namespace neeko.Menus.Pages_TargetMenu
{
    internal class Murder4Page : Target_Menu
    {
        internal static void Murder4PageMenu(UiManager _uiManager)
        {
            IButtonPage targetMenu = _uiManager.TargetMenu;
            targetMenu.AddMenuPage("Murder Hacks Menu", "Murder Hacks Menu");
            ReMenuPage menuPage = targetMenu.GetMenuPage("Murder Hacks Menu");
            menuPage.AddButton("Kill Player", "Kill Player", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncKill");
                }
            }, null);
            menuPage.AddButton("Set Murderer", "Set Murderer", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncAssignM");
                }
            }, null);
            menuPage.AddButton("Set Bystander", "Set Bystander", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncAssignB");
                }
            }, null);
            menuPage.AddButton("Set Detective", "Set Detective", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(PlayerExtensions.GetVRCPlayer(), "SyncAssignD");
                }
            }, null);
            menuPage.AddButton("Bring Knife", "Bring Knife", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.knifeSummoner(PlayerExtensions.GetVRCPlayer());
                }
            }, null);
            menuPage.AddButton("Bring Revolver", "Bring Revolver", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.summonTool(PlayerExtensions.GetVRCPlayer(), "Revolver");
                }
            }, null);
            menuPage.AddButton("Bring ShotGun", "Bring ShotGun", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.summonTool(PlayerExtensions.GetVRCPlayer(), "Shotgun (0)");
                }
            }, null);
            menuPage.AddButton("Bring Luger", "Bring Luger", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.summonTool(PlayerExtensions.GetVRCPlayer(), "Luger (0)");
                }
            }, null);
        }
        private static ReCategoryPage _murder4Hacks;
    }
}
