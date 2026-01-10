using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class CountLowercaseProvider : IMenuItemActionProvider
    {
        void IMenuItemActionProvider.OnMenuItemSelected()
        {
            CountLowercaseLetters();
        }

        public void CountLowercaseLetters()
        {
            Console.WriteLine("Please enter a string:");
            string userInput = Console.ReadLine();
            int lowercaseCount = 0;

            foreach (char c in userInput)
            {
                if (char.IsLower(c))
                {
                    lowercaseCount++;
                }
            }

            Console.WriteLine($"There are {lowercaseCount} lowercase letters in your text ");
        }
    }
}
