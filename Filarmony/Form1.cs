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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
            string query = $"SELECT concert.*, COALESCE(ROUND(avg_mark.avg_rating,0), 0) AS average_rating FROM concert LEFT JOIN ( SELECT name, AVG(rating) AS avg_rating FROM mark GROUP BY mark.name) AS avg_mark ON concert.name = avg_mark.name WHERE concert.start_date <= \"{time:s}\" AND concert.end_date >= \"{time:s}\"";
            MySqlDataReader list = upload.Upload(query);

            while (list.Read())
            {
                ListViewItem item = new ListViewItem(list.GetString("name"));
                item.Tag = list.GetString("id");
                picked_concert_id = list.GetString("id");
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[2];
                subItems[0] = new ListViewItem.ListViewSubItem(item, $"Рейтинг {list.GetString("average_rating")}/10");
                subItems[1] = new ListViewItem.ListViewSubItem(item, list.GetString("brief"));
                item.SubItems.Add(subItems[0]);
                item.SubItems.Add(subItems[1]);
                listView1.Items.Add(item);
            }

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            Query upload = new Query();
            string id = picked_concert_id;
            string query = $"SELECT concert.*, COALESCE(ROUND(avg_mark.avg_rating,0), 0) AS average_rating FROM concert LEFT JOIN ( SELECT name, AVG(rating) AS avg_rating FROM mark GROUP BY mark.name) AS avg_mark ON concert.name = avg_mark.name  WHERE concert.id = {id}";
            MySqlDataReader list = upload.Upload(query);

            while (list.Read())
            {
                concertNameLab.Text = list.GetString("name");
                briefBox.Text = list.GetString("brief");
                startDatePut.Text = list.GetString("start_date");
                endDatePut.Text = list.GetString("end_date");
            }

            query = $"SELECT COALESCE(ROUND(AVG(m.rating),0),0) AS average_rating FROM concert c JOIN mark m ON m.name = c.name WHERE c.id = {id} GROUP BY c.name";
            list = upload.Upload(query);

            while (list.Read())
            {
                ratingLab.Text = "Рейтинг: " + list.GetString("average_rating") + "/10";
            }

            query = $"SELECT m.feedback, m.rating FROM concert c JOIN mark m ON m.name = c.name WHERE c.id = {id} GROUP BY c.name";
            list = upload.Upload(query);

            while (list.Read())
            {
                ListViewItem item = new ListViewItem(list.GetString("rating")+"/10");
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[1];
                subItems[0] = new ListViewItem.ListViewSubItem(item, list.GetString("feedback"));
                item.SubItems.Add(subItems[0]);
                markView.Items.Add(item);
            }

            concertInfoBox.Enabled = true;
            concertInfoBox.Visible = true;
        }

        private void conDatePicker_CloseUp(object sender, EventArgs e)
        {
            LoadConcerts(conDatePicker.Value.Date);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void lkBtn_Click(object sender, EventArgs e)
        {
            MyAccount form = new MyAccount();
            form.Show();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            concertInfoBox.Enabled = false;
            concertInfoBox.Visible = false;
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            concertDiscBox.Enabled = false;
            concertDiscBox.Visible = false;
            buyBtn.Enabled = false;
            buyBtn.Visible = false;
            BackBtn.Enabled = false;
            BackBtn.Visible = false;

            seatBox.Enabled = true;
            seatBox.Visible = true;
            backToCon.Visible = true;
            backToCon.Enabled = true;

            Query upload = new Query();
            string id = picked_concert_id;
            string query = $"SELECT room.name, row_num, seat_num, price FROM ticket JOIN room ON room_id = room.id WHERE sold = 0 and concert_id = {id} ORDER BY row_num ASC, seat_num ASC";
            MySqlDataReader list = upload.Upload(query);

            while (list.Read())
            {
                ListViewItem item = new ListViewItem($"Ряд: {list.GetString("row_num")}");
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[3];
                subItems[0] = new ListViewItem.ListViewSubItem(item, $"Место: {list.GetString("seat_num")}");
                subItems[1] = new ListViewItem.ListViewSubItem(item, $"Цена: {list.GetString("price")} руб.");
                subItems[2] = new ListViewItem.ListViewSubItem(item, list.GetString("name"));
                item.SubItems.Add(subItems[0]);
                item.SubItems.Add(subItems[1]);
                item.SubItems.Add(subItems[2]);
                seatView.Items.Add(item);
            }
        }

        private void backToCon_Click(object sender, EventArgs e)
        {
            seatBox.Enabled = false;
            seatBox.Visible = false;
            backToCon.Visible = false;
            backToCon.Enabled = false;

            concertDiscBox.Enabled = true;
            concertDiscBox.Visible = true;
            buyBtn.Enabled = true;
            buyBtn.Visible = true;
            BackBtn.Enabled = true;
            BackBtn.Visible = true;
        }

        private void seatView_ItemActivate(object sender, EventArgs e)
        {
            TicketForm ticketForm = new TicketForm();
            ticketForm.ShowDialog();
        }
    }
}
