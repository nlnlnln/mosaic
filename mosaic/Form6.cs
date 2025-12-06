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
    public partial class Form6 : Form
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS01;Database=kikh;Integrated Security=True;";
        private SqlConnection connection;
        private DataTable ordersTable;
        private DataTable orderDetailsTable;
        private SqlDataAdapter ordersAdapter;
        private SqlDataAdapter orderDetailsAdapter;
        private int currentOrderId = 0;

        // Класс для элементов ComboBox
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

        public Form6()
        {
            InitializeComponent();
            InitializeConnection();
            ApplyStyle();
            InitializeDataGridViews();
            LoadAllData();
        }

        private void InitializeConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        private void InitializeDataGridViews()
        {
            // Настройка DataGridView для заказов
            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.Columns.Clear();
            dataGridViewOrders.Columns.Add("OrderID", "ID");
            dataGridViewOrders.Columns.Add("OrderDate", "Дата");
            dataGridViewOrders.Columns.Add("Status", "Статус");
            dataGridViewOrders.Columns.Add("TotalAmount", "Сумма");
            dataGridViewOrders.Columns.Add("PartnerName", "Партнер");
            dataGridViewOrders.Columns.Add("EmployeeName", "Сотрудник");

            // Настройка DataGridView для деталей заказа
            dataGridViewOrderDetails.AutoGenerateColumns = false;
            dataGridViewOrderDetails.Columns.Clear();
            dataGridViewOrderDetails.Columns.Add("OrderDetailID", "ID детали");
            dataGridViewOrderDetails.Columns.Add("ProductName", "Товар");
            dataGridViewOrderDetails.Columns.Add("Quantity", "Количество");
            dataGridViewOrderDetails.Columns.Add("UnitPrice", "Цена за ед.");
            dataGridViewOrderDetails.Columns.Add("TotalPrice", "Общая цена");
        }

        private void ApplyStyle()
        {
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);
            this.Text = "ИС Мозаика - Управление заказами";

            // Настройка DataGridView
            dataGridViewOrders.BackgroundColor = Color.White;
            dataGridViewOrders.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersVisible = false;

            dataGridViewOrderDetails.BackgroundColor = Color.White;
            dataGridViewOrderDetails.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrderDetails.AllowUserToAddRows = false;
            dataGridViewOrderDetails.ReadOnly = true;
            dataGridViewOrderDetails.RowHeadersVisible = false;

            // Настройка панелей
            panelLeft.BackColor = ColorTranslator.FromHtml("#ABCFCE");
            panelRight.BackColor = ColorTranslator.FromHtml("#ABCFCE");
            panelDetails.BackColor = ColorTranslator.FromHtml("#ABCFCE");

            // Настройка кнопок
            StyleButtons();
        }

        private void StyleButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    StyleButton(button);
                }
            }

            foreach (Control control in panelDetails.Controls)
            {
                if (control is Button button)
                {
                    StyleButton(button);
                }
            }
        }

        private void StyleButton(Button button)
        {
            button.BackColor = ColorTranslator.FromHtml("#546F94");
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void LoadAllData()
        {
            try
            {
                LoadPartners();
                LoadEmployees();
                LoadProducts();
                LoadOrders();
                ClearOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPartners()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT PartnerID, Name FROM Partners ORDER BY Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBoxPartner.Items.Clear();
                    comboBoxPartner.Items.Add(new ComboBoxItem(0, "-- Выберите партнера --"));

                    while (reader.Read())
                    {
                        comboBoxPartner.Items.Add(new ComboBoxItem(
                            Convert.ToInt32(reader["PartnerID"]),
                            reader["Name"].ToString()
                        ));
                    }
                    comboBoxPartner.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки партнеров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, FirstName, LastName FROM Employees ORDER BY LastName, FirstName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBoxEmployee.Items.Clear();
                    comboBoxEmployee.Items.Add(new ComboBoxItem(0, "-- Выберите сотрудника --"));

                    while (reader.Read())
                    {
                        string fullName = $"{reader["LastName"]} {reader["FirstName"]}";
                        comboBoxEmployee.Items.Add(new ComboBoxItem(
                            Convert.ToInt32(reader["EmployeeID"]),
                            fullName
                        ));
                    }
                    comboBoxEmployee.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductID, Name, Price FROM Products ORDER BY Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBoxProduct.Items.Clear();
                    comboBoxProduct.Items.Add(new ComboBoxItem(0, "-- Выберите товар --"));

                    while (reader.Read())
                    {
                        string productInfo = $"{reader["Name"]} ({Convert.ToDecimal(reader["Price"]):N2} ₽)";
                        comboBoxProduct.Items.Add(new ComboBoxItem(
                            Convert.ToInt32(reader["ProductID"]),
                            productInfo
                        ));
                    }
                    comboBoxProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            o.OrderID,
                            CONVERT(varchar, o.OrderDate, 104) as OrderDate,
                            o.Status,
                            o.TotalAmount,
                            ISNULL(p.Name, 'Не указан') AS PartnerName,
                            ISNULL(e.LastName + ' ' + e.FirstName, 'Не указан') AS EmployeeName
                        FROM Orders o
                        LEFT JOIN Partners p ON o.PartnerID = p.PartnerID
                        LEFT JOIN Employees e ON o.EmployeeID = e.EmployeeID
                        ORDER BY o.OrderDate DESC";

                    ordersAdapter = new SqlDataAdapter(query, conn);
                    ordersTable = new DataTable();
                    ordersAdapter.Fill(ordersTable);

                    dataGridViewOrders.Rows.Clear();
                    foreach (DataRow row in ordersTable.Rows)
                    {
                        dataGridViewOrders.Rows.Add(
                            row["OrderID"],
                            row["OrderDate"],
                            row["Status"],
                            $"{Convert.ToDecimal(row["TotalAmount"]):N2} ₽",
                            row["PartnerName"],
                            row["EmployeeName"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                currentOrderId = orderId;

                if (orderId == 0)
                {
                    ClearOrderDetails();
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            od.OrderDetailID,
                            p.Name AS ProductName,
                            od.Quantity,
                            od.UnitPrice,
                            (od.Quantity * od.UnitPrice) AS TotalPrice
                        FROM OrderDetails od
                        LEFT JOIN Products p ON od.ProductID = p.ProductID
                        WHERE od.OrderID = @orderId
                        ORDER BY od.OrderDetailID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridViewOrderDetails.Rows.Clear();
                    decimal total = 0;

                    while (reader.Read())
                    {
                        decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                        total += totalPrice;

                        dataGridViewOrderDetails.Rows.Add(
                            reader["OrderDetailID"],
                            reader["ProductName"],
                            reader["Quantity"],
                            $"{Convert.ToDecimal(reader["UnitPrice"]):N2} ₽",
                            $"{totalPrice:N2} ₽"
                        );
                    }

                    lblOrderTotal.Text = $"Общая сумма: {total:N2} ₽";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearOrderDetails()
        {
            dataGridViewOrderDetails.Rows.Clear();
            lblOrderTotal.Text = "Общая сумма: 0 ₽";
            ClearOrderInfo();
        }

        private void ClearOrderInfo()
        {
            comboBoxPartner.SelectedIndex = 0;
            comboBoxEmployee.SelectedIndex = 0;
            comboBoxStatus.SelectedIndex = 0;
        }

        private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewOrders.SelectedRows[0];
                int orderId = Convert.ToInt32(selectedRow.Cells[0].Value);
                LoadOrderDetails(orderId);
                FillOrderInfo(orderId);
            }
        }

        private void FillOrderInfo(int orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PartnerID, EmployeeID, Status FROM Orders WHERE OrderID = @orderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int partnerId = reader["PartnerID"] != DBNull.Value ? Convert.ToInt32(reader["PartnerID"]) : 0;
                        int employeeId = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : 0;
                        string status = reader["Status"].ToString();

                        // Устанавливаем партнера
                        foreach (ComboBoxItem item in comboBoxPartner.Items)
                        {
                            if (item.Id == partnerId)
                            {
                                comboBoxPartner.SelectedItem = item;
                                break;
                            }
                        }

                        // Устанавливаем сотрудника
                        foreach (ComboBoxItem item in comboBoxEmployee.Items)
                        {
                            if (item.Id == employeeId)
                            {
                                comboBoxEmployee.SelectedItem = item;
                                break;
                            }
                        }

                        // Устанавливаем статус
                        comboBoxStatus.Text = status;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки информации о заказе: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация
                if (comboBoxPartner.SelectedIndex == 0 || comboBoxEmployee.SelectedIndex == 0)
                {
                    MessageBox.Show("Выберите партнера и сотрудника!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO Orders (PartnerID, EmployeeID, Status, TotalAmount, OrderDate) 
                        VALUES (@partnerId, @employeeId, @status, 0, GETDATE());
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@partnerId", ((ComboBoxItem)comboBoxPartner.SelectedItem).Id);
                    cmd.Parameters.AddWithValue("@employeeId", ((ComboBoxItem)comboBoxEmployee.SelectedItem).Id);
                    cmd.Parameters.AddWithValue("@status", comboBoxStatus.Text);

                    int newOrderId = Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show($"Заказ №{newOrderId} создан успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrders();
                    LoadOrderDetails(newOrderId);
                    SelectOrderInGrid(newOrderId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectOrderInGrid(int orderId)
        {
            foreach (DataGridViewRow row in dataGridViewOrders.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == orderId)
                {
                    row.Selected = true;
                    dataGridViewOrders.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("Выберите или создайте заказ!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxProduct.SelectedIndex == 0 || numericUpQuantity.Value <= 0)
            {
                MessageBox.Show("Выберите товар и укажите количество!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Получаем цену товара
                    int productId = ((ComboBoxItem)comboBoxProduct.SelectedItem).Id;
                    string priceQuery = "SELECT Price FROM Products WHERE ProductID = @productId";
                    SqlCommand priceCmd = new SqlCommand(priceQuery, conn);
                    priceCmd.Parameters.AddWithValue("@productId", productId);
                    decimal unitPrice = Convert.ToDecimal(priceCmd.ExecuteScalar());

                    // Добавляем деталь заказа
                    string query = @"
                        INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice) 
                        VALUES (@orderId, @productId, @quantity, @unitPrice)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", currentOrderId);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@quantity", (int)numericUpQuantity.Value);
                    cmd.Parameters.AddWithValue("@unitPrice", unitPrice);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Товар добавлен в заказ!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrderDetails(currentOrderId);
                    UpdateOrderTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderTotal()
        {
            if (currentOrderId == 0) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Рассчитываем общую сумму из деталей заказа
                    string query = @"
                        UPDATE Orders 
                        SET TotalAmount = (
                            SELECT ISNULL(SUM(Quantity * UnitPrice), 0) 
                            FROM OrderDetails 
                            WHERE OrderID = @orderId
                        )
                        WHERE OrderID = @orderId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", currentOrderId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления суммы заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("Выберите заказ для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить заказ №{currentOrderId}?\n" +
                "Все детали заказа также будут удалены!", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Сначала проверяем, нет ли связанных записей в Production
                        string checkQuery = "SELECT COUNT(*) FROM Production WHERE OrderID = @orderId";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@orderId", currentOrderId);
                        int productionCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (productionCount > 0)
                        {
                            MessageBox.Show($"Невозможно удалить заказ №{currentOrderId}!\n" +
                                "Заказ уже используется в производстве.\n" +
                                "Сначала удалите связанные записи из таблицы Production.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Сначала удаляем детали заказа
                        string deleteDetailsQuery = "DELETE FROM OrderDetails WHERE OrderID = @orderId";
                        SqlCommand detailsCmd = new SqlCommand(deleteDetailsQuery, conn);
                        detailsCmd.Parameters.AddWithValue("@orderId", currentOrderId);
                        detailsCmd.ExecuteNonQuery();

                        // Затем удаляем сам заказ
                        string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @orderId";
                        SqlCommand orderCmd = new SqlCommand(deleteOrderQuery, conn);
                        orderCmd.Parameters.AddWithValue("@orderId", currentOrderId);
                        orderCmd.ExecuteNonQuery();

                        MessageBox.Show("Заказ удален успешно!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        currentOrderId = 0;
                        LoadOrders();
                        ClearOrderDetails();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления заказа: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
            MessageBox.Show("Данные обновлены!", "Обновление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Предполагаем, что Form1 существует и имеет метод ReturnToMainForm
            Form1.ReturnToMainForm(this);
        }

        #region Обработчики событий

        private void numericUpQuantity_ValueChanged(object sender, EventArgs e)
        {
            // Обработка изменения количества
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработка выбора товара
        }

        private void comboBoxPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработка выбора партнера
        }

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработка выбора сотрудника
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработка изменения статуса
        }

        #endregion
    }
}