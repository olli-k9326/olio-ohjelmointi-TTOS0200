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
            int wrongGuesses = 0;

            string [] wordList = new string[]{ "administraatio", "oskilloskooppi", "observoida", "googlata" };      // lista arvattavista sanoista
            Random r = new Random();            
            int x = r.Next(0, wordList.Length );            // satunnaisluku, jolla arvotaan arvattava sana sanalistasta
            string wordToGuess = wordList[x];               // arvattavan sanan tallennus
            wordToGuess = wordToGuess.ToUpper();            // arvattavan sanan muunto ISOILLE KIRJAIMILLE

            char[] guessed = new char[wordToGuess.Length];        // Tähän talletetaan oikein arvatut merkit
            FillCharArray(ref guessed, '_');
            char[] wrongGuess = new char[body.Length];          // väärin arvatut merkit
            FillCharArray(ref wrongGuess, ' ');

            Screen(guessed, wrongGuess, win, lose, body, wrongGuesses);     // pelin tulostus näytölle

            while (!exit && !lose && !win)
            {
                
                UserInput(out input, ref exit);             // kysytään käyttäjältä kirjainta
                if (exit) continue;                         // pois silmukasta, jos syötteessä esiintyi "exit"
                
                Hirsipuu(input.ToUpper(), wordToGuess, ref guessed, ref wrongGuess, ref win, ref lose, body.Length, ref wrongGuesses);       // itse varsinainen hirsipuupeli

                Screen(guessed, wrongGuess, win, lose, body, wrongGuesses);     // pelin tulostus näytölle
            }
        }
        
        static void Hirsipuu(string input, string wordToGuess, ref char[] guessed, ref char[] wrongGuess, ref bool win, ref bool lose, int wrongMax, ref int wrongGuesses)
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
                wrongGuess[wrongGuesses] = input[0];
                wrongGuesses++;
            }
                
            if(guessed.SequenceEqual(wordToGuess))       // jos arvattujen kirjaimien tallennukseen varattu muuttuja matchaa arvattavan sanan kanssa, peli on voitettu
                win = true;

            if (wrongGuesses == wrongMax)       // Jos vääriä arvauksia on tullut maksimimäärä, niin peli on hävitty. 
                lose = true;

        }
        
        static void Screen(char[] guessed, char[] wrongGuess, bool win, bool lose, string body, int wrongGuesses)
        {
            string winLose = " ";   // voitto/ häviö tähän muuttujaan

            string bodyPart = body.Substring(0, wrongGuesses) + new string(' ', body.Length - wrongGuesses);
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
        static string PrintWord(char[] variable)  // Laitetaan arvattavan sanan kirjainten välille välilyönnit, käytetään Screen-metodissa.
        {
            string output = " ";
            for (int i = 0; i < variable.Length; i++)
            {
                output = output + variable[i] + " ";
               
            }
            return output;
        }

        static void FillCharArray(ref char[] array, char ch)        // char taulukon alustamiseen yhdellä kirjaimella
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ch;
            }
            return;
        }
    }
}
