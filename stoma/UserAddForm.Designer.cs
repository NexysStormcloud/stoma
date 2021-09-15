
namespace stoma
{
    partial class UserAddForm
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
            this.userName = new System.Windows.Forms.TextBox();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.userPass = new System.Windows.Forms.TextBox();
            this.userPass2 = new System.Windows.Forms.TextBox();
            this.userAdd = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userName.Location = new System.Drawing.Point(12, 12);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(326, 29);
            this.userName.TabIndex = 0;
            // 
            // userLogin
            // 
            this.userLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLogin.Location = new System.Drawing.Point(12, 47);
            this.userLogin.Name = "userLogin";
            this.userLogin.Size = new System.Drawing.Size(326, 29);
            this.userLogin.TabIndex = 1;
            // 
            // userPass
            // 
            this.userPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPass.Location = new System.Drawing.Point(12, 82);
            this.userPass.Name = "userPass";
            this.userPass.PasswordChar = '*';
            this.userPass.Size = new System.Drawing.Size(326, 29);
            this.userPass.TabIndex = 2;
            // 
            // userPass2
            // 
            this.userPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPass2.Location = new System.Drawing.Point(12, 117);
            this.userPass2.Name = "userPass2";
            this.userPass2.PasswordChar = '*';
            this.userPass2.Size = new System.Drawing.Size(326, 29);
            this.userPass2.TabIndex = 3;
            // 
            // userAdd
            // 
            this.userAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userAdd.Location = new System.Drawing.Point(12, 171);
            this.userAdd.Name = "userAdd";
            this.userAdd.Size = new System.Drawing.Size(151, 23);
            this.userAdd.TabIndex = 4;
            this.userAdd.Text = "Добавить";
            this.userAdd.UseVisualStyleBackColor = true;
            this.userAdd.Click += new System.EventHandler(this.userAdd_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.close.Location = new System.Drawing.Point(169, 171);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(151, 23);
            this.close.TabIndex = 5;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // UserAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 206);
            this.Controls.Add(this.close);
            this.Controls.Add(this.userAdd);
            this.Controls.Add(this.userPass2);
            this.Controls.Add(this.userPass);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.userName);
            this.Name = "UserAddForm";
            this.Text = "UserAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox userLogin;
        private System.Windows.Forms.TextBox userPass;
        private System.Windows.Forms.TextBox userPass2;
        private System.Windows.Forms.Button userAdd;
        private System.Windows.Forms.Button close;
    }
}