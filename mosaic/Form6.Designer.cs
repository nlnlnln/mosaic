using System;

namespace mosaic
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelDetails = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.numericUpQuantity = new System.Windows.Forms.NumericUpDown();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPartner = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpQuantity)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.panelDetails.Controls.Add(this.btnBack);
            this.panelDetails.Controls.Add(this.btnRefresh);
            this.panelDetails.Controls.Add(this.lblOrderTotal);
            this.panelDetails.Controls.Add(this.btnAddDetail);
            this.panelDetails.Controls.Add(this.numericUpQuantity);
            this.panelDetails.Controls.Add(this.comboBoxProduct);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Controls.Add(this.btnDeleteOrder);
            this.panelDetails.Controls.Add(this.btnAddOrder);
            this.panelDetails.Controls.Add(this.comboBoxStatus);
            this.panelDetails.Controls.Add(this.label3);
            this.panelDetails.Controls.Add(this.comboBoxEmployee);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.comboBoxPartner);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1200, 120);
            this.panelDetails.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1068, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(936, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 32);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Обновить всё";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.lblOrderTotal.Location = new System.Drawing.Point(727, 86);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(166, 25);
            this.lblOrderTotal.TabIndex = 14;
            this.lblOrderTotal.Text = "Общая сумма: 0 ₽";
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDetail.Location = new System.Drawing.Point(394, 52);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(88, 61);
            this.btnAddDetail.TabIndex = 13;
            this.btnAddDetail.Text = "Добавить товар";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // numericUpQuantity
            // 
            this.numericUpQuantity.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.numericUpQuantity.Location = new System.Drawing.Point(308, 83);
            this.numericUpQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpQuantity.Name = "numericUpQuantity";
            this.numericUpQuantity.Size = new System.Drawing.Size(80, 28);
            this.numericUpQuantity.TabIndex = 12;
            this.numericUpQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduct.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(140, 83);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(162, 28);
            this.comboBoxProduct.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(10, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Добавить товар:";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(936, 88);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(120, 32);
            this.btnDeleteOrder.TabIndex = 9;
            this.btnDeleteOrder.Text = "Удалить заказ";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(936, 10);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(120, 32);
            this.btnAddOrder.TabIndex = 7;
            this.btnAddOrder.Text = "Новый заказ";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Новый",
            "В обработке",
            "В производстве",
            "Завершен",
            "Отменен"});
            this.comboBoxStatus.Location = new System.Drawing.Point(591, 85);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(130, 28);
            this.comboBoxStatus.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(498, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Статус:";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployee.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(591, 52);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(130, 28);
            this.comboBoxEmployee.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(498, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сотрудник:";
            // 
            // comboBoxPartner
            // 
            this.comboBoxPartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartner.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.comboBoxPartner.FormattingEnabled = true;
            this.comboBoxPartner.Location = new System.Drawing.Point(140, 52);
            this.comboBoxPartner.Name = "comboBoxPartner";
            this.comboBoxPartner.Size = new System.Drawing.Size(248, 28);
            this.comboBoxPartner.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Партнер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "УПРАВЛЕНИЕ ЗАКАЗАМИ";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.panelLeft.Controls.Add(this.dataGridViewOrders);
            this.panelLeft.Location = new System.Drawing.Point(0, 120);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(653, 329);
            this.panelLeft.TabIndex = 1;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.RowTemplate.Height = 24;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(630, 306);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.SelectionChanged += new System.EventHandler(this.dataGridViewOrders_SelectionChanged);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.panelRight.Controls.Add(this.dataGridViewOrderDetails);
            this.panelRight.Location = new System.Drawing.Point(646, 120);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(554, 329);
            this.panelRight.TabIndex = 2;
            // 
            // dataGridViewOrderDetails
            // 
            this.dataGridViewOrderDetails.AllowUserToAddRows = false;
            this.dataGridViewOrderDetails.AllowUserToDeleteRows = false;
            this.dataGridViewOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.ReadOnly = true;
            this.dataGridViewOrderDetails.RowHeadersWidth = 51;
            this.dataGridViewOrderDetails.RowTemplate.Height = 24;
            this.dataGridViewOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(529, 303);
            this.dataGridViewOrderDetails.TabIndex = 0;
            // 
            // Form6
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 448);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelDetails);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление заказами";
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpQuantity)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPartner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.NumericUpDown numericUpQuantity;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
    }
}