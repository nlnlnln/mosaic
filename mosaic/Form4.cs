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
    public partial class Form4 : Form
    {
        private SqlConnection connection;
        private int selectedMaterialId;
        private string selectedMaterialName;

        public Form4(int materialId, SqlConnection connection)
        {
            InitializeComponent();

            // Связываем событие загрузки формы
            this.Load += Form4_Load;

            this.selectedMaterialId = materialId;
            this.connection = connection; // Сохраняем переданное соединение

            // Загружаем название материала
            LoadMaterialName();
            ApplyStyle();
        }

        public Form4()
        {
            InitializeComponent();
            // Создаем соединение
            connection = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=kikh;Integrated Security=True;");
            selectedMaterialId = 0; // Показываем всех поставщиков
            selectedMaterialName = "";

            // Загружаем данные при загрузке формы
            this.Load += Form4_Load;
            ApplyStyle();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Загружаем поставщиков при загрузке формы
            LoadSuppliers();
        }

        private void LoadMaterialName()
        {
            try
            {
                if (selectedMaterialId > 0 && connection != null)
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    string query = "SELECT Name FROM Materials WHERE MaterialID = @id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", selectedMaterialId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        selectedMaterialName = result.ToString();
                    }

                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки названия материала: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyStyle()
        {
            // Стиль согласно руководству
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);

            if (!string.IsNullOrEmpty(selectedMaterialName))
            {
                this.Text = $"ИС Мозаика - Поставщики материала: {selectedMaterialName}";
                labelTitle.Text = $"ПОСТАВЩИКИ МАТЕРИАЛА: {selectedMaterialName}";
            }
            else
            {
                this.Text = "ИС Мозаика - Все поставщики";
                labelTitle.Text = "ВСЕ ПОСТАВЩИКИ КОМПАНИИ";
            }
        }

        private void LoadSuppliers()
        {
            // Проверяем соединение
            if (connection == null)
            {
                MessageBox.Show("Соединение с базой данных не установлено!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Проверяем, открыто ли соединение
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query;
                if (selectedMaterialId > 0)
                {
                    // Поставщики для конкретного материала
                    query = @"
                        SELECT DISTINCT 
                            s.SupplierID AS 'ID',
                            s.Name AS 'Название компании',
                            s.ContactPerson AS 'Контактное лицо',
                            s.Phone AS 'Телефон',
                            s.Email AS 'Email'
                        FROM Supplies s
                        INNER JOIN Materials m ON s.SupplierID = m.SupplierID
                        WHERE m.MaterialID = @materialId
                        ORDER BY s.Name";
                }
                else
                {
                    // Все поставщики
                    query = @"
                        SELECT 
                            SupplierID AS 'ID',
                            Name AS 'Название компании',
                            ContactPerson AS 'Контактное лицо',
                            Phone AS 'Телефон',
                            Email AS 'Email'
                        FROM Supplies
                        ORDER BY Name";
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    if (selectedMaterialId > 0)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@materialId", selectedMaterialId);
                    }

                    DataTable suppliersTable = new DataTable();
                    adapter.Fill(suppliersTable);

                    // Устанавливаем источник данных для DataGridView
                    dataGridViewSuppliers.DataSource = suppliersTable;

                    // Настройка внешнего вида DataGridView
                    dataGridViewSuppliers.AutoGenerateColumns = true;
                    dataGridViewSuppliers.AllowUserToAddRows = false;
                    dataGridViewSuppliers.AllowUserToDeleteRows = false;
                    dataGridViewSuppliers.ReadOnly = true;
                    dataGridViewSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Обновляем отображение
                    dataGridViewSuppliers.Refresh();

                    // Если нет данных, показываем сообщение
                    if (suppliersTable.Rows.Count == 0)
                    {
                        if (selectedMaterialId > 0)
                        {
                            MessageBox.Show($"Для выбранного материала нет поставщиков!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"В базе данных нет поставщиков!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Возвращаемся к форме материалов
            Form2 materialsForm = new Form2();
            materialsForm.Show();
            this.Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }
    }
}