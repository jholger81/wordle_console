using WordleConsole.Wordlist;
using WordleConsole.Wordle;
using WordleConsole.Extensions;

Game wordle = new Game();

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

    foreach (var word in wordle.Compare(guess))
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
    wordle.Chars_not_tried = wordle.Chars_not_tried.Remove_Char_From_List(guess);
    foreach (char c in wordle.Chars_not_tried)
        Console.Write($" {c}");
    Console.Write(" ");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("   ");
}

//Aufloesung
Console.WriteLine("Die Wörter waren:");
foreach (var wort in wordle.Zu_erraten_Liste)
{
    Console.WriteLine(wort);
}
Console.ReadLine();
