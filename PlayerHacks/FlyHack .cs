using System;
using MelonLoader;
using neeko.Config;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace neeko.PlayerHacks
{
    internal class FlyHack : neeko.Main
    {
        public static bool jetPackEnabled { get; internal set; }
        public static bool flyEnabled { get; internal set; }
        internal static void jetPack()
        {
            if (!FlyHack.jetPackEnabled || (Input.GetKey((KeyCode)32) || Networking.LocalPlayer.IsPlayerGrounded()))
            {
                return;
            }
            Vector3 velocity = Networking.LocalPlayer.GetVelocity();
            velocity.y = Networking.LocalPlayer.GetJumpImpulse();
            Networking.LocalPlayer.SetVelocity(velocity);
        }
        internal static void fly()
        {
            if (FlyHack.flyEnabled)
            {
                if (FlyHack.flyEnabled && !(Physics.gravity == Vector3.zero))
                {
                    FlyHack.justSwitchedfly = true;
                    Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = false;
                    Physics.gravity = Vector3.zero;
                }
            }
            else if (FlyHack.justSwitchedfly)
            {
                FlyHack.justSwitchedfly = false;
                Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = true;
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            if (!FlyHack.flyEnabled || Player.prop_Player_0 == null)
            {
                return;
            }
            float num = Input.GetKey((KeyCode)304) ? (Time.deltaTime * FlyHack.flySpeedCurrent) : (Time.deltaTime * (FlyHack.flySpeedCurrent / 3f));
            if (!Player.prop_Player_0.field_Private_VRCPlayerApi_0.IsUserInVR())
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    Player.prop_Player_0.transform.position -= FlyHack.camera().up * num;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    Player.prop_Player_0.transform.position += FlyHack.camera().up * num;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Player.prop_Player_0.transform.position += FlyHack.camera().transform.right;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Player.prop_Player_0.transform.position -= FlyHack.camera().transform.right;
                }
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    float moveDirection = Input.GetAxis("Vertical");
                    Player.prop_Player_0.transform.position += FlyHack.camera().forward * moveDirection;
                }
                return;
            }
            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < -0.5f)
            {
                Player.prop_Player_0.transform.position -= FlyHack.camera().up * num;
            }
            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0.5f)
            {
                Player.prop_Player_0.transform.position += FlyHack.camera().up * num;
            }
            if (Input.GetAxis("Vertical") != 0f)
            {
                Player.prop_Player_0.transform.position += FlyHack.camera().forward * (num * Input.GetAxis("Vertical"));
            }
            if (Input.GetAxis("Vertical") == 0f)
            {
                Networking.LocalPlayer.SetVelocity(Vector3.zero);
            }
            if (Input.GetAxis("Horizontal") != 0f)
            {
                Player.prop_Player_0.transform.position += FlyHack.camera().transform.right * (num * Input.GetAxis("Horizontal"));
            }
        }
        private static void setFlySpeed(float speed)
        {
            FlyHack.flySpeedCurrent = speed;
        }
        internal static void resetFlySpeed()
        {
            FlyHack.setFlySpeed(8f);
        }
        internal static void updateFlySpeed(float update)
        {
            if (update < 0f)
            {
                return;
            }
            FlyHack.flySpeedCurrent += update;
            ConfManager.flySpeedValue.Value = FlyHack.flySpeedCurrent;
            MelonPreferences.Save();
            if (FlyHack.flyEnabled)
            {
                FlyHack.setFlySpeed(FlyHack.flySpeedCurrent);
            }
        }
        private static Transform camera()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0.transform;
        }
        private static bool justSwitchedfly;
        private static float flySpeedCurrent = 8f;
    }
}
