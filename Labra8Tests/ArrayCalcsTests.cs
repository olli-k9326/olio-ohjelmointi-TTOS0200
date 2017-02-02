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
    public class ArrayCalcsTests
    {
        
        [TestMethod()]
        public void SumTest()
        {
            // arrange
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double actual;
            double expected;
            expected = 25.6;

            //act
            actual = ArrayCalcs.Sum(array);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AverageTest()
        {
            // arrange
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double actual;
            double expected;
            expected = 3.657;

            //act
            actual = ArrayCalcs.Average(array);

            // assert
            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod()]
        public void AverageTestEmpty()
        {
            // arrange
            double[] array = { };
            double actual;
            double expected;
            expected = 0;

            //act
            actual = ArrayCalcs.Average(array);

            // assert
            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod()]
        public void MinTest()
        {
            // arrange
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double actual;
            double expected;
            expected = -4.5;

            //act
            actual = ArrayCalcs.Min(array);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxTest()
        {
            // arrange
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double actual;
            double expected;
            expected = 12;

            //act
            actual = ArrayCalcs.Max(array);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}