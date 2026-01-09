using System;

namespace Ex04.Menus.Interfaces
{
    public class ShowCurrentTimeProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
            Console.WriteLine($"Current Time is: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}
