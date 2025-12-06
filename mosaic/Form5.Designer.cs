namespace mosaic
{
    partial class Form5
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboProduct = new System.Windows.Forms.ComboBox();
            this.numericRawAmount = new System.Windows.Forms.NumericUpDown();
            this.numericParam1 = new System.Windows.Forms.NumericUpDown();
            this.numericParam2 = new System.Windows.Forms.NumericUpDown();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panelResult = new System.Windows.Forms.Panel();
            this.comboMaterial = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericRawAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.labelTitle.Location = new System.Drawing.Point(15, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(429, 41);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Расчет продукции из сырья";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Продукт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Материал:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Количество сырья:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Длина (м):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ширина (м):";
            // 
            // comboProduct
            // 
            this.comboProduct.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.comboProduct.FormattingEnabled = true;
            this.comboProduct.Location = new System.Drawing.Point(229, 20);
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(262, 28);
            this.comboProduct.TabIndex = 6;
            // 
            // numericRawAmount
            // 
            this.numericRawAmount.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.numericRawAmount.Location = new System.Drawing.Point(229, 120);
            this.numericRawAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericRawAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRawAmount.Name = "numericRawAmount";
            this.numericRawAmount.Size = new System.Drawing.Size(262, 28);
            this.numericRawAmount.TabIndex = 8;
            this.numericRawAmount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericRawAmount.ValueChanged += new System.EventHandler(this.numericRawAmount_ValueChanged);
            // 
            // numericParam1
            // 
            this.numericParam1.DecimalPlaces = 2;
            this.numericParam1.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.numericParam1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericParam1.Location = new System.Drawing.Point(229, 170);
            this.numericParam1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericParam1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericParam1.Name = "numericParam1";
            this.numericParam1.Size = new System.Drawing.Size(262, 28);
            this.numericParam1.TabIndex = 9;
            this.numericParam1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericParam2
            // 
            this.numericParam2.DecimalPlaces = 2;
            this.numericParam2.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.numericParam2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericParam2.Location = new System.Drawing.Point(229, 221);
            this.numericParam2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericParam2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericParam2.Name = "numericParam2";
            this.numericParam2.Size = new System.Drawing.Size(262, 28);
            this.numericParam2.TabIndex = 10;
            this.numericParam2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(229, 270);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(117, 40);
            this.btnCalculate.TabIndex = 11;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnClear.Location = new System.Drawing.Point(374, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 40);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(111)))), ((int)(((byte)(148)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(940, 436);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 40);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblResult.Location = new System.Drawing.Point(20, 20);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(10);
            this.lblResult.Size = new System.Drawing.Size(500, 150);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "Результат появится здесь после расчета";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.txtDetails.Location = new System.Drawing.Point(20, 190);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(500, 120);
            this.txtDetails.TabIndex = 16;
            this.txtDetails.Text = "Детали расчета появятся здесь...";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(206)))));
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(1036, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(84, 39);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 17;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.comboMaterial);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.label5);
            this.panelInput.Controls.Add(this.comboProduct);
            this.panelInput.Controls.Add(this.numericRawAmount);
            this.panelInput.Controls.Add(this.numericParam1);
            this.panelInput.Controls.Add(this.numericParam2);
            this.panelInput.Controls.Add(this.btnCalculate);
            this.panelInput.Controls.Add(this.btnClear);
            this.panelInput.Location = new System.Drawing.Point(20, 80);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(540, 330);
            this.panelInput.TabIndex = 18;
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.Color.White;
            this.panelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResult.Controls.Add(this.lblResult);
            this.panelResult.Controls.Add(this.txtDetails);
            this.panelResult.Location = new System.Drawing.Point(580, 80);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(540, 330);
            this.panelResult.TabIndex = 19;
            // 
            // comboMaterial
            // 
            this.comboMaterial.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.comboMaterial.FormattingEnabled = true;
            this.comboMaterial.Location = new System.Drawing.Point(229, 67);
            this.comboMaterial.Name = "comboMaterial";
            this.comboMaterial.Size = new System.Drawing.Size(262, 28);
            this.comboMaterial.TabIndex = 14;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1144, 498);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.Name = "Form5";
            this.Text = "Расчет продукции";
            ((System.ComponentModel.ISupportInitialize)(this.numericRawAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboProduct;
        private System.Windows.Forms.NumericUpDown numericRawAmount;
        private System.Windows.Forms.NumericUpDown numericParam1;
        private System.Windows.Forms.NumericUpDown numericParam2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.ComboBox comboMaterial;
    }
}