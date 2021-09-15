
namespace stoma
{
    partial class AddDoctorForm
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
            this.ND_Profile = new System.Windows.Forms.TextBox();
            this.ND_Name = new System.Windows.Forms.TextBox();
            this.ND_Add = new System.Windows.Forms.Button();
            this.ND_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ND_Profile
            // 
            this.ND_Profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ND_Profile.Location = new System.Drawing.Point(12, 47);
            this.ND_Profile.Name = "ND_Profile";
            this.ND_Profile.Size = new System.Drawing.Size(355, 29);
            this.ND_Profile.TabIndex = 1;
            this.ND_Profile.Text = "ПРОФИЛЬ";
            // 
            // ND_Name
            // 
            this.ND_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ND_Name.Location = new System.Drawing.Point(12, 12);
            this.ND_Name.Name = "ND_Name";
            this.ND_Name.Size = new System.Drawing.Size(355, 29);
            this.ND_Name.TabIndex = 0;
            this.ND_Name.Text = "ФИО";
            // 
            // ND_Add
            // 
            this.ND_Add.Location = new System.Drawing.Point(12, 82);
            this.ND_Add.Name = "ND_Add";
            this.ND_Add.Size = new System.Drawing.Size(158, 23);
            this.ND_Add.TabIndex = 2;
            this.ND_Add.Text = "Добавить";
            this.ND_Add.UseVisualStyleBackColor = true;
            this.ND_Add.Click += new System.EventHandler(this.ND_Add_Click);
            // 
            // ND_Close
            // 
            this.ND_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ND_Close.Location = new System.Drawing.Point(209, 82);
            this.ND_Close.Name = "ND_Close";
            this.ND_Close.Size = new System.Drawing.Size(158, 23);
            this.ND_Close.TabIndex = 3;
            this.ND_Close.Text = "Закрыть";
            this.ND_Close.UseVisualStyleBackColor = true;
            this.ND_Close.Click += new System.EventHandler(this.ND_Close_Click);
            // 
            // AddDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 118);
            this.Controls.Add(this.ND_Close);
            this.Controls.Add(this.ND_Add);
            this.Controls.Add(this.ND_Name);
            this.Controls.Add(this.ND_Profile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddDoctorForm";
            this.Text = "AddDoctorForm";
            this.Load += new System.EventHandler(this.AddDoctorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ND_Profile;
        private System.Windows.Forms.TextBox ND_Name;
        private System.Windows.Forms.Button ND_Add;
        private System.Windows.Forms.Button ND_Close;
    }
}