
namespace stoma
{
    partial class UsersForm
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
            this.userListView = new System.Windows.Forms.DataGridView();
            this.userAdd = new System.Windows.Forms.Button();
            this.userEdit = new System.Windows.Forms.Button();
            this.userDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userListView)).BeginInit();
            this.SuspendLayout();
            // 
            // userListView
            // 
            this.userListView.AllowUserToAddRows = false;
            this.userListView.AllowUserToDeleteRows = false;
            this.userListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userListView.Location = new System.Drawing.Point(12, 12);
            this.userListView.Name = "userListView";
            this.userListView.ReadOnly = true;
            this.userListView.Size = new System.Drawing.Size(637, 387);
            this.userListView.TabIndex = 0;
            // 
            // userAdd
            // 
            this.userAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userAdd.Location = new System.Drawing.Point(12, 415);
            this.userAdd.Name = "userAdd";
            this.userAdd.Size = new System.Drawing.Size(100, 23);
            this.userAdd.TabIndex = 1;
            this.userAdd.Text = "Добавить";
            this.userAdd.UseVisualStyleBackColor = true;
            this.userAdd.Click += new System.EventHandler(this.userAdd_Click);
            // 
            // userEdit
            // 
            this.userEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userEdit.Location = new System.Drawing.Point(118, 415);
            this.userEdit.Name = "userEdit";
            this.userEdit.Size = new System.Drawing.Size(99, 23);
            this.userEdit.TabIndex = 2;
            this.userEdit.Text = "Изменить";
            this.userEdit.UseVisualStyleBackColor = true;
            this.userEdit.Click += new System.EventHandler(this.userEdit_Click);
            // 
            // userDelete
            // 
            this.userDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userDelete.Location = new System.Drawing.Point(223, 415);
            this.userDelete.Name = "userDelete";
            this.userDelete.Size = new System.Drawing.Size(99, 23);
            this.userDelete.TabIndex = 3;
            this.userDelete.Text = "Удалить";
            this.userDelete.UseVisualStyleBackColor = true;
            this.userDelete.Click += new System.EventHandler(this.userDelete_Click);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 450);
            this.Controls.Add(this.userDelete);
            this.Controls.Add(this.userEdit);
            this.Controls.Add(this.userAdd);
            this.Controls.Add(this.userListView);
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userListView;
        private System.Windows.Forms.Button userAdd;
        private System.Windows.Forms.Button userEdit;
        private System.Windows.Forms.Button userDelete;
    }
}