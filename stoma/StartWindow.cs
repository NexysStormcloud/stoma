using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stoma.DataModels;



namespace stoma
{
    
    
    public partial class StartWindow : Form
    {

        string[] personViewFilters =
        {
            "","","","","","",""
        };
        string[] orderFilter = { "", "" };
        
        

        public StartWindow()
        {
            InitializeComponent();

        }

        User user;

        Action[] tabRefresher;

        Dictionary<string, scheduleRecord> CellRecord = new Dictionary<string, scheduleRecord>();

        List<scheduleRecord> schedule = new List<scheduleRecord>();

        private void StartWindow_Load(object sender, EventArgs e)
        {
            //Timer update = new Timer();
            //update.Interval = 1000;

            //update.Tick += (object s, EventArgs a) => {
            //    ticks.Text = DateTime.Now.Ticks.ToString();
            //};
            //update.Start();
            

            tabRefresher = new Action[]
            {
                ()=>{ UpdateTimeTable(this, new DateRangeEventArgs(calendar.SelectionStart.Date, calendar.SelectionStart.Date.AddDays(1)));},
                ()=>{ UpdateOrderList(); UpdateServiceTab(); },
                ()=>{UpdateDoctorSelector(); RefreshDoctSchedule(); },
                ()=>{UpdateServiceList(); },
                ()=>{UpdateDoctorsList(); },
                ()=>{ UpdatePersonView(surnameFilter:personViewFilters[1], nameFilter:personViewFilters[2],patrioFilter: personViewFilters[3], phoneFilter: personViewFilters[5], addresFilter:personViewFilters[6]); }
            };

            DoctorSelector.SelectedIndexChanged += (object sdr, EventArgs a) => {
                RefreshDoctSchedule();
            };

            DoctorCalendar.DateSelected += (object sdr, DateRangeEventArgs a) =>
              {
                  RefreshDoctSchedule();
              };

            tabControl1.Selected += RefreshTab;
            //PersonalDataView.CellClick += OnPersonalDataViewClick;
            PersonalDataView.CellMouseDoubleClick += OnPersonalDataViewClick;
            PersonalDataView.CellMouseClick += OnPersonalDataSearch;


            //UpdateTimeTable(this, new DateRangeEventArgs(DateTime.Now.Date, DateTime.Now.AddDays(1).Date));

            calendar.DateSelected += UpdateTimeTable;

            timeTable.CellClick += OnCellClick;



            DBHandler.onScheduleChanded += UpdateTimeTable;

            calendar.MouseLeave += (object s, EventArgs a) => {
                if(ActiveForm==this)
                timeTable.Focus();
            };

            calendar.SetDate(DateTime.Now.Date);

            ServiceListView.CellMouseClick += (object sdr, DataGridViewCellMouseEventArgs a) =>
              {
                  if (a.Button == MouseButtons.Right&&a.RowIndex>=0)
                  {
                      string serviceID = ServiceListView.Rows[a.RowIndex].Cells[0].Value.ToString();
                      string toothType = ServiceListView.Rows[a.RowIndex].Cells[3].Value.ToString();

                      DialogResult res = MessageBox.Show(string.Format("Удалить услугу {0} ? (будет удалена услуга только для зуба {1})",serviceID,toothType),"удаление услуги",MessageBoxButtons.YesNo);
                      if (res == DialogResult.Yes)
                      {
                          

                          DBHandler.RemoveService(serviceID, toothType);
                          Focus();
                          UpdateServiceList();
                      }
                  }
                  

              };

            UsersViewMenuItem.Click += (object sdr, EventArgs a) =>
              {
                  UsersForm viewForm = new UsersForm();

                  viewForm.Show();

              };

            UsersGroupMenuItem.Click += (object sdr, EventArgs a) =>
            {

            };
            initOrderList();

            orderView.CellMouseClick += (object sdr, DataGridViewCellMouseEventArgs a) =>
              {

                  if (a.RowIndex < 0)
                  {
                      if (a.Button == MouseButtons.Right && a.ColumnIndex >= 0)
                      {
                          FilterWindow W = new FilterWindow();
                          W.StartPosition = FormStartPosition.Manual;
                          W.Location = Cursor.Position;
                          W.TopMost = true;
                          W.SetInitial(orderFilter[a.ColumnIndex]);
                          W.OnEdit += (string value) => {
                              orderFilter[a.ColumnIndex] = value;
                              UpdateOrderList(orderFilter:orderFilter[0], contentFilter:orderFilter[1]);

                          };
                          W.MouseLeave += (object s, EventArgs ab) => { W.Close(); };
                          W.Show();


                      }
                      return;
                  }



              };

            OrderPrintMenuItem.Click += OrderPrintClick;
            InvoicePrintMenuItem.Click += InvoicePrintClick;
            //this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            SetMenuAgreement();
            SetMenuBlank();
            
            
            
        }

