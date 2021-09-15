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
    public partial class FilterWindow : Form
    {
        public event Action<string> OnEdit;
        static FilterWindow active;

        public FilterWindow()
        {
            if (active != null) active.Close();

            active = this;
            InitializeComponent();
            textBox1.TextChanged += (object sender, EventArgs e) =>
            {
                  OnEdit?.Invoke(textBox1.Text);
            };
            textBox1.KeyDown += (object sender, KeyEventArgs e) =>
              {
                  if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter) Close();
              };
            
            
        }

        

        public void SetInitial(string value)
        {
            textBox1.Text = value;
        }
    }
}
