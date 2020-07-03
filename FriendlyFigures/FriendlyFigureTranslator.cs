using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FriendlyFigures
{
    public class FriendlyFigureTranslator
    {
        public static int Billion = 1 * 1000 * 1000 * 1000;
        public static int Million = 1 * 1000 * 1000;
        public static int Thousand = 1 * 1000;
        public static int Hundred = 100;
        public static int Ten = 10;

        //TODo: isNumber regex func
        readonly Func<string, bool> isNumber = text => Regex.IsMatch(text, @"\d");

        public string GetFriendlyName(int digit)
        {
            // Wholes:
            if (digit <= 10)
                return Constants.WholeNumberNouns[digit] + " ";

            // Teens:
            if (digit <= 19)
                return Constants.TeenNouns[digit] + " ";

            // Multiples of Ten:
            if (digit <= 99 && digit % 10 == 0)
                return Constants.IttyNouns[digit] + " ";

            // Hundreds:
            if (digit <= 999 && digit % 100 == 0)
                return Constants.DecaNouns[digit] + " ";

            // Thousands:
            if (digit <= 999999 && digit % 1000 == 0)
                return Constants.DecaNouns[digit] + " ";

            // Millions:
            if (digit <= 999999999 && digit % 1000000 == 0)
                return Constants.DecaNouns[digit] + " ";

            // Billions:
            if (digit <= int.MaxValue && digit % 1000000000 == 0)
                return Constants.DecaNouns[digit] + " ";

            return string.Empty;
        }

        public string Interpret(string text = null) =>
            !string.IsNullOrEmpty(text) && isNumber(text)
                ? Interpret(int.Parse(text))
                : throw new ArgumentException($"Invalid value {text} supplied");

        public string Interpret(int number = 0)
        {
            var result = new StringBuilder();
            if (number == int.MinValue) throw new ArgumentOutOfRangeException("Given number outside of range");

            if (number == 0)
                return "zero";

            if (number < 0)
            {
                result.Append("negative ");
                number = Math.Abs(number);
            }

            if (number <= 19)
            {
                result.Append(GetFriendlyName(number));
                return result.ToString().DeepTrim();
            }

            var digits = number.ToString().GetDigits().Where(d => d != 0);

            var place = number.Place();

            if (place % (Billion * Hundred) == 0)
            {
                var count = number / Billion;
                var digit = count * Billion;
                var magnitude = digit.Magnitude(Billion); //525
                var name = string.Empty;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Billion)}";
                result.Append(name);
                var remainder = number - magnitude * Billion;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % (Billion * Ten) == 0)
            {
                var count = number / Billion;
                var digit = count * Billion;
                var magnitude = digit.Magnitude(Billion); //525
                var name = string.Empty;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Billion)}";
                result.Append(name);
                var remainder = number - magnitude * Billion;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % Billion == 0)
            {
                var count = number / place;
                var digit = count * Billion;
                var magnitude = digit.Magnitude(Billion); //525
                var name = string.Empty;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Billion)}";
                result.Append(name);
                var remainder = number - place * count;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }

            else if (place % (Million * Hundred) == 0)
            {
                var count = number / Million;
                var digit = count * Million;
                var magnitude = digit.Magnitude(Million); //525
                var name = string.Empty;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Million)}";
                result.Append(name);
                var remainder = number - magnitude * Million;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % (Million * Ten) == 0)
            {
                var count = number / Million;
                var digit = count * Million;
                var magnitude = digit.Magnitude(Million); //525
                var name = string.Empty;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Million)}";
                result.Append(name);
                var remainder = number - magnitude * Million;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % Million == 0)
            {
                var count = number / place;
                var digit = count * Million;
                var magnitude = digit.Magnitude(Million); //525
                var name = string.Empty;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Million)}";
                result.Append(name);
                var remainder = number - place * count;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }

            else if (place % (Thousand * Hundred) == 0)
            {
                var count = number / Thousand;
                var digit = count * Thousand;
                var magnitude = digit.Magnitude(Thousand); //525
                string name;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Thousand)}";
                result.Append(name);
                var remainder = number - magnitude * Thousand;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % (Thousand * Ten) == 0)
            {
                var count = number / Thousand;
                var digit = count * Thousand;
                var magnitude = digit.Magnitude(Thousand); //525
                string name;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Thousand)}";
                result.Append(name);
                var remainder = number - magnitude * Thousand;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % Thousand == 0)
            {
                var count = number / place;
                var digit = count * Thousand;
                var magnitude = digit.Magnitude(Thousand); //525
                string name;
                name = $"{Interpret(magnitude)} {GetFriendlyName(Thousand)}";
                result.Append(name);
                var remainder = number - place * count;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % Hundred == 0)
            {
                var count = number / place;
                var digit = count * Hundred;
                var magnitude = digit.Magnitude(Hundred);
                var name = $"{Interpret(magnitude)} {GetFriendlyName(Hundred)}";
                result.Append(name);
                var remainder = number - place * count;
                if (remainder > 0)
                    result.Append(Interpret(remainder));
            }
            else if (place % 10 == 0)
            {
                foreach (var digit in digits)
                    result.Append(GetFriendlyName(digit));
            }
            else if (place < 10)
            {
                foreach (var digit in digits)
                    result.Append(GetFriendlyName(digit));
            }

            return result.ToString().DeepTrim();
        }

        public Dictionary<int, string> InterpretRange(int start = 0, int end = int.MaxValue, int step = 1)
        {
            var builder = new FriendlyFigureTranslator();
            var series = new Dictionary<int, string>();
            for (var i = start; i <= end; i += step) series.Add(i, builder.Interpret(i));

            return series;
        }
    }
}