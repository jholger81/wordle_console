using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordleConsole.Wordlist
{
    public class Operations
    {
        static string listPath = "C:\\Source\\WordleConsole\\WordleConsole\\input.txt"; //TODO nicht statischer Pfad

        public static List<string> Load_List()
        {
            String? line;
            List<string> result = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(listPath);
                do
                {
                    line = sr.ReadLine();
                    result.Add(line);
                } while (line != null);
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return result;
        }

        public static List<string> Transform_List_to_5_Chars_List(List<string> input)
        {
            List<string> result = new List<string>();
            foreach (string line in input)
            {
                if (line == null)
                    continue;
                if (line.Length==5)
                    result.Add(line);
            }
            return result;
        }

        public static List<string> Transform_List_to_X_Chars_List(List<string> input, int wLaenge)
        {
            List<string> result = new List<string>();
            foreach (string line in input)
            {
                if (line == null)
                    continue;
                if (line.Length == wLaenge)
                    result.Add(line);
            }
            return result;
        }

        public static void Save_List(List<string> input)
        {
            // TODO
        }

        public static string Get_Word_From_List(List<string> input)
        {
            Random rnd = new Random();
            int anzahl_woerter = input.Count();
            return (input.ElementAt(rnd.Next(anzahl_woerter)));
        }

        public static List<string> Create_List(List<string> input, int anzahlWoerter)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < anzahlWoerter; i++)
            {
                output.Add(Operations.Get_Word_From_List(input).ToUpper());
            }
            return output;
        }
    }
}
