using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAMK.IT;

namespace Labra4
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestaaHissi();
            // TestAmplifier();
            // TestEmployee();
            // TestBoat();
            TestRadio();
        }
        static void TestaaHissi()
        {
            Hissi hissi = new JAMK.IT.Hissi("432980-212", 1);
            hissi.OnkoPaalla = true;
            int temp;
            bool onnistuikoLukeminen;
            while (hissi.OnkoPaalla)
            {
                Console.WriteLine("Hissi on kerroksessa: {0}", hissi.NykyinenKerros());
                Console.Write("Anna kerroksen numero: ");
                do
                {
                    onnistuikoLukeminen = int.TryParse(Console.ReadLine(), out temp);

                    if (onnistuikoLukeminen)
                    {
                        hissi.SyotaUusiKerros(temp);
                        if(hissi.OnkoValidiKerros())
                        {
                            break;
                        }
                    }

                        Console.WriteLine("Kerroksia on välillä 1-5. Syötä uudelleen: ");

                } while (true);
            }
            
        }
        static void TestAmplifier()
        {
            Amplifier amplifier = new JAMK.IT.Amplifier("sfds3432w4", 0);
            amplifier.IsItOn = true;
            int temp;
            bool onnistuikoLukeminen;
            while (amplifier.IsItOn)
            {
                Console.WriteLine("Vahvistimen äänenvoimakkuus: {0}", amplifier.CurrentVolume());
                Console.Write("Anna uusi äänenvoimakkuus 0 - 100: ");
                do
                {
                    onnistuikoLukeminen = int.TryParse(Console.ReadLine(), out temp);

                    if (onnistuikoLukeminen)
                    {
                        amplifier.SetVolume(temp);
                        if (amplifier.IsValidVolume())
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Virheellinen syöte, syötä uudelleen: ");

                } while (true);
            }

        }
        static void TestEmployee()
        {
            Employee employee1 = new Employee("Matti Meikäläinen", "ohjelmoija", 3180);
            Boss boss1 = new Boss("Seppo Karhunen", "toimitusjohtaja", 12670, "Lamborghini", 2000);

            Console.WriteLine(employee1);       // tulostetaan työntekijä
            Console.WriteLine();
            Console.WriteLine(boss1);           // pomo

            boss1.Car = "Maserati";
            boss1.Profession = "toimittaja";            // muokataan pomoa

            Console.WriteLine();
            Console.WriteLine(boss1);           // uusi tulostus

        }
        static void TestBoat()
        {
            Bicycle bicycle = new Bicycle("Insera", "Cheap", 2015, "Black", "Nexus");
            Boat boat = new Boat("Tristan", "Voyager", 2008, "White", "Motorboat", 4);

            Console.WriteLine(bicycle.ToString());
            Console.WriteLine();
            Console.WriteLine(boat.ToString());
        }
        static void TestRadio()
        {
            Radio radio = new Radio("Sony JEJI39399");
            radio.IsOn = true;
            if(radio.IsOn)
            {
                Console.WriteLine(radio.ToString());
                radio.Volume = 5;
                radio.Frequency = 20030.34F;
                Console.WriteLine(radio.ToString());
                radio.Volume = 19;
                radio.Frequency = 2234030.34F;
                Console.WriteLine(radio.ToString());
                radio.Volume = -5455;
                radio.Frequency = 0.34F;
                Console.WriteLine(radio.ToString());
                radio.Volume = 4;
                radio.Frequency = 4440F;
                Console.WriteLine(radio.ToString());

            }
        }

    }
}
