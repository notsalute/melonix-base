using System;
using neeko.Config;

namespace neeko.Network
{
    internal class FakeFPS
    {
        internal static void Frame(ref float __result)
        {
            try
            {
                if (ConfManager.fakeFPSEnabled.Value)
                {
                    if (ConfManager.ping_FPSFluctuate.Value)
                    {
                        if (FakeFPS.timer >= 500)
                        {
                            FakeFPS.timer_current_number = (float)new Random().Next(Convert.ToInt32(ConfManager.fakeFPS.Value) - ConfManager.fluctuateRange.Value, Convert.ToInt32(ConfManager.fakeFPS.Value) + ConfManager.fluctuateRange.Value);
                            FakeFPS.timer = 0;
                        }
                        else
                        {
                            FakeFPS.timer++;
                        }
                        __result = 1f / FakeFPS.timer_current_number;
                    }
                    else
                    {
                        __result = 1f / ConfManager.fakeFPS.Value;
                    }
                }
            }
            catch
            {
            }
        }
        private static int timer;
        private static float timer_current_number = ConfManager.fakeFPS.Value;
    }
}
