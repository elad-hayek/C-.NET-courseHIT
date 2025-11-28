using System;

namespace Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            TreeBuilder treeBuilder = new TreeBuilder();

            treeBuilder.TryBuildTreeString(7, out string treeString);
            Console.WriteLine(treeString);
        }

    }
}
