using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleConsole.Extensions
{
    public static class ListExtensions
    {
        public static List<char> Remove_Char_From_List(this List<char> input, string charsToRemove) //TODO entfernt nichts, alte verwenden oder anpassen
        {
            List<char> result = new List<char>();
            foreach(char c in input)
                if (!charsToRemove.Contains(c))
                    result.Add(c);
            return result;
        }
    }
}
