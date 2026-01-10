using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowCurrentDateProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
            ShowCurrentDate();
        }

        public void ShowCurrentDate()
        {
            Console.WriteLine($"Current Date is: {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}
