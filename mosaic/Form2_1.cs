using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mosaic
{
    // Класс для хранения ID и названия в комбобоксе
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ComboBoxItem(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public partial class Form2_1 : Form
    {
        private int materialId;
        private SqlConnection connection;

        public Form2_1(int materialId, SqlConnection connection)
        {
            InitializeComponent();
            this.materialId = materialId;
            this.connection = connection;
            InitializeDesign();
            LoadData();
        }

        private void InitializeDesign()
        {
            this.Text = materialId == 0 ? "Добавление материала" : "Редактирование материала";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);

            // Панель для формы
            Panel mainPanel = new Panel();
            mainPanel.Size = new Size(460, 420);
            mainPanel.Location = new Point(20, 20);
            mainPanel.BackColor = ColorTranslator.FromHtml("#ABCFCE");
            mainPanel.BorderStyle = BorderStyle.FixedSingle;

            // Элементы формы
            int yPos = 20;

            Label nameLabel = new Label { Text = "Название материала:", Location = new Point(20, yPos), Size = new Size(180, 25) };
            TextBox nameBox = new TextBox { Name = "nameBox", Location = new Point(210, yPos), Size = new Size(220, 25) };
            yPos += 35;

            Label supplierLabel = new Label { Text = "Поставщик:", Location = new Point(20, yPos), Size = new Size(180, 25) };
            ComboBox supplierCombo = new ComboBox { Name = "supplierCombo", Location = new Point(210, yPos), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            yPos += 35;

            Label unitLabel = new Label { Text = "Ед. измерения:", Location = new Point(20, yPos), Size = new Size(180, 25) };
            TextBox unitBox = new TextBox { Name = "unitBox", Location = new Point(210, yPos), Size = new Size(220, 25), Text = "кг" };
            yPos += 35;

            Label stockLabel = new Label { Text = "Кол-во на складе:", Location = new Point(20, yPos), Size = new Size(180, 25) };
            TextBox stockBox = new TextBox { Name = "stockBox", Location = new Point(210, yPos), Size = new Size(220, 25), Text = "0" };
            yPos += 35;

            Label priceLabel = new Label { Text = "Цена за ед.:", Location = new Point(20, yPos), Size = new Size(180, 25) };
            TextBox priceBox = new TextBox { Name = "priceBox", Location = new Point(210, yPos), Size = new Size(220, 25), Text = "0" };
            yPos += 50;

            Button saveBtn = new Button
            {
                Text = "Сохранить",
                Location = new Point(100, yPos),
                Size = new Size(120, 35),
                BackColor = ColorTranslator.FromHtml("#546F94"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 9, FontStyle.Bold)
            };
            saveBtn.Click += SaveBtn_Click;

            Button cancelBtn = new Button
            {
                Text = "Отмена",
                Location = new Point(240, yPos),
                Size = new Size(120, 35),
                BackColor = ColorTranslator.FromHtml("#546F94"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 9, FontStyle.Bold)
            };
            cancelBtn.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Добавляем элементы на панель
            mainPanel.Controls.Add(nameLabel);
            mainPanel.Controls.Add(nameBox);
            mainPanel.Controls.Add(supplierLabel);
            mainPanel.Controls.Add(supplierCombo);
            mainPanel.Controls.Add(unitLabel);
            mainPanel.Controls.Add(unitBox);
            mainPanel.Controls.Add(stockLabel);
            mainPanel.Controls.Add(stockBox);
            mainPanel.Controls.Add(priceLabel);
            mainPanel.Controls.Add(priceBox);
            mainPanel.Controls.Add(saveBtn);
            mainPanel.Controls.Add(cancelBtn);

            this.Controls.Add(mainPanel);
        }

        private void Form2_1_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            try
            {
                connection.Open();

                // Загружаем поставщиков (только активных поставщиков)
                string suppliersQuery = "SELECT SupplierID, Name FROM Supplies ORDER BY Name";
                SqlCommand suppliersCmd = new SqlCommand(suppliersQuery, connection);
                SqlDataReader suppliersReader = suppliersCmd.ExecuteReader();

                ComboBox supplierCombo = this.Controls.Find("supplierCombo", true)[0] as ComboBox;
                supplierCombo.Items.Clear();

                while (suppliersReader.Read())
                {
                    supplierCombo.Items.Add(new ComboBoxItem(
                        Convert.ToInt32(suppliersReader["SupplierID"]),
                        suppliersReader["Name"].ToString()
                    ));
                }
                suppliersReader.Close();

                // Если редактирование существующего материала
                if (materialId > 0)
                {
                    string query = "SELECT * FROM Materials WHERE MaterialID = @id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", materialId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        this.Controls.Find("nameBox", true)[0].Text = reader["Name"].ToString();
                        this.Controls.Find("unitBox", true)[0].Text = reader["Unit"].ToString();
                        this.Controls.Find("stockBox", true)[0].Text = reader["StockQuantity"].ToString();
                        this.Controls.Find("priceBox", true)[0].Text = reader["CostPrice"].ToString();

                        // Устанавливаем выбранного поставщика
                        int supplierId = Convert.ToInt32(reader["SupplierID"]);
                        foreach (ComboBoxItem item in supplierCombo.Items)
                        {
                            if (item.Id == supplierId)
                            {
                                supplierCombo.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    reader.Close();
                }
                else
                {
                    // По умолчанию выбираем первый элемент в комбобоксе
                    if (supplierCombo.Items.Count > 0) supplierCombo.SelectedIndex = 0;
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация данных
                if (!ValidateInput())
                    return;

                // Получаем значения из полей
                string name = this.Controls.Find("nameBox", true)[0].Text;
                string unit = this.Controls.Find("unitBox", true)[0].Text;
                decimal stock = decimal.Parse(this.Controls.Find("stockBox", true)[0].Text);
                decimal price = decimal.Parse(this.Controls.Find("priceBox", true)[0].Text);

                ComboBox supplierCombo = this.Controls.Find("supplierCombo", true)[0] as ComboBox;
                ComboBoxItem selectedSupplier = (ComboBoxItem)supplierCombo.SelectedItem;

                connection.Open();

                if (materialId == 0)
                {
                    // Добавление нового материала
                    string insertQuery = @"INSERT INTO Materials 
                        (Name, Unit, StockQuantity, CostPrice, SupplierID) 
                        VALUES (@name, @unit, @stock, @price, @supplierId)";

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@supplierId", selectedSupplier.Id);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Обновление существующего материала
                    string updateQuery = @"UPDATE Materials SET 
                        Name = @name,
                        Unit = @unit,
                        StockQuantity = @stock,
                        CostPrice = @price,
                        SupplierID = @supplierId
                        WHERE MaterialID = @id";

                    SqlCommand cmd = new SqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@supplierId", selectedSupplier.Id);
                    cmd.Parameters.AddWithValue("@id", materialId);

                    cmd.ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private bool ValidateInput()
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(this.Controls.Find("nameBox", true)[0].Text))
            {
                MessageBox.Show("Название материала обязательно для заполнения", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ComboBox supplierCombo = this.Controls.Find("supplierCombo", true)[0] as ComboBox;
            if (supplierCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставщика", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка единиц измерения
            string unit = this.Controls.Find("unitBox", true)[0].Text;
            if (string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("Единица измерения обязательна для заполнения", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка числовых полей
            if (!decimal.TryParse(this.Controls.Find("priceBox", true)[0].Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Цена должна быть положительным числом", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(this.Controls.Find("stockBox", true)[0].Text, out decimal stock) || stock < 0)
            {
                MessageBox.Show("Количество на складе должно быть положительным числом", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}