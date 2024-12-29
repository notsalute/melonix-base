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
    internal class LastSeenAvatars
    {
        internal static void LastSeenAvatarsHacksMenu(UiManager uiManager)
        {
            LastSeenAvatars._uiManager = uiManager;
            LastSeenAvatars._LastSeenAvatarsMenu = LastSeenAvatars._uiManager.QMMenu.AddCategoryPage("Last Seen Avatars", "Last Seen Avatars");
            LastSeenAvatars._LastSeenAvatarsMenu.OnOpen += LastSeenAvatars.lastSeenAction;
        }
        private static void lastSeenAction()
        {
            if (LastSeenAvatars.calledTwice)
            {
                LastSeenAvatars.calledTwice = false;
                return;
            }
            LastSeenAvatars.calledTwice = true;
            if (LastSeenAvatars.tempPage != 0)
            {
                LastSeenAvatars._LastSeenAvatars.Active = false;
            }
            int num = ++LastSeenAvatars.tempPage;
            LastSeenAvatars._LastSeenAvatarsMenu.AddCategory("Last Seen (" + num.ToString() + ")");
            LastSeenAvatars._LastSeenAvatars = LastSeenAvatars._LastSeenAvatarsMenu.GetCategory("Last Seen (" + num.ToString() + ")");
            List<Avatar_Object> list = AvatarLoggerHandler.Fetch();
            if (list == null || list.Count == 0)
            {
                return;
            }
            list.Reverse();
            int count = 1;
            IEnumerable<Avatar_Object> source = list;
            Func<Avatar_Object, bool> predicate;
            using (IEnumerator<Avatar_Object> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Avatar_Object avatarObject = enumerator.Current;
                    int count2 = count;
                    count = count2 + 1;
                    if (!(avatarObject.releaseStatus != "public") && avatarObject.supportedPlatforms != 2 && !avatarObject.isblackListed)
                    {
                        string tooltip = string.Concat(new string[]
                        {
                            "Id: (",
                            avatarObject.id,
                            ") By: (",
                            avatarObject.authorName,
                            ") Description: ",
                            avatarObject.description
                        });
                        LastSeenAvatars._LastSeenAvatars.AddButton(avatarObject.name, tooltip, delegate
                        {
                            Player_Wrapper.switchToAvi(avatarObject.id);
                        }, null);
                    }
                }
            }
        }
        private static UiManager _uiManager;
        private static ReCategoryPage _LastSeenAvatarsMenu;
        private static ReMenuCategory _LastSeenAvatars;
        private static int tempPage;
        private static bool calledTwice;
    }
}
