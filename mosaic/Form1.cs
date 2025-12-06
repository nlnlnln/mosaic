using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mosaic
{
    public partial class Form1 : Form
    {
        public Form1()
        {            InitializeComponent();            

            ApplyStyle();
            // Добавляем логотип (заглушка - нужно заменить на реальное изображение)
            if (pictureBoxLogo.Image == null)
            {
                pictureBoxLogo.BackColor = ColorTranslator.FromHtml("#ABCFCE"); // Дополнительный фон
                pictureBoxLogo.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void ApplyStyle()
        {
            // Устанавливаем стиль согласно руководству
            this.BackColor = Color.White; // Основной фон
            this.Font = new Font("Comic Sans MS", 9);
            this.Text = "ИС Мозаика - Главное меню";


        }
        private void btnMaterials_Click(object sender, EventArgs e)
        {
            // Открываем форму учета материалов
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide(); // Скрываем главную форму
        }

        private void btnBatchCalc_Click(object sender, EventArgs e)
        {
            // Открываем форму расчета партий
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide(); // Скрываем главную форму
        }

        private void btnAllSuppliers_Click(object sender, EventArgs e)
        {
            // Открываем форму всех поставщиков
            Form4 suppliersForm = new Form4();
            suppliersForm.Show();
            this.Hide();
        }

        private void btnProductionCalc_Click(object sender, EventArgs e)
        {
            // Открываем форму расчета продукции (Модуль 4)
            Form5 productionForm = new Form5();
            productionForm.Show();
            this.Hide();
        }
        // Метод для возврата на главную форму (будет вызываться из других форм)
        public static void ReturnToMainForm(Form currentForm)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            currentForm.Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Form6 productionForm = new Form6();
            productionForm.Show();
            this.Hide();
        }
    }
}
