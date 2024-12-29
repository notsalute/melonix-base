using System;
using System.Collections.Generic;
using System.Linq;
using neeko.Config;
using neeko.ResourceManager;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace neeko.Menus.Pages_MainMenu
{
    internal class InstaceHistory
    {
        internal static void InstaceHistoryHacksMenu(UiManager uiManager)
        {
            InstaceHistory._uiManager = uiManager;
            InstaceHistory._InstanceHistoryMenu = InstaceHistory._uiManager.QMMenu.AddCategoryPage("Instance History", "Instance History");
        }
        internal static void instanceAction()
        {
            if (InstaceHistory.tempPage != 0)
            {
                InstaceHistory._InstanceHistory.Active = false;
            }
            int num = ++InstaceHistory.tempPage;
            InstaceHistory._InstanceHistoryMenu.AddCategory("World History (" + num.ToString() + ")");
            InstaceHistory._InstanceHistory = InstaceHistory._InstanceHistoryMenu.GetCategory("World History (" + num.ToString() + ")");
            if (WorldLoggerHandler.Fetch() == null && WorldLoggerHandler.Fetch().Count > 0)
            {
                return;
            }
            List<World_Object> list = WorldLoggerHandler.Fetch();
            list.Reverse();
            int count = 1;
            IEnumerable<World_Object> source = list;
            Func<World_Object, bool> predicate;
            using (IEnumerator<World_Object> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    World_Object world_object = enumerator.Current;
                    int count2 = count;
                    count = count2 + 1;
                    InstaceHistory._InstanceHistory.AddButton(world_object.worldName, string.Concat(new string[]
                    {
                        world_object.worldName,
                        " - ",
                        world_object.worldID,
                        ":",
                        world_object.instanceName,
                        " Type:(",
                        world_object.instanceType,
                        ")."
                    }), delegate
                    {
                        Player_Wrapper.joinWorld(world_object.worldID + ":" + world_object.instanceID);
                    }, null);
                }
            }
        }
        private static UiManager _uiManager;
        private static ReCategoryPage _InstanceHistoryMenu;
        private static ReMenuCategory _InstanceHistory;
        private static int tempPage;
    }
}
