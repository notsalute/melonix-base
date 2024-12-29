using System;
using Il2CppSystem;
using MelonLoader;
using TMPro;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using VRC.Localization;

namespace neeko.Wrappers
{
    internal class Player_Wrapper
    {
        internal static GameObject GetLocalPlayer()
        {
            foreach (GameObject gameObject in Player_Wrapper.GetAllRootGameObjects())
            {
                if (gameObject.name.StartsWith("VRCPlayer[Local]"))
                {
                    return gameObject;
                }
            }
            return new GameObject();
        }
        private static GameObject[] GetAllRootGameObjects()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }
        public static void switchToAvi(string avatar_id)
        {
            PageAvatar.Method_Public_Static_Void_ApiAvatar_String_0(new ApiAvatar
            {
                id = avatar_id
            }, "AvatarMenu");
        }
        public static void ToastNotif(string content, string description = null, Sprite icon = null, float duration = 5f)
        {
            LocalizableString localizableString = LocalizableStringExtensions.Localize(content, null, null, null);
            LocalizableString localizableString2 = LocalizableStringExtensions.Localize(description, null, null, null);
            VRCUiManager.field_Private_Static_VRCUiManager_0.field_Private_HudController_0.notification.Method_Public_Void_Sprite_LocalizableString_LocalizableString_Single_Object1PublicTYBoTYUnique_1_Boolean_0(icon, localizableString, localizableString2, duration, null);
            MelonLogger.Msg(string.Concat(new string[]
            {
                "\n",
                content,
                "\n",
                description,
                "\n\n"
            }));
        }
        internal static void tpLocalPlayerToXYZ(Vector3 position)
        {
            Player_Wrapper.GetLocalPlayer().transform.position = position;
        }
        internal static void findGameObjectNChangeState(string gameobject, bool state, string worldID = null)
        {
            if (worldID != null && !RoomManager.field_Internal_Static_ApiWorld_0.id.Contains(worldID))
            {
                NeekoLog.Msg("You are not in the correct world.", "Error");
            }
            GameObject.Find(gameobject).SetActive(state);
        }
        internal static GameObject newNameplate(string name, Player player, Color color, float Yposition)
        {
            return new GameObject();
        }
        internal static void updateNameplateText(string name, GameObject gameObject)
        {
            gameObject.transform.Find("Trust Text").GetComponent<TextMeshProUGUI>().text = name;
        }
        internal static void joinWorld(string instance)
        {
            Networking.GoToRoom(instance);
        }
        internal static bool isInCorretWorld(string worldID)
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0.id.Contains(worldID))
            {
                return true;
            }
            NeekoLog.Msg("You are not in the correct world.", "Error");
            return false;
        }
        internal static void NotifyOthersUsing()
        {
            Networking.RPC(0, neeko.Main.funnyrpcobj, "am use neeko :D", new Il2CppReferenceArray<Il2CppSystem.Object>(0L));
        }
    }
}
