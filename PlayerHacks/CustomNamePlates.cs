using System;
using System.Collections.Generic;
using MelonLoader;
using neeko.Config;
using neeko.Wrappers;
using UnityEngine;
using VRC;

namespace neeko.PlayerHacks
{
    internal class CustomNamePlates
    {
        internal static void removePlayerFromCache(Player player)
        {
            if (player._vrcplayer == null || player._vrcplayer.field_Private_VRCPlayerApi_0 == null || VRCPlayer.field_Internal_Static_VRCPlayer_0 == null || VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0 == null || VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.playerId == player._vrcplayer.field_Private_VRCPlayerApi_0.playerId)
            {
                return;
            }
            CustomNamePlates.cachedPlayers.Remove(player._vrcplayer.field_Private_VRCPlayerApi_0.playerId);
        }
        #region addPlayerFromCache
        internal static void addPlayerFromCache(Player player)
        {
            if (player._vrcplayer == null || player._vrcplayer.field_Private_VRCPlayerApi_0 == null || VRCPlayer.field_Internal_Static_VRCPlayer_0 == null || VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0 == null || VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.playerId == player._vrcplayer.field_Private_VRCPlayerApi_0.playerId)
            {
                return;
            }
            GameObject item = Player_Wrapper.newNameplate("ini", player._vrcplayer._player, CustomNamePlates.color, 30f);
            CustomNamePlates.cachedPlayers.Add(player._vrcplayer.field_Private_VRCPlayerApi_0.playerId, new Tuple<VRCPlayer, GameObject, string, int, int>(player._vrcplayer, item, "", 0, 0));
        }
        #endregion
        #region updateUserClient
        internal static void updateUserClient(int photonID, string client)
        {
            if (!CustomNamePlates.cachedPlayers.ContainsKey(photonID))
            {
                return;
            }
            VRCPlayer vrcplayer;
            GameObject gameObject;
            string text;
            int num;
            int num2;
            CustomNamePlates.cachedPlayers[photonID].Deconstruct(out vrcplayer, out gameObject, out text, out num, out num2);
            VRCPlayer item = vrcplayer;
            GameObject item2 = gameObject;
            int item3 = num;
            int item4 = num2;
            CustomNamePlates.cachedPlayers.Remove(photonID);
            CustomNamePlates.cachedPlayers.Add(photonID, new Tuple<VRCPlayer, GameObject, string, int, int>(item, item2, client, item3, item4));
        }
        #endregion
        #region NameplateUpdate
        internal static void NameplateUpdate()
        {
            if (DateTime.UtcNow <= CustomNamePlates.check || CustomNamePlates.cachedPlayers.Count <= 0)
            {
                return;
            }
            CustomNamePlates.check = DateTime.UtcNow.AddMilliseconds((double)ConfManager.namePlateUpdateTime.Value * 1000.0);
            Dictionary<int, Tuple<VRCPlayer, GameObject, string, int, int>> dictionary = new Dictionary<int, Tuple<VRCPlayer, GameObject, string, int, int>>();
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, Tuple<VRCPlayer, GameObject, string, int, int>> keyValuePair in CustomNamePlates.cachedPlayers)
            {
                int num = MelonUtils.Clamp<int>((int)(1000f / (float)keyValuePair.Value.Item1._playerNet.field_Private_Byte_0), -999, 999);
                int num2 = MelonUtils.Clamp<int>((int)keyValuePair.Value.Item1._playerNet._vrcPlayer.prop_Int16_1, -999, 999);
                dictionary[keyValuePair.Key] = new Tuple<VRCPlayer, GameObject, string, int, int>(keyValuePair.Value.Item1, keyValuePair.Value.Item2, keyValuePair.Value.Item3, num, num2);
                string text = keyValuePair.Value.Item3;
                if (text != "")
                {
                    text = "<color=#FFC0CB>[" + keyValuePair.Value.Item3 + "]</color>";
                }
                string text2;
                if (keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasModerationPowers || keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasSuperPowers || keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasScriptingAccess)
                {
                    text2 = "<color=#FF0000>[VRCDEV]</color>";
                }
                else if (keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasVeteranTrustLevel)
                {
                    text2 = "<color=#6600FF>[Trusted]</color>";
                }
                else if (keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasTrustedTrustLevel)
                {
                    text2 = "<color=#FF7B42>[Known]</color>";
                }
                else if (keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasKnownTrustLevel)
                {
                    text2 = "<color=#2BCE5C>[User]</color>";
                }
                else if (keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasBasicTrustLevel)
                {
                    text2 = "<color=#1778FF>[New User]</color>";
                }
                else if (keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasNegativeTrustLevel || keyValuePair.Value.Item1._player.field_Private_APIUser_0.hasVeryNegativeTrustLevel)
                {
                    text2 = "<color=#190708>[Nuisance]</color>";
                }
                else
                {
                    text2 = "<color=#CCCCCC>[Visitor]</color>";
                }
                string text3;
                if (keyValuePair.Value.Item1._playerNet._vrcPlayer._player.field_Private_APIUser_0.IsOnMobile)
                {
                    text3 = "<color=green>[Q/A]</color>";
                }
                else
                {
                    text3 = (keyValuePair.Value.Item1._playerNet._vrcPlayer.field_Private_VRCPlayerApi_0.IsUserInVR() ? "<color=#CE00D5>[VR]</color>" : "<color=grey>[PC]</color>");
                }
                string text4 = "";
                if (keyValuePair.Value.Item1.field_Private_VRCPlayerApi_0.isMaster)
                {
                    text4 = "<color=orange>[M]</color>";
                }
                string text5 = "";
                if (keyValuePair.Value.Item1.field_Private_VRCPlayerApi_0.isInstanceOwner)
                {
                    text5 = "<color=orange>[C]</color>";
                }
                string text6;
                if (num <= 45)
                {
                    if (num <= 15)
                    {
                        text6 = "<color=red>FPS:" + num.ToString() + "</color>";
                    }
                    else
                    {
                        text6 = "<color=yellow>FPS:" + num.ToString() + "</color>";
                    }
                }
                else
                {
                    text6 = "<color=green>FPS:" + num.ToString() + "</color>";
                }
                string text7;
                if (num2 <= 185)
                {
                    if (num2 <= 100)
                    {
                        text7 = "<color=green>PING:" + num2.ToString() + "</color>";
                    }
                    else
                    {
                        text7 = "<color=yellow>PING:" + num2.ToString() + "</color>";
                    }
                }
                else
                {
                    text7 = "<color=red>PING:" + num2.ToString() + "</color>";
                }
                string name = string.Concat(new string[]
                {
                    text,
                    " ",
                    text3,
                    " ",
                    text2,
                    " ",
                    text4,
                    " ",
                    text5,
                    "  ",
                    text6,
                    " ",
                    text7
                });
                try
                {
                    Player_Wrapper.updateNameplateText(name, keyValuePair.Value.Item2);
                }
                catch (Exception ex)
                {
                    list.Add(keyValuePair.Key);
                    dictionary.Remove(keyValuePair.Key);
                }
            }
            foreach (KeyValuePair<int, Tuple<VRCPlayer, GameObject, string, int, int>> keyValuePair2 in dictionary)
            {
                CustomNamePlates.cachedPlayers[keyValuePair2.Key] = keyValuePair2.Value;
            }
            foreach (int key in list)
            {
                CustomNamePlates.cachedPlayers.Remove(key);
            }
        }
        #endregion

        private const float Yposition = 30f;
        private static readonly Color color = Color.magenta;
        private static Dictionary<int, Tuple<VRCPlayer, GameObject, string, int, int>> cachedPlayers = new Dictionary<int, Tuple<VRCPlayer, GameObject, string, int, int>>();
        private static DateTime check = DateTime.UtcNow;
    }
}
