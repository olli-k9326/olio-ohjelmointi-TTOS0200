using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Tehtävä 8

Tee ohjelma, joka kysyy käyttäjältä 3 kokonaislukua ja tulostaa niistä suurimman.

Esimerkkitoiminta:


    Anna Luku > 5 [Enter]
    Anna Luku > 15 [Enter]
    Anna Luku > 7 [Enter]
    Suurin luku on 15
    */
namespace h1_t8
{
    class h1_t8
    {
        static void Main(string[] args)
        {
            int numAmount = 3;              // kysyttävien lukujen määrä
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
                Console.WriteLine("\nSuurin luku on " + numbers[numAmount-1] + "\n");
          
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
                if (input == "exit" || input == "x" || input =="0")
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
