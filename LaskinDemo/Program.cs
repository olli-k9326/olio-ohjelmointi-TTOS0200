using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    interface ICalculator
    {
        int Add (int number1, int number2);
        int Multiply (int number1, int number2);
    }
    public class Calculator : ICalculator
    {

        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
        public int Multiply (int number1, int number2)
        {
            return number1 * number2;
        }
        public int Division(int number1, int number2)
        {
            return number1 / number2;
        }
        public int Substract(int number1, int number2)
        {
            return number1 - number2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
