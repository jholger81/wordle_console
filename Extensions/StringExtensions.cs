using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleConsole.Extensions
{
    public static class StringExtensions
    {
        public static int CountChar(this string inputString, char charToCount)
        {            
            int count = 0;
            foreach (char c in inputString)
                if (c == charToCount)
                    count++;
            return count;
        }

        public static int WhichAppearance(this string inputString, int position)
        {
            int count = 0;
            char charToInspect = inputString[position];
            int posInWord = 0;
            foreach (char c in inputString)
            {
                if (c == charToInspect)
                {
                    count++;
                    if (posInWord >= position)
                        break;
                }
                posInWord++;
            }
            return count;
        }
    }
}
