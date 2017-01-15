using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Tehtävä 6

Auton kulutus on 7.02 litraa 100 kilometrin matkalla ja bensan hinta on 1.595 Euroa. Tee ohjelma, joka tulostaa ajetulla matkalla (kysytään käyttäjältä) kuluvan bensan määrän sekä bensaan menevän rahan määrän.

Esimerkkitoiminta:

    Anna matka > 250 [Enter]
    Bensaa kuluu 17,55 litraa, kustannus 27,99 euroa
    
 * */
namespace h1_t6
{
    class ht_t6
    {
        static void Main(string[] args)
        {
            double distance = 0;
            
            double gasolinePer100 = 7.02;
            double gasolineExpLitre = 1.595;
            bool exit = false;

            while (!exit)
            {
                exit = UserInput(ref distance);     // kysytään matka
                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"
                GasolineExpence(distance, gasolinePer100, gasolineExpLitre);
            }

        }
        static void GasolineExpence(double distance, double gasolinePer100, double gasolineExpLitre)
        {
            double gasoline = distance / 100 * gasolinePer100;
            double expence = gasoline * gasolineExpLitre;

            Console.WriteLine("Bensaa kuluu {0} litraa, kustannus {1} euroa", gasoline.ToString("#.##"), expence.ToString("#.##"));

        }


        static bool UserInput(ref double number)
        {
            bool exit = false;
            string input;

            while (true)
            {
                Console.Write("\nAnna matka > ");
                input = Console.ReadLine();                     // käyttäjän syöte
                if (input == "exit" || input == "x")
                {
                    exit = true;
                    break;
                }

                if (double.TryParse(input, out number) == false)   // syötteen muunto kokonaisluvuksi
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
