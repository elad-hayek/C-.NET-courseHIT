using System;

namespace Ex01_1
{
    public class BinaryByteNumber
    {
        private string m_BinaryByteString;
        private int m_DecimalValue;

        public BinaryByteNumber(string i_BinaryByteString)
        {
            m_BinaryByteString = i_BinaryByteString;
            m_DecimalValue = convertToDecimal();
        }

        public int GetDecimalValue()
        {
            return m_DecimalValue;
        }

        public string GetBinaryString()
        {
            return m_BinaryByteString;
        }

        private int convertToDecimal()
        {
            int decimalValue = 0;
            int powerOfTwo = 1;
            int length = m_BinaryByteString.Length;

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
            bool isValid = i_BinaryByteString.Length == 8;

            for (int i = 0; isValid && i < 8; i++)
            {
                char currentBitCharInString = i_BinaryByteString[i];

                if (currentBitCharInString != '0' && currentBitCharInString != '1')
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public bool IsPalindrome()
        {
            bool isPalindrome = true;

            for (int i = 0; i < 4 && isPalindrome; i++)
            {
                if (m_BinaryByteString[i] != m_BinaryByteString[7 - i])
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome;
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

        public int GetMaximumDifferenceBetweenOnesAndZeros()
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

        public bool IsStartAndEndWithSameBit()
        {
            return m_BinaryByteString[0] == m_BinaryByteString[7];
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", m_DecimalValue, m_BinaryByteString);
        }
    }
}
