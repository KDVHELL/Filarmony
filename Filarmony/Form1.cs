using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filarmony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            dataGridView1.Rows.Clear();
            Query upload = new Query();
            MySqlDataReader list = upload.Upload("SELECT * FROM ticket");

            while (list.Read())
            {
                dataGridView1.Rows.Add(list.GetString("id").ToString(), list.GetString("fio").ToString(), list.GetString("name").ToString(), list.GetString("row_num").ToString(), list.GetString("seat_num").ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
