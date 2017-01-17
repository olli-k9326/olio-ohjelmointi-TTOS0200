using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 * Tehtävä 1

Tee ohjelma, joka tulostaa käyttäjän antamaa lukua (1, 2 tai 3) vastaavan luvun sanana (yksi, kaksi tai kolme). Jos käyttäjä syöttää jonkin muun luvun, tulee näytölle tulostaa teksti: "joku muu luku".

Esimerkkitoiminta:

    Anna luku > 1 [Enter]
    Annoit luvun yksi
    
 */

namespace Harj1
{
    class Program
    {
        public static void H1T1()
        {
            string input;          // käyttäjän syöte
            int number;             // tähän talletetaan luku
            string numberString;  // luvun kirjallinen vastine
              

            while(true)
            {
                Console.Write("\nAnna luku > ");
                input = Console.ReadLine();                     // käyttäjän syöte
                if (int.TryParse(input, out number) == false)   // syötteen muunto kokonaisluvuksi
                {                                               // jos ei ole luku, niin poistutaan
                    break;                                     
                }

                switch (number)
                {
                    case 1:
                        numberString = "yksi";
                        break;

                    case 2:
                        numberString = "kaksi";
                        break;

                    case 3:
                        numberString = "kolme";
                        break;

                    default:
                        Console.Write("Joku muu luku");
                        continue;    // ohittaa "annoit luvun" -kohdan
                } 
                Console.Write("Annoit luvun " + numberString);
                

            }
            Console.WriteLine("Ohjelman suoritus päättyy");
        }     
    }
}
