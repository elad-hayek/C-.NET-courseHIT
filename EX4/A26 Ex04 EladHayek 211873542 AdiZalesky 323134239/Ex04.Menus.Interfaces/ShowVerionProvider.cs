using System;

namespace Ex04.Menus.Interfaces
{
    public class ShowVerionProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
            Console.WriteLine("App Version: 26.1.4.5940");
        }
    }
}
