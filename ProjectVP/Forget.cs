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
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Empty;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()=="Student")
            {
                label3.Text = "Guardian";
            }
            else if(comboBox1.SelectedItem.ToString() == "Teacher")
            {
                label3.Text = "Qualification";
            }
            else if (comboBox1.SelectedItem.ToString() == "Admin")
            {
                label3.Text = "USERNAME";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 n = new Form1();
            n.Show();
            this.Close();
        }
        LinqLogic l = new LinqLogic();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int y = 0;
                String name = textBox1.Text;
                String typeData = textBox3.Text;
                String user=comboBox1.SelectedItem.ToString();
                if (comboBox1.SelectedItem.ToString()=="Student")
                {
                     y=l.ForgetPassword("Student", name, typeData);
                }else if (comboBox1.SelectedItem.ToString() == "Teacher")
                {
                    y = l.ForgetPassword("Teacher", name, typeData);
                }
                else if (comboBox1.SelectedItem.ToString() == "Admin")
                {
                    y = l.ForgetPassword("Admin", "", typeData);
                }
                else
                {
                    MessageBox.Show("Select a option  from dropdown list");
                    return;
                }
                if (y!=0) {
                    MessageBox.Show("Your Password is > '"+y+"'","Password Requset",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You are Not eligible to Recover Password", "Password Requset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
