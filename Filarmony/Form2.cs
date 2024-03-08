using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Filarmony
{
    public partial class Form2 : Form
    {
        MySqlDataReader list;
        string openedTable;
        List<string> columnNames = new List<string>();

        public Form2()
        {
            InitializeComponent();
        }

        public void Reload(string table, List<string> columnNames)
        {
            openedTable = table;
            dataGridView1.Rows.Clear();
            Query upload = new Query();
            string query = "SELECT * FROM " + table;
            list = upload.Upload(query);

            while (list.Read())
            {
                List<string> cell = new List<string>();
                foreach(string column in columnNames)
                    cell.Add(list.GetString(column).ToString());
                dataGridView1.Rows.Add(cell.ToArray());
            }
        }

        public void ReloadRequest(string request, List<string> columnNames)
        {
            openedTable = request;
            dataGridView1.Rows.Clear();
            Query upload = new Query();
            string query = request;
            list = upload.Upload(query);

            while (list.Read())
            {
                List<string> cell = new List<string>();
                foreach (string column in columnNames)
                    cell.Add(list.GetString(column).ToString());
                dataGridView1.Rows.Add(cell.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookingTable.Visible = false;
            bookingTable.Enabled = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("concert_id", "Concert ID");
            dataGridView1.Columns.Add("room_id", "Room ID");
            dataGridView1.Columns.Add("row_num", "Row");
            dataGridView1.Columns.Add("seat_num", "Seat");
            dataGridView1.Columns.Add("price", "Price");
            dataGridView1.Columns.Add("sold", "Sold");

            columnNames = new List<string> { "id", "concert_id", "room_id", "row_num", "seat_num", "price", "sold"};

            Reload("ticket", columnNames);

            ticketTable.Visible = true;
            ticketTable.Enabled = true;

            dataGridView1.Visible = true;

            label2.Visible = true;

            changeRow.Visible = true;
            delRow.Visible = true;
            addElem.Visible = true;
            addElem.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            concertPos.Items.Clear();
            roomPos.Items.Clear();

            List <string> list = new List<string>();
            list = GetConcertList();

            foreach (string item in list)
                concertPos.Items.Add(item);

            list = GetRoomList();

            foreach (string item in list)
                roomPos.Items.Add(item);

            label8.Text = "";

            changebtn.Visible = false;
            changeBack.Visible = false;

            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;

            concertPos.Visible = true;
            roomPos.Visible = true;

            rowPos.Visible = true;
            seatPos.Visible = true;
            pricePos.Visible = true;

            checkBox1.Visible = true;

            addRow.Visible = true;
            addBack.Visible = true;
        }

        public List<string> GetConcertList()
        { 
            List<string> list = new List<string>();

            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload("SELECT concert.id FROM concert");

            while (sqList.Read())
            {
                list.Add(sqList.GetString("id"));
            }

            return list;
        }

        public List<string> GetRoomList()
        {
            List<string> list = new List<string>();

            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload("SELECT room.id FROM room");

            while (sqList.Read())
            {
                list.Add(sqList.GetString("id"));
            }

            return list;
        }

        public List<string> GetCustomerList()
        {
            List<string> list = new List<string>();

            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload("SELECT customer.id FROM customer");

            while (sqList.Read())
            {
                list.Add(sqList.GetString("id"));
            }

            return list;
        }
        public List<string> GetTicketList()
        {
            List<string> list = new List<string>();

            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload("SELECT ticket.id FROM ticket");

            while (sqList.Read())
            {
                list.Add(sqList.GetString("id"));
            }

            return list;
        }

        public bool CheckFullyFill()
        { 
            return concertPos.SelectedText != "" && roomPos.SelectedText != "" && rowPos.Text != "" && seatPos.Text != "";
        }

        public bool IsRowExist(string[] newRecord)
        {
            bool isExist = false;

            foreach (DataGridViewRow record in dataGridView1.Rows)
            {
                if (record.IsNewRow == true) break;
                bool[] match = new bool[record.Cells.Count-1];
                for (int i = 1; i < record.Cells.Count; i++)
                {
                    if (record.Cells[i].Value != null && record.Cells[i].Value.ToString() != newRecord[i - 1])
                    {
                        match[i-1] = false;
                    }
                    else
                    {
                        match[i-1] = true;
                    }
                }

                bool allTrue = true;
                foreach (bool index in match)
                {
                    allTrue = allTrue && index;
                }

                if (allTrue) { isExist = true; break; }
            }
            
            return isExist;
        }

        public bool IsBookingExist(string[] newRecord)
        {
            bool isExist = false;

            foreach (DataGridViewRow record in dataGridView1.Rows)
            {
                if (record.IsNewRow == true) break;
                if (record.Cells[1].Value != null && record.Cells[1].Value.ToString() != newRecord[0])
                {
                    isExist = false;
                }
                else
                {
                    isExist = true;
                }

                if (isExist) break;
            }

            return isExist;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string[] newString = { concertPos.Text, roomPos.Text, rowPos.Text, seatPos.Text, pricePos.Text, checkBox1.Checked.ToString()};
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString))
            {
                label8.ForeColor = Color.Red;
                label8.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"INSERT INTO {openedTable} (concert_id, room_id, row_num, seat_num, price, sold) VALUES ({newString[0]}, {newString[1]}, {newString[2]}, {newString[3]}, {newString[4]}, {newString[5]})");
                Reload(openedTable, columnNames);
                label8.ForeColor = Color.Green;
                label8.Text = "ДОБАВЛЕНО!";
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Height = 400;

            concertPos.Items.Clear();
            roomPos.Items.Clear();

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            concertPos.Visible = false;
            roomPos.Visible = false;

            rowPos.Visible = false;
            seatPos.Visible = false;
            pricePos.Visible = false;

            checkBox1.Visible = false;

            addRow.Visible = false;
            addBack.Visible = false;
        }

        private void delRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            string query = $"DELETE FROM {openedTable} WHERE id = {row.Cells[0].Value}";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            Reload(openedTable, columnNames);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            concertPos.Items.Clear();
            roomPos.Items.Clear();

            List<string> list = new List<string>();
            list = GetConcertList();

            foreach (string item in list)
                concertPos.Items.Add(item);
            concertPos.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            list = GetRoomList();

            foreach (string item in list)
                roomPos.Items.Add(item);
            roomPos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            rowPos.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            seatPos.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pricePos.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            checkBox1.Checked = dataGridView1.CurrentRow.Cells[6].Value.ToString() == "False" ? false : true ;

            label8.Text = "";

            addRow.Visible = false;
            addBack.Visible = false;

            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;

            concertPos.Visible = true;
            roomPos.Visible = true;

            rowPos.Visible = true;
            seatPos.Visible = true;
            pricePos.Visible = true;

            checkBox1.Visible = true;

            changebtn.Visible = true;
            changeBack.Visible = true;
        }

        private void changeBack_Click(object sender, EventArgs e)
        {
            this.Height = 400;

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            concertPos.Visible = false;
            roomPos.Visible = false;

            rowPos.Visible = false;
            seatPos.Visible = false;
            pricePos.Visible = false;

            checkBox1.Visible = false;

            changebtn.Visible = false;
            changeBack.Visible = false;

            concertPos.Items.Clear();
            roomPos.Items.Clear();
        }

        private void changebtn_Click(object sender, EventArgs e)
        {
            string[] newString = { concertPos.Text, roomPos.Text, rowPos.Text, seatPos.Text, pricePos.Text, checkBox1.Checked.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString() };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString))
            {
                label8.ForeColor = Color.Red;
                label8.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"UPDATE {openedTable} SET concert_id = {newString[0]}, room_id = {newString[1]}, row_num = {newString[2]}, seat_num = {newString[3]}, price = {newString[4]}, sold = {newString[5]} WHERE id = {newString[6]}");
                Reload(openedTable, columnNames);
                label8.ForeColor = Color.DarkOrange;
                label8.Text = "ИЗМЕНЕННО!";
            }
        }

        private void rowPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ticketTable.Visible = false;
            ticketTable.Enabled = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("ticket_id", "Ticket ID");
            dataGridView1.Columns.Add("customer_id", "Customer ID");
            dataGridView1.Columns.Add("booking_date", "Booking date");

            columnNames = new List<string> {"id", "ticket_id", "customer_id", "booking_date"};

            Reload("booking", columnNames);

            dataGridView1.Visible = true;

            bookingTable.Visible = true;
            bookingTable.Enabled = true;

            label10.Visible = true;

            addBooking.Visible = true;
            delBooking.Visible = true;
            cngBooking.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void addBooking_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            List<string> list = new List<string>();
            list = GetTicketList();

            foreach (string item in list)
                comboBox1.Items.Add(item);

            list = GetCustomerList();

            foreach (string item in list)
                comboBox2.Items.Add(item);

            chgRowBooking.Visible = false;
            addRowBooking.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            dateTimePicker1.Visible = true;
            backBooking.Visible = true;
        }

        private void bookingTable_Enter(object sender, EventArgs e)
        {

        }

        private void addRowBooking_Click(object sender, EventArgs e)
        {
            string[] newString = { comboBox1.Text, comboBox2.Text, dateTimePicker1.Value.ToString("s") };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString) || IsBookingExist(newString))
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"INSERT INTO {openedTable} (ticket_id, customer_id, booking_date) VALUES ({newString[0]}, {newString[1]}, \"{newString[2]}\")");
                Reload(openedTable, columnNames);
                int bookingId = int.Parse(comboBox1.Text);
                sqList = upload.Upload($"CALL MarkTicketAsSold({bookingId});");
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "ДОБАВЛЕНО!";
            }
        }

        private void backBooking_Click(object sender, EventArgs e)
        {
            this.Height = 400;

            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            statusLabel.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;

            addRowBooking.Visible = false;
            chgRowBooking.Visible = false;
            dateTimePicker1.Visible = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
        }

        private void chgRowBooking_Click(object sender, EventArgs e)
        {
            string[] newString = { comboBox1.Text, comboBox2.Text, dateTimePicker1.Value.ToString("s"), dataGridView1.CurrentRow.Cells[0].Value.ToString() };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString) || IsBookingExist(newString))
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"UPDATE {openedTable} SET ticket_id = {newString[0]} , customer_id = {newString[1]}, booking_date = \"{newString[2]}\" WHERE id = {newString[3]}");
                sqList = upload.Upload($"CALL MarkTicketAsSold({newString[3]});");
                Reload(openedTable, columnNames);
                statusLabel.ForeColor = Color.DarkOrange;
                statusLabel.Text = "ИЗМЕНЕННО!";
            }
        }

        private void cngBooking_Click(object sender, EventArgs e)
        {
            this.Height = 659;
            
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            List<string> list = new List<string>();
            list = GetTicketList();

            foreach (string item in list)
                comboBox1.Items.Add(item);

            list = GetCustomerList();

            foreach (string item in list)
                comboBox2.Items.Add(item);

            addRowBooking.Visible = false;
            chgRowBooking.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            dateTimePicker1.Visible = true;
            backBooking.Visible = true;
        }

        private void delBooking_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            string query = $"DELETE FROM {openedTable} WHERE id = {row.Cells[0].Value}";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            Reload(openedTable, columnNames);
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void request_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            requestBox.Visible = true;
            ticketTable.Visible = false;
            bookingTable.Visible = false;
        }

        private void buyTicketInfo_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("fio", "FIO");
            dataGridView1.Columns.Add("name", "Room");
            dataGridView1.Columns.Add("row_num", "Row");
            dataGridView1.Columns.Add("seat_num", "Seat");

            columnNames = new List<string> { "id", "fio", "name", "row_num", "seat_num" };

            string query = $"SELECT ticket.id, customer.fio, room.name, ticket.row_num, ticket.seat_num FROM ticket, customer, room, booking WHERE booking.ticket_id = ticket.id AND ticket.room_id = room.id AND booking.customer_id = customer.id GROUP BY ticket.id;";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            ReloadRequest(query, columnNames);
        }

        private void minPriceTicket_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("name", "Concert");
            dataGridView1.Columns.Add("row_num", "Row");
            dataGridView1.Columns.Add("seat_num", "Seat");

            columnNames = new List<string> { "id", "name", "row_num", "seat_num" };


            string query = $"SELECT room.id, SUM(ticket.price) AS Сумма FROM ticket, booking, room WHERE ticket.id = booking.ticket_id AND booking.booking_date < '2023-05-01 00:00:00' AND room.id = ticket.room_idnGROUP BY room.idnORDER BY SUM(ticket.price) DESC;";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            ReloadRequest(query, columnNames);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("name", "Room");
            dataGridView1.Columns.Add("Сумма", "Summa");

            columnNames = new List<string> { "name", "Сумма" };

            string query = $"SELECT room.name, SUM(ticket.price) AS Сумма FROM ticket, booking, room WHERE ticket.id = booking.ticket_id AND room.id = ticket.room_id GROUP BY room.id ORDER BY SUM(ticket.price) DESC;";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            ReloadRequest(query, columnNames);
        }
    }
}
