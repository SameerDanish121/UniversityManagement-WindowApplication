using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BussinessLayer;
using ADO;

namespace ProjectVP
{
    public partial class ChangePassword : Form
    {
        
        public  int id=0;
        public String User = null;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinqLogic l1 = new LinqLogic();
            
            if (textBox3.Text!="")
            {
                try
                {
                    if (User == "Student")
                    {
                        l1.PasswordUpdate(id, User, int.Parse(textBox3.Text));
                    }
                    else if (User == "Teacher")
                    {
                        l1.PasswordUpdate(id, User, int.Parse(textBox3.Text));
                    }
                    else if (User == "Admin")
                    {
                        l1.PasswordUpdate(id, User, int.Parse(textBox3.Text));
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                
                this.Close();
            }
            else
            {
                return;
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }
    }
}
