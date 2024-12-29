using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neeko.Wrappers;

namespace neeko.Config
{
    internal class ConfManager
    {
        private const string SettingsCategory = "Neeko"; 
        internal static MelonPreferences_Entry<bool> fakePingEnabled;
        internal static MelonPreferences_Entry<bool> fakeFPSEnabled;
        internal static MelonPreferences_Entry<bool> ping_FPSFluctuate;
        internal static MelonPreferences_Entry<bool> udonLogger;
        internal static MelonPreferences_Entry<bool> antiUdon;
        internal static MelonPreferences_Entry<bool> blockWorldTriggers;
        internal static MelonPreferences_Entry<bool> avatarLogging;
        internal static MelonPreferences_Entry<bool> antiRPC;
        internal static MelonPreferences_Entry<bool> rpcLogger;
        internal static MelonPreferences_Entry<bool> antiTPRPC;
        internal static MelonPreferences_Entry<bool> antiInvalidRPC;
        internal static MelonPreferences_Entry<bool> playerLogger;
        internal static MelonPreferences_Entry<bool> allowCustomBackGround;
        internal static MelonPreferences_Entry<bool> showLaunchPadButtons;
        internal static MelonPreferences_Entry<int> headLightRange;
        internal static MelonPreferences_Entry<int> fluctuateRange;
        internal static MelonPreferences_Entry<int> iconsVersion;
        internal static MelonPreferences_Entry<int> namePlateUpdateTime;
        internal static MelonPreferences_Entry<int> fakePing;
        internal static MelonPreferences_Entry<float> speedValue;
        internal static MelonPreferences_Entry<float> flySpeedValue;
        internal static MelonPreferences_Entry<float> fakeFPS;
        internal static MelonPreferences_Entry<float> headLightPower;
        internal static MelonPreferences_Entry<int> maxAvatarLogToFile;
        internal static MelonPreferences_Entry<int> maxWorldLogToFile;
        internal static MelonPreferences_Entry<int> maxAvatarUI;
        internal static MelonPreferences_Entry<int> maxWorldUI;
        private static MelonPreferences_Entry<string> resourcePath; 
        public static void FolderCheck()
        {
            string folderPath = "NeekoVRCMod";
            if (Directory.Exists(folderPath))
            {
            }
            else
            {
                Directory.CreateDirectory(folderPath);
                NeekoLog.Msg($"Created {folderPath} folder.", "Ini", ConsoleColor.Green);
            }
        }
        public static void initConfig()
        {
            NeekoLog.Msg("Initializing Config...", "Ini", ConsoleColor.Green);
            MelonPreferences_Category melonPreferences_Category = MelonPreferences.CreateCategory("Neeko", "Neeko");
            ConfManager.fakePing = melonPreferences_Category.CreateEntry<int>("fakePing", 30, "Fake Ping Value", null, false, false, null, null);
            ConfManager.fakeFPS = melonPreferences_Category.CreateEntry<float>("fakeFPS", 80f, "Fake FPS Value", null, false, false, null, null);
            ConfManager.fakePingEnabled = melonPreferences_Category.CreateEntry<bool>("fakePingEnabled", false, "Fake Ping Enabled", null, false, false, null, null);
            ConfManager.fakeFPSEnabled = melonPreferences_Category.CreateEntry<bool>("fakeFPSEnabled", false, "Fake FPS Enabled", null, false, false, null, null);
            ConfManager.ping_FPSFluctuate = melonPreferences_Category.CreateEntry<bool>("ping_FPSFluctuate", false, "Fluctuate FPS/Ping", null, false, false, null, null);
            ConfManager.udonLogger = melonPreferences_Category.CreateEntry<bool>("udonLogger", false, "Log Udon Events", null, false, false, null, null);
            ConfManager.antiUdon = melonPreferences_Category.CreateEntry<bool>("antiUdon", false, "Block Udon Events", null, false, false, null, null);
            ConfManager.blockWorldTriggers = melonPreferences_Category.CreateEntry<bool>("blockWorldTriggers", false, "Block World Triggers", null, false, false, null, null);
            ConfManager.avatarLogging = melonPreferences_Category.CreateEntry<bool>("avatarLogging", false, "Log Avatar Change", null, false, false, null, null);
            ConfManager.antiRPC = melonPreferences_Category.CreateEntry<bool>("antiRPC", false, "Block every RPC", null, false, false, null, null);
            ConfManager.antiTPRPC = melonPreferences_Category.CreateEntry<bool>("antiTPRPC", false, "Block TP RPC", null, false, false, null, null);
            ConfManager.antiInvalidRPC = melonPreferences_Category.CreateEntry<bool>("antiInvalidRPC", false, "Blocks Invalid RPC", null, false, false, null, null);
            ConfManager.rpcLogger = melonPreferences_Category.CreateEntry<bool>("rpcLogger", false, "Log RPC", null, false, false, null, null);
            ConfManager.speedValue = melonPreferences_Category.CreateEntry<float>("speedValue", 4.5f, "Speed Value", null, false, false, null, null);
            ConfManager.flySpeedValue = melonPreferences_Category.CreateEntry<float>("flySpeedValue", 8f, "Fly Speed Value", null, false, false, null, null);
            ConfManager.headLightRange = melonPreferences_Category.CreateEntry<int>("headLightRange", 5, "HeadLight Range", null, false, false, null, null);
            ConfManager.headLightPower = melonPreferences_Category.CreateEntry<float>("headLightPower", 0.5f, "HeadLight Power", null, false, false, null, null);
            ConfManager.playerLogger = melonPreferences_Category.CreateEntry<bool>("playerLogger", false, "Log Player Join/Leave Events", null, false, false, null, null);
            ConfManager.fluctuateRange = melonPreferences_Category.CreateEntry<int>("fluctuateRange", 5, "Changes range for fake Ping/FPS", null, false, false, null, null);
            ConfManager.allowCustomBackGround = melonPreferences_Category.CreateEntry<bool>("allowCustomBackGround", true, "Custom Neeko Mod BackGround", null, false, false, null, null);
            ConfManager.iconsVersion = melonPreferences_Category.CreateEntry<int>("iconsVersion", 0, "DO NOT EDIT", null, false, false, null, null);
            ConfManager.namePlateUpdateTime = melonPreferences_Category.CreateEntry<int>("namePlateUpdateTime", 2, "How often nameplates will update. More = more lag,", null, false, false, null, null);
            ConfManager.showLaunchPadButtons = melonPreferences_Category.CreateEntry<bool>("showLaunchPadButtons", true, "Show LaunchPad Buttons", null, false, false, null, null);
            ConfManager.resourcePath = melonPreferences_Category.CreateEntry<string>("resourcePath", "NeekoVRCMod", "Location for Folder", null, false, false, null, null);
            ConfManager.maxAvatarLogToFile = melonPreferences_Category.CreateEntry<int>("maxAvatarLogToFile", 96, "Max avatar entries for avatar file logging", null, false, false, null, null);
            ConfManager.maxWorldLogToFile = melonPreferences_Category.CreateEntry<int>("maxWorldLogToFile", 64, "Max world entries for world file logging", null, false, false, null, null);
            ConfManager.maxAvatarUI = melonPreferences_Category.CreateEntry<int>("maxAvatarUI", 48, "Max avatar entries for UI to display", null, false, false, null, null);
            ConfManager.maxWorldUI = melonPreferences_Category.CreateEntry<int>("maxWorldUI", 16, "Max world entries for UI to display", null, false, false, null, null);
            melonPreferences_Category.SetFilePath(getResourcePathFull()+"//NeekoConfig.cfg");
            melonPreferences_Category.SaveToFile(true);
        }
        internal static string getResourcePathFull()
        {
            return Path.Combine("NeekoVRCMod");
        }
    }
}
