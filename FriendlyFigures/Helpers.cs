using System;

namespace FriendlyFigures
{
    public class Helpers
    {
        public static void PrintRange(int start, int end = 0)
        {
            var builder = new FriendlyFigureTranslator();
            for (int i = start; i < end; i++)
            {
                Console.WriteLine(builder.Interpret(i));
            }
        } 
    }
}