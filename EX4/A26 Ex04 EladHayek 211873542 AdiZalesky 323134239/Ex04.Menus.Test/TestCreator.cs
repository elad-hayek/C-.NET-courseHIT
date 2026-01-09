using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
     public static class TestCreator
     {
        public static MainMenu CreateInterfacesMenu()
        {
            Interfaces.MenuItemWithSubMenu systemLevelMenu = new Interfaces.MenuItemWithSubMenu("Interfaces Main Menu");
            Interfaces.MenuItemWithSubMenu versionAndLowerCaseMenu = new Interfaces.MenuItemWithSubMenu("Version and Lowercase");
            Interfaces.MenuItemWithSubMenu dateAndTimeMenu = new Interfaces.MenuItemWithSubMenu("Show Current Date/Time");
            systemLevelMenu.AddSubMenuItem(versionAndLowerCaseMenu);
            systemLevelMenu.AddSubMenuItem(dateAndTimeMenu);

            IMenuItemActionProvider countLowercaseProvider = new CountLowercaseProvider();
            IMenuItemActionProvider showVerionProvider = new ShowVerionProvider();

            Interfaces.MenuItemWithAction showVersionMenuItem = new Interfaces.MenuItemWithAction("Show Version", showVerionProvider);
            Interfaces.MenuItemWithAction countLowercaseMenuItem = new Interfaces.MenuItemWithAction("Count Lowercase", countLowercaseProvider);
            versionAndLowerCaseMenu.AddSubMenuItem(showVersionMenuItem);
            versionAndLowerCaseMenu.AddSubMenuItem(countLowercaseMenuItem);

            IMenuItemActionProvider showCurrentTimeProvider = new ShowCurrentTimeProvider();
            IMenuItemActionProvider showCurrentDateProvider = new ShowCurrentDateProvider();

            Interfaces.MenuItemWithAction showCurrentTimeMenuItem = new Interfaces.MenuItemWithAction("Show Current Time", showCurrentTimeProvider);
            Interfaces.MenuItemWithAction showCurrentDateMenuItem = new Interfaces.MenuItemWithAction("Show Current Date", showCurrentDateProvider);
            dateAndTimeMenu.AddSubMenuItem(showCurrentTimeMenuItem);
            dateAndTimeMenu.AddSubMenuItem(showCurrentDateMenuItem);

            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu();
            mainMenu.CreateMenu(systemLevelMenu);

            return mainMenu;
        }

        public static MainMenu CreateEventsMenu()
        {
            // TODO: be implemented in Ex05.Menus.Events
            return null;
        }
    }
}