        void SetMenuBlank()
        {
            ServiceBlankMenuItem.DropDownItems.Clear();
            ServiceBlankPathMenuItem.DropDownItems.Clear();

            //ToolStripItem add = new ToolStripMenuItem("Добавить");
            //add.Name = "ServiceBlankPathAddMenuItem";
            //add.Click += (object s, EventArgs a) =>
            //{



            //};

            //ServiceBlankPathMenuItem.DropDownItems.Add(add);

            foreach (var rec in Settings.TemplatePath)
            {
                if (rec.Key.Contains("ServiceBlank"))
                {
                    string[] split = rec.Key.Split('.');
                    ToolStripItem n = new ToolStripMenuItem(split[1]);
                    n.Name = rec.Key;
                    n.Click += (object s, EventArgs a) =>
                    {
                        ServiceBlankPrint(rec.Key);
                    };
                    ServiceBlankMenuItem.DropDownItems.Add(n);
                    ToolStripItem p = new ToolStripMenuItem(split[1]);
                    p.Name = rec.Key+"_path";
                    p.Click += (object s, EventArgs a) =>
                    {
                        SetBlankPath(split[1]);


                    };
                    ServiceBlankPathMenuItem.DropDownItems.Add(p);

                }
            }
        }

        void SetBlankPath(string sub)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.doc, *.docx)|*.doc;*.docx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;
                Settings.StoreTemplatePath(filePath, "ServiceBlank",sub);
                Settings.TemplatePath["ServiceBlank."+sub] = filePath;
                //Read the contents of the file into a stream

            }
        }

        void SetMenuAgreement()
        {
            agreementPathMenuItem.DropDownItems.Clear();
            List<Doctor> doc = DBHandler.GetDoctors();
            doc.ForEach(D =>
            {
                ToolStripItem i = new ToolStripMenuItem(D.lastName);
                i.Name = D.id.ToString();
                i.Text = D.firstName[0] + "." + D.patrioName[0] + ". " + D.lastName;

                i.Click += (object s, EventArgs a) =>
                {
                    AgreementPrint(D);
                };

                AgreementPrintMenuItem.DropDownItems.Add(i);
            });
        }

        void initOrderList()
        {
            orderView.SelectionChanged += (object sender, EventArgs e) => {
                HashSet<int> selected = new HashSet<int>();
                HashSet<int> rows = new HashSet<int>();
                foreach(DataGridViewCell cell in orderView.SelectedCells)
                {
                    if (!rows.Contains(cell.RowIndex))
                    {
                        rows.Add(cell.RowIndex);
                        selected.Add((int)(orderView.Rows[cell.RowIndex].Cells[0].Value));
                    }
                }


                UpdateServiceTab(selected);
            };

            

        }

        public void SetCurentUser(User user)
        {
            string logined = "";
            this.user = user;
            if(user!=null) logined = "(выпполнен вход:"+ user.ToString() +")";

            Text = string.Format("Журнал {0}", logined);
        }

        void OnPersonalDataSearch(object senderm, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                if (e.Button == MouseButtons.Right && e.ColumnIndex >= 0)
                {
                    FilterWindow W = new FilterWindow();
                    W.StartPosition = FormStartPosition.Manual;
                    W.Location = Cursor.Position;
                    W.TopMost = true;
                    W.SetInitial(personViewFilters[e.ColumnIndex]);
                    W.OnEdit += (string value) => {
                        personViewFilters[e.ColumnIndex] = value;
                        UpdatePersonView(surnameFilter: personViewFilters[1], nameFilter: personViewFilters[2], patrioFilter: personViewFilters[3], phoneFilter: personViewFilters[5], addresFilter: personViewFilters[6]);

                    };
                    W.MouseLeave += (object s, EventArgs a) => { W.Close(); };
                    W.Show();


                }
                return;
            }
        }

        void OnPersonalDataViewClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            int? personID = Tools.TryParseInt(PersonalDataView.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (personID.HasValue)
            {
                Person record = DBHandler.GetPerson(personID.Value);
                PersonView PV = new PersonView();

                PV.UpdateView(record.personID,
                    (object s, EventArgs a) =>
                    {
                        string message = string.Format("Удалить запись {0} из базы?", personID);
                        DialogResult res = MessageBox.Show(message, "Удаление записи из базы", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            DBHandler.RemovePersonRecord(personID.Value);
                            UpdatePersonView();
                            PV.Close();
                        }
                    },
                    (object s, EventArgs a) =>
                    {
                        AddPersonForm addForm = new AddPersonForm();

                        addForm.SetInitialData(record.personID,
                            record.FirstName,
                            record.PatrioName,
                            record.LastName,
                            record.Birthday,
                            record.Phone,
                            record.Address,
                            record.passport,
                            record.serie,
                            record.ufms,
                            record.ufmsCode,
                            record.passIssued);
                            
                        addForm.onClear = () =>
                        {
                            addForm.SetInitialData(record.personID,
                            record.FirstName,
                            record.PatrioName,
                            record.LastName,
                            record.Birthday,
                            record.Phone,
                            record.Address,
                            record.passport,
                            record.serie,
                            record.ufms,
                            record.ufmsCode,
                            record.passIssued);
                        };

                        addForm.SetButtonNames("Применить", "Сбросить");

                        addForm.onAdd = () =>
                        {
                            addForm.EditDataFromForm(record.personID);
                            UpdatePersonView();
                            PV.Close();
                        };

                        addForm.Show();
                        
                    });
                PV.Show();
            }
        }

        void UpdateOrderList(string orderFilter="", string contentFilter = "")
        {
            List<Order> orders = DBHandler.GetOrders();
            orderView.Rows.Clear();
            orders.ForEach(O =>
            {
                if(O.Client().ToLower().Contains(contentFilter.ToLower()) && O.orderID.ToString().Contains(orderFilter)) orderView.Rows.Add(O.orderID, O.Client());
            });
        }

        void UpdateServiceTab(HashSet<int> indexes =null)
        {
            orderServiceView.Rows.Clear();
            List<ServiceView> list = DBHandler.GetOrderedServiceList();
            
            int lastID = -1;
            float price = 0;
            


            list.ForEach(L =>
            {
                if (indexes == null || indexes.Contains(L.orderID))
                {
                    if (lastID != L.orderID)
                    {
                        string closed = L.orderClosed == null ? "Ждет оплаты" : L.orderClosed.ToString();
                        if (price > 0)
                        {
                            orderServiceView.Rows.Add(null, null, null, null, null, "Итого:", price);
                            price = 0;
                        }
                        orderServiceView.Rows.Add(
                            L.orderID, L.client, L.orderOpen, closed);
                        lastID = L.orderID;

                        int index = orderServiceView.Rows.Add(null, "Код услуги", "Наименование", "Врач","Зуб", "Тип", "Описание", "Стоимость", "с учётом коэффициента");
                        orderServiceView.Rows[index].DefaultCellStyle.ForeColor = Color.Gray;
                    }

                    string tooth = Settings.toothTypes.ContainsKey(L.toothType)? Settings.toothTypes[L.toothType]:"?";
                    string toothName = "-";
                    if (Settings.toothNames.ContainsKey(L.toothName))
                     toothName = Settings.toothNames[L.toothName];
                    
                    orderServiceView.Rows.Add(null, L.serviceID, L.serviceName, L.doctor,toothName, tooth, L.serviceDescr, L.price, L.price * L.discount);
                    price += L.price * L.discount;
                }

            });
            if (price > 0)
            {
                orderServiceView.Rows.Add(null, null, null, null, null,null, "Итого:",null, price);
                price = 0;
            }
        }

        void RefreshTab(object sender, TabControlEventArgs a)
        {
            if (a.TabPageIndex < tabRefresher.Length)
            {
                tabRefresher[a.TabPageIndex]();
            }
        }

        void UpdateDoctorSelector()
        {
            DoctorSelector.Items.Clear();
            DoctorSelector.Items.AddRange(DBHandler.GetDoctors().ToArray());
        }

        void RefreshDoctSchedule()
        {
            
            List<DoctorScheduleRecord> records = DBHandler.GetDoctorsSchedule();            

            if (DoctorSelector.SelectedIndex >= 0)
            {

                int ID = ((Doctor)DoctorSelector.SelectedItem).id;


                DoctorSchedule.Rows.Clear();
                DateTime last = DateTime.MinValue;
                
                records.ForEach(R =>
                {

                    if (R.doctID == ID && R.time >= DoctorCalendar.SelectionStart && R.time <= DoctorCalendar.SelectionEnd)
                    {
                        if((R.time-last).TotalMinutes>Settings.MINUTES_PER_PATIENT)
                        {
                            DoctorSchedule.Rows.Add("");
                            if (last.Date != R.time.Date)
                            {                               
                                
                                int index=DoctorSchedule.Rows.Add( "", "", R.time.Date.ToLongDateString());
                                DoctorSchedule.Rows[index].DefaultCellStyle.BackColor = Color.DarkGray;
                                

                            }
                            
                            
                            
                        }
                        last = R.time;
                        DoctorSchedule.Rows.Add(R.time.ToShortDateString() + " " + R.time.ToShortTimeString(), R.name, R.phone, R.addres);
                    }

                });
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            DBHandler.onScheduleChanded -= UpdateTimeTable;
            base.OnClosed(e);
        }

        void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            string key = e.RowIndex + ":" + e.ColumnIndex;
            if (CellRecord.ContainsKey(key))
            {
                ShowRecordDetail(CellRecord[key]);
            }
            else
            {
                ShowAddSchedule(e);
            }

        }

        void ShowRecordDetail(scheduleRecord id)
        {
            PersonView PV = new PersonView();
            PV.UpdateView(id.personID, 
                (object sender, EventArgs e)=> {
                    string message = string.Format("Удалить запись {0} на {1}?", id.personName, id.timeString);
                    DialogResult res = MessageBox.Show(message, "Удаление записи", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        DBHandler.RemoveScheduleRecord(id.recordID);
                        PV.Close();
                    }
                    
                    
                }, 
                null);
            PV.Show();
        }

        void ShowAddSchedule(DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DateTime time = ((DateTime)timeTable.Rows[e.RowIndex].Cells[0].Value);
                if (time < DateTime.Now)
                {
                    DialogResult r = MessageBox.Show("назначенное время записи уже истекло. всё равно добавить?", "ВНИМАНИЕ", MessageBoxButtons.YesNo);
                    if (r == DialogResult.No) return;

                }

                int? doctID = Tools.TryParseInt(timeTable.Columns[e.ColumnIndex].Name);
                if (doctID.HasValue)
                {
                    ScheduleAdd schedule = new ScheduleAdd();
                    schedule.UpdateView(time, doctID.Value);
                    schedule.Show();
                }
                
            }
        }

        private void UpdateCalendar()
        {
            schedule.Clear();
            schedule = DBHandler.getSchedule();
            schedule.ForEach(F =>
            {
                calendar.AddBoldedDate(new DateTime(F.timeMark));
            });
        }

        private void DrawScheduleTable()
        {
            UpdateCalendar();
            timeTable.Columns.Clear();
            timeTable.Columns.Add("time", "Время");
            timeTable.Columns[0].DefaultCellStyle.Format = "dd.MM HH:mm";
            List<Doctor> doctors = DBHandler.GetDoctors();
            //MessageBox.Show(doctors.Count.ToString());
            doctors.ForEach(D =>
            {
                timeTable.Columns.Add(D.id.ToString(), string.Format("{2}.{3} {1} {0}", D.profile, D.lastName, D.firstName.Substring(0,1),D.patrioName.Substring(0,1)));
            });
            
        }

        private void UpdateTimeTable(object sender, EventArgs e)
        {
           
            DateRangeEventArgs a = new DateRangeEventArgs(calendar.SelectionStart.Date, calendar.SelectionStart.Date.AddDays(1));
            //MessageBox.Show(a.Start + "-" + a.End);
            UpdateTimeTable(calendar, a);
        }

        private void UpdateTimeTable(object sender, DateRangeEventArgs e)
        {
            
            CellRecord.Clear();
            DrawScheduleTable();
            timeTable.Rows.Clear();
            
            List<scheduleRecord> inRange = schedule.FindAll(F => F.timeMark > e.Start.Ticks && F.timeMark < e.End.Ticks);
            //MessageBox.Show(inRange.Count + " " + schedule.Count+" "+Application.ExecutablePath);
            int rowIndex = 0;
            for (int i =(int) Settings.DAY_BEGIN_HOUR*60; i<Settings.DAY_END_HOUR*60; i += Settings.MINUTES_PER_PATIENT)
            {
                DateTime seg = e.Start.Date.AddMinutes(i);
                object[] row = new object[timeTable.Columns.Count];
                row[0] = seg;
                while(inRange.Count>0 && inRange[0].timeMark>=seg.Ticks && inRange[0].timeMark < seg.AddMinutes(Settings.MINUTES_PER_PATIENT).Ticks)
                {
                    
                    for(int j = 1; j<timeTable.Columns.Count; j++)
                    {
                        int colIndex = int.Parse(timeTable.Columns[j].Name);
                        if (inRange[0].docID == colIndex)
                        {
                            row[j] = inRange[0].personName;
                            CellRecord.Add(rowIndex + ":" + j, inRange[0]);
                        }
                    }
                    inRange.RemoveAt(0);
                }

                rowIndex++;
                int index = timeTable.Rows.Add(row);
                if (seg < DateTime.Now) timeTable.Rows[index].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                if(DateTime.Now>seg && DateTime.Now<seg.AddMinutes(Settings.MINUTES_PER_PATIENT))
                {
                    timeTable.Rows[index].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
            timeTable.AutoResizeColumns();
            foreach(DataGridViewColumn col in timeTable.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        void UpdatePersonView(string addresFilter="", string surnameFilter = "", string nameFilter="", string patrioFilter="",  string phoneFilter = "")
        {
            List<Person> persons = DBHandler.GetPersonList();
            PersonalDataView.Rows.Clear();
            persons.ForEach(P =>
            {
                if (P.FirstName.ToLower().Contains(nameFilter.ToLower()) 
                && P.PatrioName.ToLower().Contains(patrioFilter.ToLower()) 
                && P.LastName.ToLower().Contains(surnameFilter.ToLower()) 
                && P.Phone.ToLower().Contains(phoneFilter.ToLower())
                && P.Address.ToLower().Contains(addresFilter.ToLower()))
                {
                    string birthday = P.Birthday > 0 ? new DateTime(P.Birthday).Date.ToLongDateString() : "Не указано";
                    string phone = P.Phone == string.Empty ? "Не указан" : P.Phone;
                    int index = PersonalDataView.Rows.Add(P.personID, P.LastName, P.FirstName, P.PatrioName, birthday, phone, P.Address);
                }
                

            });
            
        }

        void UpdateDoctorsList()
        {
            List<Doctor> list = DBHandler.GetDoctors();
            doctorListView.Rows.Clear();
            list.ForEach(D =>
            {
                doctorListView.Rows.Add(D.id, D.lastName, D.firstName, D.patrioName,  D.profile, D.todayClients);
            });

        }

        void UpdateServiceList()
        {
            List<Service> services = DBHandler.GetServiceList();
            ServiceListView.Rows.Clear();
            services.ForEach(S =>
            {
                
                string tooth = Settings.toothTypes.ContainsKey(S.toothtype) ? Settings.toothTypes[S.toothtype] : "?";
                ServiceListView.Rows.Add(S.serviceID, S.serviceName, S.serviceDescription, tooth, S.price);

            });
        }

        private void add_Person_Click(object sender, EventArgs e)
        {
            AddPersonForm addForm = new AddPersonForm();
           

            addForm.SetInitialData();
            addForm.onClear = () => { addForm.SetInitialData(); };


            addForm.onAdd = () => { addForm.AddDataFromForm(); };
            addForm.FormClosed += (object sdr, FormClosedEventArgs a1) => { this.Focus();  UpdatePersonView(); };
            addForm.Show();
        }

        private void add_doctor_Click(object sender, EventArgs e)
        {
            AddDoctorForm addForm = new AddDoctorForm();
            addForm.onAdd = () => { addForm.AddFN(); };
            addForm.FormClosed += (object sdr, FormClosedEventArgs a1) => { this.Focus(); UpdateDoctorsList(); };
            addForm.Show();
        }

        private void add_service_Click(object sender, EventArgs e)
        {
            NewServiceForm addSVC = new NewServiceForm();
            addSVC.onAdd = () => { Focus(); UpdateServiceList(); };
            addSVC.Show();
        }

        private void delete_service_Click(object sender, EventArgs e)
        {
            ServiceDeleteForm deleteForm = new ServiceDeleteForm();
            deleteForm.FormClosed += (object sdr, FormClosedEventArgs a) => {
                Focus();
                UpdateServiceList();
            };
            deleteForm.Show();
        }

        private void createOrder_Click(object sender, EventArgs e)
        {
            NewOrder orderForm = new NewOrder();
            orderForm.FormClosed += (object sdr, FormClosedEventArgs a) =>
              {
                  UpdateOrderList();
                  UpdateServiceTab();
              };
            orderForm.Show();
        }

        private void closeOrder_Click(object sender, EventArgs e)
        {
            if (orderView.SelectedCells.Count <= 0) return;
            
            int rowIndex = orderView.SelectedCells[0].RowIndex;
            if (rowIndex < 0) return;

            int? orderID = Tools.TryParseInt(orderView.Rows[rowIndex].Cells[0].Value.ToString());
            if(orderID.HasValue)
            {
                DialogResult res = MessageBox.Show("Наряд №" + orderID + " оплачен?", "закрытие наряда", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    DBHandler.CloseOrder(orderID.Value);
                    UpdateOrderList();
                    UpdateServiceTab();
                }


            }
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            if (orderView.SelectedCells.Count <= 0) return;

            int rowIndex = orderView.SelectedCells[0].RowIndex;
            if (rowIndex < 0) return;

            int? orderID = Tools.TryParseInt(orderView.Rows[rowIndex].Cells[0].Value.ToString());
            if (orderID.HasValue)
            {
                DialogResult res = MessageBox.Show("удалить наряд №" + orderID+" из базы? (данный наряд будет окончательно удалён из базы, номер наряда будет утерян)", "удаление наряда", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    DBHandler.DeleteOrder(orderID.Value);
                    UpdateOrderList();
                    UpdateServiceTab();
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (doctorListView.SelectedCells.Count <= 0 || doctorListView.SelectedCells[0].RowIndex < 0) return;
            int? doctID = Tools.TryParseInt(doctorListView.Rows[doctorListView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            //MessageBox.Show(doctID.ToString());
            if (!doctID.HasValue) return;
            AddDoctorForm edit = new AddDoctorForm();
            edit.SetEditData(doctID.Value);
            edit.onAdd = () => { edit.EditFN(doctID.Value);  };
            edit.FormClosed += (object sdr, FormClosedEventArgs a) =>
              {
                  UpdateDoctorsList();
              };
            edit.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (doctorListView.SelectedCells.Count <= 0 || doctorListView.SelectedCells[0].RowIndex < 0) return;
            int? doctID = Tools.TryParseInt(doctorListView.Rows[doctorListView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            //MessageBox.Show(doctID.ToString());
            if (!doctID.HasValue) return;
            DialogResult res = MessageBox.Show("Удалить запись под номером " + doctID.Value + "?", "удаление профиля врача", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                DBHandler.DeleteDoctor(doctID.Value);
                UpdateDoctorsList();
            }
        }

        private void MenuItem_DB_Open_Click(object sender, EventArgs e)
        {
            
            string filePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "data base files (*.db)|*.db|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    appSetting app = new appSetting();
                    app.SaveConnectionString("Default", "Data source=" + filePath);
                    Settings.DBPath = "Data source=" + filePath;
                    DBHandler.updateDBversion();
                    MessageBox.Show("новый путь к бд: "+ filePath);
                }
            }
        }

        private void MenuItem_DB_Close_Click(object sender, EventArgs e)
        {
            appSetting app = new appSetting();
            app.SaveConnectionString("Default", "Data source=.\\stoma.db");
            Settings.DBPath = "Data source=.\\stoma.db";
            MessageBox.Show("новый путь к бд: папка приложения");
           
        }

        private void MenuItem_DB_Clear_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены? Это действие необратимо удалит все данные из базы","очистка базы данных", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                DBHandler.ClearDB();
            }
        }

        private void MenuItem_DB_Backup_Click(object sender, EventArgs e)
        {
            string prefix = "Data source=";
            string path = Settings.DBPath.Replace(prefix, "");
            SaveFileDialog sf = new SaveFileDialog();

            sf.Filter = "Data Base files (*.db)|*.db|All files (*.*)|*.*";
            sf.FilterIndex = 1;
            sf.RestoreDirectory = true;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                File.Copy(path, sf.FileName,true);
            }
        }

        

        private void OrderPrintClick(object sender, EventArgs e)
        {
            if (!Settings.TemplatePath.ContainsKey("order"))
            {
                MessageBox.Show("не задан путь к шаблону печати");
                return;
            }
            if(tabControl1.SelectedTab.Name!= "OrderaTab")
            {
                MessageBox.Show("Перейдите на вкладку 'Наряды' и выделите наряд для печати");
                return;
            }
            if (orderView.SelectedCells.Count > 0 && orderView.SelectedCells[0].RowIndex >= 0)
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {

                    Order order = DBHandler.GetOrders()[orderView.SelectedCells[0].RowIndex];
                    MessageBox.Show(ExcelPrintHandler.PrintOrder(order, Settings.TemplatePath["order"],printDialog1.PrinterSettings.PrinterName));
                }
                //if(printDialog1.ShowDialog()==DialogResult.OK)
                //{
                //    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                //    printDocument1.Print();
                //}
            }
        }

        private void InvoicePrintClick(object sender, EventArgs e)
        {
            if (!Settings.TemplatePath.ContainsKey("invoice"))
            {
                MessageBox.Show("не задан путь к шаблону печати");
                return;
            }
            if (tabControl1.SelectedTab.Name != "OrderaTab")
            {
                MessageBox.Show("Перейдите на вкладку 'Наряды' и выделите наряд для печати договора");
                return;
            }
            if (orderView.SelectedCells.Count > 0 && orderView.SelectedCells[0].RowIndex >= 0)
            {

                Order order = DBHandler.GetOrders()[orderView.SelectedCells[0].RowIndex];

                MessageBox.Show( WordPrintHandler.PrintInvoice(order));
            }




        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (orderView.SelectedCells.Count > 0 && orderView.SelectedCells[0].RowIndex >= 0)
            {
                Order order = DBHandler.GetOrders()[orderView.SelectedCells[0].RowIndex];
                Person p = DBHandler.GetPerson(order.clientID);
                List<ServiceView> svc = DBHandler.GetOrderedServiceList(order.orderID);
                Dictionary<string, string> dict = new Dictionary<string, string>()
                {
                    {"name", p.LastName+" "+p.FirstName+" "+p.PatrioName },
                    {"addres", p.Address },
                    {"cell", p.Phone },
                    {"date", order.issued.ToShortDateString() }
                };
                GrfPrintHandler.printPage(e, new PrintTemplate(Settings.TemplatePath["orderXML"], dict));
            }
        }

        private void orderTemplatePathMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;
                Settings.StoreTemplatePath(filePath, "order");
                Settings.TemplatePath["order"] = filePath;
                //Read the contents of the file into a stream
                
            }

        }

        private void InvoiceTemplatePathMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.doc, *.docx)|*.doc;*.docx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;
                Settings.StoreTemplatePath(filePath, "invoice");
                Settings.TemplatePath["invoice"] = filePath;
                //Read the contents of the file into a stream

            }
        }

        

        private void agreementPathMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.doc, *.docx)|*.doc;*.docx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;
                Settings.StoreTemplatePath(filePath, "agreement");
                Settings.TemplatePath["agreement"] = filePath;
                //Read the contents of the file into a stream

            }
        }

        private void AgreementPrint(Doctor d)
        {
            if (!Settings.TemplatePath.ContainsKey("agreement"))
            {
                MessageBox.Show("не задан путь к шаблону печати");
                return;
            }
            if (tabControl1.SelectedTab.Name != "profileTab")
            {
                MessageBox.Show("Перейдите на вкладку 'Персональные данные' и выделите профиль для печати бланка");
                return;
            }
            if (PersonalDataView.SelectedCells.Count > 0 && PersonalDataView.SelectedCells[0].RowIndex >= 0)
            {
                int? id = Tools.TryParseInt(PersonalDataView.Rows[PersonalDataView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                if (id.HasValue)
                {
                    Person p = DBHandler.GetPerson(id.Value);
                    MessageBox.Show(WordPrintHandler.PrintAgreement(p,d));

                }
            }
        }

        private void ServiceBlankPrint(string tag)
        {
            if (tabControl1.SelectedTab.Name != "profileTab")
            {
                MessageBox.Show("Перейдите на вкладку 'Персональные данные' и выделите профиль для печати бланка");
                return;
            }

            if (PersonalDataView.SelectedCells.Count > 0 && PersonalDataView.SelectedCells[0].RowIndex >= 0)
            {
                int? id = Tools.TryParseInt(PersonalDataView.Rows[PersonalDataView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                if (id.HasValue)
                {
                    Person p = DBHandler.GetPerson(id.Value);
                    MessageBox.Show(WordPrintHandler.PrintBlank(p, tag));

                }
            }
        }
    }
}
