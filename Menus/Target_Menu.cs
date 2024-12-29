using System;
using neeko.Menus.Pages_TargetMenu;
using neeko.WorldHacks;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;
using UnityEngine;

namespace neeko.Menus
{
    internal class Target_Menu
    {
        public static void InitMainMenu(UiManager UIManager)
        {
            Target_Menu._uiManager = UIManager;
            NeekoLog.Msg("Initializing Target Menu...", "Ini", ConsoleColor.Green);
            IButtonPage targetMenu = Target_Menu._uiManager.TargetMenu;
            targetMenu.AddButton("Teleport", "Teleports to target.", delegate
            {
                Transform transform = PlayerExtensions.GetVRCPlayer().transform;
                VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.TeleportTo(transform.position, transform.rotation);
            }, null);
            SitOnHeadPage.SitOnHeadPagePageMenu(Target_Menu._uiManager);
            targetMenu.AddButton("Bring Objects to target", "Bring Objects to target.", delegate
            {
                VRCPlayer vrcplayer = PlayerExtensions.GetVRCPlayer();
                if (vrcplayer != null)
                {
                    Pickups.bringPickupsToTarget(vrcplayer);
                }
            }, null);
            targetMenu.AddButton("Force Clone", "Force Clone.", delegate
            {
                VRCPlayer vrcplayer = PlayerExtensions.GetVRCPlayer();
                if (vrcplayer == null)
                {
                    return;
                }
                if (vrcplayer._player.prop_ApiAvatar_0.releaseStatus != "public")
                {
                    NeekoLog.Msg("This avatar is private.", "UserAction", ConsoleColor.DarkMagenta);
                    Player_Wrapper.ToastNotif("Neeko", "This avatar is private.");
                    return;
                }
                Player_Wrapper.switchToAvi(vrcplayer._player.prop_ApiAvatar_0.id);
            }, null);
            targetMenu.AddButton("Download VRCA", "Download VRCA", delegate
            {
                VRCPlayer vrcplayer = PlayerExtensions.GetVRCPlayer();
                if (vrcplayer == null)
                {
                    return;
                }
                string str = "None";
                if (vrcplayer._player.prop_ApiAvatar_0.assetUrl != null)
                {
                    str = vrcplayer._player.prop_ApiAvatar_0.assetUrl;
                }
                NeekoLog.Msg("Avatar Asset url : " + str, "UserAction", ConsoleColor.DarkMagenta);
            }, null);
            targetMenu.AddButton("Print UserID to log", "Print UserID to log.", delegate
            {
                VRCPlayer vrcplayer = PlayerExtensions.GetVRCPlayer();
                if (vrcplayer != null)
                {
                    NeekoLog.Msg("Selected User ID: " + vrcplayer._player.field_Private_APIUser_0.id, "UserAction", ConsoleColor.DarkMagenta);
                }
            }, null);
            targetMenu.AddButton("Print AvatarID to log", "Print AvatarID to log.", delegate
            {
                VRCPlayer vrcplayer = PlayerExtensions.GetVRCPlayer();
                if (vrcplayer != null)
                {
                    NeekoLog.Msg("Selected Avatar ID: " + vrcplayer._player.prop_ApiAvatar_0.id, "UserAction", ConsoleColor.DarkMagenta);
                }
            }, null);
            neeko.Menus.Pages_TargetMenu.Murder4Page.Murder4PageMenu(_uiManager);
            neeko.Menus.Pages_TargetMenu.AmongASS_IhateMyselfPage.AmongASS_IhateMyselfPageMenu(_uiManager);
        }
        private static UiManager _uiManager;
        private static ReCategoryPage _murderCatapage;
    }
}
