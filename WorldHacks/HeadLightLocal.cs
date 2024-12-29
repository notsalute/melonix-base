using System;
using MelonLoader;
using neeko.Config;
using UnityEngine;

namespace neeko.WorldHacks
{
    internal class HeadLightLocal
    {
        public static bool HeadLightLocalEnabled { get; internal set; }
        internal static void headLight()
        {
            if (GameObject.Find("Headlight_MOD") == null)
            {
                HeadLightLocal.headLightIni();
            }
            HeadLightLocal.headlight.color = Color.white;
            HeadLightLocal.headlight.range = (float)ConfManager.headLightRange.Value;
            HeadLightLocal.headlight.intensity = ConfManager.headLightPower.Value;
            HeadLightLocal.headlight.spotAngle = 270f;
            HeadLightLocal.headlight.enabled = HeadLightLocal.HeadLightLocalEnabled;
        }
        private static void headLightIni()
        {
            GameObject gameObject = new GameObject("Headlight_MOD");
            gameObject.transform.SetParent(HighlightsFX.field_Private_Static_HighlightsFX_0.transform, false);
            HeadLightLocal.headlight = gameObject.AddComponent<Light>();
            HeadLightLocal.headlight.type = 0;
            HeadLightLocal.headlight.enabled = false;
        }
        internal static void updateHeadLightValue(float power = 0f, int range = 0)
        {
            if (GameObject.Find("Headlight_MOD") == null)
            {
                return;
            }
            int num = range + ConfManager.headLightRange.Value;
            float num2 = power + ConfManager.headLightPower.Value;
            HeadLightLocal.headlight.range = (float)num;
            HeadLightLocal.headlight.intensity = num2;
            ConfManager.headLightRange.Value = num;
            ConfManager.headLightPower.Value = num2;
            MelonPreferences.Save();
        }
        private static Light headlight;
    }
}
