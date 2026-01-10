using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowCurrentTimeProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
            ShowCurrentTime();
        }

        public void ShowCurrentTime()
        {
            Console.WriteLine($"Current Time is: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}
