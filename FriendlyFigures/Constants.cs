using System.Collections.Generic;

namespace FriendlyFigures
{
    public class Constants
    {
        /// <summary>
        /// 0-9
        /// </summary>
        Dictionary<int, string> integers = new Dictionary<int, string>
        {
            [0] = "ten",
            [1] = "twenty",
            [2] = "thirty",
            [3] = "forty",
            [4] = "fifty",
            [5] = "sixty",
            [6] = "seventy",
            [7] = "seventy",
            [8] = "eighty",
            [9] = "ninety",
            [10] = "ten",
        };

        /// <summary>
        /// Nouns for tens places
        /// </summary>
        Dictionary<int, string> itties = new Dictionary<int, string>
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
        Dictionary<int, string> tens = new Dictionary<int, string>
        {
            [10] = "ten",
            [100] = "hundred",
            [1000] = "thousand",
            [1000000] = "million",
            [1000000000] = "billion",
        };
    }
}