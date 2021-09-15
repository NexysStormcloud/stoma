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
    public partial class ServiceDeleteForm : Form
    {
        public ServiceDeleteForm()
        {
            InitializeComponent();
        }

        private void ServiceDeleteForm_Load(object sender, EventArgs e)
        {
            List<Service> list = DBHandler.GetServiceList(true);

            SVC_Select.Items.AddRange(list.ToArray());

            SVC_Delete.Click += (object sdr, EventArgs a) =>
              {
                  if (SVC_Select.SelectedIndex < 0)
                  {
                      MessageBox.Show("Необходимо выбрать услугу!");
                      return;
                  }
                  DialogResult res = MessageBox.Show("Вы уверены что хотие удалить данную услугу?\n (услуга будет удалена для всех зубов)", "удалить услугу?", MessageBoxButtons.YesNo);

                  if (res == DialogResult.Yes)
                  {
                      string id = ((Service)SVC_Select.SelectedItem).serviceID;

                      DBHandler.RemoveService(id);

                      this.Close();
                  }
              };

        }
    }
}
