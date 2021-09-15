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
    public partial class NewServiceForm : Form
    {
        const string id_default = "КОД УСЛУГИ";
        const string name_default = "НАИМЕНОВАНИЕ";
        const string descr_default = "ОПИСАНИЕ";
        
        public Action onAdd { get; set; }
        
        public NewServiceForm()
        {
            InitializeComponent();

            


            Tools.SetTextBoxHint(SVC_ID, id_default);
            Tools.SetTextBoxHint(SVC_caption, name_default);
            Tools.SetTextBoxHint(SVC_Descr, descr_default);
            List<ToothType> tt = new List<ToothType>();
            foreach(var pair in Settings.toothTypes)
            {
                tt.Add(new ToothType(pair.Key));
            }

            toothType.DataSource = tt;

        }

        

        private void SVC_Add_Click(object sender, EventArgs e)
        {


            string SVC_id = SVC_ID.Text;
            if (SVC_id == id_default) SVC_id = string.Empty;
            string caption = SVC_caption.Text;
            if (caption == name_default) caption = string.Empty;
            string description = SVC_Descr.Text;
            if (description == descr_default) description = string.Empty;
            float price = (float)SVC_Price.Value;

            string toothSet = ((ToothType)toothType.SelectedItem).code;
            
            if (SVC_id == string.Empty || caption == string.Empty || description == string.Empty || price <= 0)
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            DBHandler.AddServiceBunch(SVC_id, caption, description, price, toothSet);
            onAdd?.Invoke();
            Close();
        }
    }
}
