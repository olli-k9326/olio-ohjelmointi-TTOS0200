using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Tehtävä 7

Tee ohjelma, joka näyttää onko annettu vuosi karkausvuosi. Vuosiluku kysytään käyttäjältä.

    Algoritmi
    4:llä jaolliset on, paitsi täydet vuosisadat. Kuitenkin 400:lla jaolliset vuosisadat ovat
    Esim. 1991 -> ei, 1992 -> on, 1900 -> ei, 2000 -> on

Esimerkkitoiminta:

    Anna vuosi > 1992 [Enter]
    Vuosi on karkausvuosi.
    
     */
namespace h1_t7
{
    class h1_t7
    {
        static void Main(string[] args)
        {
            int year = 0;
     
            bool exit = false;

            while (!exit)
            {
                exit = UserInput(ref year);     // kysytään vuosi
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                if(LeapYear(year))
                    Console.WriteLine("\nVuosi on karkausvuosi.");
                else
                    Console.WriteLine("\nVuosi ei ole karkausvuosi.");
            }
        }

        static bool LeapYear(int year)
        {
            bool isLeapYear = false;

            if (year % 4 == 0) isLeapYear = true;

            if (year % 100 == 0) isLeapYear = false;

            if (year % 400 == 0) isLeapYear = true;

            return isLeapYear;
        }

        static bool UserInput(ref int number)
        {
            bool exit = false;
            string input;

            while (true)
            {
                Console.Write("\nAnna vuosi > ");
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
