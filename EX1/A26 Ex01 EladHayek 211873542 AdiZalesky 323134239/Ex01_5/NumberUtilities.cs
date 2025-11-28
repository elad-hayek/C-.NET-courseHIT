using System;


namespace Ex01_5
{
    public static class NumberUtilities
    {
        public static bool IsNumberValid(string i_Number)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_Number) || i_Number.Length != 7)
            {
                Console.WriteLine("Error: The string provided is null or empty or diffrent then 7 digits");
                isValid = false;
            }
            else
            {
                isValid = int.TryParse(i_Number, out int number);

                if (!isValid)
                {
                    Console.WriteLine("Error: The string provided is not a valid whole number");
                }
            }

            return isValid;
        }

        public static int HowManyDigitsAreGreaterThanTheFirstDigit(string i_Number)
        {
            bool isNumberValid = IsNumberValid(i_Number);
            int digitsCount = -1;

            if (isNumberValid)
            {
                digitsCount = 0;
                int firstDigit = (int)char.GetNumericValue(i_Number[0]);

                for (int i = 1; i < 7; i++)
                {
                    int currentDigit = (int)char.GetNumericValue(i_Number[i]);

                    if (currentDigit > firstDigit)
                    {
                        digitsCount++;
                    }
                }
            }

            return digitsCount;
        }

        public static int HowManyDigitsDevideByThree(string i_Number)
        {
            bool isNumberValid = IsNumberValid(i_Number);
            int digitsCount = -1;

            if (isNumberValid)
            {
                digitsCount = 0;

                for (int i = 0; i < 7; i++)
                {
                    int currentDigit = (int)char.GetNumericValue(i_Number[i]);
                    if (currentDigit % 3 == 0)
                    {
                        digitsCount++;
                    }
                }
            }

            return digitsCount;
        }

        public static int GetTheLargetsDiffrenceBetweenTwoDigits(string i_Number)
        {
            bool isNumberValid = IsNumberValid(i_Number);
            int diffrence = -1;

            if (isNumberValid)
            {
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

                diffrence = maxDigit - minDigit;
            }

            return diffrence;
        }

        public static int GetTheMostCommonDigit(string i_Number, out int o_NumberOfAccurences)
        {
            bool isNumberValid = IsNumberValid(i_Number);
            int mostCommonDigit = -1;

            if (!isNumberValid)
            {
                o_NumberOfAccurences = -1;
            }
            else
            {
                o_NumberOfAccurences = 0;

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
            }

            return mostCommonDigit;
        }
    }
}
