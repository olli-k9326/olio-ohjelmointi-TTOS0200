using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Tehtävä 4

Tee ohjelma, jossa kysytään käyttäjältä tämän ikä. Jos ikä on alle 18 vuotta,
tulosta "alaikäinen", jos se on 18-65 vuotta, tulosta "aikuinen",
muussa tapauksessa tulosta "seniori". 
     */
namespace Harj4
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;
            bool exit = false;

            while (exit == false)
            {
                exit = UserInput(ref age);  // kysytään käyttäjän ikä. Palauttaa arvon true, jos input = "exit"

                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"
                
                Console.WriteLine(ageToString(age));      // tulostetaan ikää vastaava sana
            }

            Console.WriteLine("Ohjelman suoritus päättyy");
        }

        static bool UserInput (ref int number)
        {
            bool exit = false;
            string input;
            while (true)
            { 
                Console.Write("\nAnna ikäsi > ");
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
        static string ageToString(int age)
        {
            string ageString;
            if (age < 18)
            {
                ageString = "alaikäinen";
            }
            else if (age >= 18 && age <= 65)
            {
                ageString = "aikuinen";
            }
            else
            {
                ageString = "seniori";
            }
            return ageString;
        }

    }
}
