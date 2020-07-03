using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FriendlyFigures
{
    public static class Helpers
    {
        public static string DeepTrim(this string text) => Regex.Replace(text, @"\s+", " ").Trim();
        public static int GCD(this int number, int value) => number == 0 ? value : GCD(value % number, number);

        public static int Place(this int n) => Convert.ToInt32(Math.Pow(10, Math.Floor(Math.Log10(n))));

        public static int Magnitude(this int digit, int place)
        {
            var closest = digit.ClosestWholeNumber(place);
            var gcd1 = digit.GCD(closest);
            var gcd2 = closest.GCD(place);
            var magnitude = gcd1 / gcd2;
            return magnitude;
        }

        public static int ClosestWholeNumber(this int number, int divisor = 10) =>
            Convert.ToInt32(Math.Floor(number / (divisor * 1.0))) * divisor;

        public static IEnumerable<int> Factors(this int number) =>
            Enumerable.Range(1, number)
                .Where(a => number % a == 0);

        public static IEnumerable<int> CreateRange(int start, int count, int step = 1) =>
            Enumerable.Range(start, count).Where(i => (i - start) % step == 0);

        public static List<int> GetDigits(this string text)
        {
            var places = new List<int>();
            for (var i = 0; i < text.Length; ++i)
            {
                var digit = text[text.Length - i - 1] - '0';
                digit *= (int) Math.Pow(10, i);
                places.Add(digit);
            }

            places.Reverse();
            return places;
        }

        public static void Print(this Dictionary<int, string> range)
        {
            foreach (var pair in range) Print(pair.Key, pair.Value);
        }

        public static void Print(int number, string friendlyName)
        {
            Console.WriteLine($"{number} is {friendlyName}");
        }

        public static void Print<T>(this IEnumerable<T> collection)
        {
            foreach (var value in collection) Console.WriteLine(value.ToString());
        }
    }
}