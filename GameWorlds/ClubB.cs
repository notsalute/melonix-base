using System;
using neeko.Wrappers;
using UnityEngine;

namespace neeko.GameWorlds
{
    internal class ClubB
    {
        internal static void joinRoom1()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom 1", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(-223.7f, -11.3f, 151.1f));
        }
        internal static void joinRoom2()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom 2", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(-211.2f, 55.7f, -91.3f));
        }
        internal static void joinRoom3()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom 3", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(-124.6f, -11.3f, 150.3f));
        }
        internal static void joinRoom4()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom 4", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(-111.3f, 55.7f, -90.5f));
        }
        internal static void joinRoom5()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom 5", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(-24.7f, -11.3f, 150.6f));
        }
        internal static void joinRoom6()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom 6", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(-11.3f, 55.7f, -90.5f));
        }
        internal static void joinRoomVIP()
        {
            Player_Wrapper.findGameObjectNChangeState("Bedroom VIP", true, "wrld_1b3b3259-0a1f-4311-984e-826abab6f481");
            Player_Wrapper.tpLocalPlayerToXYZ(new Vector3(57.9796f, 62.8633f, 0.001f));
        }
    }
}