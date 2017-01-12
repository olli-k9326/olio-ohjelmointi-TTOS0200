using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t5
{
    class h1_t5
    {
        static void Main(string[] args)
        {
            bool exit = false;
            
            int seconds = 0;
            int[] time = new int[3];
            string[] temp = new string[3];      // apu taulukkko yksittäisien tuntien tai minuuttien tai sekuntien tulostamiseen
            Console.WriteLine("Ohjelma näyttää annetun sekuntimäärän tunteina, minuutteina ja sekunteina");
            while (exit == false)
            {
                exit = UserInput(ref seconds);

                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                SecondsToHour(time, seconds);   // muunnetaan sekunnit muotoon h min s time taulukkoon

                for (int i = 0; i < 3; i++)          
                {
                    if (time[i] == 1)
                    {
                        temp[i] = " ";          // laitetaan temp taulukkoon " " jos luku sattuu olemaan yksi
                    } else                      // tarvitaan lukujen tulostuksessa.
                    {
                        temp[i] = "a";
                    }
                }

                Console.WriteLine("Antamasi sekunttiaika voidaan ilmaista muodossa: {0} tunti{3} {1} minuutti{4} {2} sekunti{5}", time[2], time[1], time[0], temp[2], temp[1], temp[0]);

            }

        }
        static bool UserInput(ref int number)
        {
            bool exit = false;
            string input;
            
            while (true)
            {
                Console.Write("\nAnna sekunnit > ");
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
        static void SecondsToHour(int [] time, int seconds)
        {
            time[1] = seconds / 60;         // lasketaan minuutit
            time[0] = seconds % 60;         // sekunnit
            time[2] = time[1] / 60;         // tunnit
        }
    }
}
