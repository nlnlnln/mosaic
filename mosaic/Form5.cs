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
    public partial class Form5 : Form
    {
        private SqlConnection connection;

        public Form5()
        {
            InitializeComponent();

            // Подключение к БД
            connection = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=kikh;Integrated Security=True;");

            // Загрузка данных при запуске формы
             LoadProducts();
            LoadMaterials();
            ApplyStyle();

            // Автоматически заполняем тестовыми данными
        }
        private void ApplyStyle()
        {
            // Стиль согласно руководству
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);
            this.Text = "ИС Мозаика - Расчет производства";

            // Начальный цвет текста результата
            lblResult.ForeColor = Color.Black;
            txtDetails.ForeColor = Color.Black;
        }
        private void LoadProducts()
        {
            try
            {
                connection.Open();
                string query = "SELECT ProductID, Name FROM Products ORDER BY Name";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                comboProduct.Items.Clear();
                comboProduct.Items.Add("-- Выберите продукт --");

                while (reader.Read())
                {
                    comboProduct.Items.Add(new ComboBoxItemForm5(
                        Convert.ToInt32(reader["ProductID"]),
                        reader["Name"].ToString()
                    ));
                }
                comboProduct.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продуктов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        // Загрузка материалов в комбобокс
        private void LoadMaterials()
        {
            try
            {
                connection.Open();
                string query = @"SELECT m.MaterialID, m.Name, s.Name as SupplierName 
                               FROM Materials m
                               LEFT JOIN Supplies s ON m.SupplierID = s.SupplierID
                               ORDER BY m.Name";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                comboMaterial.Items.Clear();
                comboMaterial.Items.Add("-- Выберите материал --");

                while (reader.Read())
                {
                    string materialName = reader["Name"].ToString();
                    string supplierName = reader["SupplierName"] != DBNull.Value ? reader["SupplierName"].ToString() : "Нет поставщика";

                    comboMaterial.Items.Add(new ComboBoxItemForm5(
                        Convert.ToInt32(reader["MaterialID"]),
                        $"{materialName} (Поставщик: {supplierName})"
                    ));
                }
                comboMaterial.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки материалов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация ввода
                if (!ValidateInput())
                    return;

                // Получение данных из формы
                int productId = ((ComboBoxItemForm5)comboProduct.SelectedItem).Id;
                int materialId = ((ComboBoxItemForm5)comboMaterial.SelectedItem).Id;
                decimal rawMaterialAmount = numericRawAmount.Value;

                // Параметры (предполагается, что это размеры в см)
                decimal length = numericParam1.Value;  // Длина в см
                decimal width = numericParam2.Value;   // Ширина в см

                // Выполняем расчет
                CalculateProduction(productId, materialId, rawMaterialAmount, length, width);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Основной метод расчета
        private void CalculateProduction(int productId, int materialId, decimal rawMaterialAmount,
                                        decimal length, decimal width)
        {
            try
            {
                connection.Open();

                // 1. Получаем информацию о продукте
                string productQuery = "SELECT Price, Weight FROM Products WHERE ProductID = @id";
                SqlCommand productCmd = new SqlCommand(productQuery, connection);
                productCmd.Parameters.AddWithValue("@id", productId);
                SqlDataReader productReader = productCmd.ExecuteReader();

                if (!productReader.Read())
                {
                    ShowError("Продукт не найден в базе данных!");
                    return;
                }

                decimal productPrice = productReader["Price"] != DBNull.Value ?
                    Convert.ToDecimal(productReader["Price"]) : 0;
                decimal productWeight = productReader["Weight"] != DBNull.Value ?
                    Convert.ToDecimal(productReader["Weight"]) : 0;
                productReader.Close();

                // 2. Получаем информацию о материале
                string materialQuery = "SELECT CostPrice, Unit, StockQuantity FROM Materials WHERE MaterialID = @id";
                SqlCommand materialCmd = new SqlCommand(materialQuery, connection);
                materialCmd.Parameters.AddWithValue("@id", materialId);
                SqlDataReader materialReader = materialCmd.ExecuteReader();

                if (!materialReader.Read())
                {
                    ShowError("Материал не найден в базе данных!");
                    return;
                }

                decimal materialCost = materialReader["CostPrice"] != DBNull.Value ?
                    Convert.ToDecimal(materialReader["CostPrice"]) : 0;
                string materialUnit = materialReader["Unit"] != DBNull.Value ?
                    materialReader["Unit"].ToString() : "ед.";
                decimal materialStock = materialReader["StockQuantity"] != DBNull.Value ?
                    Convert.ToDecimal(materialReader["StockQuantity"]) : 0;
                materialReader.Close();

                // 3. Расчет
                // Площадь продукта (в см²)
                decimal area = length * width; // см²

                // Предполагаем коэффициент использования материала (0.8 = 80% эффективность)
                decimal efficiencyCoefficient = 0.8m;

                // Материал на один продукт (упрощенный расчет)
                decimal materialPerProduct = (area / 100) * efficiencyCoefficient; // в условных единицах

                // Сколько продуктов можно произвести из доступного сырья
                decimal possibleProducts = rawMaterialAmount / materialPerProduct;
                int productCount = (int)Math.Floor(possibleProducts);

                // 4. Финансовые расчеты
                decimal totalProductValue = productCount * productPrice;
                decimal materialCostTotal = productCount * materialPerProduct * materialCost;
                decimal profit = totalProductValue - materialCostTotal;

                // 5. Проверка запасов
                bool sufficientStock = materialStock >= (productCount * materialPerProduct);
                string stockStatus = sufficientStock ? "✓ Достаточно" : "⚠ Недостаточно";

                // 6. Отображение результата
                string result = $"РЕЗУЛЬТАТ РАСЧЕТА:\n\n" +
                              $"• Продукт: {comboProduct.SelectedItem}\n" +
                              $"• Материал: {comboMaterial.SelectedItem}\n" +
                              $"• Количество сырья: {rawMaterialAmount} {materialUnit}\n" +
                              $"• Размер: {length} × {width} см\n" +
                              $"• Площадь: {area:F2} см²\n\n" +
                              $"МОЖНО ПРОИЗВЕСТИ: {productCount} ЕДИНИЦ\n\n" +
                              $"ФИНАНСОВЫЙ РАСЧЕТ:\n" +
                              $"• Стоимость продукции: {totalProductValue:N2} ₽\n" +
                              $"• Стоимость материалов: {materialCostTotal:N2} ₽\n" +
                              $"• Прибыль: {profit:N2} ₽\n" +
                              $"• Запасы: {stockStatus}";

                lblResult.Text = result;
                lblResult.ForeColor = Color.Black;
                lblResult.BackColor = ColorTranslator.FromHtml("#ABCFCE");

                // 7. Детали расчета
                string details = $"ДЕТАЛИ РАСЧЕТА:\n\n" +
                               $"1. Параметры продукта:\n" +
                               $"   • Цена: {productPrice:N2} ₽/шт.\n" +
                               $"   • Вес: {productWeight:F2} кг\n\n" +
                               $"2. Параметры материала:\n" +
                               $"   • Цена: {materialCost:N2} ₽/{materialUnit}\n" +
                               $"   • На складе: {materialStock} {materialUnit}\n\n" +
                               $"3. Расчет производства:\n" +
                               $"   • Площадь: {length} × {width} = {area:F2} см²\n" +
                               $"   • Материал на 1 шт.: {materialPerProduct:F2} {materialUnit}\n" +
                               $"   • КПД использования: {efficiencyCoefficient * 100}%\n" +
                               $"   • Сырье доступно: {rawMaterialAmount} {materialUnit}\n" +
                               $"   • Возможно продуктов: {rawMaterialAmount} ÷ {materialPerProduct:F2} = {possibleProducts:F1}\n" +
                               $"   • Округлено: {productCount} шт.\n\n" +
                               $"4. Проверка запасов:\n" +
                               $"   • Требуется: {productCount * materialPerProduct:F2} {materialUnit}\n" +
                               $"   • В наличии: {materialStock} {materialUnit}\n" +
                               $"   • Статус: {stockStatus}";

                txtDetails.Text = details;

                if (!sufficientStock)
                {
                    lblResult.ForeColor = Color.DarkRed;
                    MessageBox.Show($"Внимание! Недостаточно материала на складе.\n" +
                                  $"Требуется: {productCount * materialPerProduct:F2} {materialUnit}\n" +
                                  $"В наличии: {materialStock} {materialUnit}",
                                  "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при расчете: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void ShowError(string message)
        {
            lblResult.Text = message;
            lblResult.ForeColor = Color.Red;
            lblResult.BackColor = Color.FromArgb(255, 230, 230);
            txtDetails.Text = "Ошибка при расчете. Проверьте введенные данные.";
        }
        private bool ValidateInput()
        {
            // Проверка выбора продукта
            if (comboProduct.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите продукт!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboProduct.Focus();
                return false;
            }

            // Проверка выбора материала
            if (comboMaterial.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите материал!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaterial.Focus();
                return false;
            }

            // Проверка количества сырья
            if (numericRawAmount.Value <= 0)
            {
                MessageBox.Show("Количество сырья должно быть больше 0!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericRawAmount.Focus();
                return false;
            }

            // Проверка параметров
            if (numericParam1.Value <= 0 || numericParam2.Value <= 0)
            {
                MessageBox.Show("Параметры должны быть больше 0!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericParam1.Focus();
                return false;
            }

            return true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1.ReturnToMainForm(this);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboProduct.SelectedIndex = 0;
            comboMaterial.SelectedIndex = 0;
            numericRawAmount.Value = 100;
            numericParam1.Value = 10m;  // 10 см
            numericParam2.Value = 10m;  // 10 см
            lblResult.Text = "Результат появится здесь после расчета";
            lblResult.ForeColor = Color.Black;
            lblResult.BackColor = ColorTranslator.FromHtml("#ABCFCE");
            txtDetails.Text = "Детали расчета появятся здесь...";
            txtDetails.ForeColor = Color.Black;
        }

        public class ComboBoxItemForm5
        {
            public int Id { get; set; }
            public string Text { get; set; }

            public ComboBoxItemForm5(int id, string text)
            {
                Id = id;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void numericRawAmount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
