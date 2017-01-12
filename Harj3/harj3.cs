using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harj3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;          // käyttäjän syöte
            int numberAmount = 3;       // montako lukua kysytään
            int[] numbers = new int[numberAmount];     // lukujen säilytys
            bool exit = false;
            
            while (exit == false)
            {
                for (int i = 0; i < numberAmount; i++)
                {
                    Console.Write("\nAnna {0}. luku  > ", i+1);
                    input = Console.ReadLine();                     // käyttäjän syöte
                    if (input == "exit" || input == "x")
                    {
                        Console.WriteLine("Ohjelman suoritus päättyy");
                        exit = true;
                        break;
                    }
                
                    if (int.TryParse(input, out numbers[i]) == false)   // syötteen muunto kokonaisluvuksi
                    {                                               // jos ei ole luku, niin kysytään uudestaan
                        Console.WriteLine("Virheellinen syöte");
                        i--;
                    }
 
                }
                if (exit) continue;

                Console.WriteLine("\nLukujen summa: " + numbers.Sum());
                Console.WriteLine("Lukujen keskiarvo: " + numbers.Average());

            }
            
        }
    }
}
