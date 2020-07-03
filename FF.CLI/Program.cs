using System;

namespace FriendlyFigures.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments provided!");
                return;
            }

            var text = args[0];
            var translator = new FriendlyFigureTranslator();

            var friendlyName = translator.Interpret(text);
            Console.WriteLine($"{text} is {friendlyName}");
        }
    }
}