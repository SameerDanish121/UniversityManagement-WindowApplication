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

namespace ProjectVP
{
    public partial class StudentDashBoard : Form
    {
        public Student s1;


        
        public StudentDashBoard()
        {
            InitializeComponent();
        }
        
        private void StudentDashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                label6.Text = s1.Username;
                
               
                yourIdInfo.Text = s1.Id.ToString();
                yourNameInfo.Text = s1.name;
                yourAgeInfo.Text = s1.age.ToString();
                yourFatherInfo.Text = s1.Guardian;
                yourSectionInfo.Text = s1.Section;
                yourUserNameInfo.Text = s1.Username;
                yourPasswordInfo.Text = s1.Password.ToString();
                textBox1.Text = s1.Gender;
                textBox2.Text = s1.Semeseter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            panelInformation.Visible = false;
            panelCourses.Visible = false;
            panelResult.Visible = false;
            panelAttendance.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelCourses.Visible = true;
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelInformation.Visible != false)
            {
                panelInformation.Visible = false;
            }
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }

            dataGridView1.Rows.Clear();
            foreach (Subject sr in s1.Subjects)
            {
                dataGridView1.Rows.Add(sr.Id, sr.Name, sr.creditHours, sr.TotalMarks, sr.TeacherId);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fr=new Form1();
            fr.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            panelInformation.Visible = false;
            panelCourses.Visible = false;
            panelResult.Visible = false;
            panelAttendance.Visible = false;
            try
            {
                ChangePassword cgr = new ChangePassword();
                cgr.id = s1.Id;
                cgr.User = "Student";
                cgr.Show();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
           
            
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = ColorTranslator.FromHtml("#C9DBFF");
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(249, 248, 253);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = ColorTranslator.FromHtml("#C9DBFF");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(249, 248, 253);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = ColorTranslator.FromHtml("#C9DBFF");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(249, 248, 253);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelCourses.Visible!=false)
            {
                panelCourses.Visible = false;
            }
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
                panelInformation.Visible = true;

        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            button12.BackColor = ColorTranslator.FromHtml("#E91E63");
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.BackColor = Color.FromArgb(9, 91, 116);
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.BackColor = ColorTranslator.FromHtml("#E91E63");
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.FromArgb(9, 91, 116);
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = ColorTranslator.FromHtml("#E91E63");
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.FromArgb(9, 91, 116);
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.BackColor = ColorTranslator.FromHtml("#E91E63");
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(9, 91, 116);
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = ColorTranslator.FromHtml("#E91E63");
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(9, 91, 116);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            panelInformation.Visible = false;
            panelCourses.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelCourses.Visible != false)
            {
                panelCourses.Visible = false;
            }
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
            panelInformation.Visible = true;
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelResult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelInformation.Visible != false)
            {
                panelInformation.Visible = false;
            }
            if (panelCourses.Visible != false)
            {
                panelCourses.Visible = false;
            }
            panelResult.Visible = true;
            dataGridView2.Rows.Clear();
            foreach (Result r in s1.results)
            {
                dataGridView2.Rows.Add(r.Name, r.Mid, r.Internal, r.Final, r.Grade, r.Reamrks);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            if (panelCourses.Visible != false)
            {
                panelCourses.Visible = false;
            }
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
            if (panelInformation.Visible != false)
            {
                panelInformation.Visible = false;
            }
            dataGridViewAttendace.Rows.Clear();
            panelAttendance.Visible = true;
            foreach (Attendance a in s1.attendances)
            {
                dataGridViewAttendace.Rows.Add(a.SubjectName, a.totalClasses, a.Present, a.Absents, a.Percentage);
            }
        }

        private void panelCourses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                ReportCard1 r = new ReportCard1();
                r.id = s1.Id;
                r.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

           
        }

        private void dataGridViewAttendace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yourFatherInfo_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageManager m = new MessageManager();
            m.id =s1.Id;
            m.type = "Student";
            m.Show();
        }
    }
}
