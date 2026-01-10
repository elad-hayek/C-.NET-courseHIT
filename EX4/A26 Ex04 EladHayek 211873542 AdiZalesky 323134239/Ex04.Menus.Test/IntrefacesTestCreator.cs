using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class IntrefacesTestCreator
    {
        private readonly CountLowercaseProvider r_CountLowercaseProvider = new CountLowercaseProvider();
        private readonly ShowVersionProvider r_ShowVerionProvider = new ShowVersionProvider();
        private readonly ShowCurrentTimeProvider r_ShowCurrentTimeProvider = new ShowCurrentTimeProvider();
        private readonly ShowCurrentDateProvider r_ShowCurrentDateProvider = new ShowCurrentDateProvider();

        public MainMenu CreateInterfacesMenu()
        {
            MenuItemWithSubMenu systemLevelMenu = new MenuItemWithSubMenu("Interfaces Main Menu");
            MenuItem versionAndLowerCaseMenu = createInterfacesVersionAndLowercaseSubMenu();
            MenuItem dateAndTimeMenu = createInterfacesDateAndTimeSubMenu();
            systemLevelMenu.AddSubMenuItem(versionAndLowerCaseMenu);
            systemLevelMenu.AddSubMenuItem(dateAndTimeMenu);
            MainMenu mainMenu = new MainMenu();
            mainMenu.CreateMenu(systemLevelMenu);

            return mainMenu;
        }

        private MenuItem createInterfacesVersionAndLowercaseSubMenu()
        {
            MenuItemWithSubMenu versionAndLowerCaseMenu = new MenuItemWithSubMenu("Version and Lowercase");
            MenuItemWithAction showVersionMenuItem = new MenuItemWithAction("Show Version", r_ShowVerionProvider);
            MenuItemWithAction countLowercaseMenuItem = new MenuItemWithAction("Count Lowercase", r_CountLowercaseProvider);
            versionAndLowerCaseMenu.AddSubMenuItem(showVersionMenuItem);
            versionAndLowerCaseMenu.AddSubMenuItem(countLowercaseMenuItem);

            return versionAndLowerCaseMenu;
        }

        private MenuItem createInterfacesDateAndTimeSubMenu()
        {
            MenuItemWithSubMenu dateAndTimeMenu = new MenuItemWithSubMenu("Show Current Date/Time");
            MenuItemWithAction showCurrentTimeMenuItem = new MenuItemWithAction("Show Current Time", r_ShowCurrentTimeProvider);
            MenuItemWithAction showCurrentDateMenuItem = new MenuItemWithAction("Show Current Date", r_ShowCurrentDateProvider);
            dateAndTimeMenu.AddSubMenuItem(showCurrentTimeMenuItem);
            dateAndTimeMenu.AddSubMenuItem(showCurrentDateMenuItem);

            return dateAndTimeMenu;
        }
    }
}
