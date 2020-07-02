using System;
using System.Collections.Generic;

// using  Print = FriendlyFigures.Helpers;

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

            var translator = new FriendlyFigureTranslator();
            Int32.TryParse(args[0], out var number);
            
            string friendlyName = translator.Interpret(number);
            Helpers.Print(number, friendlyName);

            var range =  translator.InterpretRange(1, 10);
            range.Print();
        }

      
    }
}