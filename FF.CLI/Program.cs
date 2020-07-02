using System;

namespace FriendlyFigures.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments provided!");
                return;
            }

            Int32.TryParse(args[0], out var number);
            Console.WriteLine("Hello World!");
            string friendlyName = "Ten";
            Console.WriteLine($"{number} is {friendlyName}");
        }
    }
}