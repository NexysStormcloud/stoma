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

    public partial class AddPersonForm : Form
    {
        const string NAME_HOLDER = "ИМЯ";
        const string PATRIO_HOLDER = "ОТЧЕСТВО";
        const string SURNAME_HOLDER = "ФАМИЛИЯ";
        const string PHONE_HOLDER = "ТЕЛЕФОН";
        const string ADDRES_HOLDER = "АДРЕС (населённый пункт, улица, дом, квартира)";
        const string ID_HOLDER = "ID ЗАПИСИ";
        const string NUM_HOLDER = "НОМЕР";
        const string SER_HOLDER = "СЕРИЯ";
        const string UFMS_HOLDER = "ПОДРАЗДЕЛЕНИЕ";
        const string UFMSCODE_HOLDER = "КОД";

        public AddPersonForm()
        {
            InitializeComponent();
        }

        public Action onAdd
        {
            get; set;
        }

        public Action onClear
        {
            get; set;
        }

        private void AddPersonForm_Load(object sender, EventArgs e)
        {



            NP_add.Click += (object s, EventArgs a) =>
            {

                onAdd?.Invoke();
            };
            NP_clear.Click += (object s, EventArgs a) =>
            {
                onClear?.Invoke();
            };
            ToolTip hint = new ToolTip();
            hint.AutoPopDelay = 5000;
            hint.InitialDelay = 1000;
            hint.ReshowDelay = 500;
            hint.ShowAlways = true;
            hint.SetToolTip(NP_idCard, "регистрационный номер записи. если оставить пустым, номер назначится автоматически");

            ToolTip hint1 = new ToolTip();
            hint1.AutoPopDelay = 5000;
            hint1.InitialDelay = 1000;
            hint1.ReshowDelay = 500;
            hint1.ShowAlways = true;
            hint.SetToolTip(NP_birthday, "дата рождения (должна быть не позже чем год назад от текущей даты)");

            ToolTip hint2 = new ToolTip();
            hint2.AutoPopDelay = 5000;
            hint2.InitialDelay = 1000;
            hint2.ReshowDelay = 500;
            hint2.ShowAlways = true;
            hint2.SetToolTip(passIssued, "дата выдачи пассорта");

            Tools.SetTextBoxHint(NP_Name, NAME_HOLDER);
            Tools.SetTextBoxHint(NP_patrio, PATRIO_HOLDER);
            Tools.SetTextBoxHint(NP_surname, SURNAME_HOLDER);
            Tools.SetTextBoxHint(NP_phone, PHONE_HOLDER);
            Tools.SetTextBoxHint(NP_idCard, ID_HOLDER);
            Tools.SetTextBoxHint(NP_addres, ADDRES_HOLDER);
            Tools.SetTextBoxHint(passField, NUM_HOLDER);
            Tools.SetTextBoxHint(serieField, SER_HOLDER);
            Tools.SetTextBoxHint(ufmsField, UFMS_HOLDER);
            Tools.SetTextBoxHint(ufmsCode, UFMSCODE_HOLDER);




        }

        public void EditDataFromForm(int personID)
        {
            string name = NP_Name.Text;
            string patrio = NP_patrio.Text;
            string surname = NP_surname.Text;
            DateTime birthday = NP_birthday.Value;
            string phone = NP_phone.Text;
            string addres = NP_addres.Text;
            string serie = serieField.Text;
            string num = passField.Text;
            string ufms = ufmsField.Text;
            string ufmsC = ufmsCode.Text;
            DateTime issued = passIssued.Value;

            if((DateTime.Today - birthday.Date) < TimeSpan.FromDays(365))
            {
                birthday = DateTime.MinValue;
            }

            if (name == string.Empty || surname == string.Empty)
            {
                MessageBox.Show("Введите корректные данные имени и фамилии");
                return;
            }
            string mess = string.Format("Изменить запись {0}: {1} {2} {3},\n дата рождения: {4}, телефон:{5},\n адрес: {6}\n Пассорт серия{7}, номер{8} \n выдан {11} {9} код подраздления {10}\n Всё верно?",
                personID, name, patrio, surname, birthday==DateTime.MinValue?"не указана":birthday.ToShortDateString(), phone, addres, serie, num, ufms, ufmsC, issued.ToShortDateString() );
            DialogResult res = MessageBox.Show(mess, "Редактирование записи", MessageBoxButtons.YesNo);


            if (res == DialogResult.Yes)
            {
                DBHandler.EditPersonRecord(personID, name, patrio, surname, birthday, phone, addres);
                if(serie!="" && num!="" && ufms!="" && ufmsC!="")
                {
                    DBHandler.EditPersonAdv(personID, num, serie, ufms, ufmsC, issued);
                }
                this.Close();
            }




        }
        
        public void SetButtonNames(string add, string clear)
        {
            if (add != null) NP_add.Text = add;
            if (clear != null) NP_clear.Text = clear;
        }


        public void AddDataFromForm()
        {
            string name = NP_Name.Text;
            string patrio = NP_patrio.Text;
            string surname = NP_surname.Text;
            if (name == NAME_HOLDER) name = string.Empty;
            if (patrio == PATRIO_HOLDER) patrio = string.Empty;
            if (surname == SURNAME_HOLDER) surname = string.Empty;
            DateTime birthday = NP_birthday.Value;
            if((DateTime.Today - birthday.Date) < TimeSpan.FromDays(365))
            {
                birthday = DateTime.MinValue;
            }
            string phone = NP_phone.Text;
            string addres = NP_addres.Text;
            if (phone == PHONE_HOLDER) phone = string.Empty;
            if (addres == string.Empty) addres = string.Empty;
            string num = passField.Text;
            if (num == NUM_HOLDER) num = string.Empty;
            string serie = serieField.Text;
            if (serie == SER_HOLDER) serie = string.Empty;
            string ufms = ufmsField.Text;
            if (ufms == UFMS_HOLDER) ufms = string.Empty;

            string ufmsC = ufmsCode.Text;
            if (ufmsC == UFMSCODE_HOLDER) ufmsC = string.Empty;

            DateTime issued = passIssued.Value;
            if ((DateTime.Today - issued.Date) < TimeSpan.FromDays(365))
            {
                issued = DateTime.MinValue;
            }



            if (name==string.Empty || surname==string.Empty)
            {
                MessageBox.Show("Введите корректные данные имени и фамилии");
                return;
            }
            
            int? id = Tools.TryParseInt(NP_idCard.Text);
            if (!id.HasValue) id = -1;

            Person newPerson = new Person(id.Value, name, patrio, surname, phone, addres, birthday.Ticks);

            int personID = DBHandler.RegisterNewPerson(newPerson);
            if (num != "" && serie != "" && ufms != "" && ufmsC != "" && issued != DateTime.MinValue && personID>=0)
            {
                DBHandler.EditPersonAdv(personID, num, serie, ufms, ufmsC, issued);
            }

            this.Close();



        }
        

        public void SetInitialData(string name, string patrio, string surname)
        {

            ResetToInitial(null, name, patrio, surname);
            
        }

        public void SetInitialData(params object[] par)
        {
            ResetToInitial(par);
        }

        void setPar<T>(object value, out T par, T resetValue)
        {
            if (value == null) par = resetValue;
            else
            try
            {
                par = (T)value;
            }
            catch
            {
                par = resetValue;
            }
        }

        void ResetToInitial(params object[] par)
        {
            //string name = NAME_HOLDER;
            //string patrio = PATRIO_HOLDER;
            //string surname = SURNAME_HOLDER;
            //string id = ID_HOLDER;
            //string addres = ADDRES_HOLDER;
            //string phone = PHONE_HOLDER;
            //DateTime birthday = DateTime.Now;
            dynamic[] values =
            {ID_HOLDER, NAME_HOLDER, PATRIO_HOLDER, SURNAME_HOLDER,  DateTime.Now.Ticks, PHONE_HOLDER, ADDRES_HOLDER, NUM_HOLDER, SER_HOLDER, UFMS_HOLDER, UFMSCODE_HOLDER, DateTime.Now.Ticks };

            for(int i =0; i<par.Length && i<values.Length; i++)
            {
                setPar(par[i], out values[i], values[i]);
            }

            //if (par.Length > 0 && par[0]!=null && par[0].ToString()!=string.Empty) id = par[0].ToString();
            //if (par.Length > 1 && par[1] != null && par[1].ToString() != string.Empty) name = par[1].ToString();
            //if (par.Length > 2 && par[2] != null && par[2].ToString() != string.Empty) patrio = par[2].ToString();
            //if (par.Length > 3 && par[3] != null && par[3].ToString() != string.Empty) surname = par[3].ToString();
            //if (par.Length > 4 && par[4] != null && (long)par[4]>0) birthday = new DateTime( (long) par[4]);
            //if (par.Length > 5 && par[5] != null && par[5].ToString() != string.Empty) phone = par[5].ToString();
            //if (par.Length > 6 && par[6] != null && par[6].ToString() != string.Empty) addres = par[6].ToString();
            //if (par.Length > 7 && par[7] != null && par[7].ToString() != string.Empty) addres = par[6].ToString();
            //if (par.Length > 8 && par[8] != null && par[8].ToString() != string.Empty) addres = par[6].ToString();
            //if (par.Length > 9 && par[9] != null && par[9].ToString() != string.Empty) addres = par[6].ToString();
            //if (par.Length > 10 && par[10] != null && par[10].ToString() != string.Empty) addres = par[6].ToString();
            //if (par.Length > 11 && par[11] != null && par[11].ToString() != string.Empty) addres = par[6].ToString();

            NP_idCard.Text = values[0].ToString();
            NP_Name.Text = values[1];
            NP_patrio.Text = values[2];
            NP_surname.Text = values[3];
            NP_birthday.Value =values[4]==0? DateTime.Now: new DateTime(values[4]);
            NP_phone.Text = values[5];
            NP_addres.Text = values[6];
            passField.Text = values[7];
            serieField.Text = values[8];
            ufmsField.Text = values[9];
            ufmsCode.Text = values[10];
            passIssued.Value = values[11] == 0 ? DateTime.Now : new DateTime(values[11]);


        }

        
    }
}
