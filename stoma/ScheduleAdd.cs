using stoma.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stoma
{
    public partial class ScheduleAdd : Form
    {
        public ScheduleAdd()
        {
            InitializeComponent();
        }

        
        int doctorID = -1;
        string serviceID = "";
        DateTime time;

        private void ScheduleAdd_Load(object sender, EventArgs e)
        {
            closeBtn.Click += (object s, EventArgs a) => {
                this.Close();
            };
            //Dictionary<int, string> doctors = DBHandler.GetDoctors();

            Tools.SetTextBoxHint(inputName, "ФИО");

            DefineNameInput();
            
            
            

            


            AddBtn.Click += (object s, EventArgs a) =>
            {
                string idstr = inputName.Text;
                int? id = idstr.IndexOf('#');
                if (id >= 0)
                {
                    idstr = idstr.Substring(id.Value+1);
                    id = Tools.TryParseInt(idstr);
                    if (id.HasValue && doctorID>=0)
                    {

                        //MessageBox.Show(string.Format("id:{0}, doctor:{1}, service:{2}, time:{3}", id, doctorID, serviceID, time));
                        int result = DBHandler.AddScheduleRecord(doctorID, id.Value, time, serviceID);
                        
                        if (result>=0)
                        {
                            this.Close();
                        }

                    }
                    
                }
                else
                {
                    DialogResult res = MessageBox.Show("Такой записи в базе нет, добавить?", "Не найдена запись", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        AddPersonForm addForm = new AddPersonForm();
                        string[] initials = inputName.Text.Split();
                        string s1 = initials.Length > 0 ? initials[0] : string.Empty;
                        string s2 = initials.Length > 1 ? initials[1] : string.Empty;
                        string s3 = initials.Length > 2 ? initials[2] : string.Empty;

                        addForm.SetInitialData(s2, s3, s1);
                        addForm.onClear = () => { addForm.SetInitialData(s2, s3, s1); };
                        
                        
                        addForm.onAdd = () => { addForm.AddDataFromForm(); };
                        addForm.FormClosed += (object sdr, FormClosedEventArgs a1) => { this.Focus(); DefineNameInput(); };
                        addForm.Show();
                    }
                }
                


            };




        }

        void DefineNameInput()
        {
            List<Person> list = DBHandler.GetPersonList();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            list.ForEach(L =>
            {
                string row = string.Format("{0} {1} {2} #{3}", L.LastName, L.FirstName, L.PatrioName, L.personID);
                col.Add(row);
            });
            //MessageBox.Show(list.Count.ToString());

            inputName.AutoCompleteCustomSource = col;
            inputName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            inputName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            
        }

        

        public void UpdateView(DateTime time, int doctID)
        {
            List<Doctor> doctors = DBHandler.GetDoctors();
            Doctor D = doctors.Find(d => d.id == doctID);
            string doctStr = string.Format("{0} {1}.{2} ({3})", D.lastName, D.firstName.Substring(0,1),D.patrioName.Substring(0,1), D.profile);
            timeLabel.Text = "Запись на: " + time.ToShortDateString() + " " + time.ToShortTimeString()+"\n врач: "+doctStr;
            doctorID = doctID;
            this.time = time;

        }
    }
}
