using System;
using System.Collections.Generic;

namespace FriendlyFigures
{
    public static class Helpers
    {
        public static List<int> GetDigits(this string text)
        {
            List<int> places = new List<int>();
            for (int i = 0; i < text.Length; ++i)
            {
                int digit = text[text.Length - i - 1] - '0';
                digit *= (int) Math.Pow(10, i);
                places.Add(digit);
            }
            places.Reverse();
            return places;
        }

        public static void Print(this Dictionary<int, string> range)
        {
            foreach (var pair in range)
            {
                Print(pair.Key, pair.Value);
            }
        }
        public static void Print(int number, string friendlyName)
        {
            Console.WriteLine($"{number} is {friendlyName}");
        }
    }
}