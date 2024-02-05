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
using DataLayer;
using ADO;
using System.Text.RegularExpressions;

namespace ProjectVP
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        Student s;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
       public int updateid = 0;
        public String LoginName = @"[A-Za-z]*@BIIT$";
        public String LoginPassword = @"^\d{5,5}$";
       public String NameOf = @"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$";
       public String NameofStudent=null;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (usage!=null)
                {
                   
                    if (s == null)
                    {
                        s = new Student();
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        s.Subjects.Add(new Subject
                        {
                            Id = int.Parse(dataGridView2[0, i].Value.ToString())
                        });
                    }
                    s.Id = updateid;
                   
                    if (!Regex.IsMatch(textBox1.Text,NameOf))
                    {
                        MessageBox.Show("Your Name is in Invalid Format.Your Name must Start with A-Z  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    s.name = textBox1.Text;
                    s.age = int.Parse(textBox2.Text);
                    if (radioButton1.Checked)
                    {
                        s.Gender = "Male";
                    }
                    else
                    {
                        s.Gender = "Female";

                    }

                    s.Semeseter = textBox4.Text;
                    s.Section = textBox5.Text;
                    s.Guardian = textBox6.Text;
                    String id1 = textBox7.Text;
                    if (!Regex.IsMatch(id1, LoginPassword))
                    {
                        MessageBox.Show("Your Password is in Invalid Format.Your Password must contain at Most 5 number  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    s.Password = int.Parse(textBox7.Text);
                    s.Username = s.name.Split(' ')[0] + "@BIIT";
                   
                    l.UpdateStudent(s);
                    System.Windows.Forms.MessageBox.Show("Data Updated", "Insertion", MessageBoxButtons.OK);
                
                return;
                }
               
                if (s == null)
                {
                    s = new Student();
                }
                for (int i=0;i<dataGridView2.Rows.Count;i++)
                {
                    s.Subjects.Add(new Subject
                    {
                        Id = int.Parse(dataGridView2[0, i].Value.ToString())
                    });
                }
                String user1 = textBox1.Text;
                if (!Regex.IsMatch(user1,NameOf))
                {
                    MessageBox.Show("Your Name must start with A-Z and contains three letters  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                s.name = textBox1.Text;
                s.age = int.Parse(textBox2.Text);
                if (radioButton1.Checked)
                {
                    s.Gender = "Male";
                }
                else
                {
                    s.Gender = "Female";
                
                }
               
                s.Semeseter= textBox4.Text;
                s.Section= textBox5.Text;
                s.Guardian = textBox6.Text;
                String id = textBox7.Text;
                if (!Regex.IsMatch(id, LoginPassword))
                {
                    MessageBox.Show("Your Password is in Invalid Format.Your Password must contain at Most 5 number  ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                s.Password=int.Parse(textBox7.Text);
                s.Username = s.name.Split(' ')[0]+"@BIIT";
                LinqLogic L=new LinqLogic();
                L.AddStudent(s);
                System.Windows.Forms.MessageBox.Show("Data Saved", "Insertion", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public String usage=null;
        public int id = 0;
        private void AddStudent_Load(object sender, EventArgs e)
        {
            if (usage!=null)
            {
                List<Student> s= l.AllStudent();
                button2.Text = "Update Student";
                Student j=s.Where(n=>n.Id==id).FirstOrDefault();
                updateid = j.Id;
                if (j.Gender=="Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox1.Text = j.name.ToString();
                textBox2.Text = j.age.ToString();
                textBox4.Text = j.Semeseter;
                textBox5.Text = j.Section;
                textBox6.Text = j.Guardian.ToString();
                textBox7.Text = j.Password.ToString();
                List<StudentSubject> s1 = l.AllStudentSubject();
                List<int> s2 = s1.Where(n => n.sid == id).Select(n => n.Id).ToList();
                List<Subject> s3 = l.AllSubject();
                foreach (int i in s2)
                {
                    String sub = s3.Where(n => n.Id == i).Select(n => n.Name).FirstOrDefault();
                    dataGridView2.Rows.Add(i,sub);
                }

            }
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        LinqLogic l = new LinqLogic();
        private void button5_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (s==null)
                {
                    s=new Student();
                }
                int id = int.Parse(textBox8.Text);
                String n=l.VerifySubject(id);
                if (n!=null)
                {
                    dataGridView2.Rows.Add(id,n);
                   
                }

            }catch(Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {


                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    int id1 = int.Parse(textBox8.Text);
                    int id2 = int.Parse(dataGridView2[0, i].Value.ToString());
                    if (id1==id2)
                    {
                        dataGridView2.Rows.RemoveAt(i);
                        break;
                    }
                }
                int id =int.Parse( textBox8.Text);
               

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Random r = new Random();
        private void button4_Click(object sender, EventArgs e)
        {          
           textBox7.Text= r.Next(10000,99999).ToString();
        }
    }
}
