using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Filarmony
{
    public partial class TreeForm : Form
    {
        MySqlDataReader list;
        List<int> idNodesExp = new List<int>();
        public TreeForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                idNodesExp = new List<int>();

                Query upload = new Query();
                string query = "select id, fio from customer";
                list = upload.Upload(query);

                while (list.Read())
                {
                    ContextMenuStrip context = new ContextMenuStrip();
                    var node = new TreeNode(list["fio"].ToString());
                    node.Name = list["id"].ToString();
                    treeView1.Nodes.Add(node);
                    node.Nodes.Add("");
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        void LoadGroup(TreeNode parent, string id)
        {
            MySqlDataReader droplist;
            try
            {
                Query upload = new Query();
                string query = "SELECT booking.ticket_id, concert.name FROM customer JOIN booking ON customer.id = booking.customer_id JOIN ticket ON booking.ticket_id = ticket.id JOIN concert ON ticket.concert_id = concert.id WHERE customer.id = " + id;
                droplist = upload.Upload(query);
                
                parent.Nodes.RemoveAt(0);

                while (droplist.Read())
                {
                    var node = new TreeNode(droplist["name"].ToString());
                    node.Name = droplist["ticket_id"].ToString();
                    parent.Nodes.Add(node);
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode nodeExp = new TreeNode();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                var node = treeView1.Nodes[i];
                if (node.IsExpanded && !idNodesExp.Contains(i))
                {
                    nodeExp = node;
                    idNodesExp.Add(i);
                    break;
                }
            }
            LoadGroup(nodeExp, nodeExp.Name.ToString());
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            for(int i = 0; i < treeView1.Nodes.Count; i++)
            {
                var node = treeView1.Nodes[i];
                if (node.IsExpanded == false && idNodesExp.Contains(i))
                {
                    idNodesExp.Remove(i);
                    node.Nodes.Clear();
                    node.Nodes.Add("");
                    break;
                }
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {

            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

           TreeNode targetNode = treeView1.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode) && targetNode != null)
            {

                draggedNode.Remove();
                targetNode.Nodes.Add(draggedNode);

                Query upload = new Query();
                MySqlDataReader sql = upload.Upload($"UPDATE booking SET customer_id = {targetNode.Name} WHERE ticket_id = {draggedNode.Name}");

                targetNode.Expand();
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        } 
        
        // Добавление элемента
        private void addBtn_Click(object sender, EventArgs e)
        {
            /*
             * 2 акта
             * 1 - добавляем в покупателя
             *   - уже имеется имя покупателя
             *   - необходимо ввести концерт и добавить ноду
             * 2 - добавляем в пустоту
             *   - необходимо ввести покупателя и концерт и добавить ноду
             * - Каждый атрибут проверяется на существование в БД
             */

            TreeNode node = treeView1.SelectedNode;

            NewNodeForm form = new NewNodeForm();
            if (node != null)
            {
                if (node.Parent != null)
                {
                    form.customerBox.Text = node.Parent.Text;
                    form.concertBox.Text = node.Text;
                }
                else
                {
                    form.customerBox.Text = node.Text;
                }
            }

            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                TreeNode add;
                Query upload = new Query();
                string query;
                // Если есть родитель и покупатель = покупателю в добавлении, то добавляем только концерт и создаем билет (нажали на концерт при добавлении)
                if (node != null)
                {
                    #region Выбор пользователя
                    query = $"SELECT id FROM customer WHERE fio = \'{form.customerBox.Text}\'";
                    MySqlDataReader data = upload.Upload(query);
                    bool customerExist = false;
                    while (data.Read())
                    {
                        if (data["id"].ToString() != "") customerExist = true;
                    }

                    if (!customerExist)
                    {
                        node = new TreeNode();
                        query = $"INSERT INTO customer SET fio = \'{form.customerBox.Text}\'";
                        upload.Upload(query);

                        query = $"SELECT id FROM customer WHERE fio = \'{form.customerBox.Text}\'";
                        data = upload.Upload(query);
                        while (data.Read())
                        {
                            node.Name = data["id"].ToString();
                        }
                        node.Text = form.customerBox.Text;
                    }
                    #endregion
                    add = new TreeNode(form.concertBox.Text);

                    // Добавляем concert
                    if (node.Parent != null)
                        query = "SELECT booking.ticket_id, concert.name FROM customer JOIN booking ON customer.id = booking.customer_id JOIN ticket ON booking.ticket_id = ticket.id JOIN concert ON ticket.concert_id = concert.id WHERE customer.id = " + node.Parent.Name.ToString();
                    else
                        query = "SELECT booking.ticket_id, concert.name FROM customer JOIN booking ON customer.id = booking.customer_id JOIN ticket ON booking.ticket_id = ticket.id JOIN concert ON ticket.concert_id = concert.id WHERE customer.id = " + node.Name.ToString();
                    MySqlDataReader droplist = upload.Upload(query); // загрузка списка концертов

                    while (droplist.Read())
                    {
                        if (droplist["name"].ToString().Equals(add.Text)) add.Name = droplist["ticket_id"].ToString(); // проверка на наличие этого концерта
                    }

                    #region Добавление концерта
                    if (add.Name == "") // Если это новый концерт
                    {
                        query = $"INSERT INTO contract SET performer = \'{add.Text}\'";
                        MySqlDataReader reader = upload.Upload(query);

                        query = $"SELECT id FROM contract WHERE performer = \'{add.Text}\'"; // загружаем составленный id концерта из БД
                        reader = upload.Upload(query);
                        while (reader.Read())
                        {
                            add.Name = reader["id"].ToString(); // присваиваем
                        }

                        query = $"INSERT INTO concert SET name = \'{add.Text}\', id = {add.Name}";
                        reader = upload.Upload(query);

                        query = $"INSERT INTO ticket SET concert_id = {add.Name}";
                        upload.Upload(query);
                        query = $"SELECT id FROM ticket WHERE concert_id = {add.Name}";
                        reader = upload.Upload(query);
                        while (reader.Read())
                        {
                            add.Name = reader["id"].ToString();
                        }
                        #endregion
                    }
                    // Добавляем в sql
                    if (node.Parent == null)
                    {
                        if (node.IsExpanded && customerExist)
                            node.Nodes.Add(add);
                        if (!customerExist)
                        {
                            treeView1.Nodes.Add(node);
                            if (add != null)
                                node.Nodes.Add(add);
                        }
                        if (add.Text != "")
                        {
                            query = $"INSERT INTO booking SET ticket_id = {add.Name}, customer_id = {node.Name}";
                            upload.Upload(query);
                        }
                    }
                    else 
                    {
                        if (add.Text != "")
                        { 
                            node.Parent.Nodes.Add(add);
                            query = $"INSERT INTO booking SET ticket_id = {add.Name}, customer_id = {node.Parent.Name}";
                            upload.Upload(query);
                        }
                    }
                } 
                // Нажали в пустоту 
                else if (node == null)
                {
                    //Создаем ноду
                    add = new TreeNode(form.customerBox.Text);

                    //Ищем в БД пользователя
                    query = $"SELECT id, fio FROM customer WHERE fio = \'{form.customerBox.Text}\'";
                    MySqlDataReader droplist = upload.Upload(query);

                    while (droplist.Read())
                    {
                        add.Name = droplist["id"].ToString();
                    }

                    if (add.Name == "")
                    {
                        query = $"INSERT INTO customer SET fio = \'{add.Text}\'";
                        upload.Upload(query);

                        query = $"SELECT id FROM customer WHERE fio = \'{add.Text}\'";
                        droplist = upload.Upload(query);
                        while (droplist.Read())
                        {
                            add.Name = droplist["id"].ToString();
                        }
                    }
                    TreeNode con = null;
                    if (form.concertBox.Text.Trim() != null)
                    {
                        con = new TreeNode(form.concertBox.Text);
                        query = $"SELECT id FROM concert WHERE name = \'{con.Text}\'";
                        droplist = upload.Upload(query);

                        while (droplist.Read())
                        {
                            con.Name = droplist["id"].ToString();
                        }
                        if (con.Name == "")
                        {
                            query = $"INSERT INTO contract SET performer = \'{con.Text}\'";
                            MySqlDataReader reader = upload.Upload(query);

                            query = $"SELECT id FROM contract WHERE performer = \'{con.Text}\'"; // загружаем составленный id концерта из БД
                            reader = upload.Upload(query);
                            while (reader.Read())
                            {
                                con.Name = reader["id"].ToString(); // присваиваем
                            }

                            query = $"INSERT INTO concert SET name = \'{con.Text}\', id = {con.Name}";
                            reader = upload.Upload(query);

                            query = $"INSERT INTO ticket SET concert_id = {con.Name}";
                            upload.Upload(query);
                            query = $"SELECT id FROM ticket WHERE concert_id = {con.Name}";
                            reader = upload.Upload(query);
                            while (reader.Read())
                            {
                                con.Name = reader["id"].ToString();
                            }
                        }
                        add.Nodes.Add(con);
                    }
                    treeView1.Nodes.Add(add);
                    if (con.Text != "")
                    {
                        query = $"INSERT INTO booking SET ticket_id = {con.Name}, customer_id = {add.Name}";
                        upload.Upload(query);
                    }
                }
            }
        }

        // Изменение объекта
        private void rnmBtn_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null) return;

            NewNodeForm form = new NewNodeForm();
            if (node.Parent != null) 
            {
                form.customerBox.Text = node.Parent.Text;
                form.concertBox.Text = node.Text;
            }
            else
            {
                form.customerBox.Text = node.Text;
            }
            
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                Query upload = new Query();
                MySqlDataReader data;
                string query;
                // Проверяем изменение в пользователе и концерте
                if (node.Parent != null)
                {
                    string idBook = "";
                    query = $"SELECT id FROM booking WHERE ticket_id = {node.Name} AND customer_id = {node.Parent.Name}";
                    data = upload.Upload(query);
                    while (data.Read())
                    {
                        idBook = data["id"].ToString();
                    }

                    // Ищем пользователя из customerBox
                    if (node.Parent.Text != form.customerBox.Text) 
                    {
                        TreeNode cust = new TreeNode();
                        query = $"SELECT id, fio FROM customer";
                        data = upload.Upload(query);
                        bool customerExist = false;
                        while (data.Read())
                        {
                            if (data["fio"].ToString() == form.customerBox.Text)
                            {
                                cust.Text = form.customerBox.Text;
                                cust.Name = data["id"].ToString();
                                customerExist = true;
                            }
                        }
                        if (customerExist)
                        {
                            for (int i = 0; i < treeView1.Nodes.Count; i++)
                            {
                                if ((treeView1.Nodes[i] as TreeNode).Text == form.customerBox.Text)
                                {
                                    TreeNode parent = treeView1.Nodes[i];
                                    node.Remove();
                                    parent.Nodes.Add(node);
                                }
                            }
                        }                   
                        // Если пользователя нет, то создаем его
                        if(!customerExist)
                        {
                            cust = new TreeNode();
                            query = $"INSERT INTO customer SET fio = \'{form.customerBox.Text}\'";
                            upload.Upload(query);

                            query = $"SELECT id FROM customer WHERE fio = \'{form.customerBox.Text}\'";
                            data = upload.Upload(query);
                            while (data.Read())
                            {
                                cust.Name = data["id"].ToString();
                            }
                            cust.Text = form.customerBox.Text;
                            treeView1.Nodes.Add(cust);
                            cust.Nodes.Add(node);
                        }
                       
                    }

                    // Меняем концерт
                    if (form.concertBox.Text != node.Text)
                    {
                        query = $"SELECT id, name FROM concert";
                        data = upload.Upload(query);
                        bool concertExist = false;
                        while (data.Read())
                        {
                            if (data["name"].ToString() == form.concertBox.Text)
                            {
                                node.Text = data["name"].ToString();
                                query = $"SELECT id FROM ticket WHERE concert_id={data["id"]}";
                                MySqlDataReader r = upload.Upload(query);
                                while (r.Read())
                                    node.Name = r["id"].ToString();
                                concertExist = true;
                            }
                        }

                        if (!concertExist)
                        {
                            query = $"INSERT INTO contract SET performer = \'{form.concertBox.Text}\'";
                            upload.Upload(query);

                            query = $"SELECT id FROM contract WHERE performer = \'{form.concertBox.Text}\'"; // загружаем составленный id концерта из БД
                            data = upload.Upload(query);
                            string id = "";
                            while (data.Read())
                            {
                                id = data["id"].ToString();
                            }
                            query = $"INSERT INTO concert SET name = \'{form.concertBox.Text}\', id = {id}";
                            upload.Upload(query); 
                            query = $"SELECT id FROM concert WHERE name = \'{form.concertBox.Text}\'";
                            data = upload.Upload(query);
                            while (data.Read())
                            {
                                id = data["id"].ToString();
                            }

                            query = $"INSERT INTO ticket SET concert_id = {id}";
                            upload.Upload(query);

                            query = $"SELECT id FROM ticket WHERE concert_id = {id}";
                            data = upload.Upload(query);
                            while (data.Read()) 
                            {
                                node.Name = data["id"].ToString();
                                node.Text = form.concertBox.Text; 
                            }
                        }
                    }

                    query = $"UPDATE booking SET ticket_id = {node.Name}, customer_id = {node.Parent.Name} WHERE id = {idBook}";
                    upload.Upload(query);
                }
                else // Проверяем только пользователя
                {
                    if (form.customerBox.Text == node.Text) return; // Если пользователь не изменился, то изменений нет
                    
                    node.Text = form.customerBox.Text;
                    query = $"UPDATE customer SET fio = \'{form.customerBox.Text}\' WHERE id = {node.Name}";
                    upload.Upload(query);
                }
            }
        }

        // Удаление элемента
        private void delBtn_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null) return;

            if (node.Parent == null)
            {
                Query upload = new Query();
                string query = $"DELETE FROM customer WHERE id = {node.Name}";
                upload.Upload(query);
                treeView1.Nodes.Remove(node);
            }
            else
            { 
                Query upload = new Query();
                string query = $"DELETE FROM booking WHERE ticket_id = {node.Name} AND customer_id = {node.Parent.Name}";
                upload.Upload(query);
                node.Parent.Nodes.Remove(node);

            }
        }
    }
}
