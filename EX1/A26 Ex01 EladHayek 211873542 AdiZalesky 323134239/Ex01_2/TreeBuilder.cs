using System.Text;

namespace Ex01_2
{
    public class TreeBuilder
    {
        private const int k_MinNumberOfLines = 4;
        private const int k_MaxNumberOfLines = 15;

        public bool TryBuildTreeString(int numberOfLines, out string o_TreeString)
        {
            bool returnValue = true;
            o_TreeString = string.Empty;

            if (numberOfLines < k_MinNumberOfLines || numberOfLines > k_MaxNumberOfLines)
            {
                o_TreeString = string.Format("Number of lines must be between {0} and {1}",
                                                k_MinNumberOfLines,
                                                k_MaxNumberOfLines);
                returnValue = false;
            }

            if (returnValue)
            {
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

                o_TreeString = stringBuilder.ToString();
            }

            return returnValue;
        }
    }
}
