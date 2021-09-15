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
    public partial class UserEditForm : Form
    {
        string login;

        public UserEditForm()
        {
            InitializeComponent();

        }

        public void SetInitialData(string user, string login)
        {
            Text = "пользователь " + user;
            userLogin.Text = login;
            this.login = login;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            userLogin.Text = login;
            oldPass.Text = "";
            newPass.Text = "";
            newPass2.Text = "";
        }

        private void accept_Click(object sender, EventArgs e)
        {
            User logged = DBHandler.Authorize(login, oldPass.Text);
            if (logged == null)
            {
                MessageBox.Show("Старый пароль введён не верно!");
                return;
            }
            if (newPass.Text != newPass2.Text)
            {
                MessageBox.Show("Новый пароль в основном и проверочном полях не совпадает");
                return;
            }
            if(userLogin.Text.Length<3 || newPass.Text.Length < 1)
            {
                MessageBox.Show("Логин должен содержать как минимум 3 символа, пароль как минимум 1");
                return;
            }

            DBHandler.EditUserRecord(logged.ID, userLogin.Text, newPass.Text);
            Close();
        }
    }
}
