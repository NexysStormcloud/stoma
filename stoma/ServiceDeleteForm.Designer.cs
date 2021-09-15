
namespace stoma
{
    partial class ServiceDeleteForm
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
            this.SVC_Select = new System.Windows.Forms.ComboBox();
            this.SVC_Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SVC_Select
            // 
            this.SVC_Select.FormattingEnabled = true;
            this.SVC_Select.Location = new System.Drawing.Point(12, 12);
            this.SVC_Select.Name = "SVC_Select";
            this.SVC_Select.Size = new System.Drawing.Size(213, 21);
            this.SVC_Select.TabIndex = 0;
            // 
            // SVC_Delete
            // 
            this.SVC_Delete.Location = new System.Drawing.Point(231, 12);
            this.SVC_Delete.Name = "SVC_Delete";
            this.SVC_Delete.Size = new System.Drawing.Size(144, 23);
            this.SVC_Delete.TabIndex = 1;
            this.SVC_Delete.Text = "Удалить";
            this.SVC_Delete.UseVisualStyleBackColor = true;
            // 
            // ServiceDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 62);
            this.Controls.Add(this.SVC_Delete);
            this.Controls.Add(this.SVC_Select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServiceDeleteForm";
            this.Text = "Выберите услугу для удаления";
            this.Load += new System.EventHandler(this.ServiceDeleteForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SVC_Select;
        private System.Windows.Forms.Button SVC_Delete;
    }
}