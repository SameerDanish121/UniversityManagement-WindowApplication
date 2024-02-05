using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DataLayer;
using ADO;
using System.Text.RegularExpressions;

namespace ProjectVP
{
    public partial class AddSubject : Form
    {
        LinqLogic l=new LinqLogic();
        public AddSubject()
        {
            InitializeComponent();
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Teacher> t = l.AllTeacher();
            foreach (Teacher r in t)
            {
                dataGridView2.Rows.Add(r.id,r.Name,r.Qualification,r.Experience);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public String NameOf = @"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$";
        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                Subject sre = new Subject();
               
                if (!Regex.IsMatch(textBox1.Text,NameOf))
                {
                    MessageBox.Show("Your Name is in Invalid Format.Your Name must Start with A-Z  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                sre.Name = textBox1.Text;
                if (!Regex.IsMatch(textBox2.Text,CreditHour))
                {
                    MessageBox.Show("Your Credit is in Invalid Format.Your CreditHours must contain at Most 1,2,3,4   ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                sre.creditHours = int.Parse(textBox2.Text);
                sre.TotalMarks = int.Parse(textBox3.Text);
                sre.TeacherId= int.Parse(textBox4.Text);
                l.AddSubject(sre);
                System.Windows.Forms.MessageBox.Show("Data Saved", "Insertion", MessageBoxButtons.OK);
            }catch(SqlException ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message); 
            }
            
        }
        String CreditHour= @"^[1234]$";
        String Name = @"^([A-Z][a-z]*(\S[A-Z][a-z]*)*){3,}$";
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
