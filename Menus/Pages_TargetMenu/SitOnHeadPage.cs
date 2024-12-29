using System;
using neeko.PlayerHacks;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.VRChat;
using UnityEngine;
using VRC.SDKBase;

namespace neeko.Menus.Pages_TargetMenu
{
    internal class SitOnHeadPage : Target_Menu
    {
        internal static void SitOnHeadPagePageMenu(UiManager _uiManager)
        {
            IButtonPage targetMenu = _uiManager.TargetMenu;
            targetMenu.AddMenuPage("SitOnHead Hacks Menu", "SitOnHead Hacks Menu");
            ReMenuPage menuPage = targetMenu.GetMenuPage("SitOnHead Hacks Menu");
            menuPage.AddButton("Sit On Head", "Sit On Head", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)10);
            }, null);
            menuPage.AddButton("Sit On Neck", "Sit On Neck", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)9);
            }, null);
            menuPage.AddButton("Sit On LeftUpperArm", "Sit On LeftUpperArm", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)13);
            }, null);
            menuPage.AddButton("Sit On LeftShoulder", "Sit On LeftShoulder", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)11);
            }, null);
            menuPage.AddButton("Sit On LeftHand", "Sit On LeftHand", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)17);
            }, null);
            menuPage.AddButton("Sit On LeftFoot", "Sit On LeftFoot", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)5);
            }, null);
            menuPage.AddButton("Sit On RightUpperArm", "Sit On RightUpperArm", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)14);
            }, null);
            menuPage.AddButton("Sit On RightShoulder", "Sit On RightShoulder", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)12);
            }, null);
            menuPage.AddButton("Sit On RightHand", "Sit On RightHand", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)18);
            }, null);
            menuPage.AddButton("Sit On RightFoot", "Sit On RightFoot", delegate
            {
                SitOnHeadPage.SetOn((HumanBodyBones)6);
            }, null);
        }
        private static void SetOn(HumanBodyBones bone)
        {
            VRCPlayerApi field_Private_VRCPlayerApi_ = PlayerExtensions.GetVRCPlayer().field_Private_VRCPlayerApi_0;
            if (field_Private_VRCPlayerApi_ == null)
            {
                return;
            }
            SitOn.sitOnPlayer(bone, field_Private_VRCPlayerApi_, VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0);
            SitOn.SitOnEnabled = true;
        }
        private static ReCategoryPage _sitOnHeadHacks;
    }
}
