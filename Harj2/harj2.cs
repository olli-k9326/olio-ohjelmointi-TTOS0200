using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harj2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;          // käyttäjän syöte
            int points;             // tähän talletetaan pisteet
            int grade = 0;   // pisteitä vastaava arvosana
            int[] gradeChart = new int[] {0, 2, 4, 6, 8, 10};     // pistetaulukko
            while (true)
            {

                Console.Write("\n\nAnna pistemäärä > ");
                input = Console.ReadLine();                     // käyttäjän syöte
                if (int.TryParse(input, out points) == false)   // syötteen muunto kokonaisluvuksi
                {                                               // jos ei ole luku, niin poistutaan
                    break;
                }

                if (points < 0 || points > 12)      // käsitellään alueen ulkopuoliset luvut
                {
                    Console.WriteLine("Anna pistemäärä väliltä 0-12");
                    continue;
                }

                grade = 0;
                for (int i = 1; i <= 5; i++)         // arvosanan määrittely
                {
                    if(points >= gradeChart[i])         
                    {
                        grade = i;                  // arvosana = "viimesen ylittyvän pisterajan indeksi"
                    }
                    else
                    {
                        break;      // poistutaan silmukasta kun löytyy raja, jota ei ylitä
                    }

                }
                
                Console.Write("Koulunumero on " + grade);


            }
            Console.WriteLine("Ohjelman suoritus päättyy");
        }
    }
}
