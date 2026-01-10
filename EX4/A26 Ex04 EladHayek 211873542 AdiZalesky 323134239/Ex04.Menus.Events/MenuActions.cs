
using System;

namespace Ex04.Menus.Events
{
    public static class MenuActions
    {
        public static void CountLowercaseLetters()
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

        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 26.1.4.5940");
        }

        public static void ShowCurrentDate()
        {
            Console.WriteLine($"Current Date is: {DateTime.Now.ToString("dd/MM/yyyy")}");
        }

        public static void ShowCurrentTime()
        {
            Console.WriteLine($"Current Time is: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}
