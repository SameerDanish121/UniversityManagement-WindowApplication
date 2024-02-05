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

namespace ProjectVP
{
    public partial class TeacherDashBoard : Form
    {
        public Teacher t;
        public int sid;
        LinqLogic l = new LinqLogic();
        public TeacherDashBoard()
        {
            InitializeComponent();
        }

        private void TeacherDashBoard_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
            label6.Text = t.UserName;
            MarkAttendance.Visible=false;
            panelInformation.Visible=false;
            StudentSearchPanel.Visible = false;
            rdbtnId.Visible = false;
            rdbtnName.Visible = false;
            SEARCHtextBox.Visible = false;
            btnSearch.Visible = false;
            panelAttendance.Visible = false;
            panelYourAttendaceSheet.Visible = false;
            panelResult.Visible = false;
            panelResultInsertion.Visible = false;
            MarkAttendance.Visible = false;


            if (t!=null)
            {
                yourIdInfo.Text = t.id.ToString();
                yourNameInfo.Text = t.Name;
                yourQaulificationInfo.Text = t.Qualification;
                yourSalaryInfo.Text = t.Salary.ToString();
                yourPasswordInfo.Text = t.Pass.ToString();
                yourExperinceInfo.Text = t.Experience.ToString();
                yourUserNameInfo.Text = t.UserName.ToString();

               

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (panelResultInsertion.Visible != false)
            {
                panelResultInsertion.Visible = false;
            }
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            if (panelInformation.Visible != false)
            {
                panelInformation.Visible = false;
            }
            if (StudentSearchPanel.Visible != false)
            {
                StudentSearchPanel.Visible = false;
            }
            if (SEARCHtextBox.Visible != false)
            {
                SEARCHtextBox.Visible = false;
            }
            if (rdbtnName.Visible != false)
            {
                rdbtnName.Visible = false;
            }
            if (rdbtnId.Visible != false)
            {
                rdbtnId.Visible = false;
            }
            if (btnSearch.Visible != false)
            {
                btnSearch.Visible = false;
            }
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            panelYourAttendaceSheet.Visible = true;
            if (panelResult.Visible!=false)
            {
                panelResult.Visible = false;
            }
            try
            {
                dataGridViewYourAttendaceSHEET.Rows.Clear();
               List<Sheet> she= l.AttendanceSheet(t.id);
                foreach(Sheet s in she)
                {
                    dataGridViewYourAttendaceSHEET.Rows.Add(s.Sname, s.Total,s.Absents,s.Absents,s.per);
                }
               
                
            }catch(Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); };
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageManager m = new MessageManager();
            m.id = t.id;
            m.type = "Teacher";
            m.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panelResultInsertion.Visible != false)
            {
                panelResultInsertion.Visible = false;
            }
            if (panelInformation.Visible!=false)
            {
                panelInformation.Visible= false;
            }
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            StudentSearchPanel.Visible = false;
            btnSearch.Visible = false;
            SEARCHtextBox.Visible = false;
            rdbtnId.Visible = false;
            rdbtnName.Visible = false;
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelYourAttendaceSheet.Visible != false)
            {
                panelYourAttendaceSheet.Visible = false;
            }
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
            StudentView sv = new StudentView();
            sv.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelInformation.Visible = true;
            if (panelResultInsertion.Visible!=false)
            {
                panelResultInsertion.Visible = false;
            }
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            if (SEARCHtextBox.Visible!=false)
            {
                SEARCHtextBox.Visible = false;
            }
            if (rdbtnName.Visible != false)
            {
                rdbtnName.Visible = false;
            }
            if(rdbtnId.Visible != false)
            {
                rdbtnId.Visible = false;
            }
            if (btnSearch.Visible != false)
            {
                btnSearch.Visible = false;
            }
            if (StudentSearchPanel.Visible != false)
            {
                StudentSearchPanel.Visible = false;
            }
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelYourAttendaceSheet.Visible!=false)
            {
                panelYourAttendaceSheet.Visible = false;
            }
           
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
            panelInformation.BringToFront();
           
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if (panelAttendance.Visible == true)
           {
                LinqLogic l = new LinqLogic();
                try
                {
                    if (rdbtnId.Checked)
                    {
                        List<Student> lt = l.AllStudent();
                        int id = int.Parse(SEARCHtextBox.Text);
                        var s = lt.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                        if (s != null)
                        {
                            List<Sheet> m = l.AttendanceSheet(t.id);
                            List<Student> s1 = l.AllStudent();
                            String name = s1.Where(n1 => n1.Id == id).Select(n1 => n1.name).FirstOrDefault();
                            if (name != null)
                            {
                                var n = m.Where(n1 => n1.Sname == name).Select(n1 => n1).FirstOrDefault();
                                if (n != null)
                                {
                                    dataGridViewAttendace.Rows.Add(n.Sname, n.Total, n.Presents, n.Absents, n.per);
                                }
                                else
                                {
                                    MessageBox.Show("No Student Exsists with such id");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No Student Exsists with such id");
                                return;
                            }



                        }
                        else
                        {
                            MessageBox.Show("No student Found with such Id");
                            return;
                        }
                    }
                    else
                    {

                        String id = SEARCHtextBox.Text;

                        List<Sheet> m = l.AttendanceSheet(t.id);
                        var n = m.Where(nt => nt.Sname == id).Select(n1 => n1).FirstOrDefault();
                        if (n != null)
                        {
                            dataGridViewAttendace.Rows.Add(n.Sname, n.Total, n.Presents, n.Absents, n.per);
                        }
                        else
                        {
                            MessageBox.Show("No student Found with such Name");
                            return;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message);}
//---------------------------------------------------------------------------------------
           }else if (panelResult.Visible==true)
            {
                LinqLogic l = new LinqLogic();
                try
                {
                    if (rdbtnId.Checked)
                    {
                        List<Student> lt = l.AllStudent();
                        int id = int.Parse(SEARCHtextBox.Text);
                        var s = lt.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                        if (s != null)
                        {

                            ReportCard1 r = new ReportCard1();
                            r.id = s.Id;
                            r.name = s.name;
                            r.Show();
                        }
                        else
                        {
                            MessageBox.Show("No student Found with such Id");
                            return;
                        }
                    }
                    else
                    {
                        List<Student> lt = l.AllStudent();
                        String id = SEARCHtextBox.Text;
                        var s = lt.Where(n => n.name == id).Select(n => n).FirstOrDefault();
                        if (s != null)
                        {

                            ReportCard1 r = new ReportCard1();
                            r.id = s.Id;
                            r.name = s.name;
                            r.Show();
                        }
                        else
                        {
                            MessageBox.Show("No student Found with such Name");
                            return;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (panelResultInsertion.Visible != false)
            {
                panelResultInsertion.Visible = false;
            }
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            if (panelInformation.Visible != false)
            {
                panelInformation.Visible = false;
            }
            if (StudentSearchPanel.Visible != false)
            {
                StudentSearchPanel.Visible = false;
            }
            panelAttendance.Visible = true;
            panelAttendance.BringToFront();
            btnSearch.Visible = true;
            

            SEARCHtextBox.Visible = true;
            
            if (rdbtnName.Visible != false)
            {
                rdbtnName.Visible = false;
            }
            if (rdbtnId.Visible != false)
            {
                rdbtnId.Visible = false;
            }
          
          
            if (panelYourAttendaceSheet.Visible != false)
            {
                panelYourAttendaceSheet.Visible = false;
            }
            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }

            btnSearch.Visible = true;
            SEARCHtextBox.Visible = true;
            if (rdbtnName.Visible == false)
            {
                rdbtnName.Visible = true;
            }
            if (rdbtnId.Visible == false)
            {
                rdbtnId.Visible = true;
            }
            

            panelResult.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (panelResultInsertion.Visible != false)
            {
                panelResultInsertion.Visible = false;
            }
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            if (panelInformation.Visible != false)
            {
                panelInformation.Visible = false;
            }
            if (StudentSearchPanel.Visible != false)
            {
                StudentSearchPanel.Visible = false;
            }
           
           
           
            if (panelAttendance.Visible!=false)
            {
                panelAttendance.Visible=false;
            }
            if (panelYourAttendaceSheet.Visible != false)
            {
                panelYourAttendaceSheet.Visible = false;
            }
            if (panelResult.Visible!=false)
            {
                panelResult.Visible = false;
            }
          
            btnSearch.Visible = true;
            SEARCHtextBox.Visible = true;
            if (rdbtnName.Visible == false)
            {
                rdbtnName.Visible = true;
            }
            if (rdbtnId.Visible == false)
            {
                rdbtnId.Visible = true;
            }
            panelResult.Visible = false;
           
            panelResult.BringToFront();

        }

        private void panelResult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

            try
            {
                ChangePassword c = new ChangePassword();
                c.id = t.id;
                c.User = "Teacher";
                c.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
            if (panelResultInsertion.Visible != false)
            {
                panelResultInsertion.Visible = false;
            }
            panelInformation.Visible = false;
            StudentSearchPanel.Visible = false;
            rdbtnId.Visible = false;
            rdbtnName.Visible = false;
            SEARCHtextBox.Visible = false;
            btnSearch.Visible = false;
            panelAttendance.Visible = false;
            panelYourAttendaceSheet.Visible = false;
            panelResult.Visible = false;
           
                MarkAttendance.Visible = false;
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (panelResultInsertion.Visible != false)
            {
                panelResultInsertion.Visible = false;
            }
            panelInformation.Visible = false;
            StudentSearchPanel.Visible = false;
            rdbtnId.Visible = false;
            rdbtnName.Visible = false;
            SEARCHtextBox.Visible = false;
            btnSearch.Visible = false;
            panelAttendance.Visible = false;
            panelYourAttendaceSheet.Visible = false;
            panelResult.Visible = false;
            MarkAttendance.Visible = true;
           

        }

        private void dataGridViewResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void SearchSection_TextChanged(object sender, EventArgs e)
        {

        }

        private void yourIdInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelInformation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            if (panelInformation.Visible!=false)
            {
                panelInformation.Visible = false;
            }
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            if (SEARCHtextBox.Visible != false)
            {
                SEARCHtextBox.Visible = false;
            }
            if (rdbtnName.Visible != false)
            {
                rdbtnName.Visible = false;
            }
            if (rdbtnId.Visible != false)
            {
                rdbtnId.Visible = false;
            }
            if (btnSearch.Visible != false)
            {
                btnSearch.Visible = false;
            }
            if (StudentSearchPanel.Visible != false)
            {
                StudentSearchPanel.Visible = false;
            }
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelYourAttendaceSheet.Visible != false)
            {
                panelYourAttendaceSheet.Visible = false;
            }

            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
        


            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            panelResultInsertion.Visible = true;

           


        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MarkAttendance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            sre.Clear();
            if (textBox1.Text != String.Empty)
            {

                try
                {
                    date = dateTimePicker1.Value.ToString();

                    section = textBox1.Text.ToString();
                    sre = l.AttendanceMark(textBox1.Text.ToString(), dateTimePicker1.Value.ToString(), t.id);
                    foreach (AttendanceMark m in sre)
                    {
                        m.status = "a";
                        l.Mark(date, section, m, t.id);

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Enter Section to Mark Attendance", "Section Required");
                return;
            }
        }
        String date;
        String section;
        List<AttendanceMark> sre = new List<AttendanceMark>();
        private void button18_Click(object sender, EventArgs e)
        {
            sre.Clear();
            try
            {
                if (textBox1.Text==String.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Enter Section to Mark Attendance", "Section Required");
                    return;
                }
                date = dateTimePicker1.Value.ToString();
                section = textBox1.Text.ToString();
                sre = l.AttendanceMark(textBox1.Text.ToString(), dateTimePicker1.Value.ToString(), t.id);
                if (sre.Count<=0)
                {
                    System.Windows.Forms.MessageBox.Show("NO student to be Marked");
                    return;
                }
                textBox2.Text = sre.FirstOrDefault().name;
                
            }catch(SqlException ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }

        private void button17_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (sre.Count <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("NO student to be Marked");
                    return;
                }
                foreach (AttendanceMark a in sre)
                {
                    if (radioButton1.Checked)
                    {
                        sre[0].status = "a";
                    }
                    
                    
                        sre[0].status = "p";
                    
                    break;
                }
                if (sre.Count > 0)
                {
                    l.Mark(date, section, sre[0], t.id);
                    sre.RemoveAt(0);
                }
                if (sre.Count <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("NO student to be Marked");
                    return;
                }
                else
                {
                    textBox2.Text = sre[0].name;
                }
            }catch(Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message);}
        }

        private void button16_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != String.Empty)
            {

                try
                {
                    date = dateTimePicker1.Value.ToString();
                    section = textBox1.Text.ToString();
                    sre = l.AttendanceMark(textBox1.Text.ToString(), dateTimePicker1.Value.ToString(), t.id);
                    foreach (AttendanceMark m in sre)
                    {
                        m.status = "p";
                        l.Mark(date, section, m, t.id);

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
               
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Enter Section to Mark Attendance", "Section Required");
                return;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panelInformation.Visible = true;
            if (MarkAttendance.Visible != false)
            {
                MarkAttendance.Visible = false;
            }
            if (SEARCHtextBox.Visible != false)
            {
                SEARCHtextBox.Visible = false;
            }
            if (rdbtnName.Visible != false)
            {
                rdbtnName.Visible = false;
            }
            if (rdbtnId.Visible != false)
            {
                rdbtnId.Visible = false;
            }
            if (btnSearch.Visible != false)
            {
                btnSearch.Visible = false;
            }
            if (StudentSearchPanel.Visible != false)
            {
                StudentSearchPanel.Visible = false;
            }
            if (panelAttendance.Visible != false)
            {
                panelAttendance.Visible = false;
            }
            if (panelYourAttendaceSheet.Visible != false)
            {
                panelYourAttendaceSheet.Visible = false;
            }

            if (panelResult.Visible != false)
            {
                panelResult.Visible = false;
            }
            panelInformation.BringToFront();
        }
        List<Student> lm=new List<Student>();
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox10.Text != null)
                {
                    lm= l.SearchStudent(textBox10.Text,"Section");
                    if (lm.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("NO student to be Marked");
                        return;
                    }
                    textBox9.Text = lm.FirstOrDefault().name;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please Enter a Section to Inset Result");
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (lm.Count <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("NO student to be Marked");
                    return;
                }
                Student s;
                foreach (Student a in lm)
                {

                    s = a;
                    break;
                }
                if (lm.Count > 0)
                {
                    //TECHAER ID ,sTUDENT ID ,mID, INTERNAL,FINAL,LAB,gRADE,fEEDBAACK
                    l.ResultInsert(t.id, lm[0].Id,textBox8.Text,textBox4.Text, textBox5.Text,textBox6.Text,textBox7.Text,richTextBox1.Text);
                    lm.RemoveAt(0);
                }
                if (lm.Count <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("NO student to be Marked");
                    return;
                }
                if (lm.Count>0)
                {
                    textBox9.Text = lm[0].name;
                }
               
                    
                
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
