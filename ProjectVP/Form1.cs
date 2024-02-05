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

namespace ProjectVP
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget f = new Forget();
            f.Show();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (textBox1.Text == "Enter Username") {
                textBox1.Text = String.Empty;

            }

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Enter Password")
            {
                textBox3.Text = String.Empty;

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
               
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
            
        }

        public String LoginName = @"[A-Za-z]*@BIIT$";
        public String LoginPassword = @"^\d{5,5}$";
        private void button1_Click(object sender, EventArgs e)
        {
          
            

            if (textBox1.Text == ""||textBox1.Text== "Enter Username")
            {
                System.Windows.Forms.MessageBox.Show("Enter UserName to Login", "Login Authetication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                    return;
            }
            else
            {
                 String user = textBox1.Text.ToString();
                    
                    if (!Regex.IsMatch(user,LoginName))
                    {
                        MessageBox.Show("Your Username is in Invalid Format.Your USERNAME must contain @BIIT at the end", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                if (textBox3.Text == ""||textBox3.Text== "Enter Password")
                {
                    System.Windows.Forms.MessageBox.Show("Enter Password to Login", "Login Authetication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                        return;
                }
                else
                {
                   
                    String id = textBox3.Text;
                    if (!Regex.IsMatch(id,LoginPassword))
                    {
                        MessageBox.Show("Your Password is in Invalid Format.Your Password must contain at Most 5 number  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    try
                    {
                       
                        LinqLogic l = new LinqLogic();
                        String g = l.Login(textBox1.Text, int.Parse(textBox3.Text));
                       

                        if (g != null)
                        {
                            
                            if (g.Equals( "Student"))
                            {
                                StudentDashBoard dr = new StudentDashBoard();
                                dr.s1 = l.s1;
                                dr.Show();
                                this.Hide();

                            }
                            else if (g.Equals("Teacher"))
                            {
                                TeacherDashBoard t = new TeacherDashBoard();
                                t.t = l.t1;
                                t.Show();
                                this.Hide();
                            }
                            else if (g.Equals("Admin"))
                            {
                                AdminDashBoard a = new AdminDashBoard();
                                a.a = l.ase;
                                a.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Your Are Not Authorized to Use System", "Login Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                            textBox1.Focus();
                            return;
                        }
                    }
                    catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
