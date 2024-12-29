using System;
using neeko.Config;
using neeko.Wrappers;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace neeko.Network
{
    internal class AvatarLoaded
    {
        internal static void OnAvaLoaded(GameObject __0, VRC_AvatarDescriptor __1, VRCPlayer __instance)
        {
            try
            {
                if (ConfManager.avatarLogging.Value)
                {
                    Player player = __instance._player;
                    string text = string.Concat(new string[]
                    {
                        "\nUser: (",
                        player.field_Private_VRCPlayerApi_0.displayName,
                        ")\nswitched to avatar: ",
                        player.prop_ApiAvatar_0.name,
                        "(",
                        player.prop_ApiAvatar_0.id,
                        ")\nAuthor: (",
                        player.prop_ApiAvatar_0.authorName,
                        ") \nCreated: (",
                        player.prop_ApiAvatar_0.created_at.ToString(),
                        ") \nLast Updated: (",
                        player.prop_ApiAvatar_0.updated_at.ToString(),
                        ")"
                    });
                    if (!(AvatarLoaded.last_log == text))
                    {
                        AvatarLoaded.last_log = text;
                        NeekoLog.Msg(text, "AvatarLog", ConsoleColor.DarkYellow);
                        AvatarLoggerHandler.Log(player.prop_ApiAvatar_0);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static string last_log;
    }
}
