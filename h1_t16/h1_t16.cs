using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Tehtävä 16

Tee ohjelma, joka arpoo satunnaisluvun väliltä 0-100. Käytä C#:n Random -luokkaa. Tämän jälkeen ohjelman käyttäjää kehoitetaan arvaaman arvottu luku. Ohjelman tulee antaa vihje arvauksen jälkeen onko arvottu luku pienemäi vai suurempi. Tämän jälkeen vihjeitä toistetaan kunnes käyttäjä arvaa oikean luvun. Tulosta lopuksi arvausten määrä näytölle. PS Satunnaislukujen arpomisesta tietokoneella löytyy mielenkiintoista luettavaa esimerkiksi tästä artikkelista: Computers are lousy random number generators.

Esimerkkitoiminta:


    Arvaa luku > 50 [Enter]
    Luku on suurempi
    Arvaa luku > 75 [Enter]
    Luku on pienempi
    Arvaa luku > 66 [Enter]
    Hienoa, arvasit luvun 3 kerralla.
    */
namespace h1_t16
{
    class h1_t16
    {
        static void Main(string[] args)
        {

            int number = 0;              // maksimi kysyttävien arvosanojen määrä
            int numToGuess;
            Random r = new Random();
            numToGuess = r.Next(1,100);
            bool exit = false;
            int counter = 0;

            Console.WriteLine("*** Luvun arvaus -sovellus ***");
            Console.WriteLine();
            while (!exit)
            {
              
                exit = UserInput(ref number);

                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                Output(number,  ref numToGuess, ref counter);
                
            }
        }
        static void Output(int number, ref int numToGuess, ref int counter)
        {
            ++counter;
            if (number == numToGuess)
            {
                Console.WriteLine("Hienoa, arvasit luvun {0} kerralla!!\n", counter );
                counter = 0;
                Random r = new Random();
                numToGuess = r.Next(1, 100);
                return;
            }
            string compare = "pienempi";
            if (number < numToGuess)
                compare = "suurempi";

            Console.WriteLine("Luku on " + compare);
            return;
            
        }
        static bool UserInput(ref int number)
        {
            bool exit = false;
            string input;

            while (true)
            {
                Console.Write("Arvaa luku > ");
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
                else if (number < 0 || number > 100)      // saatiin luku, mutta se on väärä
                {
                    Console.WriteLine("Luvun pitää olla välillä 0-100");
                    continue;
                }
                else            // saatiin hyväksyttävä luku
                {
                    break;
                }
            }
            return exit;
        }
    }
}
