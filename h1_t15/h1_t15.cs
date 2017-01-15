using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Tehtävä 15

Tee ohjelma, joka tulostaa seuraavanlaisen kuvion. Kysy käyttäjältä puunkorkeus käytä juurena kaksi korkeuden yksikkö.


    Anna Luku > 7 [Enter]    
        *
       ***
      *****
     *******
    *********
        *
        *
    */
namespace h1_t15
{
    class h1_t15
    {
        static void Main(string[] args)
        {

            int heigth = 0;              // maksimi kysyttävien arvosanojen määrä
           
            bool exit = false;

            Console.WriteLine("***Puunpiirto-sovellus!!!!!***");
            Console.WriteLine("Syötä puun korkeus, niin ohjelma tulostaa puun");
            while (!exit)
            {
                Console.WriteLine();
               
                exit = UserInput(ref heigth);  
                   
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                tree(heigth);

            }
        }
        static void tree(int height)
        {
            for (int i = 0; i < height-2 && height >= 3; i++) // Tulostetaan latvaosa
            {
                for (int j = 0; j < height - 3 - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < 2*i+1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                
            }
            for (int i = 0; i < 2 && i < height; i++)       // tulostetaan kanta
            {
                for (int j = 0; j < height - 3; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*\n");
                
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
                else if (number <= 0 )      // saatiin luku, mutta se on väärä
                {
                    Console.WriteLine("Pituuden pitää olla > 0");
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
