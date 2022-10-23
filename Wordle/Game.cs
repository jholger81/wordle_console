using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleConsole.Extensions;
using WordleConsole.Settings;
using WordleConsole.Wordlist;

namespace WordleConsole.Wordle
{
    public class Game
    {
        public List<string> Wortliste { get; set; }
        public int Anzahl_woerter { get; set; }
        public List<bool> Already_guessed_right { get; set; }
        public int WortLaenge { get; set; }
        public List<char> Chars_not_tried { get; set; }
        public bool Show_chars_not_tried { get; set; }
        public SettingsManager SettingsManager { get; set; }
        List<string> Zu_erraten_Liste { get; set; }
        //public Game(List<string> input, int aw, int wLaenge)
        //{
        //    Wortliste = input;
        //    Anzahl_woerter = aw;
        //    Already_guessed_right = new List<bool>();
        //    for (int i = 0; i < Anzahl_woerter; i++)
        //        Already_guessed_right.Add(false);
        //    SettingsManager = new SettingsManager();
        //    SettingsManager?.Load();
        //    WortLaenge = wLaenge;
        //    Chars_not_tried = new List<char>();
        //    Chars_not_tried.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ");
        //    Show_chars_not_tried = true;
        //}
        public Game()
        {
            SettingsManager = new SettingsManager();
            SettingsManager?.Load();

            Wortliste = Operations.Load_List(); //TODO nicht statischer Pfad zur Liste
            Anzahl_woerter = SettingsManager.Settings.NumberOfWords;
            Console.WriteLine("Anzahl woerter: "+Anzahl_woerter);
            WortLaenge = SettingsManager.Settings.WordLength;
            Wortliste = Operations.Transform_List_to_X_Chars_List(Wortliste, WortLaenge);
            Zu_erraten_Liste = Operations.Create_List(Wortliste, Anzahl_woerter);
            Console.WriteLine("Laenge Liste: "+Zu_erraten_Liste.Count());

            Already_guessed_right = new List<bool>();
            for (int i = 0; i < Anzahl_woerter; i++)
                Already_guessed_right.Add(false);            
            Chars_not_tried = new List<char>();
            Chars_not_tried.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ");
            Show_chars_not_tried = true;
        }
        public List<List<Stuff.Guess>> Compare(string guessed_word)
        {
            List<List<Stuff.Guess>> result = new List<List<Stuff.Guess>>();
            List<Stuff.Guess> singleResult;
            int charCountWort, charCountGuess, auftreten;
            foreach (var wort in Zu_erraten_Liste/*Wortliste*/)
            {
                singleResult = new List<Stuff.Guess>();
                for (int i = 0; i < WortLaenge; i++)
                {
                    if (guessed_word[i] == wort[i])
                    {
                        singleResult.Add(Stuff.Guess.R);
                    }
                    else if (wort.Contains(guessed_word[i]))
                    {
                        charCountGuess = guessed_word.CountChar(guessed_word[i]);
                        charCountWort = wort.CountChar(guessed_word[i]);
                        if (charCountGuess <= charCountWort)
                            singleResult.Add(Stuff.Guess.r);
                        else
                        {
                            auftreten = guessed_word.WhichAppearance(i);
                            if ((charCountGuess - auftreten) >= charCountWort)
                            {
                                singleResult.Add(Stuff.Guess.F);
                            }
                            else
                                singleResult.Add(Stuff.Guess.r);
                        }
                    }
                    else
                    {
                        singleResult.Add(Stuff.Guess.F);
                    }
                }
                result.Add(singleResult);
            }
            return result;
        }
        public bool Check_For_Right_Word(List<Stuff.Guess>input)
        {
            foreach(var character in input)
            {
                if (character != Stuff.Guess.R)
                    return false;
            }
            return true;
        }

        public bool All_Guessed_Right()
        {
            foreach(var x in Already_guessed_right)
            {
                if (x == false)
                    return false;
            }
            return true;
        }

        public List<char> RemoveCharsFromList(string guessed_word)
        {
            List<char> result = new List<char>();
            foreach(char c in Chars_not_tried)
                if (!guessed_word.Contains(c))
                    result.Add(c);
            //result.Sort();
            return result;
        }
    }
}
