using System;
using neeko.Config;

namespace neeko.Network
{
    internal class FakePing
    {
        internal static void Ping(ref int __result)
        {
            try
            {
                if (ConfManager.fakePingEnabled.Value)
                {
                    if (ConfManager.ping_FPSFluctuate.Value)
                    {
                        if (FakePing.timer >= 700)
                        {
                            FakePing.timer_current_number = new Random().Next(ConfManager.fakePing.Value - ConfManager.fluctuateRange.Value, ConfManager.fakePing.Value + ConfManager.fluctuateRange.Value);
                            FakePing.timer = 0;
                        }
                        else
                        {
                            FakePing.timer++;
                        }
                        __result = FakePing.timer_current_number;
                    }
                    else
                    {
                        __result = ConfManager.fakePing.Value;
                    }
                }
            }
            catch
            {
            }
        }
        private static int timer;
        private static int timer_current_number = ConfManager.fakePing.Value;
    }
}
