using System;

namespace Ex04.Menus.Interfaces
{
    public class ShowCurrentDateProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
            Console.WriteLine($"Current Date is: {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}
