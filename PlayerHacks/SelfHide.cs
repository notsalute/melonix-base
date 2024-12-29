using System;
using neeko.Wrappers;
using VRC;

namespace neeko.PlayerHacks
{
    internal class SelfHide : neeko.Main
    {
        public static bool SelfHideEnabled { get; internal set; }
        internal static void selfhidePlayer()
        {
            if (Player_Wrapper.GetLocalPlayer() == null)
            {
                return;
            }
            if (SelfHide.SelfHideEnabled)
            {
                if (VRCPlayer.field_Internal_Static_VRCPlayer_0._player.prop_ApiAvatar_0.id != null)
                {
                    SelfHide.backupid = VRCPlayer.field_Internal_Static_VRCPlayer_0._player.prop_ApiAvatar_0.id;
                }
            }
            Player_Wrapper.GetLocalPlayer().transform.Find("ForwardDirection").gameObject.active = !SelfHide.SelfHideEnabled;
        }
        private static string backupid;
    }
}
