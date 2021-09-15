
namespace stoma
{
    partial class NewServiceForm
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
            this.SVC_caption = new System.Windows.Forms.TextBox();
            this.SVC_Descr = new System.Windows.Forms.TextBox();
            this.SVC_Add = new System.Windows.Forms.Button();
            this.SVC_Price = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.SVC_ID = new System.Windows.Forms.TextBox();
            this.toothType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SVC_Price)).BeginInit();
            this.SuspendLayout();
            // 
            // SVC_caption
            // 
            this.SVC_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SVC_caption.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SVC_caption.Location = new System.Drawing.Point(11, 47);
            this.SVC_caption.Name = "SVC_caption";
            this.SVC_caption.Size = new System.Drawing.Size(384, 29);
            this.SVC_caption.TabIndex = 35;
            this.SVC_caption.Text = "НАИМЕНОВАНИЕ";
            // 
            // SVC_Descr
            // 
            this.SVC_Descr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SVC_Descr.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SVC_Descr.Location = new System.Drawing.Point(12, 120);
            this.SVC_Descr.Multiline = true;
            this.SVC_Descr.Name = "SVC_Descr";
            this.SVC_Descr.Size = new System.Drawing.Size(384, 141);
            this.SVC_Descr.TabIndex = 36;
            this.SVC_Descr.Text = "ОПИСАНИЕ";
            // 
            // SVC_Add
            // 
            this.SVC_Add.Location = new System.Drawing.Point(218, 278);
            this.SVC_Add.Name = "SVC_Add";
            this.SVC_Add.Size = new System.Drawing.Size(178, 23);
            this.SVC_Add.TabIndex = 38;
            this.SVC_Add.Text = "Добавить";
            this.SVC_Add.UseVisualStyleBackColor = true;
            this.SVC_Add.Click += new System.EventHandler(this.SVC_Add_Click);
            // 
            // SVC_Price
            // 
            this.SVC_Price.DecimalPlaces = 2;
            this.SVC_Price.Location = new System.Drawing.Point(12, 281);
            this.SVC_Price.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SVC_Price.Name = "SVC_Price";
            this.SVC_Price.Size = new System.Drawing.Size(178, 20);
            this.SVC_Price.TabIndex = 39;
            this.SVC_Price.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Стоимость:";
            // 
            // SVC_ID
            // 
            this.SVC_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SVC_ID.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SVC_ID.Location = new System.Drawing.Point(11, 12);
            this.SVC_ID.Name = "SVC_ID";
            this.SVC_ID.Size = new System.Drawing.Size(384, 29);
            this.SVC_ID.TabIndex = 41;
            this.SVC_ID.Text = "КОД УСЛУГИ";
            // 
            // ToothType
            // 
            this.toothType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toothType.FormattingEnabled = true;
            this.toothType.Location = new System.Drawing.Point(11, 82);
            this.toothType.Name = "ToothType";
            this.toothType.Size = new System.Drawing.Size(179, 32);
            this.toothType.TabIndex = 42;
            // 
            // NewServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 312);
            this.Controls.Add(this.toothType);
            this.Controls.Add(this.SVC_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SVC_Price);
            this.Controls.Add(this.SVC_Add);
            this.Controls.Add(this.SVC_Descr);
            this.Controls.Add(this.SVC_caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewServiceForm";
            this.Text = "Добавление Услуги";
            ((System.ComponentModel.ISupportInitialize)(this.SVC_Price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SVC_caption;
        private System.Windows.Forms.TextBox SVC_Descr;
        private System.Windows.Forms.Button SVC_Add;
        private System.Windows.Forms.NumericUpDown SVC_Price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SVC_ID;
        private System.Windows.Forms.ComboBox toothType;
    }
}