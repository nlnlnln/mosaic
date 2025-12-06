using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mosaic.Tests
{
    [TestClass]
    public class TileCalculatorTests
    {
        // ===== ПОЗИТИВНЫЕ ТЕСТ-КЕЙСЫ =====

        /// <summary>
        /// Позитивный тест 1: Корректный расчёт плиток
        /// Продукция = Мозаика, материал = керамическая основа
        /// сырьё = 100, длина = 1.5, ширина = 0.8
        /// Ожидается: Количество плиток = 10416
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenValidInputMosaic_ReturnsCorrectCount()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 100;
            decimal length = 1.5m;
            decimal width = 0.8m;
            decimal expectedCount = 10416;

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            Assert.AreEqual(expectedCount, actualCount,
                $"Неверное количество плиток для мозаики. " +
                $"Ожидалось: {expectedCount}, Получено: {actualCount}");
        }

        /// <summary>
        /// Позитивный тест 2: Большое количество сырья
        /// Продукция = Мозаика, материал = керамическая основа
        /// сырьё = 500, длина = 1, ширина = 1
        /// Ожидается: Количество плиток = 62500 (> 100)
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenLargeRawMaterial_ReturnsLargeCount()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 500;
            decimal length = 1;
            decimal width = 1;
            decimal expectedCount = 62500;

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            Assert.AreEqual(expectedCount, actualCount,
                $"Неверное количество плиток для большого количества сырья. " +
                $"Ожидалось: {expectedCount}, Получено: {actualCount}");

            // Дополнительная проверка: количество должно быть больше 100
            Assert.IsTrue(actualCount > 100,
                "Количество плиток должно быть больше 100 при большом количестве сырья");
        }

        /// <summary>
        /// Позитивный тест 3: Маленькая площадь плитки
        /// Продукция = Мозаика, материал = керамическая основа
        /// сырьё = 500, длина = 0.5, ширина = 0.5
        /// Ожидается: Количество плиток = 250000
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenSmallTileArea_ReturnsLargeCount()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 500;
            decimal length = 0.5m;
            decimal width = 0.5m;
            decimal expectedCount = 250000;

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            Assert.AreEqual(expectedCount, actualCount,
                $"Неверное количество плиток для маленькой площади. " +
                $"Ожидалось: {expectedCount}, Получено: {actualCount}");

            // Дополнительная проверка: количество должно быть больше 0
            Assert.IsTrue(actualCount > 0,
                "Количество плиток должно быть больше 0");
        }

        // ===== НЕГАТИВНЫЕ ТЕСТ-КЕЙСЫ =====

        /// <summary>
        /// Негативный тест 1: Нулевое количество сырья
        /// Продукция = Мозаика, материал = керамическая основа
        /// сырьё = 0, длина = 1, ширина = 1
        /// Ожидается: Исключение или автоматическая корректировка
        /// Фактически: Программа меняет 0 на 1
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenZeroRawMaterial_AutoCorrectsToOne()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 0; // Вводим 0
            decimal length = 1;
            decimal width = 1;
            decimal expectedCountWithCorrection = 125; // При сырье = 1: (1 * 25) * (1 * 1) * 5 = 125

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            // Проверяем, что программа автоматически корректирует 0 на 1
            Assert.AreEqual(expectedCountWithCorrection, actualCount,
                "Программа должна автоматически корректировать нулевое сырье на 1");
        }

        /// <summary>
        /// Негативный тест 2: Отрицательная длина
        /// Продукция = Мозаика, материал = керамическая основа
        /// сырьё = 50, длина = -1, ширина = 1
        /// Ожидается: Исключение или автоматическая корректировка
        /// Фактически: Программа меняет отрицательное значение на 0.10
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenNegativeLength_AutoCorrectsTo01()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 50;
            decimal length = -1; // Вводим отрицательную длину
            decimal width = 1;
            decimal correctedLength = 0.10m; // Программа корректирует на 0.10

            // Рассчитываем ожидаемый результат с корректировкой
            decimal baseEfficiency = 25; // для керамической основы
            decimal materialCoefficient = 1; // для мозаики
            decimal qualityMultiplier = 5; // для мозаики
            decimal expectedCount = (rawMaterial * baseEfficiency) / (correctedLength * width) * qualityMultiplier;
            expectedCount = Math.Round(expectedCount, 0);

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            Assert.AreEqual(expectedCount, actualCount,
                "Программа должна автоматически корректировать отрицательную длину на 0.10");
        }

        /// <summary>
        /// Негативный тест 3: Отрицательная ширина
        /// Продукция = Бордюр, материал = Глазурь
        /// сырьё = 1000, длина = 1, ширина = -1
        /// Ожидается: Исключение или автоматическая корректировка
        /// Фактически: Программа меняет отрицательное значение на 0.10
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenNegativeWidth_AutoCorrectsTo01()
        {
            // Arrange
            string productType = "Бордюр";
            string materialType = "Глазурь";
            decimal rawMaterial = 1000;
            decimal length = 1;
            decimal width = -1; // Вводим отрицательную ширину
            decimal correctedWidth = 0.10m; // Программа корректирует на 0.10

            // Рассчитываем ожидаемый результат с корректировкой
            decimal baseEfficiency = 30; // для глазури
            decimal materialCoefficient = 0.8m; // для бордюра
            decimal qualityMultiplier = 3; // для бордюра
            decimal expectedCount = (rawMaterial * baseEfficiency * materialCoefficient) / (length * correctedWidth) * qualityMultiplier;
            expectedCount = Math.Round(expectedCount, 0);

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            Assert.AreEqual(expectedCount, actualCount,
                "Программа должна автоматически корректировать отрицательную ширину на 0.10");
        }

        // ===== ДОПОЛНИТЕЛЬНЫЕ ТЕСТЫ =====

        /// <summary>
        /// Тест для разных типов продукции и материалов
        /// </summary>
        [TestMethod]
        public void CalculateTiles_ForDifferentProductTypes_ReturnsCorrectValues()
        {
            // Тест 1: Мозаика с керамической основой
            decimal count1 = TileCalculator.CalculateTilesCount(
                "Мозаика", "керамическая основа", 100, 1, 1);
            Assert.IsTrue(count1 > 0, "Мозаика должна давать положительное количество");

            // Тест 2: Бордюр с глазурью
            decimal count2 = TileCalculator.CalculateTilesCount(
                "Бордюр", "Глазурь", 100, 1, 1);
            Assert.IsTrue(count2 > 0, "Бордюр должен давать положительное количество");

            // Тест 3: Плитка с цементной основой
            decimal count3 = TileCalculator.CalculateTilesCount(
                "Плитка", "цементная основа", 100, 1, 1);
            Assert.IsTrue(count3 > 0, "Плитка должна давать положительное количество");
        }

        /// <summary>
        /// Тест для проверки деления на ноль (очень маленькие размеры)
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenExtremelySmallDimensions_HandlesGracefully()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 100;
            decimal length = 0.001m; // Очень маленькая длина
            decimal width = 0.001m;  // Очень маленькая ширина

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

        }

        /// <summary>
        /// Тест для проверки очень больших значений
        /// </summary>
        [TestMethod]
        public void CalculateTiles_WhenVeryLargeRawMaterial_CalculatesCorrectly()
        {
            // Arrange
            string productType = "Мозаика";
            string materialType = "керамическая основа";
            decimal rawMaterial = 1000000; // 1 миллион сырья
            decimal length = 1;
            decimal width = 1;

            // Act
            decimal actualCount = TileCalculator.CalculateTilesCount(
                productType, materialType, rawMaterial, length, width);

            // Assert
            Assert.IsTrue(actualCount > 0,
                "При большом количестве сырья должно быть большое количество плиток");
            Assert.IsTrue(actualCount > 1000000,
                "При 1 миллионе сырья количество плиток должно быть значительным");
        }
    }

    /// <summary>
    /// Класс для расчета количества плиток
    /// </summary>
    public static class TileCalculator
    {
        /// <summary>
        /// Рассчитывает количество плиток на основе входных параметров
        /// </summary>
        /// <param name="productType">Тип продукции (Мозаика, Бордюр, Плитка)</param>
        /// <param name="materialType">Тип материала (керамическая основа, Глазурь, цементная основа)</param>
        /// <param name="rawMaterial">Количество сырья</param>
        /// <param name="length">Длина плитки</param>
        /// <param name="width">Ширина плитки</param>
        /// <returns>Количество плиток</returns>
        public static decimal CalculateTilesCount(
            string productType,
            string materialType,
            decimal rawMaterial,
            decimal length,
            decimal width)
        {
            // 1. Корректировка входных значений (как в программе)
            rawMaterial = AdjustRawMaterial(rawMaterial);
            length = AdjustDimension(length);
            width = AdjustDimension(width);

            // 2. Получение базовых коэффициентов
            decimal baseEfficiency = GetBaseEfficiency(materialType);
            decimal materialCoefficient = GetMaterialCoefficient(productType);
            decimal qualityMultiplier = GetQualityMultiplier(productType);

            // 3. Расчет площади одной плитки
            decimal tileArea = length * width;

            // 4. Проверка на нулевую площадь (во избежание деления на ноль)
            if (tileArea <= 0)
            {
                tileArea = 0.01m; // Минимальная площадь
            }

            // 5. Расчет общего количества плиток
            // Формула: (сырьё * базовая_эффективность * коэффициент_материала) / площадь_плитки * множитель_качества
            decimal totalTiles = (rawMaterial * baseEfficiency * materialCoefficient) / tileArea * qualityMultiplier;

            // 6. Округление до целого числа
            return Math.Round(totalTiles, 0);
        }

        /// <summary>
        /// Корректировка количества сырья
        /// Если сырьё <= 0, устанавливается 1
        /// </summary>
        private static decimal AdjustRawMaterial(decimal rawMaterial)
        {
            return rawMaterial <= 0 ? 1 : rawMaterial;
        }

        /// <summary>
        /// Корректировка размеров (длины и ширины)
        /// Если размер <= 0, устанавливается 0.10
        /// </summary>
        private static decimal AdjustDimension(decimal dimension)
        {
            return dimension <= 0 ? 0.10m : dimension;
        }

        /// <summary>
        /// Получение базовой эффективности материала
        /// </summary>
        private static decimal GetBaseEfficiency(string materialType)
        {
            return materialType.ToLower() switch
            {
                "керамическая основа" => 25m,
                "глазурь" => 30m,
                "цементная основа" => 20m,
                _ => 25m // Значение по умолчанию
            };
        }

        /// <summary>
        /// Получение коэффициента материала для типа продукции
        /// </summary>
        private static decimal GetMaterialCoefficient(string productType)
        {
            return productType.ToLower() switch
            {
                "мозаика" => 1.0m,
                "бордюр" => 0.8m,
                "плитка" => 1.2m,
                _ => 1.0m // Значение по умолчанию
            };
        }

        /// <summary>
        /// Получение множителя качества для типа продукции
        /// </summary>
        private static decimal GetQualityMultiplier(string productType)
        {
            return productType.ToLower() switch
            {
                "мозаика" => 5.0m,   // Высокое качество
                "бордюр" => 3.0m,    // Среднее качество
                "плитка" => 4.0m,    // Хорошее качество
                _ => 1.0m // Значение по умолчанию
            };
        }

        /// <summary>
        /// Дополнительный метод для расчета площади плитки
        /// </summary>
        public static decimal CalculateTileArea(decimal length, decimal width)
        {
            length = AdjustDimension(length);
            width = AdjustDimension(width);
            return length * width;
        }

        /// <summary>
        /// Метод для проверки корректности входных параметров
        /// </summary>
        public static bool ValidateInput(
            string productType,
            string materialType,
            decimal rawMaterial,
            decimal length,
            decimal width)
        {
            // Проверяем, что типы не пустые
            if (string.IsNullOrWhiteSpace(productType) || string.IsNullOrWhiteSpace(materialType))
                return false;

            // Проверяем допустимость типов продукции
            string[] validProducts = { "мозаика", "бордюр", "плитка" };
            if (!Array.Exists(validProducts, p => p.Equals(productType.ToLower())))
                return false;

            // Проверяем допустимость типов материалов
            string[] validMaterials = { "керамическая основа", "глазурь", "цементная основа" };
            if (!Array.Exists(validMaterials, m => m.Equals(materialType.ToLower())))
                return false;

            return true;
        }

        /// <summary>
        /// Метод для расчета стоимости производства
        /// </summary>
        public static decimal CalculateProductionCost(
            decimal tilesCount,
            decimal costPerTile)
        {
            if (tilesCount <= 0 || costPerTile < 0)
                return 0;

            return tilesCount * costPerTile;
        }
    }
}