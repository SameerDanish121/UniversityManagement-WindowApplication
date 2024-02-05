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
using BussinessLayer;
using DataLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectVP
{
    public partial class ReportCard1 : Form
    {
        public  int id;
        public String name = null;
        public ReportCard1()
        {
            InitializeComponent();
        }

        private void ReportCard_Load(object sender, EventArgs e)
        {
            LinqLogic l=new LinqLogic();
            List<Student> s1 = l.AllStudent();
            Student s = s1.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
            if (s1!=null)
            {
                RegNo.Text = s.Id.ToString();
                Name1.Text = s.name.ToString();
                Section.Text = s.Section.ToString();
                Degree.Text = s.Semeseter.ToString();
                List<StudentResult> result = l.AllStudentResult();
                List<StudentAttendance> attend = l.AllStudentAttendances();
                List<StudentResult> myResult = result.Where(n => n.StudentId == s.Id).Select(n => n).ToList();
                List<StudentAttendance> myAttend = attend.Where(n => n.StudentId == s.Id).Select(n => n).ToList();
                List<Subject> subject = l.AllSubject();
                foreach(StudentResult r in myResult)
                {
                    String sName = subject.Where(n => n.Id == r.SubjectId).Select(n => n.Name).FirstOrDefault();
                    int total = r.Mid + r.Internal + r.Final + r.Lab;
                    dataGridView1.Rows.Add(sName,r.Mid,r.Internal,r.Final,r.Grade,total);
                }
                List<StudentSubject> ne = l.AllStudentSubject();
                l.s1 = new Student();
                l.s1.Id = id;
                l.userSubject = ne.Where(n => n.sid == id).Select(n => n.Id).ToList();
                List<Attendance> a = l.CollectAttendance(s.Id);
                foreach (Attendance a1 in a)
                {                   
                    dataGridViewAttendace.Rows.Add(a1.SubjectName,a1.totalClasses,a1.Present,a1.Absents,a1.Percentage);
                }
                

                


            }
          


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewAttendace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iod = id;
            LinqLogic L = new LinqLogic();
            L.MessageInsert("Student","Admin", id,1,richTextBox1.Text);
            MessageBox.Show("Feedback Submitted");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
