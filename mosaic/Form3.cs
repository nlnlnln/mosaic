using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mosaic
{
    public partial class Form3 : Form
    {
        private SqlConnection connection;
        private DataTable displayTable;
        private FlowLayoutPanel cardsPanel;
        public Form3()
        {
            InitializeComponent();
            // Подключение к БД
            connection = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=kikh;Integrated Security=True;");

            // Создаем панель для карточек
            CreateCardsPanel();

            // Загрузка данных при запуске формы
            LoadMaterials();
        }
        private void CreateCardsPanel()
        {
            // Создаем FlowLayoutPanel для карточек
            cardsPanel = new FlowLayoutPanel();
            cardsPanel.Location = new Point(20, 80);
            cardsPanel.Size = new Size(940, 350);
            cardsPanel.AutoScroll = true;
            cardsPanel.BackColor = Color.White;
            cardsPanel.BorderStyle = BorderStyle.None;
            this.Controls.Add(cardsPanel);
        }

        // Загрузка списка материалов
        private void LoadMaterials()
        {
            try
            {
                connection.Open();

                // Загружаем данные для отображения (с JOIN с таблицей Suppliers)
                string displayQuery = @"SELECT
                    m.MaterialID AS ID,
                    m.Name AS 'Название',
                    m.Unit AS 'ЕдИзмерения',
                    m.StockQuantity AS 'КоличествоНаСкладе',
                    m.CostPrice AS 'ЦенаЗаЕдиницу',
                    s.Name AS 'Поставщик',
                    s.ContactPerson AS 'КонтактноеЛицо',
                    s.Phone AS 'ТелефонПоставщика',
                    s.Email AS 'EmailПоставщика'
                FROM Materials m
                LEFT JOIN Supplies s ON m.SupplierID = s.SupplierID
                ORDER BY m.Name";

                SqlDataAdapter displayAdapter = new SqlDataAdapter(displayQuery, connection);
                displayTable = new DataTable();
                displayAdapter.Fill(displayTable);

                // Очищаем панель карточек
                cardsPanel.Controls.Clear();

                // Создаем карточки для каждого материала
                foreach (DataRow row in displayTable.Rows)
                {
                    CreateMaterialCard(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void CreateMaterialCard(DataRow row)
        {
            try
            {
                // Создаем панель для карточки
                Panel cardPanel = new Panel();
                cardPanel.Size = new Size(280, 150);
                cardPanel.BackColor = ColorTranslator.FromHtml("#ABCFCE");
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.Margin = new Padding(10);
                cardPanel.Padding = new Padding(10);
                cardPanel.Cursor = Cursors.Hand;

                // Рассчитываем статус запасов
                decimal stockQuantity = Convert.ToDecimal(row["КоличествоНаСкладе"]);
                string stockStatus = "В наличии";
                Color statusColor = ColorTranslator.FromHtml("#546F94"); 

                if (stockQuantity < 10)
                {
                    stockStatus = "Мало";
                    statusColor = ColorTranslator.FromHtml("#546F94");
                }
                else if (stockQuantity < 50)
                {
                    stockStatus = "Средне";
                    statusColor = ColorTranslator.FromHtml("#546F94");
                }

                // Создаем элементы карточки
                Label nameLabel = new Label();
                nameLabel.Text = row["Название"].ToString();
                nameLabel.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
                nameLabel.Location = new Point(10, 10);
                nameLabel.Size = new Size(240, 25);
                nameLabel.ForeColor = Color.Black;

                Label supplierLabel = new Label();
                supplierLabel.Text = $"Поставщик: {row["Поставщик"]}";
                supplierLabel.Font = new Font("Comic Sans MS", 9);
                supplierLabel.Location = new Point(10, 40);
                supplierLabel.Size = new Size(240, 20);
                supplierLabel.ForeColor = ColorTranslator.FromHtml("#546F94");

                Label stockLabel = new Label();
                stockLabel.Text = $"На складе: {stockQuantity} {row["ЕдИзмерения"]}";
                stockLabel.Font = new Font("Comic Sans MS", 9);
                stockLabel.Location = new Point(10, 65);
                stockLabel.Size = new Size(120, 20);
                stockLabel.ForeColor = Color.Black;

                Label statusLabel = new Label();
                statusLabel.Text = $"Статус: {stockStatus}";
                statusLabel.Font = new Font("Comic Sans MS", 9);
                statusLabel.Location = new Point(120, 65);
                statusLabel.Size = new Size(130, 20);
                statusLabel.ForeColor = Color.Black;
                statusLabel.BackColor = statusColor;
                statusLabel.TextAlign = ContentAlignment.MiddleCenter;
                statusLabel.BorderStyle = BorderStyle.FixedSingle;

                Label priceLabel = new Label();
                priceLabel.Text = $"Цена: {Convert.ToDecimal(row["ЦенаЗаЕдиницу"]):N2} ₽";
                priceLabel.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);
                priceLabel.Location = new Point(10, 90);
                priceLabel.Size = new Size(240, 20);
                priceLabel.ForeColor = ColorTranslator.FromHtml("#546F94");

                Label unitLabel = new Label();
                unitLabel.Text = $"Ед. изм.: {row["ЕдИзмерения"]}";
                unitLabel.Font = new Font("Comic Sans MS", 8);
                unitLabel.Location = new Point(10, 115);
                unitLabel.Size = new Size(100, 15);
                unitLabel.ForeColor = Color.Gray;

                Label idLabel = new Label();
                idLabel.Text = $"ID: {row["ID"]}";
                idLabel.Font = new Font("Comic Sans MS", 8);
                idLabel.Location = new Point(150, 115);
                idLabel.Size = new Size(100, 15);
                idLabel.ForeColor = Color.Gray;
                idLabel.TextAlign = ContentAlignment.MiddleRight;

                // Добавляем элементы на карточку
                cardPanel.Controls.Add(nameLabel);
                cardPanel.Controls.Add(supplierLabel);
                cardPanel.Controls.Add(stockLabel);
                cardPanel.Controls.Add(statusLabel);
                cardPanel.Controls.Add(priceLabel);
                cardPanel.Controls.Add(unitLabel);
                cardPanel.Controls.Add(idLabel);

                // Добавляем обработчик клика
                cardPanel.Click += (sender, e) =>
                {
                    ShowMaterialDetails(row);
                };

                // Добавляем обработчики клика для всех дочерних элементов
                foreach (Control control in cardPanel.Controls)
                {
                    control.Click += (s, e) =>
                    {
                        ShowMaterialDetails(row);
                    };
                    control.Cursor = Cursors.Hand;
                }

                // Добавляем карточку на панель
                cardsPanel.Controls.Add(cardPanel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания карточки: {ex.Message}");
            }
        }
        private void ShowMaterialDetails(DataRow row)
        {
            try
            {
                int materialId = Convert.ToInt32(row["ID"]);

                // Загружаем дополнительную информацию о поставщике
                string supplierInfo = "";
                if (row["КонтактноеЛицо"] != DBNull.Value)
                    supplierInfo += $"Контактное лицо: {row["КонтактноеЛицо"]}\n";
                if (row["ТелефонПоставщика"] != DBNull.Value)
                    supplierInfo += $"Телефон: {row["ТелефонПоставщика"]}\n";
                if (row["EmailПоставщика"] != DBNull.Value)
                    supplierInfo += $"Email: {row["EmailПоставщика"]}\n";

                // Формируем детальную информацию
                string details = $"ДЕТАЛЬНАЯ ИНФОРМАЦИЯ О МАТЕРИАЛЕ:\n\n" +
                    $"ID: {materialId}\n" +
                    $"Название: {row["Название"]}\n" +
                    $"Ед. измерения: {row["ЕдИзмерения"]}\n" +
                    $"На складе: {row["КоличествоНаСкладе"]} {row["ЕдИзмерения"]}\n" +
                    $"Цена за единицу: {Convert.ToDecimal(row["ЦенаЗаЕдиницу"]):N2} ₽\n" +
                    $"Поставщик: {row["Поставщик"]}\n" +
                    $"\nИНФОРМАЦИЯ О ПОСТАВЩИКЕ:\n{supplierInfo}";

                MessageBox.Show(details, "Детали материала",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при показе деталей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            // Возвращаемся на главную форму
            Form1.ReturnToMainForm(this);
        }
    }
}
