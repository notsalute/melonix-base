using System;
using System.Collections.Generic;
using System.IO;
using neeko.Config;
using Newtonsoft.Json;
using VRC.Core;

namespace neeko.Wrappers
{
    public class WorldLoggerHandler
    {
        internal static void Log(ApiWorld wrld, ApiWorldInstance instance)
        {
            WorldLoggerHandler.Handle(new World_Object(wrld, instance));
        }
        internal static List<World_Object> Fetch()
        {
            return WorldLoggerHandler.FetchFile();
        }
        internal static void Clear()
        {
            if (!File.Exists(WorldLoggerHandler.filePath))
            {
                return;
            }
            File.Delete(WorldLoggerHandler.filePath);
            NeekoLog.Msg("World Logger file cleared!", "UserAction", ConsoleColor.DarkMagenta);
        }
        private static void Handle(World_Object wrld)
        {
            try
            {
                List<World_Object> list = WorldLoggerHandler.FetchFile();
                list.RemoveAll((World_Object worldObjects) => worldObjects.instanceID == wrld.instanceID);
                list.Add(wrld);
                if (list.Count > WorldLoggerHandler.maxEntries)
                {
                    list.RemoveRange(0, list.Count - WorldLoggerHandler.maxEntries);
                }
                File.WriteAllText(WorldLoggerHandler.filePath, JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                NeekoLog.Msg("Failed fetching/writing to world log file. " + ex.Message, "ERROR", ConsoleColor.Red);
            }
        }
        private static List<World_Object> FetchFile()
        {
            List<World_Object> list = null;
            if (File.Exists(WorldLoggerHandler.filePath))
            {
                list = JsonConvert.DeserializeObject<List<World_Object>>(File.ReadAllText(WorldLoggerHandler.filePath));
            }
            return list ?? new List<World_Object>();
        }
        private const string fileName = "/WorldLogger.json";
        private static readonly string filePath = ConfManager.getResourcePathFull() + "/WorldLogger.json";
        private static readonly int maxEntries = ConfManager.maxWorldLogToFile.Value;
    }
}
