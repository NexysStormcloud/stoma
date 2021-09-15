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
    public partial class UserAddForm : Form
    {
        public UserAddForm()
        {
            InitializeComponent();
            DefineNameInput();


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

            userName.AutoCompleteCustomSource = col;
            userName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            userName.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userAdd_Click(object sender, EventArgs e)
        {
            string userInfo = userName.Text;

            if (userInfo.Contains("#"))
            {
                int? id = Tools.TryParseInt(userInfo.Substring(userInfo.IndexOf("#") + 1));
                if (id.HasValue)
                {

                    if (userLogin.Text.Length < 3)
                    {
                        MessageBox.Show("Введите логин длиннее 3х символов");
                        return;
                    }
                    if(DBHandler.CheckUser(userLogin.Text))
                    {
                        MessageBox.Show("Данный логин уже занят");
                        return;
                    }

                    if(userPass.Text.Length<1 || userPass.Text != userPass2.Text)
                    {
                        MessageBox.Show("Введённое в основном и проверочном поле должно совпадать и содержать как минимум 1 символ");
                        return;
                    }

                    DBHandler.AddUser(id.Value, userLogin.Text, userPass.Text, 0);
                    Close();
                    return;

                }
            }
            DialogResult res = MessageBox.Show("Такой записи в базе нет, добавить?", "Не найдена запись", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                AddPersonForm addForm = new AddPersonForm();
                string[] initials = userName.Text.Split();
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
    }
}
