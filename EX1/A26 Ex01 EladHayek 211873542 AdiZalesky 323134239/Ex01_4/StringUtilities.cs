using System;

namespace Ex01_4
{
    public static class StringUtilities
    {
        public static bool IsStringValid(string i_String)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_String) || i_String.Length != 10)
            {
                Console.WriteLine("Error: The string provided can not be null or empty and must have exactly 10 characters");
                isValid = false;
            }

            return isValid;
        }

        public static bool IsAllNumbers(string i_String)
        {
            bool returnValue = true;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (!char.IsDigit(i_String[i]))
                {
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

        public static bool CanBeDevidedByThree(string i_String)
        {
            bool parseSuccess = long.TryParse(i_String, out long number);

            if (!parseSuccess)
            {
                Console.WriteLine("Error: The string provided is not all numbers");
            }

            return parseSuccess ? number % 3 == 0 : false;
        }

        public static bool IsAllAlphabets(string i_String)
        {
            bool returnValue = true;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (!char.IsLetter(i_String[i]))
                {
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

        public static int GetLowercaseLettersCount(string i_String)
        {
            bool isAllAlphabets = IsAllAlphabets(i_String);
            int lowercaseCount = -1;

            if (!isAllAlphabets)
            {
                Console.WriteLine("Error: The string provided is not all alphabets");
            }
            else
            {
                lowercaseCount = 0;

                for (int i = 0; i < i_String.Length; i++)
                {
                    if (char.IsLower(i_String[i]))
                    {
                        lowercaseCount++;
                    }
                }
            }

            return lowercaseCount;
        }


        public static bool IsInAlphabeticalAscendingOrder(string i_String)
        {
            bool isAllAlphabets = IsAllAlphabets(i_String);
            bool isAscendingOrder = true;

            if (!isAllAlphabets)
            {
                Console.WriteLine("Error: The string provided is not all alphabets");
                isAscendingOrder = false;
            }
            else
            {
                for (int i = 1; i < i_String.Length; i++)
                {
                    if (char.ToLower(i_String[i]) < char.ToLower(i_String[i - 1]))
                    {
                        isAscendingOrder = false;
                        break;
                    }
                }
            }

            return isAscendingOrder;
        }

        public static bool IsPalindromeRecursive(string i_String)
        {
            bool isPalindrome = false;

            if (i_String.Length <= 1)
            {
                isPalindrome = true;
            }
            else if (i_String[0] == i_String[i_String.Length - 1])
            {
                isPalindrome = IsPalindromeRecursive(i_String.Substring(1, i_String.Length - 2));
            }
           
            return isPalindrome;
        }
    }
}
