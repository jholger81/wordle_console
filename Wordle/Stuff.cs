using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleConsole.Wordle
{
    public class Stuff
    {
        public enum Guess
        {
            F = 0, // wrong char
            R = 1, // right char, right postition
            r = 2  // right char, wrong position
        }
    }
}
