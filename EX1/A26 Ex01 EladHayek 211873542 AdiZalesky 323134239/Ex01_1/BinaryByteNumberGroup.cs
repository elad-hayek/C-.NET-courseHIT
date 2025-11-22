using System;
using System.Text;

namespace Ex01_1
{
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