using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neeko.Wrappers
{
    public static class NeekoLog
    {
        public static void Msg(string message, string prefix = "", ConsoleColor color = ConsoleColor.Cyan)
        {
            MelonLogger.Msg(color, "[" + prefix + "] " + message);
        }
        public static void Msg(object message, string prefix = "", ConsoleColor color = ConsoleColor.Cyan)
        {
            MelonLogger.Msg(color, "[" + prefix + "] " + ((message != null) ? message.ToString() : null));
        }
    }
}
