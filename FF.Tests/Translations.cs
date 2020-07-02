using System;
using System.Collections.Generic;
using FriendlyFigures;
using Xunit;
using Xunit.Abstractions;

namespace FF.Tests
{
    public class Translations
    {
        FriendlyFigureTranslator translator = new FriendlyFigureTranslator();
        ITestOutputHelper _outputHelper;

        public Translations(ITestOutputHelper outputHelper) => _outputHelper = outputHelper;

        [Fact]
        public void CanTranslateWholeNumbers()
        {
            string expected = "ten";
            
            var actual = translator.Interpret(10);
            
            Print(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanTranslate_Itties()
        {
            // List<int> keys = new List<int> {};  //TODO: Add all -itties and loop
            
            int key = 70;
            string expected = Constants.Itties[key];

            var actual = translator.Interpret(key);
            
            Print(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanTranslateTens()
        {
            int key = 1000;
            string expected = Constants.Tens[key];

            var actual = translator.Interpret(key);
            
            Print(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WontTranslateNonTens()
        {
            
        }

        [Fact]
        public void CanGetDigitsOfANumber()
        {
            var digits  = "1205632".GetDigits();
            Print(digits);
            Assert.NotEmpty(digits);
        }
        
        private void Print(string expected, string actual)
        {
            _outputHelper.WriteLine($"expected: {expected}, actual: {actual}");
        }

        private void Print<T>(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                _outputHelper.WriteLine(value.ToString());
            }            
        }
    }
}