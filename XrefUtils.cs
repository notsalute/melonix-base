using Harmony;
using MelonLoader;
using ReMod.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib.XrefScans;

namespace neeko
{
    public static class XrefUtils
    {
        public static bool CheckMethod(MethodInfo method, string match)
        {
            try
            {
                foreach (XrefInstance xrefInstance in XrefScanner.XrefScan(method))
                {
                    if (xrefInstance.Type == XrefType.Global && xrefInstance.ReadAsObject().ToString().Contains(match))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
            }
            return false;
        }
        public static bool CheckUsedBy(MethodInfo method, string methodName, System.Type type = null)
        {
            foreach (XrefInstance xrefInstance in XrefScanner.UsedBy(method))
            {
                if (xrefInstance.Type == XrefType.Method)
                {
                    try
                    {
                        if ((type == null || xrefInstance.TryResolve().DeclaringType == type) && xrefInstance.TryResolve().Name.Contains(methodName))
                        {
                            return true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return false;
        }
        public static bool CheckUsing(MethodInfo method, string methodName, System.Type type = null)
        {
            foreach (XrefInstance xrefInstance in XrefScanner.XrefScan(method))
            {
                if (xrefInstance.Type == XrefType.Method)
                {
                    try
                    {
                        if ((type == null || xrefInstance.TryResolve().DeclaringType == type) && xrefInstance.TryResolve().Name.Contains(methodName))
                        {
                            return true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return false;
        }
        public static void DumpXRefs(this System.Type type)
        {
            MelonLogger.Msg(type.Name + " XRefs:");
            foreach (MethodInfo method in AccessTools.GetDeclaredMethods(type))
            {
                method.DumpXRefs(1);
            }
        }
        public static void DumpXRefs(this MethodInfo method, int depth = 0)
        {
            string text = new string('\t', depth);
            MelonLogger.Msg(text + method.Name + " XRefs:");
            foreach (XrefInstance xrefInstance in XrefScanner.XrefScan(method))
            {
                if (xrefInstance.Type == XrefType.Global)
                {
                    string str = "\tString = ";
                    Il2CppSystem.Object @object = xrefInstance.ReadAsObject();
                    MelonLogger.Msg(str + ((@object != null) ? @object.ToString() : null));
                }
                else
                {
                    MethodBase methodBase = xrefInstance.TryResolve();
                    if (methodBase != null)
                    {
                        string[] array = new string[5];
                        array[0] = text;
                        array[1] = "\tMethod -> ";
                        int num = 2;
                        System.Type declaringType = methodBase.DeclaringType;
                        array[num] = ((declaringType != null) ? declaringType.Name : null);
                        array[3] = ".";
                        array[4] = methodBase.Name;
                        MelonLogger.Msg(string.Concat(array));
                    }
                }
            }
        }
    }
}
