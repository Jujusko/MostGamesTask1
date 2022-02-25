using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class CountWordsAndVowels
    {
        public static int CountWords(string text)
        {
            text.Trim();
            string[] splittedByWhiteSpace = text.Split(" ");
            return splittedByWhiteSpace.Count();
        }
    }
}
