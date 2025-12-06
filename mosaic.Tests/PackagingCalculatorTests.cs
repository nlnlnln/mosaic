using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mosaic.Tests
{
    [TestClass]
    public class PackagingCalculatorTests
    {
        // ===== ПОЗИТИВНЫЕ ТЕСТ-КЕЙСЫ =====

        /// <summary>
        /// Позитивный тест 1: Расчёт, когда на складе меньше минимального
        /// На складе = 300
        /// </summary>
        [TestMethod]
        public void CalculateOrderCost_WhenStockLessThanMin_CalculatesCorrectCost()
        {
            // Arrange
            decimal stockQuantity = 300;
            decimal minRequired = 500;
            decimal packageSize = 100;
            decimal pricePerUnit = 150;

            // Рассчитываем ожидаемый результат:
            // Недостаток: 500 - 300 = 200
            // Упаковок нужно: 200 / 100 = 2
            // Всего единиц в упаковках: 2 * 100 = 200
            // Стоимость: 200 * 150 = 30000
            decimal expectedCost = 30000;

            // Act
            decimal actualCost = PackagingCalculator.CalculateTotalCost(
                stockQuantity,
                minRequired,
                packageSize,
                pricePerUnit);

            // Assert
            Assert.AreEqual(expectedCost, actualCost,
                "Неверно рассчитана стоимость при недостатке на складе");
        }

        /// <summary>
        /// Позитивный тест 2: На складе достаточно
        /// На складе = 600
        /// </summary>
        [TestMethod]
        public void CalculateOrderCost_WhenStockSufficient_ReturnsZero()
        {
            // Arrange
            decimal stockQuantity = 600;
            decimal minRequired = 500;
            decimal packageSize = 100;
            decimal pricePerUnit = 150;
            decimal expectedCost = 0; // На складе достаточно, заказ не нужен

            // Act
            decimal actualCost = PackagingCalculator.CalculateTotalCost(
                stockQuantity,
                minRequired,
                packageSize,
                pricePerUnit);

            // Assert
            Assert.AreEqual(expectedCost, actualCost,
                "Стоимость должна быть 0, когда на складе достаточно товара");
        }

        /// <summary>
        /// Позитивный тест 3: Крайний случай, нужно ровно 1 упаковка
        /// На складе = 900
        /// </summary>
        [TestMethod]
        public void CalculateOrderCost_WhenNeedExactlyOnePackage_CalculatesCorrectCost()
        {
            // Arrange
            decimal stockQuantity = 900;
            decimal minRequired = 1000;
            decimal packageSize = 100;
            decimal pricePerUnit = 200;

            // Рассчитываем ожидаемый результат:
            // Недостаток: 1000 - 900 = 100
            // Упаковок нужно: 100 / 100 = 1
            // Всего единиц в упаковках: 1 * 100 = 100
            // Стоимость: 100 * 200 = 20000
            decimal expectedCost = 20000;

            // Act
            decimal actualCost = PackagingCalculator.CalculateTotalCost(
                stockQuantity,
                minRequired,
                packageSize,
                pricePerUnit);

            // Assert
            Assert.AreEqual(expectedCost, actualCost,
                "Неверно рассчитана стоимость для крайнего случая (ровно 1 упаковка)");
        }

        // ===== НЕГАТИВНЫЕ ТЕСТ-КЕЙСЫ =====

        /// <summary>
        /// Негативный тест 1: Отрицательное количество на складе
        /// На складе = -50
        /// Ожидается: Исключение ArgumentException с сообщением:
        /// "Количество на складе должно быть положительным."
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Должно быть выброшено исключение при отрицательном количестве на складе")]
        public void CalculateTotalCost_WhenNegativeStock_ThrowsArgumentException()
        {
            // Arrange
            decimal stockQuantity = -50;
            decimal minRequired = 500;
            decimal packageSize = 100;
            decimal pricePerUnit = 200;

            // Act
            decimal actualCost = PackagingCalculator.CalculateTotalCost(
                stockQuantity,
                minRequired,
                packageSize,
                pricePerUnit);
        }

        /// <summary>
        /// Негативный тест 1 (дополнительная проверка сообщения исключения)
        /// Проверяем, что сообщение исключения соответствует ожидаемому
        /// </summary>
        [TestMethod]
        public void CalculateTotalCost_WhenNegativeStock_ThrowsCorrectMessage()
        {
            // Arrange
            decimal stockQuantity = -50;
            decimal minRequired = 500;
            decimal packageSize = 100;
            decimal pricePerUnit = 200;
            string expectedMessage = "Количество на складе должно быть положительным";

            try
            {
                // Act
                decimal actualCost = PackagingCalculator.CalculateTotalCost(
                    stockQuantity,
                    minRequired,
                    packageSize,
                    pricePerUnit);

                // Если не выброшено исключение - тест не пройден
                Assert.Fail("Ожидалось исключение, но его не было выброшено");
            }
            catch (ArgumentException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, expectedMessage,
                    $"Сообщение исключения не соответствует ожидаемому. Ожидалось: '{expectedMessage}', Получено: '{ex.Message}'");
            }
        }

        /// <summary>
        /// Негативный тест 2: Цена = 0
        /// На складе = 2, цена за ед. = 0
        /// Ожидается: Стоимость партии = 0
        /// </summary>
        [TestMethod]
        public void CalculateOrderCost_WhenPriceIsZero_ReturnsZero()
        {
            // Arrange
            decimal quantity = 2;
            decimal unitPrice = 0;
            decimal expectedCost = 0;

            // Act
            decimal actualCost = PackagingCalculator.CalculateOrderCost(quantity, unitPrice);

            // Assert
            Assert.AreEqual(expectedCost, actualCost,
                "Стоимость должна быть 0 при нулевой цене");
        }

        /// <summary>
        /// Дополнительный тест: Нулевое количество на складе
        /// </summary>
        [TestMethod]
        public void CalculateTotalCost_WhenZeroStock_CalculatesCorrectCost()
        {
            // Arrange
            decimal stockQuantity = 0;
            decimal minRequired = 500;
            decimal packageSize = 100;
            decimal pricePerUnit = 200;

            // Рассчитываем ожидаемый результат:
            // Недостаток: 500 - 0 = 500
            // Упаковок нужно: 500 / 100 = 5
            // Всего единиц в упаковках: 5 * 100 = 500
            // Стоимость: 500 * 200 = 100000
            decimal expectedCost = 100000;

            // Act
            decimal actualCost = PackagingCalculator.CalculateTotalCost(
                stockQuantity,
                minRequired,
                packageSize,
                pricePerUnit);

            // Assert
            Assert.AreEqual(expectedCost, actualCost,
                "Неверно рассчитана стоимость при нулевом количестве на складе");
        }

        /// <summary>
        /// Дополнительный тест: Крайний случай - нулевая минимальная потребность
        /// </summary>
        [TestMethod]
        public void CalculateTotalCost_WhenMinRequiredIsZero_ReturnsZero()
        {
            // Arrange
            decimal stockQuantity = 100;
            decimal minRequired = 0;
            decimal packageSize = 100;
            decimal pricePerUnit = 200;
            decimal expectedCost = 0; // Минимальная потребность 0, заказ не нужен

            // Act
            decimal actualCost = PackagingCalculator.CalculateTotalCost(
                stockQuantity,
                minRequired,
                packageSize,
                pricePerUnit);

            // Assert
            Assert.AreEqual(expectedCost, actualCost,
                "Стоимость должна быть 0 при нулевой минимальной потребности");
        }

        /// <summary>
        /// Дополнительный негативный тест: Отрицательная цена
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Должно быть выброшено исключение при отрицательной цене")]
        public void CalculateOrderCost_WhenPriceIsNegative_ThrowsException()
        {
            // Arrange
            decimal quantity = 100;
            decimal unitPrice = -50;

            // Act
            PackagingCalculator.CalculateOrderCost(quantity, unitPrice);
        }

        /// <summary>
        /// Дополнительный негативный тест: Отрицательное минимальное количество
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Должно быть выброшено исключение при отрицательном минимальном количестве")]
        public void CalculateTotalCost_WhenMinRequiredIsNegative_ThrowsException()
        {
            // Arrange
            decimal stockQuantity = 50;
            decimal minRequired = -100;
            decimal packageSize = 10;
            decimal pricePerUnit = 200;

            // Act
            PackagingCalculator.CalculateTotalCost(stockQuantity, minRequired, packageSize, pricePerUnit);
        }

        /// <summary>
        /// Дополнительный негативный тест: Отрицательный размер упаковки
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Должно быть выброшено исключение при отрицательном размере упаковки")]
        public void CalculateTotalCost_WhenPackageSizeIsNegative_ThrowsException()
        {
            // Arrange
            decimal stockQuantity = 50;
            decimal minRequired = 100;
            decimal packageSize = -10;
            decimal pricePerUnit = 200;

            // Act
            PackagingCalculator.CalculateTotalCost(stockQuantity, minRequired, packageSize, pricePerUnit);
        }

        /// <summary>
        /// Дополнительный негативный тест: Нулевой размер упаковки
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Должно быть выброшено исключение при нулевом размере упаковки")]
        public void CalculateTotalCost_WhenPackageSizeIsZero_ThrowsException()
        {
            // Arrange
            decimal stockQuantity = 50;
            decimal minRequired = 100;
            decimal packageSize = 0;
            decimal pricePerUnit = 200;

            // Act
            PackagingCalculator.CalculateTotalCost(stockQuantity, minRequired, packageSize, pricePerUnit);
        }
    }

    /// <summary>
    /// Класс для расчетов упаковок (адаптирован под ваши тест-кейсы)
    /// </summary>
    public static class PackagingCalculator
    {
        /// <summary>
        /// Рассчитывает необходимое количество упаковок для заказа
        /// </summary>
        public static decimal CalculateRequiredPackages(
            decimal stockQuantity,
            decimal minRequired,
            decimal packageSize)
        {
            // Валидация входных данных
            ValidateInput(stockQuantity, minRequired, packageSize);

            // Если на складе достаточно - не заказываем ничего
            if (stockQuantity >= minRequired)
            {
                return 0;
            }

            // Рассчитываем недостающее количество
            decimal shortage = minRequired - stockQuantity;

            // Рассчитываем количество упаковок (округляем вверх)
            decimal packagesNeeded = Math.Ceiling(shortage / packageSize);

            return packagesNeeded;
        }

        /// <summary>
        /// Рассчитывает стоимость заказа
        /// </summary>
        public static decimal CalculateOrderCost(decimal quantity, decimal unitPrice)
        {
            // Валидация
            if (quantity < 0)
                throw new ArgumentException("Количество не может быть отрицательным", nameof(quantity));

            if (unitPrice < 0)
                throw new ArgumentException("Цена не может быть отрицательной", nameof(unitPrice));

            return quantity * unitPrice;
        }

        /// <summary>
        /// Рассчитывает общее количество товара в упаковках
        /// </summary>
        public static decimal CalculateTotalQuantity(decimal packages, decimal packageSize)
        {
            // Валидация
            if (packages < 0)
                throw new ArgumentException("Количество упаковок не может быть отрицательным", nameof(packages));

            if (packageSize <= 0)
                throw new ArgumentException("Размер упаковки должен быть положительным", nameof(packageSize));

            return packages * packageSize;
        }

        /// <summary>
        /// Валидация входных параметров
        /// </summary>
        private static void ValidateInput(
            decimal stockQuantity,
            decimal minRequired,
            decimal packageSize)
        {
            if (stockQuantity < 0)
                throw new ArgumentException(
                    "Количество на складе должно быть положительным",
                    nameof(stockQuantity));

            if (minRequired < 0)
                throw new ArgumentException(
                    "Минимальное необходимое количество не может быть отрицательным",
                    nameof(minRequired));

            if (packageSize <= 0)
                throw new ArgumentException(
                    "Количество в упаковке должно быть больше 0",
                    nameof(packageSize));
        }

        /// <summary>
        /// Рассчитывает общую стоимость заказа упаковок
        /// </summary>
        public static decimal CalculateTotalCost(
            decimal stockQuantity,
            decimal minRequired,
            decimal packageSize,
            decimal pricePerUnit)
        {
            // Получаем количество необходимых упаковок
            decimal packagesNeeded = CalculateRequiredPackages(stockQuantity, minRequired, packageSize);

            // Рассчитываем общее количество единиц в упаковках
            decimal totalQuantity = CalculateTotalQuantity(packagesNeeded, packageSize);

            // Рассчитываем общую стоимость
            return CalculateOrderCost(totalQuantity, pricePerUnit);
        }
    }
}