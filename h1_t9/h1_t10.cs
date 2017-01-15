using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Tehtävä 10

Tee ohjelma, joka alustaa sovellukseen käyttöö seuraavan taulukon 
arvot = [1,2,33,44,55,68,77,96,100]. Käy sovelluksessa taulukko läpi ja tulosta 
ruutuun "HEP"-sana aina kun taulukossa oleva luku on parillinen. */

namespace h1_t10
{
    class h1_t10
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 33, 44, 55, 68, 77, 96, 100 };

            for (int i = 0; i < numbers.Length; i++)
            {
                if( numbers[i] % 2 == 0)
                    Console.WriteLine("HEP");
            }

            
        }
        
    }
}
