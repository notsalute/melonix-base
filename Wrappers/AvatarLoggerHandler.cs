using System;
using System.Collections.Generic;
using System.IO;
using neeko.Config;
using Newtonsoft.Json;
using VRC.Core;

namespace neeko.Wrappers
{
    internal class AvatarLoggerHandler
    {
        internal static void Log(ApiAvatar avtr)
        {
            AvatarLoggerHandler.Handle(new Avatar_Object(avtr));
        }
        internal static void Log(Avatar_Object avtr)
        {
            AvatarLoggerHandler.Handle(avtr);
        }
        internal static List<Avatar_Object> Fetch()
        {
            return AvatarLoggerHandler.FetchFile();
        }
        internal static void Clear()
        {
            if (!File.Exists(AvatarLoggerHandler.filePath))
            {
                return;
            }
            File.Delete(AvatarLoggerHandler.filePath);
            NeekoLog.Msg("Avatar Logger file cleared!", "UserAction", ConsoleColor.DarkMagenta);
        }
        private static void Handle(Avatar_Object avtr)
        {
            try
            {
                List<Avatar_Object> list = AvatarLoggerHandler.FetchFile();
                list.RemoveAll((Avatar_Object avatarObject) => avatarObject.id == avtr.id);
                list.Add(avtr);
                if (list.Count > AvatarLoggerHandler.maxEntries)
                {
                    list.RemoveRange(0, list.Count - AvatarLoggerHandler.maxEntries);
                }
                File.WriteAllText(AvatarLoggerHandler.filePath, JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                NeekoLog.Msg("Failed fetching/writing to avatar log file. " + ex.Message, "ERROR", ConsoleColor.Red);
            }
        }
        private static List<Avatar_Object> FetchFile()
        {
            List<Avatar_Object> list = null;
            if (File.Exists(AvatarLoggerHandler.filePath))
            {
                list = JsonConvert.DeserializeObject<List<Avatar_Object>>(File.ReadAllText(AvatarLoggerHandler.filePath));
            }
            return list ?? new List<Avatar_Object>();
        }
        private const string fileName = "/AvatarLogger.json";
        private static readonly int maxEntries = ConfManager.maxAvatarLogToFile.Value;
        private static readonly string filePath = ConfManager.getResourcePathFull() + "/AvatarLogger.json";
    }
}
