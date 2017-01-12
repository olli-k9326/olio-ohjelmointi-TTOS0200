using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harj1
{
    class Program
    {
        static void Main(string[] args)
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
                        continue;
                } 
                Console.Write("Annoit luvun " + numberString);
                

            }
            Console.WriteLine("Ohjelman suoritus päättyy");
        }     
    }
}
