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
            bool isIndexInRange = i_Index >= 0 && i_Index < m_BinaryByteNumbers.Length;

            if (isIndexInRange)
            {
                m_BinaryByteNumbers[i_Index] = i_BinaryByteNumber;
            }

            return isIndexInRange;
        }

        public void PrintAverageDecimalValue()
        {
            float sumOfDecimalNumbers = 0f;

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                sumOfDecimalNumbers += binaryByteNumber.GetDecimalValue();
            }

            float averageOfDecimalNumbers = sumOfDecimalNumbers / m_BinaryByteNumbers.Length;
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

        public void PrintNumbersInAscendingOrder()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Decimal numbers in ascending order: ");
            Array.Sort(m_BinaryByteNumbers,
                (i_First, i_Second) =>
                    i_First.GetDecimalValue().CompareTo(i_Second.GetDecimalValue()));

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
            StringBuilder stringBuilder = new StringBuilder();
            int shortestConsecutiveBitsCount = m_BinaryByteNumbers[0].GetShortestConsecutiveBitsCount();

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
                    stringBuilder.Append(binaryByteNumber.GetBinaryString());
                }
            }

            stringBuilder.Append(")");
            Console.WriteLine(string.Format(stringBuilder.ToString(), shortestConsecutiveBitsCount));
        }

        public void PrintMaximumDifferencesBetweenOnesAndZeros()
        {
            int maxDifference = m_BinaryByteNumbers[0].GetMaximumDifferenceBetweenOnesAndZeros();
            BinaryByteNumber maxDifferenceBinaryNumber = m_BinaryByteNumbers[0];

            for (int i = 1; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];
                int currentDifference = binaryByteNumber.GetMaximumDifferenceBetweenOnesAndZeros();

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

            Console.WriteLine(
                string.Format(
                    "Number with maximum difference between number 1s and 0s: {0} - difference of {1}",
                    maxDifferenceBinaryNumber.ToString(),
                    maxDifference));
        }

        public void PrintCountOfNumbersThatStartAndEndWithSameBit()
        {
            int numberOfNumbersThatStartAndEndWithTheSameBit = 0;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Numbers that start and end with same digit: {0} (");

            for (int i = 0; i < m_BinaryByteNumbers.Length; i++)
            {
                BinaryByteNumber binaryByteNumber = m_BinaryByteNumbers[i];

                if (binaryByteNumber.IsStartAndEndWithSameBit())
                {
                    if (numberOfNumbersThatStartAndEndWithTheSameBit > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    numberOfNumbersThatStartAndEndWithTheSameBit++;
                    stringBuilder.Append(binaryByteNumber.GetBinaryString());
                }
            }

            stringBuilder.Append(")");
            Console.WriteLine(string.Format(stringBuilder.ToString(), numberOfNumbersThatStartAndEndWithTheSameBit));
        }
    }
}
