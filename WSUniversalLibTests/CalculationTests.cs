using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace WSUniversalLib.Tests
{
    [TestClass()]
    public class CalculationTests
    {
        [TestMethod()]
        public void GetQuantityForProduct_ForCorrectParameters()
        {
            int expected = 114148;
            int actual = Calculation.GetQuantityForProduct(3, 1, 15, 20, 45);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetQuantityForProduct_ForUnknownProductType()
        {
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(4, 2, 5, 10, 20);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetQuantityForProduct_ForUnknownMaterialType()
        {
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(3, 3, 3, 15, 25);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetQuantityForProduct_ForNullableCount()
        {
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(1, 1, 0, 10, 10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetQuantityForProduct_ForNegativeProductCount()
        {
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(3, 1, -5, 20, 45);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetQuantityForProduct_ForNullableArea()
        {
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(2, 2, 10, 0, 0);
            Assert.AreEqual(expected, actual); ;
        }
    }
}