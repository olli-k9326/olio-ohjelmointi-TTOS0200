using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t14
{
    class h1_t14
    {
        static void Main(string[] args)
        {
            
            int gradeAmount = 10000;              // kysyttävien arvosanojen määrä
            int gradesSaved = 0;
            int[] grades = new int[gradeAmount];     //taulukko luvuille
            bool exit = false;

            Console.WriteLine("***Arvosanajakauma***");
            Console.WriteLine("Syötä arvosanoja väliltä 0-5. Ohjelma tulostaa niistä jakauman syöttämällä -1");
            while (!exit)
            {
                Console.WriteLine();
                for (int i = 0; i < gradeAmount; i++)
                {
                    exit = UserInput(ref grades[i]);  // kysytään numerot
                    if (grades[i] == -1 || exit)
                        break;

                    gradesSaved++;
                }
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                GradeDistribution(grades, gradesSaved);
                gradesSaved = 0;
                
            }
        }
        static void GradeDistribution(int[] grades, int gradesSaved)
        {
            int[] gradeDist = new int[6];
            for (int i = 0; i < gradesSaved; i++)      
            {
                gradeDist[grades[i]]++;         // lasketaan arvosanojen frekvenssit
            }
            for (int i = 0; i <= 5; i++)
            {
                Console.Write("\n" + i + ":");

                for (int j = 0; j < gradeDist[i]; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static bool UserInput(ref int number)
        {
            bool exit = false;
            string input;

            while (true)
            {
                Console.Write("Anna arvosana > ");
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
                else if (number == -1)
                {
                    break;
                } 
                else if (number < 0 || number > 5)      // saatiin luku, mutta se on väärä
                {
                    Console.WriteLine("Arvosanan pitää olla väliltä 0-5");
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
