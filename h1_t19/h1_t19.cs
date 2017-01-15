using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t19
{
    class h1_t19
    {
        static void Main(string[] args)
        {
            bool exit = false;      // ohjelman lopetus
            bool win = false;       // voitto
            bool lose = false;      // häviö
            string input;           // käyttäjän syöttämä kirjain
            string body = "O|/\\|/\\";      // hirsipuun ruumiin kehon osat
            
            string [] wordList = new string[]{ "administraatio", "oskilloskooppi", "observoida", "googlata" };      // lista arvattavista sanoista
            Random r = new Random();            
            int x = r.Next(0, wordList.Length );            // satunnaisluku, jolla arvotaan arvattava sana sanalistasta
            string wordToGuess = wordList[x];               // arvattavan sanan tallennus
            wordToGuess = wordToGuess.ToUpper();            // arvattavan sanan muunto ISOILLE KIRJAIMILLE

            StringBuilder guessed = new StringBuilder();        // Tähän talletetaan oikein arvatut merkit
            guessed.Append('_', wordToGuess.Length);            // täytetään se _ merkeillä
            StringBuilder wrongGuess = new StringBuilder();   
            wrongGuess.Append(" ");                             // Tähän talletetaan pieleen menneet arvaukset

            Screen(guessed, wrongGuess, win, lose, body);     // pelin tulostus näytölle

            while (!exit && !lose && !win)
            {
                
                UserInput(out input, ref exit);             // kysytään käyttäjältä kirjainta
                if (exit) continue;                         // pois silmukasta, jos syötteessä esiintyi "exit"
                
                Hirsipuu(input.ToUpper(), wordToGuess, ref guessed, ref wrongGuess, ref win, ref lose, body.Length);       // itse varsinainen hirsipuupeli

                Screen(guessed, wrongGuess, win, lose, body);     // pelin tulostus näytölle
            }
        }
        static void Hirsipuu(string input, string wordToGuess, ref StringBuilder guessed, ref StringBuilder wrongGuess, ref bool win, ref bool lose, int wrongMax)
        {
            bool match = false;         // löytyykö syötetty kirjain arvattavasta sanasta?
            for (int i = 0; i < wordToGuess.Length; i++)      
            {
                if(input[0] == wordToGuess[i])      // jos löytyi,
                {
                    guessed[i] = wordToGuess[i];    // talletetaan se oikein arvattujen merkkien joukkoon    
                    match = true;                   // merkitään löytyminen muuttujaan match
                }
            }
            if (match == false)     // jos ei löytynyt, niin lisätään syötetty kirjain wrongGuess muuttujaan.
            {
                wrongGuess.Append(input[0]);
            }
                
            if(guessed.ToString() == wordToGuess)       // jos arvattujen kirjaimien tallennukseen varattu muuttuja matchaa arvattavan sanan kanssa, peli on voitettu
                win = true;

            if (wrongGuess.Length -1 == wrongMax)       // Jos vääriä arvauksia on tullut maksimimäärä, niin peli on hävitty. ( -1 ylimääräisen välilyönnin takia)
                lose = true;

        }
        
        static void Screen(StringBuilder guessed, StringBuilder wrongGuess, bool win, bool lose, string body)
        {
            string winLose = " ";   // voitto/ häviö tähän muuttujaan

            string bodyPart = body.Substring(0, wrongGuess.Length - 1) + new string(' ', body.Length - (wrongGuess.Length-1));
                                                        // Muodostetaan hirsipuun ruumista väärien arvauksien mukaan.
            if (win)
                winLose = "Arvasit sanan, hyvä!";
            if (lose)
                winLose = "Hävisit!";

            Console.Clear();
            Console.WriteLine("*** HIRSIPUUU ***");
            Console.WriteLine("*****************");
            Console.WriteLine();
            Console.WriteLine(" _____        ");
            Console.WriteLine("|     |      " +  PrintWord(guessed));
            Console.WriteLine("|     {0}      ", bodyPart[0]);
            Console.WriteLine("|    {1}{0}{2} ", bodyPart[1], bodyPart[2], bodyPart[3]);
            Console.WriteLine("|     {0}       Väärät arvaukset:", bodyPart[4]);
            Console.WriteLine("|    {0} {1}   " + PrintWord(wrongGuess), bodyPart[5], bodyPart[6]);
            Console.WriteLine("|            ");
            Console.WriteLine("|____________    " + winLose );
            
        }

        static StringBuilder PrintWord(StringBuilder variable)  // Laitetaan stringbuilderin kirjainten välille välilyönnit, käytetään Screen-metodissa.
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < variable.Length; i++)
            {
                output.Append(" " + variable[i]);
            }
            return output;
        }

        static void UserInput(out string input, ref bool exit)          // kysytään syöte käyttäjältä
        {
            bool correctInput = false;
            do
            {
                Console.Write("\nSyötä kirjain > ");
                input = Console.ReadLine();                     // käyttäjän syöte

                if (input == "exit")        
                {
                    exit = true;
                    correctInput = true;
                }
                else if (input.Length > 1 || input.Length == 0)  // ei oteta vastaan kuin yksi kirjain
                {
                    Console.WriteLine("Virheellinen syöte");
                }
                else
                {
                    correctInput = true;            // syöttö on oikein, poistutaan silmukasta
                }
            } while (correctInput == false);
            
            return;
        }
    }
}
