using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleConsole.Extensions
{
    public static class ListExtensions
    {
        public static List<char> Remove_Char_From_List(this List<char> input, char charToRemove)
        {
            List<char> result = new List<char>();
            foreach(var c in input)
                if (!input.Contains(c))
                    result.Add(c);
            return result;
        }
    }
}
