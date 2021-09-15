
namespace stoma
{
    partial class NewOrder
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
            this.clientName = new System.Windows.Forms.TextBox();
            this.ServiceLister = new System.Windows.Forms.DataGridView();
            this.serviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toothName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tooth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.add = new System.Windows.Forms.Button();
            this.serviceSelector = new System.Windows.Forms.ComboBox();
            this.toothSelector = new System.Windows.Forms.ComboBox();
            this.doctorSelector = new System.Windows.Forms.ComboBox();
            this.append = new System.Windows.Forms.Button();
            this.discountSet = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lr8 = new System.Windows.Forms.CheckBox();
            this.lr7 = new System.Windows.Forms.CheckBox();
            this.lr6 = new System.Windows.Forms.CheckBox();
            this.lr5 = new System.Windows.Forms.CheckBox();
            this.lr4 = new System.Windows.Forms.CheckBox();
            this.lr3 = new System.Windows.Forms.CheckBox();
            this.lr2 = new System.Windows.Forms.CheckBox();
            this.lr1 = new System.Windows.Forms.CheckBox();
            this.ur8 = new System.Windows.Forms.CheckBox();
            this.ur7 = new System.Windows.Forms.CheckBox();
            this.ur6 = new System.Windows.Forms.CheckBox();
            this.ur5 = new System.Windows.Forms.CheckBox();
            this.ur4 = new System.Windows.Forms.CheckBox();
            this.ur3 = new System.Windows.Forms.CheckBox();
            this.ur2 = new System.Windows.Forms.CheckBox();
            this.ur1 = new System.Windows.Forms.CheckBox();
            this.ll8 = new System.Windows.Forms.CheckBox();
            this.ll7 = new System.Windows.Forms.CheckBox();
            this.ll6 = new System.Windows.Forms.CheckBox();
            this.ll5 = new System.Windows.Forms.CheckBox();
            this.ll4 = new System.Windows.Forms.CheckBox();
            this.ll3 = new System.Windows.Forms.CheckBox();
            this.ll2 = new System.Windows.Forms.CheckBox();
            this.ll1 = new System.Windows.Forms.CheckBox();
            this.ul8 = new System.Windows.Forms.CheckBox();
            this.ul7 = new System.Windows.Forms.CheckBox();
            this.ul6 = new System.Windows.Forms.CheckBox();
            this.ul5 = new System.Windows.Forms.CheckBox();
            this.ul4 = new System.Windows.Forms.CheckBox();
            this.ul3 = new System.Windows.Forms.CheckBox();
            this.ul2 = new System.Windows.Forms.CheckBox();
            this.ul1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientName
            // 
            this.clientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.clientName.Location = new System.Drawing.Point(12, 12);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(550, 29);
            this.clientName.TabIndex = 0;
            this.clientName.Text = "ФИО клиента";
            // 
            // ServiceLister
            // 
            this.ServiceLister.AllowUserToAddRows = false;
            this.ServiceLister.AllowUserToDeleteRows = false;
            this.ServiceLister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceLister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceLister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serviceID,
            this.toothName,
            this.tooth,
            this.doctor,
            this.price,
            this.discount,
            this.remove});
            this.ServiceLister.Location = new System.Drawing.Point(12, 202);
            this.ServiceLister.Name = "ServiceLister";
            this.ServiceLister.ReadOnly = true;
            this.ServiceLister.Size = new System.Drawing.Size(542, 304);
            this.ServiceLister.TabIndex = 11;
            this.ServiceLister.TabStop = false;
            this.ServiceLister.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiceLister_CellContentClick);
            // 
            // serviceID
            // 
            this.serviceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.serviceID.HeaderText = "код услуги";
            this.serviceID.Name = "serviceID";
            this.serviceID.ReadOnly = true;
            this.serviceID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.serviceID.Width = 86;
            // 
            // toothName
            // 
            this.toothName.HeaderText = "зуб";
            this.toothName.Name = "toothName";
            this.toothName.ReadOnly = true;
            // 
            // tooth
            // 
            this.tooth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tooth.HeaderText = "Тип";
            this.tooth.Name = "tooth";
            this.tooth.ReadOnly = true;
            this.tooth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tooth.Width = 51;
            // 
            // doctor
            // 
            this.doctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.doctor.HeaderText = "Врач";
            this.doctor.Name = "doctor";
            this.doctor.ReadOnly = true;
            this.doctor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.doctor.Width = 56;
            // 
            // price
            // 
            this.price.HeaderText = "Стоимость";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.HeaderText = "коэффициент";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // remove
            // 
            this.remove.HeaderText = "";
            this.remove.Name = "remove";
            this.remove.ReadOnly = true;
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add.Location = new System.Drawing.Point(16, 512);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(180, 23);
            this.add.TabIndex = 7;
            this.add.Text = "Оформить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // serviceSelector
            // 
            this.serviceSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceSelector.FormattingEnabled = true;
            this.serviceSelector.Location = new System.Drawing.Point(16, 47);
            this.serviceSelector.Name = "serviceSelector";
            this.serviceSelector.Size = new System.Drawing.Size(234, 21);
            this.serviceSelector.TabIndex = 1;
            // 
            // toothSelector
            // 
            this.toothSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toothSelector.FormattingEnabled = true;
            this.toothSelector.Location = new System.Drawing.Point(16, 74);
            this.toothSelector.Name = "toothSelector";
            this.toothSelector.Size = new System.Drawing.Size(234, 21);
            this.toothSelector.TabIndex = 3;
            // 
            // doctorSelector
            // 
            this.doctorSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doctorSelector.FormattingEnabled = true;
            this.doctorSelector.Location = new System.Drawing.Point(256, 47);
            this.doctorSelector.Name = "doctorSelector";
            this.doctorSelector.Size = new System.Drawing.Size(224, 21);
            this.doctorSelector.TabIndex = 2;
            // 
            // append
            // 
            this.append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.append.Location = new System.Drawing.Point(486, 47);
            this.append.Name = "append";
            this.append.Size = new System.Drawing.Size(75, 48);
            this.append.TabIndex = 5;
            this.append.Text = "+";
            this.append.UseVisualStyleBackColor = true;
            this.append.Click += new System.EventHandler(this.append_Click);
            // 
            // discountSet
            // 
            this.discountSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discountSet.DecimalPlaces = 2;
            this.discountSet.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.discountSet.Location = new System.Drawing.Point(256, 74);
            this.discountSet.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.discountSet.Name = "discountSet";
            this.discountSet.Size = new System.Drawing.Size(224, 20);
            this.discountSet.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lr8);
            this.groupBox1.Controls.Add(this.ll8);
            this.groupBox1.Controls.Add(this.ll7);
            this.groupBox1.Controls.Add(this.lr7);
            this.groupBox1.Controls.Add(this.ll6);
            this.groupBox1.Controls.Add(this.ll5);
            this.groupBox1.Controls.Add(this.lr6);
            this.groupBox1.Controls.Add(this.ll4);
            this.groupBox1.Controls.Add(this.ll3);
            this.groupBox1.Controls.Add(this.lr5);
            this.groupBox1.Controls.Add(this.ur8);
            this.groupBox1.Controls.Add(this.ll2);
            this.groupBox1.Controls.Add(this.ll1);
            this.groupBox1.Controls.Add(this.lr4);
            this.groupBox1.Controls.Add(this.ul8);
            this.groupBox1.Controls.Add(this.ur7);
            this.groupBox1.Controls.Add(this.ul7);
            this.groupBox1.Controls.Add(this.lr3);
            this.groupBox1.Controls.Add(this.ul6);
            this.groupBox1.Controls.Add(this.ur6);
            this.groupBox1.Controls.Add(this.ul5);
            this.groupBox1.Controls.Add(this.lr2);
            this.groupBox1.Controls.Add(this.ul4);
            this.groupBox1.Controls.Add(this.ur5);
            this.groupBox1.Controls.Add(this.ul3);
            this.groupBox1.Controls.Add(this.lr1);
            this.groupBox1.Controls.Add(this.ul2);
            this.groupBox1.Controls.Add(this.ur4);
            this.groupBox1.Controls.Add(this.ul1);
            this.groupBox1.Controls.Add(this.ur1);
            this.groupBox1.Controls.Add(this.ur3);
            this.groupBox1.Controls.Add(this.ur2);
            this.groupBox1.Location = new System.Drawing.Point(16, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 93);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Зуб";
            // 
            // lr8
            // 
            this.lr8.AutoSize = true;
            this.lr8.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr8.Location = new System.Drawing.Point(11, 56);
            this.lr8.Name = "lr8";
            this.lr8.Size = new System.Drawing.Size(17, 31);
            this.lr8.TabIndex = 31;
            this.lr8.Text = "8";
            this.lr8.UseVisualStyleBackColor = true;
            // 
            // lr7
            // 
            this.lr7.AutoSize = true;
            this.lr7.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr7.Location = new System.Drawing.Point(34, 56);
            this.lr7.Name = "lr7";
            this.lr7.Size = new System.Drawing.Size(17, 31);
            this.lr7.TabIndex = 30;
            this.lr7.Text = "7";
            this.lr7.UseVisualStyleBackColor = true;
            // 
            // lr6
            // 
            this.lr6.AutoSize = true;
            this.lr6.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr6.Location = new System.Drawing.Point(57, 56);
            this.lr6.Name = "lr6";
            this.lr6.Size = new System.Drawing.Size(17, 31);
            this.lr6.TabIndex = 29;
            this.lr6.Text = "6";
            this.lr6.UseVisualStyleBackColor = true;
            // 
            // lr5
            // 
            this.lr5.AutoSize = true;
            this.lr5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr5.Location = new System.Drawing.Point(80, 56);
            this.lr5.Name = "lr5";
            this.lr5.Size = new System.Drawing.Size(17, 31);
            this.lr5.TabIndex = 28;
            this.lr5.Text = "5";
            this.lr5.UseVisualStyleBackColor = true;
            // 
            // lr4
            // 
            this.lr4.AutoSize = true;
            this.lr4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr4.Location = new System.Drawing.Point(103, 56);
            this.lr4.Name = "lr4";
            this.lr4.Size = new System.Drawing.Size(17, 31);
            this.lr4.TabIndex = 27;
            this.lr4.Text = "4";
            this.lr4.UseVisualStyleBackColor = true;
            // 
            // lr3
            // 
            this.lr3.AutoSize = true;
            this.lr3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr3.Location = new System.Drawing.Point(126, 56);
            this.lr3.Name = "lr3";
            this.lr3.Size = new System.Drawing.Size(17, 31);
            this.lr3.TabIndex = 26;
            this.lr3.Text = "3";
            this.lr3.UseVisualStyleBackColor = true;
            // 
            // lr2
            // 
            this.lr2.AutoSize = true;
            this.lr2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr2.Location = new System.Drawing.Point(149, 56);
            this.lr2.Name = "lr2";
            this.lr2.Size = new System.Drawing.Size(17, 31);
            this.lr2.TabIndex = 25;
            this.lr2.Text = "2";
            this.lr2.UseVisualStyleBackColor = true;
            // 
            // lr1
            // 
            this.lr1.AutoSize = true;
            this.lr1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lr1.Location = new System.Drawing.Point(172, 56);
            this.lr1.Name = "lr1";
            this.lr1.Size = new System.Drawing.Size(17, 31);
            this.lr1.TabIndex = 24;
            this.lr1.Text = "1";
            this.lr1.UseVisualStyleBackColor = true;
            // 
            // ur8
            // 
            this.ur8.AutoSize = true;
            this.ur8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur8.Location = new System.Drawing.Point(11, 19);
            this.ur8.Name = "ur8";
            this.ur8.Size = new System.Drawing.Size(17, 31);
            this.ur8.TabIndex = 23;
            this.ur8.Text = "8";
            this.ur8.UseVisualStyleBackColor = true;
            // 
            // ur7
            // 
            this.ur7.AutoSize = true;
            this.ur7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur7.Location = new System.Drawing.Point(34, 19);
            this.ur7.Name = "ur7";
            this.ur7.Size = new System.Drawing.Size(17, 31);
            this.ur7.TabIndex = 22;
            this.ur7.Text = "7";
            this.ur7.UseVisualStyleBackColor = true;
            // 
            // ur6
            // 
            this.ur6.AutoSize = true;
            this.ur6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur6.Location = new System.Drawing.Point(57, 19);
            this.ur6.Name = "ur6";
            this.ur6.Size = new System.Drawing.Size(17, 31);
            this.ur6.TabIndex = 21;
            this.ur6.Text = "6";
            this.ur6.UseVisualStyleBackColor = true;
            // 
            // ur5
            // 
            this.ur5.AutoSize = true;
            this.ur5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur5.Location = new System.Drawing.Point(80, 19);
            this.ur5.Name = "ur5";
            this.ur5.Size = new System.Drawing.Size(17, 31);
            this.ur5.TabIndex = 20;
            this.ur5.Text = "5";
            this.ur5.UseVisualStyleBackColor = true;
            // 
            // ur4
            // 
            this.ur4.AutoSize = true;
            this.ur4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur4.Location = new System.Drawing.Point(103, 19);
            this.ur4.Name = "ur4";
            this.ur4.Size = new System.Drawing.Size(17, 31);
            this.ur4.TabIndex = 19;
            this.ur4.Text = "4";
            this.ur4.UseVisualStyleBackColor = true;
            // 
            // ur3
            // 
            this.ur3.AutoSize = true;
            this.ur3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur3.Location = new System.Drawing.Point(126, 19);
            this.ur3.Name = "ur3";
            this.ur3.Size = new System.Drawing.Size(17, 31);
            this.ur3.TabIndex = 18;
            this.ur3.Text = "3";
            this.ur3.UseVisualStyleBackColor = true;
            // 
            // ur2
            // 
            this.ur2.AutoSize = true;
            this.ur2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur2.Location = new System.Drawing.Point(149, 19);
            this.ur2.Name = "ur2";
            this.ur2.Size = new System.Drawing.Size(17, 31);
            this.ur2.TabIndex = 17;
            this.ur2.Text = "2";
            this.ur2.UseVisualStyleBackColor = true;
            // 
            // ur1
            // 
            this.ur1.AutoSize = true;
            this.ur1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ur1.Location = new System.Drawing.Point(172, 19);
            this.ur1.Name = "ur1";
            this.ur1.Size = new System.Drawing.Size(17, 31);
            this.ur1.TabIndex = 16;
            this.ur1.Text = "1";
            this.ur1.UseVisualStyleBackColor = true;
            // 
            // ll8
            // 
            this.ll8.AutoSize = true;
            this.ll8.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll8.Location = new System.Drawing.Point(378, 56);
            this.ll8.Name = "ll8";
            this.ll8.Size = new System.Drawing.Size(17, 31);
            this.ll8.TabIndex = 15;
            this.ll8.Text = "8";
            this.ll8.UseVisualStyleBackColor = true;
            // 
            // ll7
            // 
            this.ll7.AutoSize = true;
            this.ll7.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll7.Location = new System.Drawing.Point(355, 56);
            this.ll7.Name = "ll7";
            this.ll7.Size = new System.Drawing.Size(17, 31);
            this.ll7.TabIndex = 14;
            this.ll7.Text = "7";
            this.ll7.UseVisualStyleBackColor = true;
            // 
            // ll6
            // 
            this.ll6.AutoSize = true;
            this.ll6.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll6.Location = new System.Drawing.Point(332, 56);
            this.ll6.Name = "ll6";
            this.ll6.Size = new System.Drawing.Size(17, 31);
            this.ll6.TabIndex = 13;
            this.ll6.Text = "6";
            this.ll6.UseVisualStyleBackColor = true;
            // 
            // ll5
            // 
            this.ll5.AutoSize = true;
            this.ll5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll5.Location = new System.Drawing.Point(309, 56);
            this.ll5.Name = "ll5";
            this.ll5.Size = new System.Drawing.Size(17, 31);
            this.ll5.TabIndex = 12;
            this.ll5.Text = "5";
            this.ll5.UseVisualStyleBackColor = true;
            // 
            // ll4
            // 
            this.ll4.AutoSize = true;
            this.ll4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll4.Location = new System.Drawing.Point(286, 56);
            this.ll4.Name = "ll4";
            this.ll4.Size = new System.Drawing.Size(17, 31);
            this.ll4.TabIndex = 11;
            this.ll4.Text = "4";
            this.ll4.UseVisualStyleBackColor = true;
            // 
            // ll3
            // 
            this.ll3.AutoSize = true;
            this.ll3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll3.Location = new System.Drawing.Point(263, 56);
            this.ll3.Name = "ll3";
            this.ll3.Size = new System.Drawing.Size(17, 31);
            this.ll3.TabIndex = 10;
            this.ll3.Text = "3";
            this.ll3.UseVisualStyleBackColor = true;
            // 
            // ll2
            // 
            this.ll2.AutoSize = true;
            this.ll2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll2.Location = new System.Drawing.Point(240, 56);
            this.ll2.Name = "ll2";
            this.ll2.Size = new System.Drawing.Size(17, 31);
            this.ll2.TabIndex = 9;
            this.ll2.Text = "2";
            this.ll2.UseVisualStyleBackColor = true;
            // 
            // ll1
            // 
            this.ll1.AutoSize = true;
            this.ll1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ll1.Location = new System.Drawing.Point(217, 56);
            this.ll1.Name = "ll1";
            this.ll1.Size = new System.Drawing.Size(17, 31);
            this.ll1.TabIndex = 8;
            this.ll1.Text = "1";
            this.ll1.UseVisualStyleBackColor = true;
            // 
            // ul8
            // 
            this.ul8.AutoSize = true;
            this.ul8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul8.Location = new System.Drawing.Point(378, 19);
            this.ul8.Name = "ul8";
            this.ul8.Size = new System.Drawing.Size(17, 31);
            this.ul8.TabIndex = 7;
            this.ul8.Text = "8";
            this.ul8.UseVisualStyleBackColor = true;
            // 
            // ul7
            // 
            this.ul7.AutoSize = true;
            this.ul7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul7.Location = new System.Drawing.Point(355, 19);
            this.ul7.Name = "ul7";
            this.ul7.Size = new System.Drawing.Size(17, 31);
            this.ul7.TabIndex = 6;
            this.ul7.Text = "7";
            this.ul7.UseVisualStyleBackColor = true;
            // 
            // ul6
            // 
            this.ul6.AutoSize = true;
            this.ul6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul6.Location = new System.Drawing.Point(332, 19);
            this.ul6.Name = "ul6";
            this.ul6.Size = new System.Drawing.Size(17, 31);
            this.ul6.TabIndex = 5;
            this.ul6.Text = "6";
            this.ul6.UseVisualStyleBackColor = true;
            // 
            // ul5
            // 
            this.ul5.AutoSize = true;
            this.ul5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul5.Location = new System.Drawing.Point(309, 19);
            this.ul5.Name = "ul5";
            this.ul5.Size = new System.Drawing.Size(17, 31);
            this.ul5.TabIndex = 4;
            this.ul5.Text = "5";
            this.ul5.UseVisualStyleBackColor = true;
            // 
            // ul4
            // 
            this.ul4.AutoSize = true;
            this.ul4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul4.Location = new System.Drawing.Point(286, 19);
            this.ul4.Name = "ul4";
            this.ul4.Size = new System.Drawing.Size(17, 31);
            this.ul4.TabIndex = 3;
            this.ul4.Text = "4";
            this.ul4.UseVisualStyleBackColor = true;
            // 
            // ul3
            // 
            this.ul3.AutoSize = true;
            this.ul3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul3.Location = new System.Drawing.Point(263, 19);
            this.ul3.Name = "ul3";
            this.ul3.Size = new System.Drawing.Size(17, 31);
            this.ul3.TabIndex = 2;
            this.ul3.Text = "3";
            this.ul3.UseVisualStyleBackColor = true;
            // 
            // ul2
            // 
            this.ul2.AutoSize = true;
            this.ul2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul2.Location = new System.Drawing.Point(240, 19);
            this.ul2.Name = "ul2";
            this.ul2.Size = new System.Drawing.Size(17, 31);
            this.ul2.TabIndex = 1;
            this.ul2.Text = "2";
            this.ul2.UseVisualStyleBackColor = true;
            // 
            // ul1
            // 
            this.ul1.AutoSize = true;
            this.ul1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ul1.Location = new System.Drawing.Point(217, 19);
            this.ul1.Name = "ul1";
            this.ul1.Size = new System.Drawing.Size(17, 31);
            this.ul1.TabIndex = 0;
            this.ul1.Text = "1";
            this.ul1.UseVisualStyleBackColor = true;
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.discountSet);
            this.Controls.Add(this.append);
            this.Controls.Add(this.doctorSelector);
            this.Controls.Add(this.toothSelector);
            this.Controls.Add(this.serviceSelector);
            this.Controls.Add(this.add);
            this.Controls.Add(this.ServiceLister);
            this.Controls.Add(this.clientName);
            this.Name = "NewOrder";
            this.Text = "NewOrder";
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.DataGridView ServiceLister;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ComboBox serviceSelector;
        private System.Windows.Forms.ComboBox toothSelector;
        private System.Windows.Forms.ComboBox doctorSelector;
        private System.Windows.Forms.Button append;
        private System.Windows.Forms.NumericUpDown discountSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox lr8;
        private System.Windows.Forms.CheckBox lr7;
        private System.Windows.Forms.CheckBox lr6;
        private System.Windows.Forms.CheckBox lr5;
        private System.Windows.Forms.CheckBox lr4;
        private System.Windows.Forms.CheckBox lr3;
        private System.Windows.Forms.CheckBox lr2;
        private System.Windows.Forms.CheckBox lr1;
        private System.Windows.Forms.CheckBox ur8;
        private System.Windows.Forms.CheckBox ur7;
        private System.Windows.Forms.CheckBox ur6;
        private System.Windows.Forms.CheckBox ur5;
        private System.Windows.Forms.CheckBox ur4;
        private System.Windows.Forms.CheckBox ur3;
        private System.Windows.Forms.CheckBox ur2;
        private System.Windows.Forms.CheckBox ur1;
        private System.Windows.Forms.CheckBox ll8;
        private System.Windows.Forms.CheckBox ll7;
        private System.Windows.Forms.CheckBox ll6;
        private System.Windows.Forms.CheckBox ll5;
        private System.Windows.Forms.CheckBox ll4;
        private System.Windows.Forms.CheckBox ll3;
        private System.Windows.Forms.CheckBox ll2;
        private System.Windows.Forms.CheckBox ll1;
        private System.Windows.Forms.CheckBox ul8;
        private System.Windows.Forms.CheckBox ul7;
        private System.Windows.Forms.CheckBox ul6;
        private System.Windows.Forms.CheckBox ul5;
        private System.Windows.Forms.CheckBox ul4;
        private System.Windows.Forms.CheckBox ul3;
        private System.Windows.Forms.CheckBox ul2;
        private System.Windows.Forms.CheckBox ul1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn toothName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tooth;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewButtonColumn remove;
    }
}