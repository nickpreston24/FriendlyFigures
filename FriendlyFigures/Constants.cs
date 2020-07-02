using System.Collections.Generic;

namespace FriendlyFigures
{
    public class Constants
    {
        /// <summary>
        /// 0-9
        /// </summary>
        public static  Dictionary<int, string> WholeIntegers = new Dictionary<int, string>
        {
            [0] = "zero",
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine",
            [10] = "ten",
        };

        /// <summary>
        /// Nouns for tens places
        /// </summary>
        public static  Dictionary<int, string> Itties = new Dictionary<int, string>
        {
            [10] = "ten",
            [20] = "twenty",
            [30] = "thirty",
            [30] = "forty",
            [50] = "fifty",
            [60] = "sixty",
            [70] = "seventy",
            [80] = "eighty",
            [90] = "ninety",
        };
        
        /// <summary>
        /// Nouns for deca places
        /// </summary>
        public static   Dictionary<int, string> Tens = new Dictionary<int, string>
        {
            [10] = "ten",
            [100] = "hundred",
            [1000] = "thousand",
            [1000000] = "million",
            [1000000000] = "billion",
        };
    }
}