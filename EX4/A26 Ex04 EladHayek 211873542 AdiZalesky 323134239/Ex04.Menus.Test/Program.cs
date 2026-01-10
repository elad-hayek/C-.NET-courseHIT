using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            IntrefacesTestCreator intrefacesTestCreator = new IntrefacesTestCreator();
            Interfaces.MainMenu interfacesMenu = intrefacesTestCreator.CreateInterfacesMenu();
            interfacesMenu.Show();

            EventsTestCreator eventsTestCreator = new EventsTestCreator();
            Events.MainMenu eventsMenu = eventsTestCreator.CreateEventsMenu();
            eventsMenu.Show();
        }
    }
}
