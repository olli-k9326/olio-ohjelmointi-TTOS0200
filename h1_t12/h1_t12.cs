using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t12
{
    class h1_t12
    {
        static void Main(string[] args)
        {
            int numAmount = 5;              // kysyttävien lukujen määrä
            int[] numbers = new int[numAmount];     //taulukko luvuille
            bool exit = false;

            while (!exit)
            {
                for (int i = 0; i < numAmount; i++)
                {
                    exit = UserInput(ref numbers[i]);  // kysytään numerot
                    if (exit) break;
                }
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"
                Array.Sort(numbers);        // järjestetään taulukko pienimmästä suurimpaan.
                Array.Reverse(numbers);     // käännetään
                Console.Write("Luvut ovat ");
                for (int i = 0; i < numAmount; i++)
                {
                    Console.Write(numbers[i]);
                    if (i != numAmount - 1) 
                    Console.Write(", ");
                }
                Console.WriteLine("\n");

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
