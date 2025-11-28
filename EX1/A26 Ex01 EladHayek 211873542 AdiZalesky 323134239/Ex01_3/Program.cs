using Ex01_2;
using System;


namespace Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            string userInput;
            int numberOfLines = 0;
            bool numberOfLinesParseResult = false;

            do
            {
                Console.WriteLine("Please enter the tree height it should be between 4 and 15:");
                userInput = Console.ReadLine();
                numberOfLinesParseResult = int.TryParse(userInput, out numberOfLines);
            }
            while (!numberOfLinesParseResult || (numberOfLines < 4 || numberOfLines > 15));

            TreeBuilder treeBuilder = new TreeBuilder();

            treeBuilder.TryBuildTreeString(numberOfLines, out string treeString);
            Console.WriteLine(treeString);
        }
    }
}
