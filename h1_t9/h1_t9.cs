using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1_t9
{
    class h1_t9
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
