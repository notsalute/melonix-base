using neeko.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.SDKBase;

namespace neeko.Network
{
    internal class TriggerWorld
    {
        internal static bool OnTriggerWorld(ref VRC_EventHandler.VrcEvent __0, ref VRC_EventHandler.VrcBroadcastType __1, ref int __2)
        {
            try
            {
                if (ConfManager.blockWorldTriggers.Value)
                {
                    __1 = (VRC_EventHandler.VrcBroadcastType)4;
                }
            }
            catch
            {
            }
            return true;
        }
    }
}
