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

                exit = UserInput(out sentence);

                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"
                Palindrome(sentence);
                
            }
        }
        static void Palindrome(string input)
        {
            StringBuilder modified = new StringBuilder();
            bool IsItpalindrome = true;
            for (int i = 0 ; i < input.Length ; i++)
            {
                if ( (char.IsLetter(input[i])) )
                {
                    modified.Append(input[i]);
                }
               
            }
            
            for (int i = 0; i < modified.Length / 2; i++)
            {
                if (modified[i] != modified[modified.Length - 1 - i] )
                    IsItpalindrome = false;
            }
            if (IsItpalindrome == true)
            {
                Console.WriteLine("Annettu merkkijono on palindromi");
            }
            else
            {
                Console.WriteLine("Annettu merkkijono ei ole palindromi");
            }


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
