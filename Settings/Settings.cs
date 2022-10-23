using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WordleConsole.Settings
{
    public class Settings
    {
        public int WordLength { get; set; }
        public int NumberOfWords { get; set; }
        public int NumberOfGuesses { get; set; }
        public string PathToWordList { get; set; }
    }
}
