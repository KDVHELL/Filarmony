using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filarmony
{
    public partial class Form1 : Form
    {
        public string picked_concert_id;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void Reload()
        {
            //dataGridView1.Rows.Clear();
            //Query upload = new Query();
            //MySqlDataReader list = upload.Upload("SELECT * FROM ticket");

            //while (list.Read())
            //{
            //    dataGridView1.Rows.Add(list.GetString("id").ToString(), list.GetString("fio").ToString(), list.GetString("name").ToString(), list.GetString("row_num").ToString(), list.GetString("seat_num").ToString());
            //}
        }

        public void LoadConcerts(DateTime time)
        {
            listView1.Items.Clear();
            Query upload = new Query();
            string query = $"SELECT * FROM concert WHERE start_date <= \"{time:s}\" AND end_date >= \"{time:s}\"";
            MySqlDataReader list = upload.Upload(query);

            while (list.Read())
            {
                ListViewItem item = new ListViewItem(list.GetString("name"));
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[2];
                subItems[0] = new ListViewItem.ListViewSubItem(item, "Рейтинг 4/5");
                subItems[1] = new ListViewItem.ListViewSubItem(item, list.GetString("brief"));
                item.SubItems.Add(subItems[0]);
                item.SubItems.Add(subItems[1]);
                listView1.Items.Add(item);
            }

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {

        }

        private void conDatePicker_CloseUp(object sender, EventArgs e)
        {
            LoadConcerts(conDatePicker.Value.Date);
        }
    }
}
