using System;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace neeko.Menus.Pages_MainMenu
{
    public class ContributorsPage
    {
        public static void ContributorsMenu(UiManager UIManager)
        {
            ContributorsPage._contributors = UIManager.QMMenu.AddCategoryPage("Contributors", null);
            ContributorsPage._contributors.AddCategory("Contributors");
            ReMenuCategory category = ContributorsPage._contributors.GetCategory("Contributors");
            category.AddButton("Devs:", "",null);
            category.AddButton("Neeko", "", null);
            category.AddButton("Cyril XD", "", null);
            category.AddButton("catnotadog", "", null);
            category.AddButton("Special Thanks:", "", null);
            category.AddButton("Requi", "ReMod", null);
            category.AddButton("XoX-Toxic", "ReMod - Quest", null);
            category.AddButton("Lunar", "Discord Kitten", null);
            category.AddButton("Davi", "Cutie", null);
        }
        private static UiManager _uiManager;
        private static ReCategoryPage _contributors;
    }
}
