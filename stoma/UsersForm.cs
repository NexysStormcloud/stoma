using stoma.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stoma
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            refresh();


        }

        public void refresh()
        {
            var con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            try
            {
                con.Open();
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ID, login, groupID, lastSession FROM Users ";
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd.CommandText, con))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    userListView.DataSource = dataTable.AsDataView();

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void userAdd_Click(object sender, EventArgs e)
        {
            UserAddForm addForm = new UserAddForm();
            addForm.FormClosed += (object sdr, FormClosedEventArgs a) =>
            {
                refresh();
            };


            addForm.Show();
        }

        private void userEdit_Click(object sender, EventArgs e)
        {
            UserEditForm userForm = new UserEditForm();
            //MessageBox.Show();
            if (userListView.SelectedCells.Count <= 0) return;
            string login = userListView.Rows[userListView.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            int id = int.Parse(userListView.Rows[userListView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            Person p = DBHandler.GetPerson(id);
            userForm.SetInitialData(p.FirstName + " " + p.LastName, login);
            userForm.Show();
            userForm.FormClosed += (object sdr, FormClosedEventArgs a) =>
            {
                refresh();
            };
        }

        private void userDelete_Click(object sender, EventArgs e)
        {
            if (userListView.SelectedCells.Count <= 0 || userListView.SelectedCells[0].RowIndex<0) return;

            int? id = Tools.TryParseInt(userListView.Rows[userListView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            if (!id.HasValue) return;


            DialogResult res = MessageBox.Show("Удалить пользователя" + id.Value + "?","удаление", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                DBHandler.DeleteUser(id.Value);
                refresh();
            }
        }
    }
}
