using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Tehtävä 17

Tee ohjelma, joka lajittelee kahdessa kokonaislukutaulukossa olevat alkiot suurusjärjestykseen kolmanteen kokonaislukutaulukkoon. Tulosta lopuksi lajitellun taulukon sisältö.

Esimerkkitoiminta:


    Luvut taulukossa 1 : 10,20,30,40,50
    Luvut taulukossa 2 : 5,15,25,35,45
    Luvut yhdistetyssä taulukossa : 5,10,15,20,25,30,35,40,45,50
    */
namespace h1_17
{
    class h1_t17
    {
        static void Main(string[] args)
        {
            int[] numbers1 = new int[5] { 10, 20, 30, 40, 50 };
            int[] numbers2 = new int[5] { 5, 15, 25, 35, 45 };
            int[] numbers3 = new int[10];
            for (int i = 0; i < 5; i++)
            {
                numbers3[i] = numbers1[i];
            }
            for (int i = 5; i < 10; i++)
            {
                numbers3[i] = numbers2[i-5];
            }
            Array.Sort(numbers3);
            PrintArray(numbers1, numbers1.Length, "Luvut taulukossa 1 : ");
            PrintArray(numbers2, numbers2.Length, "Luvut taulukossa 2 : ");
            PrintArray(numbers3, numbers3.Length, "Luvut yhdistetyssä taulukossa : ");

        }
        static void PrintArray(int[] array, int max, string arrayString)
        {
            Console.Write(arrayString);
            for (int i = 0; i < max; i++)
            {
                Console.Write(array[i]);

                if (i != max-1)
                    Console.Write(",");
            }
            Console.WriteLine();
        }
    }
}
