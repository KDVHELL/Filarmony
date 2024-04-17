﻿using System;
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
        /// <summary>
        /// Вызов таблицы room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            bookingTable.Visible = false;
            bookingTable.Enabled = false;
            ticketTable.Visible = false;
            ticketTable.Enabled = false;
            customerBox.Visible = false;
            customerBox.Enabled = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("seats_amount", "Seats amount");

            columnNames = new List<string> { "id", "name", "seats_amount" };

            Reload("room", columnNames);

            roomBox.Visible = true;
            roomBox.Enabled = true;

            dataGridView1.Visible = true;

            label16.Visible = true;

            roomAddfieldBtn.Visible = true;
            roomChgfieldBtn.Visible = true;
            roomDelBtn.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Вызов таблицы customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            bookingTable.Visible = false;
            bookingTable.Enabled = false;
            ticketTable.Visible = false;
            ticketTable.Enabled = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("status_id", "Status ID");
            dataGridView1.Columns.Add("fio", "FIO");
            dataGridView1.Columns.Add("email", "Email");
            dataGridView1.Columns.Add("phone_number", "Phone number");

            columnNames = new List<string> { "id", "status_id", "fio", "email", "phone_number" };

            Reload("customer", columnNames);

            customerBox.Visible = true;
            customerBox.Enabled = true;

            dataGridView1.Visible = true;

            label14.Visible = true;

            custChgfieldBtn.Visible = true;
            custDelfieldBtn.Visible = true;
            custAddfieldBtn.Visible = true;
        }

        /// <summary>
        /// Вызов таблицы ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            bookingTable.Visible = false;
            bookingTable.Enabled = false;
            customerBox.Visible = false;
            customerBox.Enabled = false;
            roomBox.Visible = false;
            roomBox.Enabled = false;

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
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Получение информации для полей добавления билета в таблицу booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            concertPos.Items.Clear();
            roomPos.Items.Clear();

            List <string> list = new List<string>();
            list = GetIDList("concert");

            foreach (string item in list)
                concertPos.Items.Add(item);

            list = GetIDList("room");

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
        /// <summary>
        /// Получение списка id из таблицы
        /// </summary>
        /// <returns></returns>
        public List<string> GetIDList(string table)
        {
            List<string> list = new List<string>();

            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload($"SELECT {table}.id FROM {table}");

            while (sqList.Read())
            {
                list.Add(sqList.GetString("id"));
            }

            return list;
        }
        /// <summary>
        /// Проверка на NULL значения в полях для добавления билета
        /// </summary>
        /// <returns></returns>
        public bool CheckFullyFill()
        { 
            return concertPos.SelectedText != "" && roomPos.SelectedText != "" && rowPos.Text != "" && seatPos.Text != "";
        }
        /// <summary>
        /// Проверка существования записи
        /// </summary>
        /// <param name="newRecord">Новая запись</param>
        /// <returns></returns>
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
        /// <summary>
        /// Проверка существования заказа
        /// </summary>
        /// <param name="newRecord"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Добавление полей для изменения записи в таблице ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            concertPos.Items.Clear();
            roomPos.Items.Clear();

            List<string> list = new List<string>();
            list = GetIDList("concert");

            foreach (string item in list)
                concertPos.Items.Add(item);
            concertPos.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            list = GetIDList("room");

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
        /// <summary>
        /// Открытие полей для добавления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBooking_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            List<string> list = new List<string>();
            list = GetIDList("ticket");

            foreach (string item in list)
                comboBox1.Items.Add(item);

            list = GetIDList("customer");

            foreach (string item in list)
                comboBox2.Items.Add(item);

            chgRowBooking.Visible = false;
            addRowBooking.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            dateTimePicker1.Visible = true;
            backBooking.Visible = true;
        }
        /// <summary>
        /// Добавление записи в таблицу booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            list = GetIDList("ticket");

            foreach (string item in list)
                comboBox1.Items.Add(item);

            list = GetIDList("customer");

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
            customerBox.Visible = false;
            roomBox.Visible = false;
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
        /// <summary>
        /// Доабавление полей для создания записи в customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custAddfieldBtn_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            statusLab.Visible = true;
            fioLab.Visible = true;
            emailLab.Visible = true;
            phoneLab.Visible = true;

            label15.Text = "";
            label15.Visible = true;

            statusBox.Items.Clear();

            List<string> list = new List<string>();
            list = GetIDList("status");

            foreach (string item in list)
                comboBox1.Items.Add(item);

            list = GetIDList("customer");

            foreach (string item in list)
                comboBox2.Items.Add(item);

            custChgBtn.Visible = false;
            custAddBtn.Visible = true;
            statusBox.Visible = true;
            fioBox.Visible = true;
            emailBox.Visible = true;
            phoneBox.Visible = true;
            custBackBtn.Visible = true;
        }
        /// <summary>
        /// Добавление полей для изменения записи в customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custChgfieldBtn_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            statusBox.Items.Clear();

            List<string> list = new List<string>();
            list = GetIDList("status");

            foreach (string item in list)
                statusBox.Items.Add(item);
            statusBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            fioBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            emailBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            phoneBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            label15.Text = "";

            custAddBtn.Visible = false;
            custChgBtn.Visible = true;

            statusLab.Visible = true;
            fioLab.Visible = true;
            emailLab.Visible = true;
            phoneLab.Visible = true;
            label15.Visible = true;

            statusBox.Visible = true;
            fioBox.Visible = true;
            emailBox.Visible = true;
            phoneBox.Visible = true;
            custBackBtn.Visible = true;
        }
        /// <summary>
        /// Удаление выделенного поля в customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custDelfieldBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            string query = $"DELETE FROM {openedTable} WHERE id = {row.Cells[0].Value}";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            Reload(openedTable, columnNames);
        }
        /// <summary>
        /// Сокращение меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custBackBtn_Click(object sender, EventArgs e)
        {
            this.Height = 400;

            statusLab.Visible = false;
            fioLab.Visible = false;
            emailLab.Visible = false;
            phoneLab.Visible = false;

            statusBox.Visible = false;
            fioBox.Visible = false;
            emailBox.Visible = false;
            phoneBox.Visible = false;

            custAddBtn.Visible = false;
            custChgBtn.Visible = false;

            statusBox.Items.Clear();
        }
        /// <summary>
        /// Добавление записи в customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custAddBtn_Click(object sender, EventArgs e)
        {
            string[] newString = { statusBox.Text, fioBox.Text, emailBox.Text, phoneBox.Text };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString))
            {
                label15.ForeColor = Color.Red;
                label15.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"INSERT INTO {openedTable} (status_id, fio, email, phone_number) VALUES ({newString[0]}, \"{newString[1]}\", \"{newString[2]}\", \"{newString[3]}\")");
                Reload(openedTable, columnNames);
                label15.ForeColor = Color.Green;
                label15.Text = "ДОБАВЛЕНО!";
            }
        }
        /// <summary>
        /// Изменение записи в customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void custChgBtn_Click(object sender, EventArgs e)
        {
            string[] newString = { statusBox.Text, fioBox.Text, emailBox.Text, phoneBox.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString() };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString))
            {
                label15.ForeColor = Color.Red;
                label15.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"UPDATE {openedTable} SET status_id = {newString[0]}, fio = \"{newString[1]}\", email = \"{newString[2]}\", phone_number = \"{newString[3]}\" WHERE id = {newString[6]}");
                Reload(openedTable, columnNames);
                label15.ForeColor = Color.DarkOrange;
                label15.Text = "ИЗМЕНЕННО!";
            }
        }
        /// <summary>
        /// Удаление выделенного поля в room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomDelBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            string query = $"DELETE FROM {openedTable} WHERE id = {row.Cells[0].Value}";
            Query upload = new Query();
            MySqlDataReader sqList = upload.Upload(query);
            Reload(openedTable, columnNames);
        }
        /// <summary>
        /// Сокращение меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomBackBtn_Click(object sender, EventArgs e)
        {
            this.Height = 400;

            nameLab.Visible = false;
            seatamountLab.Visible = false;

            nameBox.Visible = false;
            seatamountBox.Visible = false;

            roomAddBtn.Visible = false;
            roomChgBtn.Visible = false;
        }
        /// <summary>
        /// Добавление полей для создание записи в room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomAddfieldBtn_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            nameLab.Visible = true;
            seatamountLab.Visible = true;

            label17.Text = "";
            label17.Visible = true;

            roomChgBtn.Visible = false;
            roomAddBtn.Visible = true;
            nameBox.Visible = true;
            seatamountBox.Visible = true;
            roomBackBtn.Visible = true;
        }
        /// <summary>
        /// Добавление полей для изменения записи в room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomChgfieldBtn_Click(object sender, EventArgs e)
        {
            this.Height = 659;

            nameBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            seatamountBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            label17.Text = "";

            roomAddBtn.Visible = false;
            roomChgBtn.Visible = true;

            nameLab.Visible = true;
            seatamountLab.Visible = true;
            label17.Visible = true;

            nameBox.Visible = true;
            seatamountBox.Visible = true;
            custBackBtn.Visible = true;
        }
        /// <summary>
        /// Добавление записи в room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomAddBtn_Click(object sender, EventArgs e)
        {
            string[] newString = { nameBox.Text, seatamountBox.Text };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString))
            {
                label15.ForeColor = Color.Red;
                label15.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"INSERT INTO {openedTable} (name, seats_amount) VALUES (\"{newString[0]}\", {newString[1]})");
                Reload(openedTable, columnNames);
                label15.ForeColor = Color.Green;
                label15.Text = "ДОБАВЛЕНО!";
            }
        }
        /// <summary>
        /// Изменение записи в room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomChgBtn_Click(object sender, EventArgs e)
        {
            string[] newString = { nameBox.Text, seatamountBox.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString() };
            bool stringNull = true;
            foreach (string str in newString)
                if (str == "" || str == "False") stringNull = stringNull && true;
                else stringNull = stringNull && false;

            if (stringNull || IsRowExist(newString))
            {
                label15.ForeColor = Color.Red;
                label15.Text = "ОШИБКА!";
            }
            else
            {
                Query upload = new Query();
                MySqlDataReader sqList = upload.Upload($"UPDATE {openedTable} SET name = \"{newString[0]}\", seats_amount = {newString[1]} WHERE id = {newString[6]}");
                Reload(openedTable, columnNames);
                label15.ForeColor = Color.DarkOrange;
                label15.Text = "ИЗМЕНЕННО!";
            }
        }
    }
}
