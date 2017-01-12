using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t10
{
    class h1_t10
    {
        static void Main(string[] args)
        {
            int numAmount = 10000;              // kysyttävien lukujen määrä
            int[] numbers = new int[numAmount];     //taulukko luvuille
            bool exit = false;

            while (!exit)
            {
                for (int i = 0; i < numAmount; i++)
                {
                    exit = UserInput(ref numbers[i]);  // kysytään numerot
                    if ( numbers[i] == 0 || exit ) break;
                }
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                Console.WriteLine("\nLukujen summa on " + numbers.Sum() + "\n");

            }
        }

        static bool UserInput(ref int number)
        {
            bool exit = false;
            string input;

            while (true)
            {
                Console.Write("Anna luku > ");
                input = Console.ReadLine();                     // käyttäjän syöte
                if (input == "exit" || input == "x")
                {
                    exit = true;
                    break;
                }

                if (int.TryParse(input, out number) == false)   // syötteen muunto kokonaisluvuksi
                {                                               // jos ei ole luku, niin kysytään uudestaan
                    Console.WriteLine("Virheellinen syöte");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return exit;
        }
    }
}
