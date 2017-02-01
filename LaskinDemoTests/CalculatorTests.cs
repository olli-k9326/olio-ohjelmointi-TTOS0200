using Microsoft.VisualStudio.TestTools.UnitTesting;
using JAMK.IT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // AAA periaate
            // A = Arrange, tietojen alustus
            // A = Act,     kutsutaan metodia
            // A = Assert,  varmistetaan, että tulos OK

            // arrange
            Calculator calc = new Calculator();
            int a = 4;
            int b = 5;
            int expected = 9;

            //act
            int actual = calc.Add(a, b);

            //assert
            Assert.AreEqual(expected, actual);

            // ja toinen testi Add metodilla
            a = 0;
            b = 1;
            expected = 1;
            actual = calc.Add(a, b);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void MultiplyTest()
        {
            // arrange
            Calculator calc = new Calculator();
            int a = 4;
            int b = 5;
            int expected =20;

            //act
            int actual = calc.Multiply(a, b);

            //assert
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void DivisionTest()
        {
            // arrange
            Calculator calc = new Calculator();
            int a = 15;
            int b = 5;
            int expected = 3;

            //act
            int actual = calc.Division(a, b);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void SubstractTest()
        {
            // arrange
            Calculator calc = new Calculator();
            int a = 15;
            int b = 5;
            int expected = 10;

            //act
            int actual = calc.Substract(a, b);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}