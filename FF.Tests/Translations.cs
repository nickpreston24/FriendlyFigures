using System;
using System.Collections.Generic;
using System.Linq;
using FriendlyFigures;
using Xunit;
using Xunit.Abstractions;

namespace FF.Tests
{
    public class Translations
    {
        public Translations(ITestOutputHelper outputHelper) => _outputHelper = outputHelper;
        readonly FriendlyFigureTranslator translator = new FriendlyFigureTranslator();
        readonly ITestOutputHelper _outputHelper;

        void Print(string expected, string actual) =>
            _outputHelper.WriteLine($"expected: {expected}\n actual: {actual}");

        void Print<T>(IEnumerable<T> collection)
        {
            foreach (var value in collection) _outputHelper.WriteLine(value.ToString());
        }

        [Fact]
        public void CanGetDigitsOfANumber()
        {
            var digits = "1234".GetDigits();
            Print(digits);
            Assert.NotEmpty(digits);
        }

        [Fact]
        public void CanTranslate_Itties()
        {
            var key = 70;
            var expected = Constants.IttyNouns[key];

            var actual = translator.Interpret(key);

            Print(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanTranslateComplexNumbers()
        {
            var set = new Dictionary<int, string>
            {
                [int.MinValue + 1] =
                    "negative two billion one hundred forty seven million four hundred eighty three thousand six hundred forty seven",
                [int.MaxValue] =
                    "two billion one hundred forty seven million four hundred eighty three thousand six hundred forty seven",
                [987654321] =
                    "nine hundred eighty seven million six hundred fifty four thousand three hundred twenty one",
                [525600] = "five hundred twenty five thousand six hundred",
                [1000000000] = "one billion", // Dollars?
                [-1000000000] = "negative one billion",
                [150000000] = "one hundred fifty million",
                [9999] = "nine thousand nine hundred ninety nine",
                [2020200] = "two million twenty thousand two hundred",
                [1000000] = "one million", //dun dun DUN!
                [2000000] = "two million",
                [1000001] = "one million one",
                [200000] = "two hundred thousand",
                [200001] = "two hundred thousand one",
                [100000] = "one hundred thousand", //single magnitude numbers fail
                [100] = "one hundred",
                [200] = "two hundred",
                [-11] = "negative eleven",
                [1024] = "one thousand twenty four",
                [99] = "ninety nine",
                [71] = "seventy one"
            };

            foreach (var pair in set)
            {
                var expected = pair.Value;
                var actual = translator.Interpret(pair.Key);
                Print(expected, actual);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void CanTranslateRandomRange()
        {
            var rng = new Random(DateTime.Now.Millisecond);
            var start = rng.Next(10);
            var end = rng.Next(1000);
            var step = rng.Next(20);
            var results = translator.InterpretRange(start, end, step);
            Print(results.Take(25));
        }

        [Fact]
        public void CanTranslateRange()
        {
            Print(translator.InterpretRange(100, 300, 20));
        }

        [Fact]
        public void CanTranslateTens()
        {
            var key = 1000;
            var expected = Constants.DecaNouns[key];

            var actual = translator.Interpret(key);

            Print(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanTranslateWholeNumbers()
        {
            var expected = "ten";

            var actual = translator.Interpret(10);
            var range = translator.InterpretRange(1, 10);
            Print(expected, actual);
            Print(range);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WontTranslateNonTens()
        {
            var key = 123;
            var expected = "twenty three";

            var actual = translator.Interpret(key);

            Print(expected, actual);
            Assert.NotEqual(expected, actual);
        }
    }
}