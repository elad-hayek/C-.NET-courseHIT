using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
     public class EventsTestCreator
     {
        private readonly CountLowercaseProvider r_CountLowercaseProvider = new CountLowercaseProvider();
        private readonly ShowVersionProvider r_ShowVerionProvider = new ShowVersionProvider();
        private readonly ShowCurrentTimeProvider r_ShowCurrentTimeProvider = new ShowCurrentTimeProvider();
        private readonly ShowCurrentDateProvider r_ShowCurrentDateProvider = new ShowCurrentDateProvider();

        public MainMenu CreateEventsMenu()
        {
            MenuItemWithSubMenu systemLevelMenu = new MenuItemWithSubMenu("Events Main Menu");
            MenuItem versionAndLowerCaseMenu = createEventsVersionAndLowercaseSubMenu();
            MenuItem dateAndTimeMenu = createEventsDateAndTimeSubMenu();
            systemLevelMenu.AddSubMenuItem(versionAndLowerCaseMenu);
            systemLevelMenu.AddSubMenuItem(dateAndTimeMenu);
            MainMenu mainMenu = new MainMenu();
            mainMenu.CreateMenu(systemLevelMenu);

            return mainMenu;
        }

        private MenuItem createEventsVersionAndLowercaseSubMenu()
        {
            MenuItemWithSubMenu versionAndLowerCaseMenu = new MenuItemWithSubMenu("Version and Lowercase");
            MenuItemWithAction showVersionMenuItem = new MenuItemWithAction("Show Version");
            MenuItemWithAction countLowercaseMenuItem = new MenuItemWithAction("Count Lowercase");
            showVersionMenuItem.Selected += r_ShowVerionProvider.ShowVersion;
            countLowercaseMenuItem.Selected += r_CountLowercaseProvider.CountLowercaseLetters;
            versionAndLowerCaseMenu.AddSubMenuItem(showVersionMenuItem);
            versionAndLowerCaseMenu.AddSubMenuItem(countLowercaseMenuItem);

            return versionAndLowerCaseMenu;
        }

        private MenuItem createEventsDateAndTimeSubMenu()
        {
            MenuItemWithSubMenu dateAndTimeMenu = new MenuItemWithSubMenu("Show Current Date/Time");
            MenuItemWithAction showCurrentTimeMenuItem = new MenuItemWithAction("Show Current Time");
            MenuItemWithAction showCurrentDateMenuItem = new MenuItemWithAction("Show Current Date");
            showCurrentTimeMenuItem.Selected += r_ShowCurrentTimeProvider.ShowCurrentTime;
            showCurrentDateMenuItem.Selected += r_ShowCurrentDateProvider.ShowCurrentDate;
            dateAndTimeMenu.AddSubMenuItem(showCurrentTimeMenuItem);
            dateAndTimeMenu.AddSubMenuItem(showCurrentDateMenuItem);

            return dateAndTimeMenu;
        }
    }
}
