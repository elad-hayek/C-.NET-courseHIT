using System;
using System.Text;

namespace Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            int numberOfLines = 7;
            StringBuilder stringBuilder = new StringBuilder();

            int lineStartChar = 'A';
            int digit = 1;

            for (int i = 0; i < numberOfLines - 2; i++)
            {
                stringBuilder.Append((char)lineStartChar);
                lineStartChar += 1;

                for (int j = numberOfLines - 2 - i; j > 0; j--)
                {
                    stringBuilder.Append("  ");
                }

                for (int j = 1; j < (i + 1) * 2; j++)
                {
                    stringBuilder.Append(" ");
                    stringBuilder.Append(digit);
                    digit += 1;
                    if (digit > 9)
                    {
                        digit = 1;
                    }
                }

                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
            }

            for (int i = 0; i < 2; i++)
            {
                stringBuilder.Append((char)lineStartChar);
                lineStartChar += 1;

                for (int j = numberOfLines - 2; j > 0; j--)
                {
                    stringBuilder.Append("  ");
                }

                stringBuilder.Append(string.Format("|{0}|", digit));
                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
            }


            Console.WriteLine(stringBuilder.ToString());

        }

    }
}
