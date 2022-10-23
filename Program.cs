using WordleConsole.Wordlist;
using WordleConsole.Wordle;
using WordleConsole.Extensions;

//List<string> wortliste;
//wortliste = Operations.Load_List();

//Load List
//int wortLaenge = 5;
//Console.WriteLine($"{wortliste.Count()} Wörter in geladener Liste");
//wortliste = Operations.Transform_List_to_X_Chars_List(wortliste, wortLaenge);
//Console.WriteLine($"{wortliste.Count()} Wörter mit {wortLaenge} Buchstaben in Liste");
//Operations.Save_List(wortliste);

//erzeuge Liste zu erratender Wörter
//int anzahlWoerter = 3;
//List<string> zu_erraten_Liste = Operations.Create_List(wortliste, anzahlWoerter);

//Start Game
//Game wordle = new Game(zu_erraten_Liste, anzahlWoerter, wortLaenge);
Game wordle = new Game();

//TEST
//foreach (var x in wordle.Wortliste)
//    Console.WriteLine(x);

string guess;
int wort_zaehler, position;
for (int i = 1; i <= 10; i++)
{    
    wort_zaehler = 0;
    do
    {
        Console.Write($"{i}. Versuch: ");
        guess = Console.ReadLine();
    } while (guess.Length != wordle.SettingsManager.Settings.WordLength);
    guess = guess.ToUpper();

    var comparer = wordle.Compare(guess);
    Console.WriteLine(comparer.Count());

    foreach (var word in comparer)
    {
        position = 0;
        //skip already guessed right words
        if (wordle.Already_guessed_right[wort_zaehler])
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            foreach (char c in wordle.Wortliste[wort_zaehler])
                Console.Write($" {c} ");
            wort_zaehler++;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t");
            continue;
        }        
        
        Console.ForegroundColor = ConsoleColor.Black;
        foreach (var pos in word)
        {
            if ((int)pos == 0)
                Console.BackgroundColor = ConsoleColor.Red;
            if ((int)pos == 1)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            if ((int)pos == 2)
                Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write($" {guess[position]} ");
            position++;
        }
        Console.BackgroundColor= ConsoleColor.Black;
        Console.ForegroundColor= ConsoleColor.White;
        Console.Write(" ");

        //check for new guessed right words
        wordle.Already_guessed_right[wort_zaehler] = wordle.Check_For_Right_Word(word);
        wort_zaehler++;
    }
    if (wordle.All_Guessed_Right())
    {
        Console.WriteLine("Gewonnen!");
        break;
    }
    //show unused characters
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    wordle.Chars_not_tried = wordle.RemoveCharsFromList(guess);
    foreach (char c in wordle.Chars_not_tried)
        Console.Write($" {c}");
    Console.Write(" ");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("   ");
}

//Auflösung
Console.WriteLine("Die Wörter waren:");
foreach (var wort in wordle.Wortliste)
{
    Console.WriteLine(wort);
}
Console.ReadLine();
