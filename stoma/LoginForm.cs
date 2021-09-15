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
    public partial class LoginForm : Form
    {
        bool warningShown = false;
        public LoginForm()
        {
            InitializeComponent();
            Settings.ReadSettings();
            DBHandler.updateDBversion();
            
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;
            string password = passField.Text;
            if (DBHandler.HasUsers())
            {



                DataModels.User logged = DBHandler.Authorize(login, password);
                if (logged != null)
                {

                    this.Hide();
                    StartWindow mainWindow = new StartWindow();
                    mainWindow.SetCurentUser(logged);
                    mainWindow.Show();
                    mainWindow.FormClosed += (object caller, FormClosedEventArgs args) =>
                    {
                        Application.Exit();
                    };

                }
                else
                {
                    if (!warningShown) ShowWarning();
                }
            }
            else
            {
                this.Hide();
                StartWindow mainWindow = new StartWindow();
                mainWindow.Show();
                mainWindow.FormClosed += (object caller, FormClosedEventArgs args) =>
                {
                    Application.Exit();
                };
            }
        }

        async void ShowWarning()
        {
            warningShown = true;
            captionBack.BackColor = Color.Red;
            loginCaption.Text = "ОШИБКА!";

            await Task.Delay(2000);

            captionBack.BackColor = SystemColors.ActiveCaption;
            loginCaption.Text = "АВТОРИЗАЦИЯ";
            warningShown = false;

        }
    }
}
