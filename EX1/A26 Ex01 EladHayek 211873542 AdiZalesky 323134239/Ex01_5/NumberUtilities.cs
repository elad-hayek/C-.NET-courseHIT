using System;


namespace Ex01_5
{
    public static class NumberUtilities
    {
        public static bool IsNumberValid(string i_Number)
        {
            if (string.IsNullOrEmpty(i_Number) || i_Number.Length != 7)
            {
                Console.WriteLine("Error: The string provided is null or empty");
                return false;
            }

            return int.TryParse(i_Number, out int number);
        }

        public static int HowManyDigitsAreGraterThanTheFirstDigit(string i_Number)
        {
            int digitsCount = 0;
            if (!IsNumberValid(i_Number))
            {
                return -1;
            }

            int firstDigit = (int)char.GetNumericValue(i_Number[0]);
            for (int i = 1; i < 7; i++)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);
                if (currentDigit > firstDigit)
                {
                    digitsCount++;
                }
            }

            return digitsCount;
        }

        public static int HowManyDigitsDevideByThree(string i_Number)
        {
            int digitsCount = 0;
            if (!IsNumberValid(i_Number))
            {
                return -1;
            }

            for (int i = 0; i < 7; i++)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);
                if (currentDigit % 3 == 0)
                {
                    digitsCount++;
                }
            }
            return digitsCount;
        }

        public static int GetTheLargetsDiffrenceBetweenTwoDigits(string i_Number)
        {
            if (!IsNumberValid(i_Number))
            {
                return -1;
            }

            int maxDigit = (int)char.GetNumericValue(i_Number[0]);
            int minDigit = (int)char.GetNumericValue(i_Number[0]);

            for (int i = 1; i < 7; i++)
            {
                int currentDigit = (int)char.GetNumericValue(i_Number[i]);
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }
            return maxDigit - minDigit;
        }

        public static int GetTheMostCommonDigit(string i_Number, out int o_NumberOfAccurences)
        {
            if (!IsNumberValid(i_Number))
            {
                o_NumberOfAccurences = -1;
                return -1;
            }

            o_NumberOfAccurences = 0;
            int mostCommonDigit = -1;

            for (int digit = 0; digit <= 9; digit++)
            {
                int currentDigitCount = 0;
                for (int i = 0; i < 7; i++)
                {
                    int currentDigit = (int)char.GetNumericValue(i_Number[i]);
                    if (currentDigit == digit)
                    {
                        currentDigitCount++;
                    }
                }
                if (currentDigitCount > o_NumberOfAccurences)
                {
                    o_NumberOfAccurences = currentDigitCount;
                    mostCommonDigit = digit;
                }
            }

            return mostCommonDigit;

        }
    }
}
