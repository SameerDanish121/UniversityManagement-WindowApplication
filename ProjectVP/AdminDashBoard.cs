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
    public partial class AdminDashBoard : Form
    {
        public Admin a;
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminDashBoard_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Close();

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AdminInformation ar = new AdminInformation();
            ar.a = a;
            ar.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            AddSubject sb = new AddSubject();
            sb.Show();
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddStudent sd = new AddStudent();
            sd.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChangePassword p = new ChangePassword();
            p.id = a.Id;
            p.User = "Admin";
            p.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           DialogResult dr= MessageBox.Show("Are Your Sure to Reset Data ","Confirmation",MessageBoxButtons.OKCancel);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageManager md=new MessageManager();
            md.type = "Admin";
            md.id = a.Id;
            md.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AddTeacher td = new AddTeacher();
            td.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeacherView ts = new TeacherView();
            ts.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentView sw = new StudentView();
            sw.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            StudentView sw = new StudentView();
            sw.Show();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            StudentView sw = new StudentView();
            sw.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AddStudent asm= new AddStudent();
            asm.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            StudentView sw = new StudentView();
            sw.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            TeacherView ts = new TeacherView();
            ts.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TeacherView ts = new TeacherView();
            ts.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TeacherView ts = new TeacherView();
            ts.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AddSubject s = new AddSubject();
            s.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SubjectView se = new SubjectView();
            se.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            SubjectView se = new SubjectView();
            se.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SubjectView se = new SubjectView();
            se.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            StudentView v = new StudentView();
            v.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MessageManager m = new MessageManager();
            m.id = a.Id;
            m.type = "Admin";
            m.Show();
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            StudentView v = new StudentView();
            v.Show();
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            StudentView v = new StudentView();
            v.Show();
        }
    }
}
