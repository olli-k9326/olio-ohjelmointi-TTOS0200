using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *Tehtävä 13

Mäkihypyssä käytetään viittä arvostelutuomaria. Kirjoita ohjelma, joka kysyy arvostelupisteet yhdelle hypylle ja tulostaa tyylipisteiden summan siten, että summasta on vähennetty pois pienin ja suurin tyylipiste.

Esimerkkitoiminta:


    Anna pisteet > 18 [Enter]
    Anna pisteet > 15 [Enter]
    Anna pisteet > 20 [Enter]
    Anna pisteet > 19 [Enter]
    Anna pisteet > 17 [Enter]
    Kokonaispisteet ovat 54
    */
namespace h1_t13
{
    class h1_t13
    {
        static void Main(string[] args)
        {
            int numAmount = 5;              // kysyttävien lukujen määrä
            int[] points = new int[numAmount];     //taulukko luvuille
            int sum;
            bool exit = false;

            while (!exit)
            {
                for (int i = 0; i < numAmount; i++)
                {
                    exit = UserInput(ref points[i]);  // kysytään numerot
                    if (exit) break;
                }
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"
                Array.Sort(points);        // järjestetään taulukko pienimmästä suurimpaan.
                sum = points.Sum() - points[0] - points[numAmount-1];
                Console.WriteLine("Kokonaispisteet ovat " + sum);

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
