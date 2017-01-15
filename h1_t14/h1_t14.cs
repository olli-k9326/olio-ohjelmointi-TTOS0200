using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Tehtävä 14

Kirjoita ohjelma, joka pyytää käyttäjältä opiskelijoiden arvosanat 0-5 ohjelmointi-opintojaksosta (voit itse päättää lopetusehdon). Tulosta arvosanajakauma käyttäen tähtimerkkejä seuraavasti:

Arvosanajakauma:
0:
1:****
2:**
3:******
4:*****
5:** 
*/
namespace h1_t14
{
    class h1_t14
    {
        static void Main(string[] args)
        {
            
            int gradeAmount = 10000;              // maksimi kysyttävien arvosanojen määrä
            int gradesSaved = 0;
            int[] grades = new int[gradeAmount];     //taulukko luvuille
            bool exit = false;

            Console.WriteLine("***Arvosanajakauma***");
            Console.WriteLine("Syötä arvosanoja väliltä 0-5. Ohjelma tulostaa niistä jakauman syöttämällä -1");
            while (!exit)
            {
                Console.WriteLine();
               
                exit = UserInput(ref grades, gradeAmount, ref gradesSaved);  // kysytään numerot
                
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
        static bool UserInput(ref int[] grades, int gradeAmount, ref int gradesSaved)
        {
            bool exit = false;
            bool finishInput = false;
            string input;
            for (int i = 0; i < gradeAmount && !finishInput; i++)
            {

                while (true)
                {
                    Console.Write("Anna arvosana > ");
                    input = Console.ReadLine();                     // käyttäjän syöte

                    if (input == "exit" || input == "x")
                    {
                        exit = true;
                        finishInput = true;
                        break;
                    }

                    if (int.TryParse(input, out grades[i]) == false)   // syötteen muunto kokonaisluvuksi
                    {                                               // jos ei ole luku, niin kysytään uudestaan
                        Console.WriteLine("Virheellinen syöte");
                    }
                    else if (grades[i] == -1)
                    {
                        finishInput = true;
                        break;
                    } 
                    else if (grades[i] < 0 || grades[i] > 5)      // saatiin luku, mutta se on väärä
                    {
                        Console.WriteLine("Arvosanan pitää olla väliltä 0-5");
                    }
                    else            // saatiin hyväksyttävä luku
                    {
                        gradesSaved++;
                        break;
                        
                    }
                }
                
            }
            return exit;
        }
    }
}
