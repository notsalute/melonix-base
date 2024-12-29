﻿using System;
using System.Reflection;
using Harmony;

namespace neeko.Network
{
    internal class NetworkHelper
    {
        internal static HarmonyMethod GetLocalPatch<T>(string name)
        {
            return new HarmonyMethod(typeof(T).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }
    }
}