using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

namespace neeko.WorldHacks
{
    internal class Pickups
    {
        public static bool disablePickupsEnabled { get; internal set; }
        public static bool itemsAreNotPickableEnabled { get; internal set; }
        public static bool ItemESPEnabled { get; internal set; }
        public static bool TriggerESPEnabled { get; internal set; }
        public static bool UdonESPEnabled { get; internal set; }
        internal static void respawnAllObjects()
        {
            foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
            {
                Networking.LocalPlayer.TakeOwnership(vrc_Pickup.gameObject);
                vrc_Pickup.transform.localPosition = new Vector3(0f, -100000f, 0f);
            }
        }
        internal static void triggerESP()
        {
            foreach (VRC_Trigger vrc_Trigger in Resources.FindObjectsOfTypeAll<VRC_Trigger>())
            {
                if (!(vrc_Trigger == null) && vrc_Trigger.gameObject.active && !vrc_Trigger.name.Contains("ViewFinder") && !(HighlightsFX.field_Private_Static_HighlightsFX_0 == null))
                {
                    HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Protected_Boolean_Boolean_Boolean_PDM_0(vrc_Trigger.GetComponentInChildren<MeshRenderer>(), Pickups.TriggerESPEnabled);
                }
            }
        }
        internal static void itemESP()
        {
            foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
            {
                if (!(vrc_Pickup == null) && vrc_Pickup.gameObject.active && vrc_Pickup.enabled && vrc_Pickup.pickupable && !vrc_Pickup.name.Contains("ViewFinder") && !(HighlightsFX.field_Private_Static_HighlightsFX_0 == null))
                {
                    HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Protected_Boolean_Boolean_Boolean_PDM_0(vrc_Pickup.GetComponentInChildren<MeshRenderer>(), Pickups.ItemESPEnabled);
                }
            }
        }
        internal static void udonESP()
        {
            foreach (UdonBehaviour udonBehaviour in Resources.FindObjectsOfTypeAll<UdonBehaviour>())
            {
                if (!(udonBehaviour == null) && udonBehaviour.gameObject.active && !udonBehaviour.name.Contains("ViewFinder") && !(HighlightsFX.field_Private_Static_HighlightsFX_0 == null) && udonBehaviour._eventTable.System_Collections_IDictionary_Contains("_interact"))
                {
                    HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Protected_Boolean_Boolean_Boolean_PDM_0(udonBehaviour.GetComponentInChildren<MeshRenderer>(), Pickups.UdonESPEnabled);
                }
            }
        }
        internal static void bringPickupsToTarget(VRCPlayer vrcplayer)
        {
            foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray<VRC_Pickup>())
            {
                if (vrc_Pickup.gameObject)
                {
                    Networking.LocalPlayer.TakeOwnership(vrc_Pickup.gameObject);
                    Transform transform = vrc_Pickup.transform;
                    transform.localPosition = new Vector3(0f, 0.3f, 0f);
                    transform.position = vrcplayer._player.transform.position + new Vector3(0f, 0.3f, 0f);
                }
            }
            foreach (VRCPickup vrcpickup in Resources.FindObjectsOfTypeAll<VRCPickup>().ToArray<VRCPickup>())
            {
                if (vrcpickup.gameObject)
                {
                    Networking.LocalPlayer.TakeOwnership(vrcpickup.gameObject);
                    Transform transform2 = vrcpickup.transform;
                    transform2.localPosition = new Vector3(0f, 0.3f, 0f);
                    transform2.position = vrcplayer._player.transform.position + new Vector3(0f, 0.3f, 0f);
                }
            }
        }
        internal static void disablePickups()
        {
            foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray<VRC_Pickup>())
            {
                if (!Pickups.blacklistedPickups.Contains(vrc_Pickup.name))
                {
                    vrc_Pickup.gameObject.SetActive(!Pickups.disablePickupsEnabled);
                }
            }
        }
        internal static void itemsAreNotPickable()
        {
            foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray<VRC_Pickup>())
            {
                if (!Pickups.blacklistedPickups.Contains(vrc_Pickup.name))
                {
                    vrc_Pickup.GetComponent<VRC_Pickup>().pickupable = !Pickups.itemsAreNotPickableEnabled;
                }
            }
        }
        internal static void forcePickup()
        {
            foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray<VRC_Pickup>())
            {
                if (!Pickups.blacklistedPickups.Contains(vrc_Pickup.name))
                {
                    vrc_Pickup.GetComponent<VRC_Pickup>().DisallowTheft = false;
                    vrc_Pickup.GetComponent<VRC_Pickup>().pickupable = true;
                    vrc_Pickup.GetComponent<VRC_Pickup>().allowManipulationWhenEquipped = true;
                    vrc_Pickup.GetComponent<VRC_Pickup>().proximity = float.MaxValue;
                    vrc_Pickup.GetComponent<VRC_Pickup>().orientation = 0;
                }
            }
        }
        internal static readonly List<string> blacklistedPickups = new List<string>
        {
            "OscDebugConsole",
            "MirrorPickup",
            "PhotoCamera",
            "ViewFinder",
            "AvatarDebugConsole"
        };
    }
}
