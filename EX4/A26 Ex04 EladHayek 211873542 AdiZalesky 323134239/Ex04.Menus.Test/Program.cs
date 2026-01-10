using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfacesMenu = TestCreator.CreateInterfacesMenu();
            interfacesMenu.Show();

            Events.MainMenu eventsMenu = TestCreator.CreateEventsMenu();
            eventsMenu.Show();
        }
    }
}
