using System;

namespace Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            BinaryByteNumberGroup binaryByteNumberGroup = new BinaryByteNumberGroup();
            bool addBinaryByteNumberOperationSucceeded = true;
            bool isInputValid = false;

            for (int i = 0; i < 3; i++)
            {
                string input;

                do
                {
                    Console.Write(
                        string.Format("Enter binary byte number {0} (8 bits): ", i + 1));

                    input = Console.ReadLine();
                    isInputValid = BinaryByteNumber.ValidateString(input);

                    if (!isInputValid)
                    {
                        Console.WriteLine("Invalid input. Please enter exactly 8 bits (0s and 1s only).");
                    }
                }
                while (!isInputValid);

                BinaryByteNumber binaryByteNumber = new BinaryByteNumber(input);
                addBinaryByteNumberOperationSucceeded =
                    binaryByteNumberGroup.AddBinaryByteNumber(binaryByteNumber, i);

                if (!addBinaryByteNumberOperationSucceeded)
                {
                    Console.WriteLine("Error: Could not add binary byte number to the group.");

                    return;
                }
            }

            binaryByteNumberGroup.PrintNumbersInAscendingOrder();
            binaryByteNumberGroup.PrintAverageDecimalValue();
            binaryByteNumberGroup.PrintShortestConsecutiveBitsCounts();
            binaryByteNumberGroup.PrintNumberOfPalindromes();
            binaryByteNumberGroup.PrintMaximumDifferencesBetweenOnesAndZeros();
            binaryByteNumberGroup.PrintCountOfNumbersThatStartAndEndWithSameBit();
        }
    }
}
