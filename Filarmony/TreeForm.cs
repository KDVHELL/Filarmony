using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class TreeForm : Form
    {
        MySqlDataReader list;
        List<int> idNodesExp = new List<int>();
        public TreeForm()
        {
            InitializeComponent();
        }

        private void TreeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Query upload = new Query();
                string query = "select id, fio from customer";
                list = upload.Upload(query);

                while (list.Read())
                {
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
                string query = "SELECT concert.name FROM customer JOIN booking ON customer.id = booking.customer_id JOIN ticket ON booking.ticket_id = ticket.id JOIN concert ON ticket.concert_id = concert.id WHERE customer.id = " + id;
                droplist = upload.Upload(query);
                
                parent.Nodes.RemoveAt(0);

                while (droplist.Read())
                {
                    var node = new TreeNode(droplist[0].ToString());
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

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {

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
    }
}
