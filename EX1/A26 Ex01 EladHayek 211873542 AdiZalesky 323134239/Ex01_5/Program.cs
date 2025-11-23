using System;


namespace Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string userInput;
            do
            {
                Console.WriteLine("Please enter a whole number of exactly 7 digits:");
                userInput = Console.ReadLine();

            }
            while (!NumberUtilities.IsNumberValid(userInput));

            int graterThanFirstDigitCount = NumberUtilities.HowManyDigitsAreGraterThanTheFirstDigit(userInput);
            Console.WriteLine(string.Format("Number of digits grater than the first digit: {0}", graterThanFirstDigitCount));

            int digitsDividedByThreeCount = NumberUtilities.HowManyDigitsDevideByThree(userInput);
            Console.WriteLine(string.Format("Number of digits that can be divided by 3: {0}", digitsDividedByThreeCount));

            int largestDifference = NumberUtilities.GetTheLargetsDiffrenceBetweenTwoDigits(userInput);
            Console.WriteLine(string.Format("The largest difference between two digits is: {0}", largestDifference));

            int mostCommonDigit = NumberUtilities.GetTheMostCommonDigit(userInput, out int mostCommonDigitOccurrences);
            Console.WriteLine(string.Format("The most common digit is: {0}, it appears {1} times", mostCommonDigit, mostCommonDigitOccurrences));
        }
    }
}
