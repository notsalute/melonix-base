using System;
using System.IO;
using MelonLoader;
using neeko.Config;

namespace neeko.Wrappers
{
    internal class CompatibilityCheck
    {
        internal static void iniCheck()
        {
            NeekoLog.Msg("Checking for compatibility.", "CompatibilityCheck", ConsoleColor.Yellow);
            CompatibilityCheck.checkIfMidNightClientPresent();
        }
        private static void checkIfMidNightClientPresent()
        {
            string path = Path.Combine(new string[]
            {
                Environment.CurrentDirectory + "RedCore"
            });
            string path2 = Path.Combine(new string[]
            {
                Environment.CurrentDirectory + "/Plugins/RCLoader.dll"
            });
            if (!Directory.Exists(path) && !File.Exists(path2))
            {
                return;
            }
            NeekoLog.Msg("RedCore Client Detected - Setting LaunchPadButtons false", "CompatibilityCheck", ConsoleColor.Yellow);
            ConfManager.showLaunchPadButtons.Value = false;
            MelonPreferences.Save();
        }
    }
}
