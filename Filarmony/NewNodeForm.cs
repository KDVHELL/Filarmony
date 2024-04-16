using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filarmony
{
    public partial class NewNodeForm : Form
    {
        public string customer { get; set; }
        public string concert { get; set; }
        public NewNodeForm()
        {
            InitializeComponent();
            customer = "";
            concert = "";
            customerBox.Text = customer;
            concertBox.Text = concert;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customerBox.Text == "")
            {
                MessageBox.Show("Нельзя добавить пустого покупателя!");
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
