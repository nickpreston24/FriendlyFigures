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

            string text = args[0];
            
            var translator = new FriendlyFigureTranslator();
            Int32.TryParse(text, out var number);
            
            string friendlyName = translator.Interpret(text);
            Helpers.Print(number, friendlyName);
            
            
            Console.WriteLine("Whole numbers: ");
            translator.InterpretRange(1, 10).Print();
            
            Console.WriteLine("20's: ");
            translator.InterpretRange(11, 20).Print();
        }
    }
}