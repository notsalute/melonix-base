using neeko.Config;
using neeko.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC;

namespace neeko.Network
{
    internal class Udon
    {
        internal static bool OnUdon(string __0, Player __1)
        {
            if (ConfManager.udonLogger.Value)
            {
                NeekoLog.Msg("Type: " + __0 + " | From " + __1.field_Private_VRCPlayerApi_0.displayName, "Udon", ConsoleColor.DarkYellow);
            }
            return !ConfManager.antiUdon.Value;
        }
    }
}
