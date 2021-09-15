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
    public partial class PersonView : Form
    {
        public PersonView()
        {
            InitializeComponent();
        }

        

        private void PersonView_Load(object sender, EventArgs e)
        {

        }

        

        public void UpdateView(int personID, Action<object, EventArgs> onDeleteBtn = null, Action<object,EventArgs> onEditBtn = null)
        {
            Person person = DBHandler.GetPerson(personID);

            PV_name.Text = person.FirstName + " " + person.PatrioName + " " + person.LastName;
            PV_phone.Text ="Телефон: "+ person.Phone;
            PV_addres.Text ="Адрес: "+ person.Address;
            //MessageBox.Show(person.Birthday.ToString());

            string birthday = person.Birthday > 0 ? "Дата рождения: " + new DateTime(person.Birthday).Date.ToShortDateString() : "Дата рождения не указана";
            PV_brthday.Text = birthday;
            PV_Age.Text = person.Birthday > 0 ? "Возраст: " + (DateTime.Now.Year - new DateTime(person.Birthday).Year).ToString() : "Возраст не указан";

            if (onDeleteBtn == null) PV_Delete.Enabled = false;
            PV_EditBtn.Click += (object sender, EventArgs a) => onEditBtn?.Invoke(sender, a);
            if (onEditBtn == null) PV_EditBtn.Enabled = false;
            PV_Delete.Click += (object sender, EventArgs a) => onDeleteBtn?.Invoke(sender, a);

            PV_View.Click += (object sender, EventArgs a) => { ShowPersonSchedule(person); };

        }

        void ShowPersonSchedule(Person person)
        {
            List<scheduleRecord> List = DBHandler.getSchedule();
            List<Doctor> doctors = DBHandler.GetDoctors();
            string msg = string.Format("Записи для {0}: ",person.LastName+" "+person.FirstName[0]+". "+person.PatrioName[0]+".");
            List.ForEach(Rec =>
            {
                DateTime time = new DateTime(Rec.timeMark);
                Doctor doc = doctors.Find(d => d.id == Rec.docID);
                if (Rec.personID == person.personID && time > DateTime.Now.Date)
                    msg += string.Format("\n    {0} запись к {1}", time.ToShortDateString() + " " + time.ToShortTimeString(), doc.lastName + " " + doc.firstName[0] + ". " + doc.patrioName[0] + ". (" + doc.profile + ")");

            });
            MessageBox.Show(msg);

        }
       
    }
}
