using System;

namespace Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            string userInput;
            do
            {
                Console.WriteLine("Please enter an alphanumeric string of exactly 10 characters:");
                userInput = Console.ReadLine();

            }
            while (!StringUtilities.IsStringValid(userInput));

            bool isPalindrome = StringUtilities.IsPalindromeRecursive(userInput);
            Console.WriteLine("Is a palindrome: {0}", isPalindrome);

            bool isAllNumbers = StringUtilities.IsAllNumbers(userInput);
            bool isAllAlphabets = StringUtilities.IsAllAlphabets(userInput);
            if (isAllNumbers)
            {
                bool canBeDevidedByThree = StringUtilities.CanBeDevidedByThree(userInput);
                Console.WriteLine("Can be divided by 3: {0}", canBeDevidedByThree);
            }
            else if (isAllAlphabets)
            {
                int lowercaseCount = StringUtilities.GetLowercaseLettersCount(userInput);
                bool isInAscendingOrder = StringUtilities.IsInAlphabeticalAscendingOrder(userInput);
                Console.WriteLine("Number of lowercase letters: {0}", lowercaseCount);
                Console.WriteLine("Is in alphabetical ascending order: {0}", isInAscendingOrder);
            }

        }
    }

}
