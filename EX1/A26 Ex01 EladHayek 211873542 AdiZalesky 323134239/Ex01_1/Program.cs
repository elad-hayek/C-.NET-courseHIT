using System;

namespace Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            BinaryByteNumberGroup binaryByteNumberGroup = new BinaryByteNumberGroup();
            bool addBinaryByteNumberOperationSuceeded = true;
            bool validationCheck = false;

            for (int i = 0; i < 3; i++)
            {
                string input;
                do
                {
                    Console.Write(string.Format("Enter binary byte number {0} (8 bits): ", i + 1));
                    input = Console.ReadLine();
                    validationCheck = BinaryByteNumber.ValidateString(input);
                    if (!validationCheck)
                    {
                        Console.WriteLine("Invalid input. Please enter exactly 8 bits (0s and 1s only).");
                    }
                } while (!validationCheck);

                BinaryByteNumber binaryByteNumber = new BinaryByteNumber(input);
                addBinaryByteNumberOperationSuceeded = binaryByteNumberGroup.AddBinaryByteNumber(binaryByteNumber, i);
                if (!addBinaryByteNumberOperationSuceeded)
                {
                    Console.WriteLine("Error: Could not add binary byte number to the group.");
                    return;
                }
            }

            binaryByteNumberGroup.PrintNumbersInAcendingOrder();
            binaryByteNumberGroup.PrintAverageDecimalValue();
            binaryByteNumberGroup.PrintShortestConsecutiveBitsCounts();
            binaryByteNumberGroup.PrintNumberOfPalindromes();
            binaryByteNumberGroup.PrintMaximumDiffrencesBetweenOnesAndZeros();
            binaryByteNumberGroup.PrintCountOfNumbersThatStartAndEndWithSameBit();
        }
    }
}
