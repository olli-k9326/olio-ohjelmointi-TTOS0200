using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t18
{
    class h1_t18
    {
        static void Main(string[] args)
        {
            string sentence;
            bool exit = false;
            
            Console.WriteLine("*** Palindromin tarkistus ***");
            Console.WriteLine();
            while (!exit)
            {

                exit = UserInput(out sentence); // kysytään käyttäjältä merkkijono

                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"
                
                if (Palindrome(sentence))
                {
                    Console.WriteLine("Annettu merkkijono on palindromi");
                }
                else
                {
                    Console.WriteLine("Annettu merkkijono ei ole palindromi");
                }

            }
        }
        static bool Palindrome(string input)
        {
            
            StringBuilder modified = new StringBuilder();  // tähän tulee merkkijono, johon laitetaan vain kirjaimet
            bool IsItpalindrome = true;
            for (int i = 0 ; i < input.Length ; i++)    // käydään läpi syötetyn merkkijonon jokainen kirjain
            {
                if ( (char.IsLetterOrDigit(input[i])) )    // Jos on kirjain tai numero, niin lisätään muuttujaan modified
                {
                    modified.Append(input[i]);
                }
               
            }
            
            for (int i = 0; i < modified.Length / 2; i++)  // sitten itse palindromi-tarkistus
            {
                if (modified[i] != modified[modified.Length - 1 - i] )
                    IsItpalindrome = false;         // jos ei täsmää, niin merkitään muuttujaan
            }

            return IsItpalindrome;

        }

        static bool UserInput(out string input)
        {
            bool exit = false;
            
            Console.Write("Syötä merkkijono > ");
            input = Console.ReadLine().ToLower();                     // käyttäjän syöte
               
            if ( input == "exit" || input == "x")
            {
                exit = true;
            }

            return exit;
        }
    }
}
