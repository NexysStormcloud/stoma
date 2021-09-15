using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stoma.DataModels;

namespace stoma
{
    public partial class AddDoctorForm : Form
    {
        public Action onAdd { get; set; }



        public AddDoctorForm()
        {
            InitializeComponent();
        }

        private void AddDoctorForm_Load(object sender, EventArgs e)
        {

            DefineNameInput();
            Tools.SetTextBoxHint(ND_Name, "ФИО");
            Tools.SetTextBoxHint(ND_Profile, "ПРОФИЛЬ");


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

            ND_Name.AutoCompleteCustomSource = col;
            ND_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ND_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            
        }



        private void ND_Add_Click(object sender, EventArgs e)
        {

            onAdd?.Invoke();
        }

        public void SetEditData(int doctID)
        {
            ND_Name.Enabled = false;
            Person P = DBHandler.GetPerson(doctID);
            ND_Name.Text = P.LastName + " " + P.FirstName + " " + P.PatrioName + " #" + P.personID;
            ND_Add.Text = "Применить";
        }

        public void EditFN(int doctID)
        {
            if (ND_Profile.Text == string.Empty)
            {
                MessageBox.Show("Введите название профиля врача");
                return;
            }
            DBHandler.EditDoctor(doctID, ND_Profile.Text);
            this.Close();

        }

        public void AddFN()
        {
            if (ND_Profile.Text == string.Empty)
            {
                MessageBox.Show("Введите название профиля врача");
                return;
            }
            if (ND_Name.Text.Contains("#"))
            {
                int? id = Tools.TryParseInt(ND_Name.Text.Substring(ND_Name.Text.IndexOf("#") + 1));
                if (id.HasValue)
                {
                    DBHandler.AddNewDoctor(id.Value, ND_Profile.Text);
                    this.Close();
                    return;
                }
            }
            DialogResult result = MessageBox.Show("Такой записи нет в базе, добавить?", "Не найдена запись", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AddPersonForm addForm = new AddPersonForm();
                string[] initials = ND_Name.Text.Split();
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

        private void ND_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
