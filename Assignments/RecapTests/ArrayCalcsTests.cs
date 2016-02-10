using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Tests
{
    [TestClass()]
    public class ArrayCalcsTests
    {
        static double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };

        [TestMethod()]
        public void SumTest()
        {
            double expected = array.Sum();
            double actual = ArrayCalcs.Sum(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AverageTest()
        {
            double expected = array.Average();
            double actual = ArrayCalcs.Average(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinTest()
        {
            double expected = array.Min();
            double actual = ArrayCalcs.Min(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxTest()
        {
            double expected = array.Max();
            double actual = ArrayCalcs.Max(array);
            Assert.AreEqual(expected, actual);
        }
    }
}