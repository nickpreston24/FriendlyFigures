using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FriendlyFigures
{
    public class FriendlyFigureTranslator
    {
        // public  string GetDigits

        public string GetFriendlyName(int digit)
        {
            if (digit <= 10)
                return Constants.WholeIntegers[digit];

            if (digit <= 99)
                return Constants.Itties[digit];
                
            if (digit <= 999)
                return Constants.Tens[digit];
            
            if (digit % 1000 == 0)
                return Constants.Tens[digit];
            
            // if (number % 10 == 0)
            // {
            //     // result.Append(Constants.Itties[closest]);
            // }

            return string.Empty;
        }

        //TODo: isNumber regex func
        Func<string,bool> isNumber =(string text) => Regex.IsMatch(text,@"\d");
        public string Interpret(string text = null) => 
            !string.IsNullOrEmpty(text) && isNumber(text) 
                ? Interpret(Int32.Parse(text)) 
                : throw new ArgumentException($"Invalid value {text} supplied");

        public string Interpret(int number = 0)
        {
            StringBuilder result = new StringBuilder();
            int closest = Convert.ToInt32(Math.Floor(number / 10.0))  * 10;
            // int place = 

            if (number == 0)
                return "zero";

            if (number < 0)
                result.Append("negative ");
            

            return result.ToString();
        }

        public Dictionary<int, string> InterpretRange(int start = Int32.MinValue, int end = Int32.MaxValue, int step = 1)
        {
            var builder = new FriendlyFigureTranslator();
            Dictionary<int, string> series = new Dictionary<int, string>();
            for (int i = start; i < end; i+=step)
            {
                series.Add(i, builder.Interpret(i));
            }

            return series;
        } 
    }
}