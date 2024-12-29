using System;
using MelonLoader;
using neeko.Config;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace neeko.PlayerHacks
{
    internal class SpeedHack
    {
        public static bool SpeedEnabled { get; internal set; }
        internal static void setSpeedToggle()
        {
            if (SpeedHack.SpeedEnabled)
            {
                SpeedHack.SpeedEnabled = true;
                SpeedHack.setSpeed(SpeedHack.speedCurrent);
                return;
            }
            SpeedHack.SpeedEnabled = false;
            SpeedHack.resetSpeed();
        }
        private static void setSpeed(float speed)
        {
            Networking.LocalPlayer.SetWalkSpeed(speed);
            Networking.LocalPlayer.SetRunSpeed(speed);
            Networking.LocalPlayer.SetStrafeSpeed(speed);
            Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = true;
        }
        internal static void resetSpeed()
        {
            SpeedHack.setSpeed(4f);
        }
        internal static void updateSpeed(float update)
        {
            if (update < 0f)
            {
                return;
            }
            SpeedHack.speedCurrent += update;
            ConfManager.speedValue.Value = SpeedHack.speedCurrent;
            MelonPreferences.Save();
            if (SpeedHack.SpeedEnabled)
            {
                SpeedHack.setSpeed(SpeedHack.speedCurrent);
            }
        }
        private static float speedCurrent = 4f;
    }
}
