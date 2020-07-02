using System;
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

        private void Print(string expected, string actual)
        {
            _outputHelper.WriteLine($"expected: {expected}, actual: {actual}");
        }
    }
}