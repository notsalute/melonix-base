#region Using shit
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.DataModel;
using VRC.SDKBase;
using VRC.UI.Elements.Menus;
using VRC.Udon;
using UnityEngine.UI;
using ReMod.Core.Managers;
using ReMod.Core.Unity;
using ReMod.Core.VRChat;
using ReMod.Core.UI.QuickMenu;
using System.Diagnostics;
using VRC.Udon.Common.Interfaces;
using VRC.SDK3.Components;
using VRC.UI.Core.Styles;
using ReMod.Core.UI.ActionMenu;
using VRC.Animation;
using VRC.UI.Elements.Controls;
using TMPro;
using ReMod.Core.UI.MainMenu;
using ExitGames.Client.Photon;
using System.Security.Policy;
using neeko.Config;
using neeko.Wrappers;
using neeko.Network;
using neeko.Menus.Pages_MainMenu;
using neeko.PlayerHacks;
using neeko.WorldHacks;
#endregion

namespace neeko
{
    class Main : MelonMod
    {
        internal static GameObject funnyrpcobj;
        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<EnableDisableListener>();
            ConfManager.FolderCheck();
            //neeko.ResourceManager.Resources.InitResources();
            ConfManager.initConfig();
            CompatibilityCheck.iniCheck();
            Patches.initPatches(base.HarmonyInstance);
            MelonCoroutines.Start(WaitForUI());
            MelonPreferences.Load();
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex == -1)
            {
                //InstaceHistory.instanceAction();
                ItemManipulator.refreshPickups();
                ItemManipulator.disableSelection();
                if (GameObject.Find("neekorpcfunni") == null)
                {
                    funnyrpcobj = new GameObject("neekorpcfunni");
                }
                if (Pickups.itemsAreNotPickableEnabled)
                {
                    Pickups.itemsAreNotPickable();
                }
                if (Pickups.disablePickupsEnabled)
                {
                    Pickups.disablePickups();
                }
                MelonCoroutines.Start(WaitForInstace());
            }
        }
        public override void OnUpdate()
        {
            FlyHack.fly();
            FlyHack.jetPack();
            SitOn.sitOnPlayerUpdate();
            ItemManipulator.freezeItemUpdate();
            CustomNamePlates.NameplateUpdate();
        }
        private IEnumerator WaitForInstace()
        {
            while (RoomManager.field_Private_Static_ApiWorldInstance_0 == null)
            {
                yield return null;
            }
            while (RoomManager.field_Internal_Static_ApiWorld_0 == null)
            {
                yield return null;
            }
            WorldLoggerHandler.Log(RoomManager.field_Internal_Static_ApiWorld_0, RoomManager.field_Private_Static_ApiWorldInstance_0);
            yield break;
        }
        private IEnumerator WaitForUI()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null)
            {
                yield return null;
            }
            Menus.MenuBuilder.MenuStart();
            yield break;
        }
    }
}