using System;
using UnityEngine;
using VRC.SDKBase;

namespace neeko.PlayerHacks
{
    internal class SitOn
    {
        public static bool SitOnEnabled { get; internal set; }
        internal static void sitOnPlayer(HumanBodyBones bonePosition, VRCPlayerApi sitTarget, VRCPlayerApi sitCaller)
        {
            SitOn.Target = sitTarget;
            SitOn.Caller = sitCaller;
            SitOn.Bone = bonePosition;
            SitOn.SitOnEnabled = true;
        }
        internal static void sitOnPlayerUpdate()
        {
            if (OVRInput.GetDown((OVRInput.Button)1, (OVRInput.Controller)3) && SitOn.SitOnEnabled)
            {
                SitOn.SitOnEnabled = false;
                Networking.LocalPlayer.UseLegacyLocomotion();
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            if (!SitOn.SitOnEnabled)
            {
                return;
            }
            if (SitOn.Caller == null || SitOn.Target == null)
            {
                SitOn.Caller = null;
                SitOn.Target = null;
                SitOn.SitOnEnabled = false;
                return;
            }
            Networking.LocalPlayer.UseLegacyLocomotion();
            Physics.gravity = new Vector3(0f, 0f, 0f);
            try
            {
                SitOn.Caller.gameObject.transform.position = SitOn.Target.GetBonePosition(SitOn.Bone) + new Vector3(0f, 0.15f, 0f);
            }
            catch
            {
                SitOn.SitOnEnabled = false;
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
        }
        private static VRCPlayerApi Caller;
        private static VRCPlayerApi Target;
        private static HumanBodyBones Bone;
    }
}
