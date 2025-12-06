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
    public partial class Form2 : Form
    {
        private SqlConnection connection;
        private DataTable materialsTable;
        private DataTable displayTable;
        private SqlDataAdapter adapter;

        public Form2()
        {
            InitializeComponent();

            // Подключение к БД
            connection = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=kikh;Integrated Security=True;");

            // Загрузка данных при запуске формы
            LoadMaterials();
        }
        private void LoadMaterials()
        {
            try
            {
                connection.Open();

                // 1. Загружаем основную таблицу "Materials" для редактирования
                string materialsQuery = "SELECT * FROM Materials";
                adapter = new SqlDataAdapter(materialsQuery, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                materialsTable = new DataTable();
                adapter.Fill(materialsTable);

                // 2. Загружаем таблицу для отображения (с JOIN с таблицей Suppliers)
                string displayQuery = @"SELECT 
    m.MaterialID AS ID,
    m.Name AS 'Название материала',
    m.Unit AS 'Ед. изм.',
    m.StockQuantity AS 'Кол-во на складе',
    m.CostPrice AS 'Цена за ед.',
    s.Name AS 'Поставщик',
    s.ContactPerson AS 'Контактное лицо',
    s.Phone AS 'Телефон',
    s.Email AS 'Email'
FROM Materials m
LEFT JOIN Supplies s ON m.SupplierID = s.SupplierID";

                SqlDataAdapter displayAdapter = new SqlDataAdapter(displayQuery, connection);
                displayTable = new DataTable();
                displayAdapter.Fill(displayTable);
                dataGridView1.DataSource = displayTable;

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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем форму для добавления
                Form2_1 editForm = new Form2_1(0, connection);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем обе таблицы после добавления
                    RefreshData();
                    MessageBox.Show("Материал добавлен!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите материал для редактирования!", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Получаем ID выбранного материала
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int materialId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                // Открываем форму редактирования
                Form2_1 editForm = new Form2_1(materialId, connection);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем обе таблицы после редактирования
                    RefreshData();
                    MessageBox.Show("Изменения сохранены!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите материал для просмотра поставщиков!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int materialId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string materialName = selectedRow.Cells["Название материала"].Value.ToString();

                // Передаем соединение в Form4
                Form4 suppliersForm = new Form4(materialId, connection);
                suppliersForm.Show();
                this.Hide(); // Скрываем текущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Возвращаемся на главную форму
            Form1.ReturnToMainForm(this);
        }
        // Обновление данных
        private void RefreshData()
        {
            try
            {
                // Очищаем и перезагружаем таблицы
                if (materialsTable != null) materialsTable.Clear();
                if (displayTable != null) displayTable.Clear();

                connection.Open();

                // Перезагружаем основную таблицу
                adapter.Fill(materialsTable);

                // Перезагружаем таблицу для отображения (с JOIN с таблицей Suppliers)
                string displayQuery = @"SELECT 
            m.MaterialID AS ID,
            m.Name AS 'Название материала',
            m.Unit AS 'Ед. изм.',
            m.StockQuantity AS 'Кол-во на складе',
            m.CostPrice AS 'Цена за ед.',
            s.Name AS 'Поставщик',
            s.ContactPerson AS 'Контактное лицо',
            s.Phone AS 'Телефон',
            s.Email AS 'Email'
        FROM Materials m
        LEFT JOIN Supplies s ON m.SupplierID = s.SupplierID";

                SqlDataAdapter displayAdapter = new SqlDataAdapter(displayQuery, connection);
                displayAdapter.Fill(displayTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
