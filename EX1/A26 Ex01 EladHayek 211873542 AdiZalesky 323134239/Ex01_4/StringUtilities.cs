using System;

namespace Ex01_4
{
    public static class StringUtilities
    {
        public static bool IsStringValid(string i_String)
        {
            if (string.IsNullOrEmpty(i_String))
            {
                Console.WriteLine("Error: The string provided is null or empty");
                return false;
            }

            if (i_String.Length != 10)
            {
                Console.WriteLine("Error: The string provided does not contain exactly 10 characters");
                return false;
            }

            return true;
        }

        public static bool IsAllNumbers(string i_String)
        {
            for (int i = 0; i < i_String.Length; i++)
            {
                if (!char.IsDigit(i_String[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CanBeDevidedByThree(string i_String)
        {
            bool parseSuccess = long.TryParse(i_String, out long number);

            if (!parseSuccess)
            {
                Console.WriteLine("Error: The string provided is not all numbers");
                return false;
            }

            return number % 3 == 0;
        }

        public static bool IsAllAlphabets(string i_String)
        {
            for (int i = 0; i < i_String.Length; i++)
            {
                if (!char.IsLetter(i_String[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetLowercaseLettersCount(string i_String)
        {
            if (!IsAllAlphabets(i_String))
            {
                Console.WriteLine("Error: The string provided is not all alphabets");
                return -1;
            }

            int lowercaseCount = 0;
            for (int i = 0; i < i_String.Length; i++)
            {
                if (char.IsLower(i_String[i]))
                {
                    lowercaseCount++;
                }
            }
            return lowercaseCount;
        }


        public static bool IsInAlphabeticalAscendingOrder(string i_String)
        {
            if (!IsAllAlphabets(i_String))
            {
                Console.WriteLine("Error: The string provided is not all alphabets");
                return false;
            }

            for (int i = 1; i < i_String.Length; i++)
            {
                if (char.ToLower(i_String[i]) < char.ToLower(i_String[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPalindromeRecursive(string i_String)
        {
            if (i_String.Length <= 1)
            {
                return true;
            }

            if (i_String[0] != i_String[i_String.Length - 1])
            {
                return false;
            }
            else
            {
                return IsPalindromeRecursive(i_String.Substring(1, i_String.Length - 2));
            }
        }
    }
}
