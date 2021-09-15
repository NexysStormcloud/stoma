
namespace stoma
{
    partial class PersonView
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
            this.PV_name = new System.Windows.Forms.Label();
            this.PV_phone = new System.Windows.Forms.Label();
            this.PV_addres = new System.Windows.Forms.Label();
            this.PV_brthday = new System.Windows.Forms.Label();
            this.PV_Age = new System.Windows.Forms.Label();
            this.PV_EditBtn = new System.Windows.Forms.Button();
            this.PV_Delete = new System.Windows.Forms.Button();
            this.PV_View = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PV_name
            // 
            this.PV_name.AutoSize = true;
            this.PV_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PV_name.Location = new System.Drawing.Point(12, 12);
            this.PV_name.Name = "PV_name";
            this.PV_name.Size = new System.Drawing.Size(529, 25);
            this.PV_name.TabIndex = 0;
            this.PV_name.Text = "Перекопанийский Вольдемариан Арсениалексович";
            // 
            // PV_phone
            // 
            this.PV_phone.AutoSize = true;
            this.PV_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PV_phone.Location = new System.Drawing.Point(12, 48);
            this.PV_phone.Name = "PV_phone";
            this.PV_phone.Size = new System.Drawing.Size(195, 20);
            this.PV_phone.TabIndex = 1;
            this.PV_phone.Text = "Телефон: +79183345566";
            // 
            // PV_addres
            // 
            this.PV_addres.AutoSize = true;
            this.PV_addres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PV_addres.Location = new System.Drawing.Point(12, 77);
            this.PV_addres.Name = "PV_addres";
            this.PV_addres.Size = new System.Drawing.Size(322, 40);
            this.PV_addres.TabIndex = 2;
            this.PV_addres.Text = "Адрес: краснодарский край ст.северская\r\nулица Красноперекопская д113 к.2 кв. 14";
            // 
            // PV_brthday
            // 
            this.PV_brthday.AutoSize = true;
            this.PV_brthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PV_brthday.Location = new System.Drawing.Point(12, 153);
            this.PV_brthday.Name = "PV_brthday";
            this.PV_brthday.Size = new System.Drawing.Size(212, 20);
            this.PV_brthday.TabIndex = 3;
            this.PV_brthday.Text = "Дата рождения:18.05.1928";
            // 
            // PV_Age
            // 
            this.PV_Age.AutoSize = true;
            this.PV_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PV_Age.Location = new System.Drawing.Point(12, 173);
            this.PV_Age.Name = "PV_Age";
            this.PV_Age.Size = new System.Drawing.Size(96, 20);
            this.PV_Age.TabIndex = 4;
            this.PV_Age.Text = "возраст: 93";
            // 
            // PV_EditBtn
            // 
            this.PV_EditBtn.Location = new System.Drawing.Point(501, 161);
            this.PV_EditBtn.Name = "PV_EditBtn";
            this.PV_EditBtn.Size = new System.Drawing.Size(93, 32);
            this.PV_EditBtn.TabIndex = 5;
            this.PV_EditBtn.Text = "редактировать";
            this.PV_EditBtn.UseVisualStyleBackColor = true;
            // 
            // PV_Delete
            // 
            this.PV_Delete.Location = new System.Drawing.Point(402, 161);
            this.PV_Delete.Name = "PV_Delete";
            this.PV_Delete.Size = new System.Drawing.Size(93, 32);
            this.PV_Delete.TabIndex = 6;
            this.PV_Delete.Text = "удалить";
            this.PV_Delete.UseVisualStyleBackColor = true;
            // 
            // PV_View
            // 
            this.PV_View.Location = new System.Drawing.Point(303, 161);
            this.PV_View.Name = "PV_View";
            this.PV_View.Size = new System.Drawing.Size(93, 32);
            this.PV_View.TabIndex = 7;
            this.PV_View.Text = "Просмотр";
            this.PV_View.UseVisualStyleBackColor = true;
            
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 202);
            this.Controls.Add(this.PV_View);
            this.Controls.Add(this.PV_Delete);
            this.Controls.Add(this.PV_EditBtn);
            this.Controls.Add(this.PV_Age);
            this.Controls.Add(this.PV_brthday);
            this.Controls.Add(this.PV_addres);
            this.Controls.Add(this.PV_phone);
            this.Controls.Add(this.PV_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PersonView";
            this.Text = "PersonView";
            this.Load += new System.EventHandler(this.PersonView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PV_name;
        private System.Windows.Forms.Label PV_phone;
        private System.Windows.Forms.Label PV_addres;
        private System.Windows.Forms.Label PV_brthday;
        private System.Windows.Forms.Label PV_Age;
        private System.Windows.Forms.Button PV_EditBtn;
        private System.Windows.Forms.Button PV_Delete;
        private System.Windows.Forms.Button PV_View;
    }
}