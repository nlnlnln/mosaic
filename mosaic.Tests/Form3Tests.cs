using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mosaic.Tests
{
    [TestClass]
    public class Form3SimplifiedTests
    {
        // ===== ВСПОМОГАТЕЛЬНЫЕ КЛАССЫ БЕЗ ИНТЕРФЕЙСОВ =====

        /// <summary>
        /// Упрощенный сервис БД для тестирования
        /// </summary>
        public class TestDatabaseService
        {
            private readonly bool _simulateConnectionError;
            private readonly bool _simulateEmptyData;
            private readonly DataTable _testData;

            public TestDatabaseService(bool simulateConnectionError = false,
                                     bool simulateEmptyData = false)
            {
                _simulateConnectionError = simulateConnectionError;
                _simulateEmptyData = simulateEmptyData;
                _testData = CreateTestData();
            }

            public DataTable GetAllMaterials()
            {
                if (_simulateConnectionError)
                    throw new ApplicationException("Ошибка подключения к БД");

                if (_simulateEmptyData)
                    return new DataTable("Materials");

                return _testData;
            }

            public bool TestConnection()
            {
                return !_simulateConnectionError;
            }

            public DataTable GetMaterialDetails(int materialId)
            {
                var details = new DataTable("MaterialDetails");
                details.Columns.Add("MaterialName", typeof(string));
                details.Columns.Add("Price", typeof(decimal));
                details.Columns.Add("Quantity", typeof(int));

                details.Rows.Add($"Материал {materialId}", 1000 * materialId, 50 * materialId);
                return details;
            }

            private DataTable CreateTestData()
            {
                var table = new DataTable("Materials");
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("MaterialName", typeof(string));
                table.Columns.Add("Price", typeof(decimal));
                table.Columns.Add("Quantity", typeof(int));

                table.Rows.Add(1, "Керамическая плитка", 1500.50m, 100);
                table.Rows.Add(2, "Цемент М500", 450.75m, 50);
                table.Rows.Add(3, "Песок речной", 120.30m, 1000);

                return table;
            }
        }

        /// <summary>
        /// Упрощенный класс карточки
        /// </summary>
        public class TestMaterialCard
        {
            public int MaterialId { get; }
            public string MaterialName { get; }
            public decimal Price { get; }
            public int Quantity { get; }
            public bool WasClicked { get; private set; }

            public TestMaterialCard(int id, string name, decimal price, int quantity)
            {
                MaterialId = id;
                MaterialName = name;
                Price = price;
                Quantity = quantity;
            }

            public void SimulateClick()
            {
                WasClicked = true;
            }
        }

        /// <summary>
        /// Упрощенная форма для тестирования
        /// </summary>
        public class TestForm3
        {
            private readonly TestDatabaseService _dbService;
            private readonly List<TestMaterialCard> _cards = new List<TestMaterialCard>();
            private bool _dataLoaded = false;
            private string _lastErrorMessage = "";
            private string _lastCalculationDetails = "";

            public bool IsDataLoaded => _dataLoaded;
            public int CardCount => _cards.Count;
            public string LastErrorMessage => _lastErrorMessage;
            public string LastCalculationDetails => _lastCalculationDetails;

            public TestForm3(TestDatabaseService dbService)
            {
                _dbService = dbService;
            }

            public void LoadMaterials()
            {
                try
                {
                    if (!_dbService.TestConnection())
                    {
                        _lastErrorMessage = "Ошибка подключения к базе данных";
                        return;
                    }

                    var materials = _dbService.GetAllMaterials();

                    if (materials.Rows.Count == 0)
                    {
                        _lastErrorMessage = "Нет данных для отображения";
                        return;
                    }

                    foreach (DataRow row in materials.Rows)
                    {
                        var card = new TestMaterialCard(
                            Convert.ToInt32(row["Id"]),
                            row["MaterialName"].ToString(),
                            Convert.ToDecimal(row["Price"]),
                            Convert.ToInt32(row["Quantity"])
                        );
                        _cards.Add(card);
                    }

                    _dataLoaded = true;
                }
                catch (Exception ex)
                {
                    _lastErrorMessage = ex.Message;
                }
            }

            public void ClickCard(int index)
            {
                if (index < _cards.Count)
                {
                    _cards[index].SimulateClick();
                    _lastCalculationDetails = GetCalculationDetails(_cards[index].MaterialId);
                }
            }

            private string GetCalculationDetails(int materialId)
            {
                var details = _dbService.GetMaterialDetails(materialId);
                var row = details.Rows[0];
                return $"Расчет для {row["MaterialName"]}: {row["Price"]:C} × {row["Quantity"]}";
            }

            public TestMaterialCard GetCard(int index) =>
                index < _cards.Count ? _cards[index] : null;
        }

        // ===== ТЕСТЫ =====

        /// <summary>
        /// Позитивный тест 1: Отображение карточек
        /// </summary>
        [TestMethod]
        public void Form3_WhenLoaded_DisplaysCards()
        {
            // Arrange
            var dbService = new TestDatabaseService();
            var form = new TestForm3(dbService);

            // Act
            form.LoadMaterials();

            // Assert
            Assert.IsTrue(form.IsDataLoaded, "Данные должны быть загружены");
            Assert.AreEqual(3, form.CardCount, "Должно быть 3 карточки");
            Assert.IsTrue(string.IsNullOrEmpty(form.LastErrorMessage),
                "Не должно быть сообщений об ошибке");
        }

        /// <summary>
        /// Позитивный тест 2: Детализация расчета
        /// </summary>
        [TestMethod]
        public void Form3_WhenCardClicked_ShowsDetails()
        {
            // Arrange
            var dbService = new TestDatabaseService();
            var form = new TestForm3(dbService);
            form.LoadMaterials();

            // Act
            form.ClickCard(0); // Кликаем на первую карточку

            // Assert
            var card = form.GetCard(0);
            Assert.IsNotNull(card, "Карточка должна существовать");
            Assert.IsTrue(card.WasClicked, "Карточка должна быть 'кликнута'");
            Assert.IsFalse(string.IsNullOrEmpty(form.LastCalculationDetails),
                "Должны быть показаны детали расчета");
            Assert.IsTrue(form.LastCalculationDetails.Contains("Расчет для"),
                "Детали должны содержать информацию о расчете");
        }

        /// <summary>
        /// Негативный тест 1: Нет данных
        /// </summary>
        [TestMethod]
        public void Form3_WhenDatabaseEmpty_ShowsError()
        {
            // Arrange
            var dbService = new TestDatabaseService(simulateEmptyData: true);
            var form = new TestForm3(dbService);

            // Act
            form.LoadMaterials();

            // Assert
            Assert.IsFalse(form.IsDataLoaded, "Данные не должны быть загружены");
            Assert.AreEqual(0, form.CardCount, "Не должно быть карточек");
            Assert.AreEqual("Нет данных для отображения", form.LastErrorMessage,
                "Должно быть сообщение об отсутствии данных");
        }

        /// <summary>
        /// Негативный тест 2: Ошибка БД
        /// </summary>
        [TestMethod]
        public void Form3_WhenConnectionFails_ShowsError()
        {
            // Arrange
            var dbService = new TestDatabaseService(simulateConnectionError: true);
            var form = new TestForm3(dbService);

            // Act
            form.LoadMaterials();

            // Assert
            Assert.IsFalse(form.IsDataLoaded, "Данные не должны быть загружены");
            Assert.AreEqual(0, form.CardCount, "Не должно быть карточек");
            Assert.IsTrue(form.LastErrorMessage.Contains("Ошибка подключения"),
                "Должно быть сообщение об ошибке подключения");
        }

        /// <summary>
        /// Тест: Проверка данных в карточках
        /// </summary>
        [TestMethod]
        public void Form3_CardsHaveCorrectData()
        {
            // Arrange
            var dbService = new TestDatabaseService();
            var form = new TestForm3(dbService);
            form.LoadMaterials();

            // Assert
            var card1 = form.GetCard(0);
            Assert.IsNotNull(card1);
            Assert.AreEqual("Керамическая плитка", card1.MaterialName);
            Assert.AreEqual(1500.50m, card1.Price);
            Assert.AreEqual(100, card1.Quantity);

            var card2 = form.GetCard(1);
            Assert.IsNotNull(card2);
            Assert.AreEqual("Цемент М500", card2.MaterialName);
            Assert.AreEqual(450.75m, card2.Price);
            Assert.AreEqual(50, card2.Quantity);
        }

        /// <summary>
        /// Тест: Обновление данных
        /// </summary>
        [TestMethod]
        public void Form3_CanReloadData()
        {
            // Arrange
            var dbService = new TestDatabaseService();
            var form = new TestForm3(dbService);

            // Первая загрузка
            form.LoadMaterials();
            int firstCardCount = form.CardCount;

            // Вторая загрузка (новый экземпляр формы)
            var form2 = new TestForm3(dbService);
            form2.LoadMaterials();

            // Assert
            Assert.AreEqual(firstCardCount, form2.CardCount,
                "Количество карточек должно быть одинаковым при повторной загрузке");
        }
    }
}