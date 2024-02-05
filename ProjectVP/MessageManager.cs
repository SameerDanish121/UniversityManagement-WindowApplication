using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADO;

namespace ProjectVP
{
    public partial class MessageManager : Form
    {
         public  String type;
        public int id=0;
        public MessageManager()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        LinqLogic L = new LinqLogic();
        private void MessageManager_Load(object sender, EventArgs e)
        {
            if (type == "Admin" && id!=0)
            {
                List<MessageBoxList> m = L.AllMessage();
                var j=m.Where(n=>n.ReciveType=="Admin").Select(n=>n).ToList();
                foreach (var n in j)
                {
                    dataGridView2.Rows.Add( n.id, n.type,n.message);
                }
            }else if (type=="Student" && id!=0)
            {
                List<MessageBoxList> m = L.AllMessage();
                var j = m.Where(n => n.ReciveType == "Student" && n.ReciverId==id).Select(n => n).ToList();
                foreach (var n in j)
                {
                    dataGridView2.Rows.Add( n.id,n.type, n.message);
                }
            }
            else if (type == "Teacher" && id != 0)
            {
                List<MessageBoxList> m = L.AllMessage();
                var j = m.Where(n => n.ReciveType == "Student" && n.ReciverId == id).Select(n => n).ToList();
                foreach (var n in j)
                {
                    dataGridView2.Rows.Add( n.id,n.type, n.message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String receiverType = comboBox1.SelectedItem.ToString();
                int iod = int.Parse(textBox2.Text);
                L.MessageInsert(type,receiverType,id,iod,textBox1.Text);
                MessageBox.Show("Message Send Successfully");

            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
