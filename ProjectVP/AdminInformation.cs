using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;

namespace ProjectVP
{
    public partial class AdminInformation : Form
    {
       public Admin a = new Admin();
        public AdminInformation()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminInformation_Load(object sender, EventArgs e)
        {
            textBox1.Text = a.Id.ToString();
            textBox2.Text = a.Designation.ToString();
            textBox3.Text = a.Username.ToString();
            textBox4.Text = a.Password.ToString();
        }
    }
}
