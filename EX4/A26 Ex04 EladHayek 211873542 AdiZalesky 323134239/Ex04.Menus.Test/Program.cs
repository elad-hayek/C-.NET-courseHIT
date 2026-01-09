using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfacesMenu = TestCreator.CreateInterfacesMenu();
            interfacesMenu.Show();

            // TODO: create and show Events menu when Ex05.Menus.Events is implemented
            //Events.MainMenu eventsMenu = TestCreator.CreateEventsMenu();
            //eventsMenu.Show();
        }
    }
}
