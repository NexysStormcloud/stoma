
namespace stoma
{
    partial class AddPersonForm
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
            this.NP_Name = new System.Windows.Forms.TextBox();
            this.NP_patrio = new System.Windows.Forms.TextBox();
            this.NP_surname = new System.Windows.Forms.TextBox();
            this.NP_phone = new System.Windows.Forms.TextBox();
            this.NP_addres = new System.Windows.Forms.TextBox();
            this.NP_add = new System.Windows.Forms.Button();
            this.NP_clear = new System.Windows.Forms.Button();
            this.NP_idCard = new System.Windows.Forms.TextBox();
            this.passField = new System.Windows.Forms.TextBox();
            this.serieField = new System.Windows.Forms.TextBox();
            this.ufmsField = new System.Windows.Forms.TextBox();
            this.ufmsCode = new System.Windows.Forms.TextBox();
            this.passIssued = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NP_birthday = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NP_Name
            // 
            this.NP_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NP_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_Name.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NP_Name.Location = new System.Drawing.Point(12, 76);
            this.NP_Name.Name = "NP_Name";
            this.NP_Name.Size = new System.Drawing.Size(518, 26);
            this.NP_Name.TabIndex = 1;
            this.NP_Name.Text = "ИМЯ";
            // 
            // NP_patrio
            // 
            this.NP_patrio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NP_patrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_patrio.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NP_patrio.Location = new System.Drawing.Point(12, 108);
            this.NP_patrio.Name = "NP_patrio";
            this.NP_patrio.Size = new System.Drawing.Size(518, 26);
            this.NP_patrio.TabIndex = 2;
            this.NP_patrio.Text = "ОТЧЕСТВО";
            // 
            // NP_surname
            // 
            this.NP_surname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NP_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_surname.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NP_surname.Location = new System.Drawing.Point(12, 44);
            this.NP_surname.Name = "NP_surname";
            this.NP_surname.Size = new System.Drawing.Size(518, 26);
            this.NP_surname.TabIndex = 0;
            this.NP_surname.Text = "ФАМИЛИЯ";
            // 
            // NP_phone
            // 
            this.NP_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_phone.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NP_phone.Location = new System.Drawing.Point(12, 140);
            this.NP_phone.Name = "NP_phone";
            this.NP_phone.Size = new System.Drawing.Size(321, 26);
            this.NP_phone.TabIndex = 3;
            this.NP_phone.Text = "ТЕЛЕФОН";
            // 
            // NP_addres
            // 
            this.NP_addres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NP_addres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_addres.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NP_addres.Location = new System.Drawing.Point(3, 115);
            this.NP_addres.Multiline = true;
            this.NP_addres.Name = "NP_addres";
            this.NP_addres.Size = new System.Drawing.Size(513, 89);
            this.NP_addres.TabIndex = 11;
            this.NP_addres.Text = "АДРЕС (населённый пункт, улица, дом, квартира)";
            // 
            // NP_add
            // 
            this.NP_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NP_add.Location = new System.Drawing.Point(362, 383);
            this.NP_add.Name = "NP_add";
            this.NP_add.Size = new System.Drawing.Size(162, 23);
            this.NP_add.TabIndex = 13;
            this.NP_add.Text = "Добавить";
            this.NP_add.UseVisualStyleBackColor = true;
            // 
            // NP_clear
            // 
            this.NP_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NP_clear.Location = new System.Drawing.Point(12, 383);
            this.NP_clear.Name = "NP_clear";
            this.NP_clear.Size = new System.Drawing.Size(164, 23);
            this.NP_clear.TabIndex = 12;
            this.NP_clear.Text = "Сбросить";
            this.NP_clear.UseVisualStyleBackColor = true;
            // 
            // NP_idCard
            // 
            this.NP_idCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_idCard.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NP_idCard.Location = new System.Drawing.Point(12, 12);
            this.NP_idCard.Name = "NP_idCard";
            this.NP_idCard.Size = new System.Drawing.Size(164, 26);
            this.NP_idCard.TabIndex = 14;
            this.NP_idCard.Text = "ID ЗАПИСИ";
            // 
            // passField
            // 
            this.passField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passField.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.passField.Location = new System.Drawing.Point(149, 19);
            this.passField.Name = "passField";
            this.passField.Size = new System.Drawing.Size(172, 26);
            this.passField.TabIndex = 7;
            this.passField.Text = "НОМЕР";
            // 
            // serieField
            // 
            this.serieField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serieField.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.serieField.Location = new System.Drawing.Point(6, 19);
            this.serieField.Name = "serieField";
            this.serieField.Size = new System.Drawing.Size(137, 26);
            this.serieField.TabIndex = 6;
            this.serieField.Text = "СЕРИЯ";
            // 
            // ufmsField
            // 
            this.ufmsField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ufmsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ufmsField.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ufmsField.Location = new System.Drawing.Point(6, 51);
            this.ufmsField.Name = "ufmsField";
            this.ufmsField.Size = new System.Drawing.Size(507, 26);
            this.ufmsField.TabIndex = 9;
            this.ufmsField.Text = "ПОДРАЗДЕЛЕНИЕ";
            // 
            // ufmsCode
            // 
            this.ufmsCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ufmsCode.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ufmsCode.Location = new System.Drawing.Point(6, 83);
            this.ufmsCode.Name = "ufmsCode";
            this.ufmsCode.Size = new System.Drawing.Size(137, 26);
            this.ufmsCode.TabIndex = 10;
            this.ufmsCode.Text = "КОД";
            // 
            // passIssued
            // 
            this.passIssued.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passIssued.Location = new System.Drawing.Point(327, 19);
            this.passIssued.Name = "passIssued";
            this.passIssued.Size = new System.Drawing.Size(186, 26);
            this.passIssued.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.NP_addres);
            this.groupBox1.Controls.Add(this.passIssued);
            this.groupBox1.Controls.Add(this.ufmsField);
            this.groupBox1.Controls.Add(this.passField);
            this.groupBox1.Controls.Add(this.serieField);
            this.groupBox1.Controls.Add(this.ufmsCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 207);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пасспортные данные";
            // 
            // NP_birthday
            // 
            this.NP_birthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NP_birthday.Location = new System.Drawing.Point(339, 140);
            this.NP_birthday.Name = "NP_birthday";
            this.NP_birthday.Size = new System.Drawing.Size(186, 26);
            this.NP_birthday.TabIndex = 4;
            // 
            // AddPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 415);
            this.Controls.Add(this.NP_birthday);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NP_idCard);
            this.Controls.Add(this.NP_clear);
            this.Controls.Add(this.NP_add);
            this.Controls.Add(this.NP_phone);
            this.Controls.Add(this.NP_surname);
            this.Controls.Add(this.NP_patrio);
            this.Controls.Add(this.NP_Name);
            this.MinimumSize = new System.Drawing.Size(552, 453);
            this.Name = "AddPersonForm";
            this.Text = "Создать регистрационную запись";
            this.Load += new System.EventHandler(this.AddPersonForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NP_Name;
        private System.Windows.Forms.TextBox NP_patrio;
        private System.Windows.Forms.TextBox NP_surname;
        private System.Windows.Forms.TextBox NP_phone;
        private System.Windows.Forms.TextBox NP_addres;
        private System.Windows.Forms.Button NP_add;
        private System.Windows.Forms.Button NP_clear;
        private System.Windows.Forms.TextBox NP_idCard;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.TextBox serieField;
        private System.Windows.Forms.TextBox ufmsField;
        private System.Windows.Forms.TextBox ufmsCode;
        private System.Windows.Forms.DateTimePicker passIssued;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker NP_birthday;
    }
}