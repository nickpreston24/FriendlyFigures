using System;
using System.Text.RegularExpressions;

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

            
            if (Regex.IsMatch(text, @"[^\d-]"))
            {
                Console.WriteLine("Non-numeric values are not allowed!"); //TODO: clean duplicate dashes
                return;
            }

            var number = int.Parse(text);

            if (number <= int.MinValue)
            {
                Console.WriteLine("Int32 Minimum Value is not supported.  Try a larger number");
                return;
            }

            var translator = new FriendlyFigureTranslator();

            var friendlyName = translator.Interpret(text);
            Console.WriteLine($"{text} is {friendlyName}");
        }
    }
}