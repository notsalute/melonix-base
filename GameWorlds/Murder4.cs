using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace neeko.GameWorlds
{
    internal class Murder4
    {
        internal static void TargetRoles(VRCPlayer selection, string role)
        {
            string value = selection._player.ToString();
            for (int i = 0; i < 24; i++)
            {
                if (GameObject.Find("Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + i.ToString() + ")/Player Name Text").GetComponent<Text>().text.Equals(value))
                {
                    GameObject.Find("Player Node (" + i.ToString() + ")").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, role);
                }
            }
        }
        internal static void summonTool(VRCPlayer selection, string item)
        {
            GameObject gameObject = GameObject.Find(item);
            Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject);
            gameObject.transform.position = selection.transform.position + new Vector3(0f, 0.1f, 0f);
        }
        internal static void objectState(string objecttofix, string state)
        {
            GameObject.Find(objecttofix).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, state);
        }
        internal static void bearTrapsMover(GameObject trap, Vector3 location)
        {
            Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, trap);
            trap.transform.position = location;
            GameObject.Find(trap.name).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncArm");
            GameObject.Find(trap.name).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDeploy");
        }
        internal static void knifeSummoner(VRCPlayer target)
        {
            foreach (GameObject gameObject in Murder4.knifeList)
            {
                Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject);
                gameObject.transform.position = target.transform.position + new Vector3(0f, 0.1f, 0f);
            }
        }
        private static readonly List<GameObject> knifeList = new List<GameObject>
        {
            GameObject.Find("Game Logic").transform.Find("Weapons/Knife (0)").gameObject,
            GameObject.Find("Game Logic").transform.Find("Weapons/Knife (1)").gameObject,
            GameObject.Find("Game Logic").transform.Find("Weapons/Knife (2)").gameObject,
            GameObject.Find("Game Logic").transform.Find("Weapons/Knife (3)").gameObject,
            GameObject.Find("Game Logic").transform.Find("Weapons/Knife (4)").gameObject,
            GameObject.Find("Game Logic").transform.Find("Weapons/Knife (5)").gameObject
        };
    }
}
