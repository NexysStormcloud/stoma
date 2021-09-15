
namespace stoma
{
    partial class StartWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.timeTable = new System.Windows.Forms.DataGridView();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.OrderaTab = new System.Windows.Forms.TabPage();
            this.deleteOrder = new System.Windows.Forms.Button();
            this.closeOrder = new System.Windows.Forms.Button();
            this.createOrder = new System.Windows.Forms.Button();
            this.orderView = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderServiceView = new System.Windows.Forms.DataGridView();
            this.serviceOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.individual = new System.Windows.Forms.TabPage();
            this.DoctorSelector = new System.Windows.Forms.ComboBox();
            this.DoctorCalendar = new System.Windows.Forms.MonthCalendar();
            this.DoctorSchedule = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceList = new System.Windows.Forms.TabPage();
            this.delete_service = new System.Windows.Forms.Button();
            this.add_service = new System.Windows.Forms.Button();
            this.ServiceListView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tootType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doct = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.add_doctor = new System.Windows.Forms.Button();
            this.doctorListView = new System.Windows.Forms.DataGridView();
            this.doctID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileTab = new System.Windows.Forms.TabPage();
            this.add_Person = new System.Windows.Forms.Button();
            this.PersonalDataView = new System.Windows.Forms.DataGridView();
            this.P_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_patrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_addres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuItem_DB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DB_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DB_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DB_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DB_Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.UsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderPrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvoicePrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgreementPrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServiceBlankMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templaesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderTemplatePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvoiceTemplatePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agreementPathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServiceBlankPathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.scheduleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeTable)).BeginInit();
            this.OrderaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderServiceView)).BeginInit();
            this.individual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorSchedule)).BeginInit();
            this.ServiceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceListView)).BeginInit();
            this.doct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorListView)).BeginInit();
            this.profileTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalDataView)).BeginInit();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.scheduleTab);
            this.tabControl1.Controls.Add(this.OrderaTab);
            this.tabControl1.Controls.Add(this.individual);
            this.tabControl1.Controls.Add(this.ServiceList);
            this.tabControl1.Controls.Add(this.doct);
            this.tabControl1.Controls.Add(this.profileTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 467);
            this.tabControl1.TabIndex = 2;
            // 
            // scheduleTab
            // 
            this.scheduleTab.Controls.Add(this.timeTable);
            this.scheduleTab.Controls.Add(this.calendar);
            this.scheduleTab.Location = new System.Drawing.Point(4, 22);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTab.Size = new System.Drawing.Size(801, 441);
            this.scheduleTab.TabIndex = 0;
            this.scheduleTab.Text = "Расписание";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // timeTable
            // 
            this.timeTable.AllowUserToAddRows = false;
            this.timeTable.AllowUserToDeleteRows = false;
            this.timeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timeTable.Location = new System.Drawing.Point(187, 13);
            this.timeTable.MultiSelect = false;
            this.timeTable.Name = "timeTable";
            this.timeTable.ReadOnly = true;
            this.timeTable.Size = new System.Drawing.Size(606, 408);
            this.timeTable.TabIndex = 1;
            // 
            // calendar
            // 
            this.calendar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.calendar.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calendar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.calendar.Location = new System.Drawing.Point(12, 12);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            // 
            // OrderaTab
            // 
            this.OrderaTab.Controls.Add(this.splitContainer1);
            this.OrderaTab.Controls.Add(this.deleteOrder);
            this.OrderaTab.Controls.Add(this.closeOrder);
            this.OrderaTab.Controls.Add(this.createOrder);
            this.OrderaTab.Location = new System.Drawing.Point(4, 22);
            this.OrderaTab.Name = "OrderaTab";
            this.OrderaTab.Padding = new System.Windows.Forms.Padding(3);
            this.OrderaTab.Size = new System.Drawing.Size(801, 441);
            this.OrderaTab.TabIndex = 1;
            this.OrderaTab.Text = "Наряды";
            this.OrderaTab.UseVisualStyleBackColor = true;
            // 
            // deleteOrder
            // 
            this.deleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteOrder.Location = new System.Drawing.Point(570, 410);
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(223, 23);
            this.deleteOrder.TabIndex = 4;
            this.deleteOrder.Text = "удалить наряд";
            this.deleteOrder.UseVisualStyleBackColor = true;
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // closeOrder
            // 
            this.closeOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeOrder.Location = new System.Drawing.Point(203, 410);
            this.closeOrder.Name = "closeOrder";
            this.closeOrder.Size = new System.Drawing.Size(197, 23);
            this.closeOrder.TabIndex = 3;
            this.closeOrder.Text = "оплатить";
            this.closeOrder.UseVisualStyleBackColor = true;
            this.closeOrder.Click += new System.EventHandler(this.closeOrder_Click);
            // 
            // createOrder
            // 
            this.createOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createOrder.Location = new System.Drawing.Point(8, 410);
            this.createOrder.Name = "createOrder";
            this.createOrder.Size = new System.Drawing.Size(189, 23);
            this.createOrder.TabIndex = 2;
            this.createOrder.Text = "создать наряд";
            this.createOrder.UseVisualStyleBackColor = true;
            this.createOrder.Click += new System.EventHandler(this.createOrder_Click);
            // 
            // orderView
            // 
            this.orderView.AllowUserToAddRows = false;
            this.orderView.AllowUserToDeleteRows = false;
            this.orderView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.clientID});
            this.orderView.Location = new System.Drawing.Point(3, 3);
            this.orderView.Name = "orderView";
            this.orderView.ReadOnly = true;
            this.orderView.RowHeadersWidth = 10;
            this.orderView.Size = new System.Drawing.Size(190, 392);
            this.orderView.TabIndex = 1;
            // 
            // order
            // 
            this.order.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.order.HeaderText = "Наряд";
            this.order.Name = "order";
            this.order.ReadOnly = true;
            this.order.Width = 64;
            // 
            // clientID
            // 
            this.clientID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clientID.HeaderText = "#";
            this.clientID.Name = "clientID";
            this.clientID.ReadOnly = true;
            this.clientID.Width = 39;
            // 
            // orderServiceView
            // 
            this.orderServiceView.AllowUserToAddRows = false;
            this.orderServiceView.AllowUserToDeleteRows = false;
            this.orderServiceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderServiceView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderServiceView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serviceOrder,
            this.patient,
            this.issued,
            this.closed,
            this.dop1,
            this.dop2,
            this.dop3,
            this.dop4,
            this.dop5});
            this.orderServiceView.Location = new System.Drawing.Point(3, 3);
            this.orderServiceView.Name = "orderServiceView";
            this.orderServiceView.ReadOnly = true;
            this.orderServiceView.Size = new System.Drawing.Size(586, 392);
            this.orderServiceView.TabIndex = 0;
            // 
            // serviceOrder
            // 
            this.serviceOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.serviceOrder.HeaderText = "Наряд";
            this.serviceOrder.Name = "serviceOrder";
            this.serviceOrder.ReadOnly = true;
            this.serviceOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serviceOrder.Width = 45;
            // 
            // patient
            // 
            this.patient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.patient.HeaderText = "Клиент";
            this.patient.Name = "patient";
            this.patient.ReadOnly = true;
            this.patient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patient.Width = 49;
            // 
            // issued
            // 
            this.issued.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.issued.HeaderText = "Оформлено";
            this.issued.Name = "issued";
            this.issued.ReadOnly = true;
            this.issued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.issued.Width = 73;
            // 
            // closed
            // 
            this.closed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.closed.HeaderText = "Оплачено";
            this.closed.Name = "closed";
            this.closed.ReadOnly = true;
            this.closed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.closed.Width = 62;
            // 
            // dop1
            // 
            this.dop1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dop1.HeaderText = "";
            this.dop1.Name = "dop1";
            this.dop1.ReadOnly = true;
            this.dop1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dop1.Width = 5;
            // 
            // dop2
            // 
            this.dop2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dop2.HeaderText = "";
            this.dop2.Name = "dop2";
            this.dop2.ReadOnly = true;
            this.dop2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dop2.Width = 5;
            // 
            // dop3
            // 
            this.dop3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dop3.HeaderText = "";
            this.dop3.Name = "dop3";
            this.dop3.ReadOnly = true;
            this.dop3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dop3.Width = 5;
            // 
            // dop4
            // 
            this.dop4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dop4.HeaderText = "";
            this.dop4.Name = "dop4";
            this.dop4.ReadOnly = true;
            this.dop4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dop4.Width = 5;
            // 
            // dop5
            // 
            this.dop5.HeaderText = "";
            this.dop5.Name = "dop5";
            this.dop5.ReadOnly = true;
            // 
            // individual
            // 
            this.individual.Controls.Add(this.DoctorSelector);
            this.individual.Controls.Add(this.DoctorCalendar);
            this.individual.Controls.Add(this.DoctorSchedule);
            this.individual.Location = new System.Drawing.Point(4, 22);
            this.individual.Name = "individual";
            this.individual.Size = new System.Drawing.Size(801, 441);
            this.individual.TabIndex = 2;
            this.individual.Text = "Личный График";
            this.individual.UseVisualStyleBackColor = true;
            // 
            // DoctorSelector
            // 
            this.DoctorSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorSelector.FormattingEnabled = true;
            this.DoctorSelector.Location = new System.Drawing.Point(628, 186);
            this.DoctorSelector.Name = "DoctorSelector";
            this.DoctorSelector.Size = new System.Drawing.Size(164, 21);
            this.DoctorSelector.TabIndex = 2;
            // 
            // DoctorCalendar
            // 
            this.DoctorCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorCalendar.Location = new System.Drawing.Point(628, 12);
            this.DoctorCalendar.Name = "DoctorCalendar";
            this.DoctorCalendar.TabIndex = 1;
            // 
            // DoctorSchedule
            // 
            this.DoctorSchedule.AllowUserToAddRows = false;
            this.DoctorSchedule.AllowUserToDeleteRows = false;
            this.DoctorSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DoctorSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.Client,
            this.phone,
            this.addres});
            this.DoctorSchedule.Location = new System.Drawing.Point(8, 12);
            this.DoctorSchedule.Name = "DoctorSchedule";
            this.DoctorSchedule.ReadOnly = true;
            this.DoctorSchedule.Size = new System.Drawing.Size(615, 421);
            this.DoctorSchedule.TabIndex = 0;
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.time.Width = 46;
            // 
            // Client
            // 
            this.Client.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Client.HeaderText = "Имя";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Client.Width = 35;
            // 
            // phone
            // 
            this.phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.phone.HeaderText = "Телефон";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.phone.Width = 58;
            // 
            // addres
            // 
            this.addres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.addres.HeaderText = "Адрес";
            this.addres.Name = "addres";
            this.addres.ReadOnly = true;
            this.addres.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.addres.Width = 44;
            // 
            // ServiceList
            // 
            this.ServiceList.Controls.Add(this.delete_service);
            this.ServiceList.Controls.Add(this.add_service);
            this.ServiceList.Controls.Add(this.ServiceListView);
            this.ServiceList.Location = new System.Drawing.Point(4, 22);
            this.ServiceList.Name = "ServiceList";
            this.ServiceList.Size = new System.Drawing.Size(801, 441);
            this.ServiceList.TabIndex = 3;
            this.ServiceList.Text = "Перечень услуг";
            this.ServiceList.UseVisualStyleBackColor = true;
            // 
            // delete_service
            // 
            this.delete_service.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delete_service.Location = new System.Drawing.Point(89, 404);
            this.delete_service.Name = "delete_service";
            this.delete_service.Size = new System.Drawing.Size(75, 23);
            this.delete_service.TabIndex = 2;
            this.delete_service.Text = "Удалить";
            this.delete_service.UseVisualStyleBackColor = true;
            this.delete_service.Click += new System.EventHandler(this.delete_service_Click);
            // 
            // add_service
            // 
            this.add_service.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add_service.Location = new System.Drawing.Point(8, 404);
            this.add_service.Name = "add_service";
            this.add_service.Size = new System.Drawing.Size(75, 23);
            this.add_service.TabIndex = 1;
            this.add_service.Text = "Добавить";
            this.add_service.UseVisualStyleBackColor = true;
            this.add_service.Click += new System.EventHandler(this.add_service_Click);
            // 
            // ServiceListView
            // 
            this.ServiceListView.AllowUserToAddRows = false;
            this.ServiceListView.AllowUserToDeleteRows = false;
            this.ServiceListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.serviceName,
            this.serviceDescr,
            this.tootType,
            this.ServicePrice});
            this.ServiceListView.Location = new System.Drawing.Point(8, 3);
            this.ServiceListView.Name = "ServiceListView";
            this.ServiceListView.ReadOnly = true;
            this.ServiceListView.Size = new System.Drawing.Size(785, 395);
            this.ServiceListView.TabIndex = 0;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "Код Услуги";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 90;
            // 
            // serviceName
            // 
            this.serviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.serviceName.HeaderText = "Наменование";
            this.serviceName.Name = "serviceName";
            this.serviceName.ReadOnly = true;
            this.serviceName.Width = 102;
            // 
            // serviceDescr
            // 
            this.serviceDescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.serviceDescr.HeaderText = "Описание";
            this.serviceDescr.Name = "serviceDescr";
            this.serviceDescr.ReadOnly = true;
            this.serviceDescr.Width = 82;
            // 
            // tootType
            // 
            this.tootType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tootType.HeaderText = "Тип зуба";
            this.tootType.Name = "tootType";
            this.tootType.ReadOnly = true;
            this.tootType.Width = 77;
            // 
            // ServicePrice
            // 
            this.ServicePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ServicePrice.HeaderText = "Цена Услуги";
            this.ServicePrice.Name = "ServicePrice";
            this.ServicePrice.ReadOnly = true;
            this.ServicePrice.Width = 97;
            // 
            // doct
            // 
            this.doct.Controls.Add(this.button2);
            this.doct.Controls.Add(this.button1);
            this.doct.Controls.Add(this.add_doctor);
            this.doct.Controls.Add(this.doctorListView);
            this.doct.Location = new System.Drawing.Point(4, 22);
            this.doct.Name = "doct";
            this.doct.Size = new System.Drawing.Size(801, 441);
            this.doct.TabIndex = 4;
            this.doct.Text = "Врачи";
            this.doct.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(170, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(89, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // add_doctor
            // 
            this.add_doctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add_doctor.Location = new System.Drawing.Point(8, 410);
            this.add_doctor.Name = "add_doctor";
            this.add_doctor.Size = new System.Drawing.Size(75, 23);
            this.add_doctor.TabIndex = 1;
            this.add_doctor.Text = "Добавить";
            this.add_doctor.UseVisualStyleBackColor = true;
            this.add_doctor.Click += new System.EventHandler(this.add_doctor_Click);
            // 
            // doctorListView
            // 
            this.doctorListView.AllowUserToAddRows = false;
            this.doctorListView.AllowUserToDeleteRows = false;
            this.doctorListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctorListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doctID,
            this.Surname,
            this.FName,
            this.Patrio,
            this.Profile,
            this.clients});
            this.doctorListView.Location = new System.Drawing.Point(8, 12);
            this.doctorListView.Name = "doctorListView";
            this.doctorListView.ReadOnly = true;
            this.doctorListView.Size = new System.Drawing.Size(785, 392);
            this.doctorListView.TabIndex = 0;
            // 
            // doctID
            // 
            this.doctID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.doctID.HeaderText = "#";
            this.doctID.Name = "doctID";
            this.doctID.ReadOnly = true;
            this.doctID.Width = 39;
            // 
            // Surname
            // 
            this.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Surname.HeaderText = "Фамилия";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            this.Surname.Width = 81;
            // 
            // FName
            // 
            this.FName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FName.HeaderText = "Имя";
            this.FName.Name = "FName";
            this.FName.ReadOnly = true;
            this.FName.Width = 54;
            // 
            // Patrio
            // 
            this.Patrio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Patrio.HeaderText = "Отчество";
            this.Patrio.Name = "Patrio";
            this.Patrio.ReadOnly = true;
            this.Patrio.Width = 79;
            // 
            // Profile
            // 
            this.Profile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Profile.HeaderText = "Профиль";
            this.Profile.Name = "Profile";
            this.Profile.ReadOnly = true;
            this.Profile.Width = 78;
            // 
            // clients
            // 
            this.clients.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clients.HeaderText = "записей на сегодня";
            this.clients.Name = "clients";
            this.clients.ReadOnly = true;
            this.clients.Width = 122;
            // 
            // profileTab
            // 
            this.profileTab.Controls.Add(this.add_Person);
            this.profileTab.Controls.Add(this.PersonalDataView);
            this.profileTab.Location = new System.Drawing.Point(4, 22);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(3);
            this.profileTab.Size = new System.Drawing.Size(801, 441);
            this.profileTab.TabIndex = 5;
            this.profileTab.Text = "Персональные данные";
            this.profileTab.UseVisualStyleBackColor = true;
            // 
            // add_Person
            // 
            this.add_Person.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add_Person.Location = new System.Drawing.Point(8, 404);
            this.add_Person.Name = "add_Person";
            this.add_Person.Size = new System.Drawing.Size(75, 23);
            this.add_Person.TabIndex = 1;
            this.add_Person.Text = "Добавить";
            this.add_Person.UseVisualStyleBackColor = true;
            this.add_Person.Click += new System.EventHandler(this.add_Person_Click);
            // 
            // PersonalDataView
            // 
            this.PersonalDataView.AllowUserToAddRows = false;
            this.PersonalDataView.AllowUserToDeleteRows = false;
            this.PersonalDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonalDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersonalDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_id,
            this.P_surname,
            this.P_name,
            this.P_patrio,
            this.P_birthday,
            this.P_phone,
            this.P_addres});
            this.PersonalDataView.Location = new System.Drawing.Point(6, 6);
            this.PersonalDataView.Name = "PersonalDataView";
            this.PersonalDataView.ReadOnly = true;
            this.PersonalDataView.Size = new System.Drawing.Size(787, 392);
            this.PersonalDataView.TabIndex = 0;
            // 
            // P_id
            // 
            this.P_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_id.HeaderText = "#";
            this.P_id.Name = "P_id";
            this.P_id.ReadOnly = true;
            this.P_id.Width = 39;
            // 
            // P_surname
            // 
            this.P_surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_surname.HeaderText = "Фамилия";
            this.P_surname.Name = "P_surname";
            this.P_surname.ReadOnly = true;
            this.P_surname.Width = 81;
            // 
            // P_name
            // 
            this.P_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_name.HeaderText = "Имя";
            this.P_name.Name = "P_name";
            this.P_name.ReadOnly = true;
            this.P_name.Width = 54;
            // 
            // P_patrio
            // 
            this.P_patrio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_patrio.HeaderText = "Отчество";
            this.P_patrio.Name = "P_patrio";
            this.P_patrio.ReadOnly = true;
            this.P_patrio.Width = 79;
            // 
            // P_birthday
            // 
            this.P_birthday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_birthday.HeaderText = "Дата рождения";
            this.P_birthday.Name = "P_birthday";
            this.P_birthday.ReadOnly = true;
            this.P_birthday.Width = 102;
            // 
            // P_phone
            // 
            this.P_phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_phone.HeaderText = "Телефон";
            this.P_phone.Name = "P_phone";
            this.P_phone.ReadOnly = true;
            this.P_phone.Width = 77;
            // 
            // P_addres
            // 
            this.P_addres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.P_addres.HeaderText = "Адрес";
            this.P_addres.Name = "P_addres";
            this.P_addres.ReadOnly = true;
            this.P_addres.Width = 63;
            // 
            // MenuItem_DB
            // 
            this.MenuItem_DB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_DB_Open,
            this.MenuItem_DB_Close,
            this.MenuItem_DB_Clear,
            this.MenuItem_DB_Backup});
            this.MenuItem_DB.Name = "MenuItem_DB";
            this.MenuItem_DB.Size = new System.Drawing.Size(86, 20);
            this.MenuItem_DB.Text = "база данных";
            // 
            // MenuItem_DB_Open
            // 
            this.MenuItem_DB_Open.Name = "MenuItem_DB_Open";
            this.MenuItem_DB_Open.Size = new System.Drawing.Size(184, 22);
            this.MenuItem_DB_Open.Text = "открыть";
            this.MenuItem_DB_Open.Click += new System.EventHandler(this.MenuItem_DB_Open_Click);
            // 
            // MenuItem_DB_Close
            // 
            this.MenuItem_DB_Close.Name = "MenuItem_DB_Close";
            this.MenuItem_DB_Close.Size = new System.Drawing.Size(184, 22);
            this.MenuItem_DB_Close.Text = "путь по умолчанию";
            this.MenuItem_DB_Close.Click += new System.EventHandler(this.MenuItem_DB_Close_Click);
            // 
            // MenuItem_DB_Clear
            // 
            this.MenuItem_DB_Clear.Name = "MenuItem_DB_Clear";
            this.MenuItem_DB_Clear.Size = new System.Drawing.Size(184, 22);
            this.MenuItem_DB_Clear.Text = "очистить";
            this.MenuItem_DB_Clear.Click += new System.EventHandler(this.MenuItem_DB_Clear_Click);
            // 
            // MenuItem_DB_Backup
            // 
            this.MenuItem_DB_Backup.Name = "MenuItem_DB_Backup";
            this.MenuItem_DB_Backup.Size = new System.Drawing.Size(184, 22);
            this.MenuItem_DB_Backup.Text = "резервировать";
            this.MenuItem_DB_Backup.Click += new System.EventHandler(this.MenuItem_DB_Backup_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_DB,
            this.UsersMenuItem,
            this.печатьToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(809, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // UsersMenuItem
            // 
            this.UsersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersViewMenuItem,
            this.UsersGroupMenuItem});
            this.UsersMenuItem.Name = "UsersMenuItem";
            this.UsersMenuItem.Size = new System.Drawing.Size(95, 20);
            this.UsersMenuItem.Text = "пользователи";
            // 
            // UsersViewMenuItem
            // 
            this.UsersViewMenuItem.Name = "UsersViewMenuItem";
            this.UsersViewMenuItem.Size = new System.Drawing.Size(129, 22);
            this.UsersViewMenuItem.Text = "просмотр";
            // 
            // UsersGroupMenuItem
            // 
            this.UsersGroupMenuItem.Name = "UsersGroupMenuItem";
            this.UsersGroupMenuItem.Size = new System.Drawing.Size(129, 22);
            this.UsersGroupMenuItem.Text = "группы";
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderPrintMenuItem,
            this.InvoicePrintMenuItem,
            this.AgreementPrintMenuItem,
            this.ServiceBlankMenuItem,
            this.templaesToolStripMenuItem});
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.печатьToolStripMenuItem.Text = "Печать";
            // 
            // OrderPrintMenuItem
            // 
            this.OrderPrintMenuItem.Name = "OrderPrintMenuItem";
            this.OrderPrintMenuItem.Size = new System.Drawing.Size(204, 22);
            this.OrderPrintMenuItem.Text = "Наряд";
            // 
            // InvoicePrintMenuItem
            // 
            this.InvoicePrintMenuItem.Name = "InvoicePrintMenuItem";
            this.InvoicePrintMenuItem.Size = new System.Drawing.Size(204, 22);
            this.InvoicePrintMenuItem.Text = "Договор";
            // 
            // AgreementPrintMenuItem
            // 
            this.AgreementPrintMenuItem.Name = "AgreementPrintMenuItem";
            this.AgreementPrintMenuItem.Size = new System.Drawing.Size(204, 22);
            this.AgreementPrintMenuItem.Text = "Соглание на обработку";
            // 
            // ServiceBlankMenuItem
            // 
            this.ServiceBlankMenuItem.Name = "ServiceBlankMenuItem";
            this.ServiceBlankMenuItem.Size = new System.Drawing.Size(204, 22);
            this.ServiceBlankMenuItem.Text = "Бланк Услуг";
            // 
            // templaesToolStripMenuItem
            // 
            this.templaesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderTemplatePathMenuItem,
            this.InvoiceTemplatePathMenuItem,
            this.agreementPathMenuItem,
            this.ServiceBlankPathMenuItem});
            this.templaesToolStripMenuItem.Name = "templaesToolStripMenuItem";
            this.templaesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.templaesToolStripMenuItem.Text = "Путь к шаблону";
            // 
            // orderTemplatePathMenuItem
            // 
            this.orderTemplatePathMenuItem.Name = "orderTemplatePathMenuItem";
            this.orderTemplatePathMenuItem.Size = new System.Drawing.Size(201, 22);
            this.orderTemplatePathMenuItem.Text = "наряд";
            this.orderTemplatePathMenuItem.Click += new System.EventHandler(this.orderTemplatePathMenuItem_Click);
            // 
            // InvoiceTemplatePathMenuItem
            // 
            this.InvoiceTemplatePathMenuItem.Name = "InvoiceTemplatePathMenuItem";
            this.InvoiceTemplatePathMenuItem.Size = new System.Drawing.Size(201, 22);
            this.InvoiceTemplatePathMenuItem.Text = "договор";
            this.InvoiceTemplatePathMenuItem.Click += new System.EventHandler(this.InvoiceTemplatePathMenuItem_Click);
            // 
            // agreementPathMenuItem
            // 
            this.agreementPathMenuItem.Name = "agreementPathMenuItem";
            this.agreementPathMenuItem.Size = new System.Drawing.Size(201, 22);
            this.agreementPathMenuItem.Text = "согласие на обработку";
            this.agreementPathMenuItem.Click += new System.EventHandler(this.agreementPathMenuItem_Click);
            // 
            // ServiceBlankPathMenuItem
            // 
            this.ServiceBlankPathMenuItem.Name = "ServiceBlankPathMenuItem";
            this.ServiceBlankPathMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ServiceBlankPathMenuItem.Text = "бланк услуг";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.orderServiceView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.orderView);
            this.splitContainer1.Size = new System.Drawing.Size(792, 398);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.TabIndex = 5;
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 491);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip2);
            this.MinimumSize = new System.Drawing.Size(825, 529);
            this.Name = "StartWindow";
            this.Text = "Журнал";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.scheduleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeTable)).EndInit();
            this.OrderaTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderServiceView)).EndInit();
            this.individual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DoctorSchedule)).EndInit();
            this.ServiceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceListView)).EndInit();
            this.doct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doctorListView)).EndInit();
            this.profileTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PersonalDataView)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage scheduleTab;
        private System.Windows.Forms.TabPage OrderaTab;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DataGridView timeTable;
        private System.Windows.Forms.DataGridView orderServiceView;
        private System.Windows.Forms.TabPage individual;
        private System.Windows.Forms.TabPage ServiceList;
        private System.Windows.Forms.TabPage doct;
        private System.Windows.Forms.DataGridView DoctorSchedule;
        private System.Windows.Forms.DataGridView ServiceListView;
        private System.Windows.Forms.MonthCalendar DoctorCalendar;
        private System.Windows.Forms.DataGridView doctorListView;
        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.ComboBox DoctorSelector;
        private System.Windows.Forms.Button add_service;
        private System.Windows.Forms.Button add_doctor;
        private System.Windows.Forms.Button add_Person;
        private System.Windows.Forms.DataGridView PersonalDataView;
        private System.Windows.Forms.Button delete_service;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DB;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DB_Open;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DB_Close;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DB_Clear;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DB_Backup;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem UsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersGroupMenuItem;
        private System.Windows.Forms.DataGridView orderView;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientID;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.Button closeOrder;
        private System.Windows.Forms.Button createOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_patrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_addres;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clients;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn issued;
        private System.Windows.Forms.DataGridViewTextBoxColumn closed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn tootType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePrice;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrderPrintMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InvoicePrintMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AgreementPrintMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templaesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderTemplatePathMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InvoiceTemplatePathMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn addres;
        private System.Windows.Forms.ToolStripMenuItem agreementPathMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServiceBlankMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServiceBlankPathMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}