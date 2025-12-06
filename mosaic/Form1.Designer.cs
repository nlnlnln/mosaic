namespace mosaic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnMaterials = new System.Windows.Forms.Button();
            this.btnBatchCalc = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnProductionCalc = new System.Windows.Forms.Button();
            this.btnAllSuppliers = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaterials
            // 
            this.btnMaterials.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterials.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMaterials.ForeColor = System.Drawing.Color.White;
            this.btnMaterials.Location = new System.Drawing.Point(3, 159);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(246, 44);
            this.btnMaterials.TabIndex = 0;
            this.btnMaterials.Text = "Учет материалов";
            this.btnMaterials.UseVisualStyleBackColor = false;
            this.btnMaterials.Click += new System.EventHandler(this.btnMaterials_Click);
            // 
            // btnBatchCalc
            // 
            this.btnBatchCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnBatchCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchCalc.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBatchCalc.ForeColor = System.Drawing.Color.White;
            this.btnBatchCalc.Location = new System.Drawing.Point(4, 107);
            this.btnBatchCalc.Name = "btnBatchCalc";
            this.btnBatchCalc.Size = new System.Drawing.Size(246, 46);
            this.btnBatchCalc.TabIndex = 1;
            this.btnBatchCalc.Text = "Расчет стоимости партий";
            this.btnBatchCalc.UseVisualStyleBackColor = false;
            this.btnBatchCalc.Click += new System.EventHandler(this.btnBatchCalc_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(408, 41);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Информационная система";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.labelSubtitle.Location = new System.Drawing.Point(12, 50);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(169, 41);
            this.labelSubtitle.TabIndex = 3;
            this.labelSubtitle.Text = "\"Мозаика\"";
            this.labelSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(335, 259);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(220, 96);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnOrders);
            this.panelButtons.Controls.Add(this.btnProductionCalc);
            this.panelButtons.Controls.Add(this.btnAllSuppliers);
            this.panelButtons.Controls.Add(this.btnMaterials);
            this.panelButtons.Controls.Add(this.btnBatchCalc);
            this.panelButtons.Font = new System.Drawing.Font("Comic Sans MS", 1.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelButtons.Location = new System.Drawing.Point(12, 94);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(255, 261);
            this.panelButtons.TabIndex = 6;
            // 
            // btnProductionCalc
            // 
            this.btnProductionCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnProductionCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductionCalc.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProductionCalc.ForeColor = System.Drawing.Color.White;
            this.btnProductionCalc.Location = new System.Drawing.Point(3, 55);
            this.btnProductionCalc.Name = "btnProductionCalc";
            this.btnProductionCalc.Size = new System.Drawing.Size(246, 46);
            this.btnProductionCalc.TabIndex = 7;
            this.btnProductionCalc.Text = "Расчет продукции";
            this.btnProductionCalc.UseVisualStyleBackColor = false;
            this.btnProductionCalc.Click += new System.EventHandler(this.btnProductionCalc_Click);
            // 
            // btnAllSuppliers
            // 
            this.btnAllSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnAllSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllSuppliers.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnAllSuppliers.Location = new System.Drawing.Point(3, 3);
            this.btnAllSuppliers.Name = "btnAllSuppliers";
            this.btnAllSuppliers.Size = new System.Drawing.Size(246, 46);
            this.btnAllSuppliers.TabIndex = 6;
            this.btnAllSuppliers.Text = "Все поставщики";
            this.btnAllSuppliers.UseVisualStyleBackColor = false;
            this.btnAllSuppliers.Click += new System.EventHandler(this.btnAllSuppliers_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.Location = new System.Drawing.Point(4, 209);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(246, 44);
            this.btnOrders.TabIndex = 8;
            this.btnOrders.Text = "Заказы и управление";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 367);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Button btnBatchCalc;
        private System.Windows.Forms.Button btnProductionCalc;
        private System.Windows.Forms.Button btnAllSuppliers;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Button btnOrders;
    }
}

