using System;
using System.Text;

namespace FriendlyFigures
{
    public class FriendlyFigureTranslator
    {
        StringBuilder result = new StringBuilder();
        
        public string Interpret(int number = 0)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                result.Append("negative ");

            if (number <= 10)
            {
                result.Append(Constants.WholeIntegers[number]);
                return result.ToString();
            }

            return null;
        }
    }
}