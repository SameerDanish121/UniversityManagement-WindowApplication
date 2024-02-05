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
using ADO;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectVP
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public String LoginPassword = @"^\d{5,5}$";
        public String NameOf = @"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$";
        private void button2_Click(object sender, EventArgs e)
        {
            LinqLogic l=new LinqLogic();
            try
            {
                if (user!=null)
                {
                    Teacher t = new Teacher();
                    t.id = eid;
                   
                    if (!Regex.IsMatch(textBox1.Text,NameOf))
                    {
                        MessageBox.Show("Your Name is in Invalid Format.Your Name must Start with A-Z  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    t.Name = textBox1.Text.ToString();
                    t.Qualification = textBox2.Text.ToString();
                    t.Experience = int.Parse(textBox3.Text);
                    t.Salary = double.Parse(textBox4.Text);
                    String id = textBox5.Text;
                    if (!Regex.IsMatch(id, LoginPassword))
                    {
                        MessageBox.Show("Your Password is in Invalid Format.Your Password must contain at Most 5 number  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    t.Pass = int.Parse(textBox5.Text);
                    t.UserName = t.Name.Split(' ')[0];
                    t.UserName = t.UserName + "@BIIT";
                    l.UpdateTeacher(t);
                    System.Windows.Forms.MessageBox.Show("Data Updated", "Insertion", MessageBoxButtons.OK);
                }
                else
                {
                    Teacher t = new Teacher();
                    String u = textBox1.Text;
                    if (!Regex.IsMatch(u,NameOf))
                    {
                        MessageBox.Show("Your Name is in Invalid Format.Your Name must Start with A-Z  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    t.Name = textBox1.Text.ToString();
                    t.Qualification = textBox2.Text.ToString();
                    t.Experience = int.Parse(textBox3.Text);
                    t.Salary = double.Parse(textBox4.Text);
                    String id = textBox5.Text;
                    if (!Regex.IsMatch(id, LoginPassword))
                    {
                        MessageBox.Show("Your Password is in Invalid Format.Your Password must contain at Most 5 number  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    t.Pass = int.Parse(textBox5.Text);
                    t.UserName = t.Name.Split(' ')[0];
                    t.UserName = t.UserName + "@BIIT";
                    l.AddTeacher(t);
                    System.Windows.Forms.MessageBox.Show("Data Saved", "Insertion", MessageBoxButtons.OK);
                }


                
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public int eid = 0;
        public String user = null;
        LinqLogic l = new LinqLogic();
        private void AddTeacher_Load(object sender, EventArgs e)
        {
            if (user!=null)
            {
                Teacher t = l.AllTeacher().Where(n => n.id == eid).FirstOrDefault();
                textBox1.Text = t.Name.ToString();
                textBox2.Text = t.Qualification.ToString();
                textBox3.Text = t.Experience.ToString();
                textBox4.Text = t.Salary.ToString();
                textBox5.Text = t.Pass.ToString();
                button2.Text = "Update Teacher";

            }
        }
        Random r = new Random();
        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = r.Next(10000, 99999).ToString();
        }
    }
}
