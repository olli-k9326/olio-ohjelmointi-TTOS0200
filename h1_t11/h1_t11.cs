using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Tehtävä 11

Tee kahden sisäkkäisen for-silmukan avulla ohjelma, joka tulostaa seuraavanlaisen kuvion:
*
**
***
****
*****
     */
namespace h1_t11
{
    class h1_t11
    {
        static void Main(string[] args)
        {
            int number = 1;   
            bool exit = false;

            while (!exit)
            {
                
                exit = UserInput(ref number);  // kysytään
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                for (int i = 1; i <= number; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }


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
