using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
     public static class TestCreator
     {
        public static Interfaces.MainMenu CreateInterfacesMenu()
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

        public static Events.MainMenu CreateEventsMenu()
        {
            Events.MenuItemWithSubMenu systemLevelMenu = new Events.MenuItemWithSubMenu("Events Main Menu");
            Events.MenuItemWithSubMenu versionAndLowerCaseMenu = new Events.MenuItemWithSubMenu("Version and Lowercase");
            Events.MenuItemWithSubMenu dateAndTimeMenu = new Events.MenuItemWithSubMenu("Show Current Date/Time");
            systemLevelMenu.AddSubMenuItem(versionAndLowerCaseMenu);
            systemLevelMenu.AddSubMenuItem(dateAndTimeMenu);

            Events.MenuItemWithAction showVersionMenuItem = new Events.MenuItemWithAction("Show Version");
            Events.MenuItemWithAction countLowercaseMenuItem = new Events.MenuItemWithAction("Count Lowercase");
            showVersionMenuItem.Selected += Events.MenuActions.ShowVersion;
            countLowercaseMenuItem.Selected += Events.MenuActions.CountLowercaseLetters;
            versionAndLowerCaseMenu.AddSubMenuItem(showVersionMenuItem);
            versionAndLowerCaseMenu.AddSubMenuItem(countLowercaseMenuItem);

            Events.MenuItemWithAction showCurrentTimeMenuItem = new Events.MenuItemWithAction("Show Current Time");
            Events.MenuItemWithAction showCurrentDateMenuItem = new Events.MenuItemWithAction("Show Current Date");
            showCurrentTimeMenuItem.Selected += Events.MenuActions.ShowCurrentTime;
            showCurrentDateMenuItem.Selected += Events.MenuActions.ShowCurrentDate;
            dateAndTimeMenu.AddSubMenuItem(showCurrentTimeMenuItem);
            dateAndTimeMenu.AddSubMenuItem(showCurrentDateMenuItem);

            Events.MainMenu mainMenu = new Events.MainMenu();
            mainMenu.CreateMenu(systemLevelMenu);

            return mainMenu;
        }
    }
}
