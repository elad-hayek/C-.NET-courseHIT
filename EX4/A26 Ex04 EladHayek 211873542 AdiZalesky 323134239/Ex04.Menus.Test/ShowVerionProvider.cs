using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowVerionProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
           ShowVersion();
        }

        public void ShowVersion()
        {
            Console.WriteLine("App Version: 26.1.4.5940");
        }
    }
}
