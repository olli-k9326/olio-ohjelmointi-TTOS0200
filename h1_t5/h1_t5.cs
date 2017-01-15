using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Tehtävä 5

Tee ohjelma, joka näyttää annetun sekuntimäärän tunteina, 
minuutteina ja sekunteina. Aikamääre sekuntteina kysytään käyttäjältä.

Esimerkkitoiminta:

    Anna sekunnit > 3661 [Enter]
    Antamasi sekunttiaika voidaan ilmaista muodossa: 1 tunti 1 minuutti 1 sekuntti
    
     */
namespace h1_t5
{
    class h1_t5
    {
        static void Main(string[] args)
        {
            bool exit = false;
            
            int seconds = 0;
            int[] time = new int[3];
            string[] a = new string[3];      // apu taulukkko yksittäisien tuntien tai minuuttien tai sekuntien tulostamiseen
            Console.WriteLine("Ohjelma näyttää annetun sekuntimäärän tunteina, minuutteina ja sekunteina");
            while (exit == false)
            {
                seconds = UserInput(ref exit);

                if (exit) continue;     // pois silmukasta, jos syötteessä esiintyi "exit"

                SecondsToHour(time, seconds);   // muunnetaan sekunnit muotoon h min s time taulukkoon
         
                extraA(time, ref a);

                Console.WriteLine("Antamasi sekunttiaika voidaan ilmaista muodossa: {0} tunti{3} {1} minuutti{4} {2} sekunti{5}", time[2], time[1], time[0], a[2], a[1], a[0]);

            }

        }
        
        static int UserInput(ref bool exit)
        {
            string input;
            int number = 0;
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
            return number;
        }
        static void SecondsToHour(int [] time, int seconds)
        {

            time[2] = seconds / 60 / 60;         // tunnit
            time[1] = (seconds / 60) % 60;         // lasketaan minuutit
            time[0] = seconds % 60;         // sekunnit
        }
        static void extraA(int[] time, ref string[] a)
        {
            for (int i = 0; i < 3; i++)
            {
                if (time[i] == 1)
                {
                    a[i] = " ";          // laitetaan a taulukkoon " " jos luku sattuu olemaan yksi
                }
                else                      // tarvitaan lukujen tulostuksessa.
                {
                    a[i] = "a";
                }
            }
        }
    }
}
