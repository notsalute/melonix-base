using System;
using neeko.GameWorlds;
using neeko.Wrappers;
using ReMod.Core.Managers;
using ReMod.Core.UI.QuickMenu;

namespace neeko.Menus.Pages_MainMenu
{
    internal class GameWorldHacks : Main_Menu
    {
        internal static void GameWorldHacksMenu(UiManager _uiManager)
        {
            GameWorldHacks._gameworldhacks = _uiManager.QMMenu.AddCategoryPage("GameWorld Hacks", null);
            GameWorldHacks._gameworldhacks.AddCategory("GameWorld Hacks");
            ReMenuCategory category = GameWorldHacks._gameworldhacks.GetCategory("GameWorld Hacks");
            GameWorldHacks._murderMenuCatapage = category.AddCategoryPage("Murder Hacks", null);
            GameWorldHacks._murderMenuCatapage.AddCategory("Murder Hacks 1");
            ReMenuCategory category2 = GameWorldHacks._murderMenuCatapage.GetCategory("Murder Hacks 1");
            category2.AddButton("Start Game", "Start Game", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.objectState("Game Logic", "SyncStart");
                }
            }, null);
            category2.AddButton("Abort Game", "Abort Game", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.objectState("Game Logic", "SyncAbort");
                }
            }, null);
            category2.AddButton("Murderer Win", "Murderer Win", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.objectState("Game Logic", "SyncVictoryM");
                }
            }, null);
            category2.AddButton("Bystander Win", "Bystander Win", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.objectState("Game Logic", "SyncVictoryB");
                }
            }, null);
            GameWorldHacks._murderMenuCatapage.AddCategory("Murder Hacks 2");
            ReMenuCategory category3 = GameWorldHacks._murderMenuCatapage.GetCategory("Murder Hacks 2");
            category3.AddButton("Set Murderer", "Set Murderer", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(VRCPlayer.field_Internal_Static_VRCPlayer_0, "SyncAssignM");
                }
            }, null);
            category3.AddButton("Set Bystander", "Set Bystander", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(VRCPlayer.field_Internal_Static_VRCPlayer_0, "SyncAssignB");
                }
            }, null);
            category3.AddButton("Set Detective", "Set Detective", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.TargetRoles(VRCPlayer.field_Internal_Static_VRCPlayer_0, "SyncAssignD");
                }
            }, null);
            GameWorldHacks._murderMenuCatapage.AddCategory("Murder Hacks 3");
            ReMenuCategory category4 = GameWorldHacks._murderMenuCatapage.GetCategory("Murder Hacks 3");
            category4.AddButton("Bring Knife", "Bring Knife", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.knifeSummoner(VRCPlayer.field_Internal_Static_VRCPlayer_0);
                }
            }, null);
            category4.AddButton("Bring Revolver", "Bring Revolver", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.summonTool(VRCPlayer.field_Internal_Static_VRCPlayer_0, "Revolver");
                }
            }, null);
            category4.AddButton("Bring ShotGun", "Bring ShotGun", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.summonTool(VRCPlayer.field_Internal_Static_VRCPlayer_0, "Shotgun (0)");
                }
            }, null);
            category4.AddButton("Bring Luger", "Bring Luger", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"))
                {
                    Murder4.summonTool(VRCPlayer.field_Internal_Static_VRCPlayer_0, "Luger (0)");
                }
            }, null);
            GameWorldHacks._clubBMenuCatapage = category.AddCategoryPage("Club B Hacks", null);
            GameWorldHacks._clubBMenuCatapage.AddCategory("Club B Hacks");
            ReMenuCategory category5 = GameWorldHacks._clubBMenuCatapage.GetCategory("Club B Hacks");
            category5.AddButton("Join room 1", "Join room 1", new Action(ClubB.joinRoom1), null);
            category5.AddButton("Join room 2", "Join room 2", new Action(ClubB.joinRoom2), null);
            category5.AddButton("Join room 3", "Join room 3", new Action(ClubB.joinRoom3), null);
            category5.AddButton("Join room 4", "Join room 4", new Action(ClubB.joinRoom4), null);
            category5.AddButton("Join room 5", "Join room 5", new Action(ClubB.joinRoom5), null);
            category5.AddButton("Join room 6", "Join room 6", new Action(ClubB.joinRoom6), null);
            category5.AddButton("Join room VIP", "Join room VIP", new Action(ClubB.joinRoomVIP), null);
            GameWorldHacks._amongASSMenuCatapage = category.AddCategoryPage("Among ASS Hacks", null);
            GameWorldHacks._amongASSMenuCatapage.AddCategory("Among ASS Hacks 1");
            ReMenuCategory category6 = GameWorldHacks._amongASSMenuCatapage.GetCategory("Among ASS Hacks 1");
            category6.AddButton("Start Game", "Start Game", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncStart");
                }
            }, null);
            category6.AddButton("Abort Game", "Abort Game", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncAbort");
                }
            }, null);
            category6.AddButton("Importer Win", "Importer Win", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncVictoryI");
                }
            }, null);
            category6.AddButton("Crew Win", "Crew Win", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncVictoryC");
                }
            }, null);
            GameWorldHacks._amongASSMenuCatapage.AddCategory("Among ASS Hacks 2");
            ReMenuCategory category7 = GameWorldHacks._amongASSMenuCatapage.GetCategory("Among ASS Hacks 2");
            category7.AddButton("Complete Tasks", "Complete Tasks", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "OnLocalPlayerCompletedTask");
                }
            }, null);
            category7.AddButton("Stop Voting", "Stop Voting", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncCloseVoting");
                }
            }, null);
            category7.AddButton("Start Meeting", "Start Meeting", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "StartMeeting");
                }
            }, null);
            GameWorldHacks._amongASSMenuCatapage.AddCategory("Among ASS Hacks 3");
            ReMenuCategory category8 = GameWorldHacks._amongASSMenuCatapage.GetCategory("Among ASS Hacks 3");
            category8.AddButton("Kill self", "Kill self", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.TargetRoles(VRCPlayer.field_Internal_Static_VRCPlayer_0, "SyncKill");
                }
            }, null);
            category8.AddButton("Set Crew", "Set Crew", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.TargetRoles(VRCPlayer.field_Internal_Static_VRCPlayer_0, "SyncAssignB");
                }
            }, null);
            category8.AddButton("Set Imposter", "Set Imposter", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.TargetRoles(VRCPlayer.field_Internal_Static_VRCPlayer_0, "SyncAssignM");
                }
            }, null);
            GameWorldHacks._amongASSMenuCatapage.AddCategory("Among ASS Hacks 4");
            ReMenuCategory category9 = GameWorldHacks._amongASSMenuCatapage.GetCategory("Among ASS Hacks 4");
            category9.AddButton("Repair Oxygen", "Repair Oxygen", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncRepairOxygen");
                }
            }, null);
            category9.AddButton("Break Oxygen", "Break Oxygen", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncDoSabotageOxygen");
                }
            }, null);
            category9.AddButton("Repair Light", "Repair Light", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncRepairLights");
                }
            }, null);
            category9.AddButton("Break Lights", "Break Lights", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncDoSabotageLights");
                }
            }, null);
            category9.AddButton("Fix Comms", "Fix Comms", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncRepairComms");
                }
            }, null);
            category9.AddButton("Break Comms", "Break Comms", delegate
            {
                if (Player_Wrapper.isInCorretWorld("wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"))
                {
                    AmongASS_IHateMyself.objectState("Game Logic", "SyncDoSabotageComms");
                }
            }, null);
        }
        private static ReCategoryPage _gameworldhacks;
        private static ReCategoryPage _murderMenuCatapage;
        private static ReCategoryPage _clubBMenuCatapage;
        private static ReCategoryPage _amongASSMenuCatapage;
    }
}
