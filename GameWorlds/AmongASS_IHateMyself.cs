using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.Udon;

namespace neeko.GameWorlds
{
    public class AmongASS_IHateMyself
    {
        public static void objectState(string objecttofix, string state)
        {
            GameObject.Find(objecttofix).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, state);
        }
        public static void TargetRoles(VRCPlayer selection, string role)
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
    }
}
