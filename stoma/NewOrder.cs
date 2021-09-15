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
    public partial class NewOrder : Form
    {
        List<OrderService> serviceList = new List<OrderService>();
        int clientID = 1;
        List<CheckBox> toothBoxes;
        public NewOrder()
        {
            InitializeComponent();
            serviceSelector.Enabled = false;
            toothSelector.Enabled = false;
            doctorSelector.Enabled = false;
            discountSet.Enabled = false;
            append.Enabled = false;
            toothBoxes = new List<CheckBox>()
            {
                ul1,ul2,ul3,ul4,ul5,ul6,ul7,ul8,
                ur1,ur2,ur3,ur4,ur5,ur6,ur7,ur8,
                lr1,lr2,lr3,lr4,lr5,lr6,lr7,lr8,
                ll1,ll2,ll3,ll4,ll5,ll6,ll7,ll8
            };

            Tools.SetTextBoxHint(clientName, "ФИО клиента");
            
            DefineNameInput();

            ServiceLister.CellClick += (object sender, DataGridViewCellEventArgs e) =>
            {
                if (e.ColumnIndex == 6 && e.RowIndex>=0 && e.RowIndex<serviceList.Count)
                {
                    serviceList.RemoveAt(e.RowIndex);
                    updateGridView();
                }
            };

            clientName.TextChanged += (object sender, EventArgs e) =>
            {
                if (clientName.Text.Contains("#"))
                {

                    int? id = Tools.TryParseInt(clientName.Text.Substring(clientName.Text.IndexOf("#")+1));
                    if (id.HasValue)
                    {
                        clientID = id.Value;
                        serviceSelector.Enabled = true;
                        DefineServiceList();
                        return;
                    }

                }
                serviceSelector.Enabled = false;
                clientID = -1;
            };
            serviceSelector.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                  if (serviceSelector.SelectedIndex >= 0)
                  {
                      toothSelector.Enabled = true;
                      DefineToothType(((Service)serviceSelector.SelectedItem).serviceID);
                      return;
                  }
                  toothSelector.Enabled = false;
            };
            toothSelector.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                if (toothSelector.SelectedIndex >= 0)
                {
                    doctorSelector.Enabled = true;
                    DefineDoctorList();
                    return;
                }
                doctorSelector.Enabled = false;
            };
            doctorSelector.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                if (doctorSelector.SelectedIndex >= 0)
                {
                    discountSet.Enabled = true;
                    discountSet.Value = 1;
                    append.Enabled = true;
                    return;
                }
                discountSet.Enabled = false;
                append.Enabled = false;
            };





        }

        void DefineServiceList()
        {
            serviceSelector.DataSource = DBHandler.GetServiceList(true);
            
        }

        void DefineToothType(string serviceID)
        {
            toothSelector.Enabled = true;
            toothSelector.DataSource = DBHandler.GetServiceToothList(serviceID);
        }

        void DefineDoctorList()
        {
            doctorSelector.Enabled = true;
            doctorSelector.DataSource = DBHandler.GetDoctors();
        }

       

        void updateGridView()
        {
            ServiceLister.Rows.Clear();
            float price = 0;
            serviceList.ForEach(S =>
            {
                
                string tooth = Settings.toothTypes.ContainsKey(S.toothType)? Settings.toothTypes[S.toothType]:"-";
                string toothName = "-";
                if (Settings.toothNames.ContainsKey(S.toothName)) toothName = Settings.toothNames[S.toothName];
                ServiceLister.Rows.Add(S.serviceID, toothName, tooth, S.doctorID, S.servicePrice, S.discount, "убрать");
                price += S.servicePrice * S.discount;

            });
            ServiceLister.Rows.Add(null, null,null,  "Итого с учётом К:", price);
        }


        private void add_Click(object sender, EventArgs e)
        {
            if (clientID < 0)
            {
                MessageBox.Show("Клиент в базе не обнаружен");
                return;

            }
            if(serviceList.Count<=0)
            {
                MessageBox.Show("Необходимо добавить услугу в наряд");
                return;
            }
            DBHandler.CreateNewOrder(clientID, serviceList, clientName.Text);
            Close();
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

            

            clientName.AutoCompleteCustomSource = col;
            clientName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            clientName.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private void append_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();  

            toothBoxes.ForEach(tn =>
            {
                if (tn.Checked) selected.Add(tn.Name);
            });

            if (selected.Count <= 0)
            {
                selected.Add("-");
            }

            selected.ForEach(S =>
            {
                serviceList.Add(new OrderService(((Service)serviceSelector.SelectedItem).serviceID, ((ToothType)toothSelector.SelectedItem).code, ((Doctor)doctorSelector.SelectedItem).id, (float)discountSet.Value, S));
            });

            
            updateGridView();
        }

        private void ServiceLister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
