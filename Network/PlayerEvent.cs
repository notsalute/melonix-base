using System;
using neeko.Config;
using neeko.PlayerHacks;
using neeko.Wrappers;
using VRC;

namespace neeko.Network
{
    internal class PlayerEvent
    {
        internal static void OnJoinEvent(Player __0)
        {
            Player_Wrapper.NotifyOthersUsing();
            if (ConfManager.playerLogger.Value)
            {
                PlayerEvent.OnJoinLog(__0.field_Private_APIUser_0.displayName);
            }
        }
        internal static void OnLeaveEvent(Player __0)
        {
            if (ConfManager.playerLogger.Value)
            {
                PlayerEvent.OnLeaveLog(__0.field_Private_APIUser_0.displayName);
            }
        }
        private static void OnJoinLog(string nickname)
        {
            NeekoLog.Msg(nickname, "Join", ConsoleColor.DarkYellow);
        }
        private static void OnLeaveLog(string nickname)
        {
            NeekoLog.Msg(nickname, "Leave", ConsoleColor.DarkYellow);
        }
    }
}
