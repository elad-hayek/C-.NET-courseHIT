
using System;
using System.Text;

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

    public class BinaryByteNumber
    {
        private string m_BinaryByteString;
        private int m_DecimalValue;

        public BinaryByteNumber(string i_BinaryByteString)
        {
            m_BinaryByteString = i_BinaryByteString;
            m_DecimalValue = toDecimal();
        }

        public int GetDecimalValue()
        {
            return m_DecimalValue;
        }

        public string GetBinaryString()
        {
            return m_BinaryByteString;
        }

        private int toDecimal()
        {
            int decimalValue = 0;
            int length = m_BinaryByteString.Length;
            int powerOfTwo = 1;
            for (int i = 0; i < length; i++)
            {
                if (m_BinaryByteString[length - i - 1] == '1')
                {
                    decimalValue += powerOfTwo;
                }
                powerOfTwo *= 2;
            }
            return decimalValue;
        }

        public static bool ValidateString(string i_BinaryByteString)
        {
            if (i_BinaryByteString.Length != 8)
            {
                return false;
            }

            for (int i = 0; i < 8; i++)
            {
                char currentBitCharInString = i_BinaryByteString[i];

                if (currentBitCharInString != '0' && currentBitCharInString != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPalindrome()
        {
            for (int i = 0; i < 4; i++)
            {
                if (m_BinaryByteString[i] != m_BinaryByteString[7 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetShortestConsecutiveBitsCount()
        {
            int minCountOfConsecutiveBits = 8;
            int currentCountOfConsecutiveBits = 1;
            for (int i = 1; i < 8; i++)
            {
                if (m_BinaryByteString[i] == m_BinaryByteString[i - 1])
                {
                    currentCountOfConsecutiveBits++;
                }
                else
                {
                    if (currentCountOfConsecutiveBits < minCountOfConsecutiveBits)
                    {
                        minCountOfConsecutiveBits = currentCountOfConsecutiveBits;
                    }
                    currentCountOfConsecutiveBits = 1;
                }
            }
            if (currentCountOfConsecutiveBits < minCountOfConsecutiveBits)
            {
                minCountOfConsecutiveBits = currentCountOfConsecutiveBits;
            }
            return minCountOfConsecutiveBits;
        }

        public int GetMaximumDiffrenceBetweenOnesAndZeros()
        {
            int countOnes = 0;
            int countZeros = 0;

            for (int i = 0; i < 8; i++)
            {
                if (m_BinaryByteString[i] == '1')
                {
                    countOnes++;
                }
                else
                {
                    countZeros++;
                }
            }

            return Math.Abs(countOnes - countZeros);
        }

        public bool IsStartsAndEndsWithSameBit()
        {
            return m_BinaryByteString[0] == m_BinaryByteString[7];
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", m_DecimalValue, m_BinaryByteString);
        }

    }

    public class BinaryByteNumberGroup
    {
        private BinaryByteNumber[] m_BinaryByteNumbers;

        public BinaryByteNumberGroup()
        {
            m_BinaryByteNumbers = new BinaryByteNumber[3];
        }

        public bool AddBinaryByteNumber(BinaryByteNumber i_BinaryByteNumber, int i_Index)
        {
            if (i_Index < 0 || i_Index >= m_BinaryByteNumbers.Length)
            {
                return false;
            }
            m_BinaryByteNumbers[i_Index] = i_BinaryByteNumber;
            return true;
        }

        public void PrintAverageDecimalValue()
        {
            int sumOfDecimalNumbers = 0;

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                sumOfDecimalNumbers += binaryByteNumber.GetDecimalValue();
            }

            float averageOfDecimalNumbers = (float)sumOfDecimalNumbers / m_BinaryByteNumbers.Length;
            Console.WriteLine("Average: {0:F2}", averageOfDecimalNumbers);
        }

        public void PrintNumberOfPalindromes()
        {
            int numberOfPalindromes = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Number of palindromes: {0} (");

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                if (binaryByteNumber.IsPalindrome())
                {
                    if (numberOfPalindromes > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    numberOfPalindromes++;
                    stringBuilder.Append(binaryByteNumber.GetBinaryString());
                }
            }

            stringBuilder.Append(")");

            Console.WriteLine(string.Format(stringBuilder.ToString(), numberOfPalindromes));
        }

        public void PrintNumbersInAcendingOrder()
        {
            Array.Sort(m_BinaryByteNumbers, (a, b) => a.GetDecimalValue().CompareTo(b.GetDecimalValue()));
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Decimal numbers in ascending order: ");

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                stringBuilder.Append(m_BinaryByteNumbers[i].ToString());

                if (i < m_BinaryByteNumbers.Length - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        public void PrintShortestConsecutiveBitsCounts()
        {
            int shortestConsecutiveBitsCount = m_BinaryByteNumbers[0].GetShortestConsecutiveBitsCount();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Shortest bit sequence: {0} (");

            for (int i = 1; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                int currentBinaryNumberShortestConsecutiveBitsCount = binaryByteNumber.GetShortestConsecutiveBitsCount();
                if (currentBinaryNumberShortestConsecutiveBitsCount < shortestConsecutiveBitsCount)
                {
                    shortestConsecutiveBitsCount = currentBinaryNumberShortestConsecutiveBitsCount;
                }
            }

            int numberOfBinaryNumbersWithShortestConsecutiveBitsCount = 0;

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                if (shortestConsecutiveBitsCount == binaryByteNumber.GetShortestConsecutiveBitsCount())
                {
                    if (numberOfBinaryNumbersWithShortestConsecutiveBitsCount > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    numberOfBinaryNumbersWithShortestConsecutiveBitsCount++;
                    stringBuilder.Append(m_BinaryByteNumbers[i].GetBinaryString());
                }

            }

            stringBuilder.Append(")");

            Console.WriteLine(string.Format(
                stringBuilder.ToString(),
                shortestConsecutiveBitsCount));
        }

        public void PrintMaximumDiffrencesBetweenOnesAndZeros()
        {
            int maxDifference = m_BinaryByteNumbers[0].GetMaximumDiffrenceBetweenOnesAndZeros();
            BinaryByteNumber maxDifferenceBinaryNumber = m_BinaryByteNumbers[0];

            for (int i = 1; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                int currentDifference = binaryByteNumber.GetMaximumDiffrenceBetweenOnesAndZeros();
                if (currentDifference > maxDifference)
                {
                    maxDifference = currentDifference;
                    maxDifferenceBinaryNumber = binaryByteNumber;
                }
                else if (currentDifference == maxDifference &&
                    binaryByteNumber.GetDecimalValue() < maxDifferenceBinaryNumber.GetDecimalValue())
                {
                    maxDifferenceBinaryNumber = binaryByteNumber;
                }
            }

            Console.WriteLine(string.Format(
                "Number with maximum difference between number 1s and 0s: {0} - diffrence of {1}",
                maxDifferenceBinaryNumber.ToString(),
                maxDifference));
        }

        public void PrintCountOfNumbersThatStartAndEndWithSameBit()
        {
            int numberOfNumbersThatStartsAndEndWithTheSameBit = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Numbers that start and end with same digit: {0} (");

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                if (binaryByteNumber.IsStartsAndEndsWithSameBit())
                {
                    if (numberOfNumbersThatStartsAndEndWithTheSameBit > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    numberOfNumbersThatStartsAndEndWithTheSameBit++;
                    stringBuilder.Append(binaryByteNumber.GetBinaryString());

                }
            }

            stringBuilder.Append(")");

            Console.WriteLine(string.Format(
                stringBuilder.ToString(),
                numberOfNumbersThatStartsAndEndWithTheSameBit));
        }


    }
}
