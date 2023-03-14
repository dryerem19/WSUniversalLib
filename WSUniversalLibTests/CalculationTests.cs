using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace WSUniversalLib.Tests
{
    [TestClass()]
    public class CalculationTests
    {

        #region СЛОЖНЫЕ ТЕСТ КЕЙСЫ
        /// <summary>
        /// В этом тест-кейсе мы проверяем, что функция возвращает -1,
        /// если значение percentage равно 0. Это важно, потому что если процент брака равен 0%,
        /// то функция не может рассчитать количество необходимого материала, и должна вернуть -1.
        /// </summary>
        [TestMethod()]
        public void TestGetQuantityForProductPercentageZero()
        {
            long result = Calculation.GetQuantityForProduct(1, 0, 10, 2.0f, 2.0f);
            Assert.AreEqual(-1, result);
        }
        #endregion

        [TestMethod()]
        public void TestGetQuantityForProductPercentageSmall()
        {
            long result = Calculation.GetQuantityForProduct(2, 1, 5, 1.0f, 1.0f);
            Assert.AreEqual(13, result);
        }

        [TestMethod()]
        public void TestGetQuantityForProductPositiveCheck()
        {
            long result = Calculation.GetQuantityForProduct(3, 2, 5, 3.8f, 9.6f);
            Assert.AreEqual(1540, result);
        }

        [TestMethod()]
        public void TestGetQuantityForProductPositiveCheck2()
        {
            long result = Calculation.GetQuantityForProduct(1, 1, 10, 5.5f, 7.2f);
            Assert.AreEqual(437, result);
        }



        [TestMethod()]
        public void TestGetQuantityForProductWithZeroValues()
        {
            // Arrange
            int productType = 1;
            int materialType = 1;
            int count = 0;
            float width = 0;
            float length = 0;

            // Act
            long result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod()]
        public void GetQuantityForProduct_MaxValues()
        {
            // Arrange
            int productType = 1;
            int materialType = 1;
            int count = int.MaxValue;
            float width = float.MaxValue;
            float length = float.MaxValue;

            // Act
            long result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(-1, result);
        }



        [TestMethod()]
        public void TestGetQuantityForProductWithNegativeValues()
        {
            // Arrange
            int productType = 1;
            int materialType = 1;
            int count = -10;
            float width = -4;
            float length = -4;

            // Act
            long result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(-1, result);
        }

        /// <summary>
        /// Проверка при правильных параметрах
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForCorrectParameters()
        {
            int expected = 114148;
            long actual = Calculation.GetQuantityForProduct(3, 1, 15, 20, 45);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Проверка, если тип продукта не существует
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForUnknownProductType()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(4, 2, 5, 10, 20);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка, если тип материала не существует
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForUnknownMaterialType()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(3, 3, 3, 15, 25);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка, если кол-во продукта == 0
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForNullableCount()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(1, 1, 0, 10, 10);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка, если кол-во продукта < 0
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForNegativeProductCount()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(3, 1, -5, 20, 45);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка, если площадь == 0
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForNullableArea()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(2, 2, 10, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка, если длина < 0
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForNegativeLength()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(2, 2, 10, 0, -10);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка, если ширина < 0
        /// </summary>
        [TestMethod()]
        public void GetQuantityForProduct_ForNegativeWidth()
        {
            int expected = -1;
            long actual = Calculation.GetQuantityForProduct(2, 2, 10, 0, -5);
            Assert.AreEqual(expected, actual);
        }
    }
}