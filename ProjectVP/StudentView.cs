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
using static System.Collections.Specialized.BitVector32;


namespace ProjectVP
{
    public partial class StudentView : Form
    {
        public StudentView()
        {
            InitializeComponent();
        }
      
       
        
        LinqLogic l = new LinqLogic();
        private void StudentView_Load(object sender, EventArgs e)
        {
            List<Student> sr=l.AllStudent();
            foreach (Student se in sr)
            {
                dataGridViewAttendace.Rows.Add(se.Id,se.name,se.age,se.Guardian,se.Gender,se.Semeseter,se.Section,se.Password);
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewAttendace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == String.Empty)
                {
                    if (dataGridViewAttendace.SelectedRows.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Select Rows to Delete Student Or Enter Id in Text Box", "Required");
                        return;
                    }
                    else
                    {
                        var Data = dataGridViewAttendace.SelectedRows[0];
                        var Column1 = Data.Cells[0].Value;
                        int id = int.Parse(Column1.ToString());
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete student with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            l.DeleteStudentByID(id);
                            System.Windows.Forms.MessageBox.Show("Data Deleted", "Done");
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    int id = int.Parse(textBox2.Text.ToString());
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete student with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        l.DeleteStudentByID(id);
                        System.Windows.Forms.MessageBox.Show("Data Deleted", "Done");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception er) { System.Windows.Forms.MessageBox.Show(er.Message); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == String.Empty)
                {
                    if (dataGridViewAttendace.SelectedRows.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Select Rows to Update Student Or Enter Id in Text Box", "Required");
                        return;
                    }
                    else
                    {
                        var Data = dataGridViewAttendace.SelectedRows[0];
                        var Column1 = Data.Cells[0].Value;
                        int id = int.Parse(Column1.ToString());
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Update student with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            //l.DeleteStudentByID(id);
                            AddStudent sr = new AddStudent();
                            sr.usage = "Update";
                            sr.id = id;
                            sr.Show();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    int id = int.Parse(textBox2.Text.ToString());
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Update student with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        AddStudent sr = new AddStudent();
                        sr.usage = "Update";
                        sr.id = id;
                        sr.Show();
                        //l.DeleteStudentByID(id);
                     
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception er) { System.Windows.Forms.MessageBox.Show(er.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                List<Student> sr = new List<Student>();
                if (comboBox1.SelectedItem == null)
                {
                    System.Windows.Forms.MessageBox.Show("Please Enter a Value Or Select Option for Filteration", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (comboBox1.SelectedItem.ToString() == "All")
                {
                    sr = l.AllStudent();

                }
                else if (comboBox1.SelectedItem.ToString() == "Name")
                {
                    if (textBox1.Text == String.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("Please Enter a Value Or Select Option for Filteration", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox1.Focus();
                        return;
                    }
                    sr = l.SearchStudent(textBox1.Text, "Name");
                }
                else if (comboBox1.SelectedItem.ToString() == "ID")
                {
                    if (textBox1.Text == String.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("Please Enter a Value Or Select Option for Filteration", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox1.Focus();
                        return;
                    }
                    sr = l.SearchStudent(textBox1.Text, "ID");
                }
                else if (comboBox1.SelectedItem.ToString() == "Section")
                {
                    if (textBox1.Text == String.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("Please Enter a Value Or Select Option for Filteration", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox1.Focus();
                        return;
                    }
                    sr = l.SearchStudent(textBox1.Text, "Section");
                }
                else if (comboBox1.SelectedItem.ToString() == "Descipline")
                {
                    if (textBox1.Text == String.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("Please Enter a Value Or Select Option for Filteration", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox1.Focus();
                        return;
                    }
                    sr = l.SearchStudent(textBox1.Text, "Semester");
                }
                dataGridViewAttendace.Rows.Clear();
                foreach (Student se in sr)
                {

                    dataGridViewAttendace.Rows.Add(se.Id, se.name, se.age, se.Guardian, se.Gender, se.Semeseter, se.Section, se.Password);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



              
            
            
                
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == String.Empty)
                {
                    if (dataGridViewAttendace.SelectedRows.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Select Rows to Generate Student  Report Card Or Enter Id in Text Box", "Required");
                        return;
                    }
                    else
                    {
                        var Data = dataGridViewAttendace.SelectedRows[0];
                        var Column1 = Data.Cells[0].Value;
                        int id = int.Parse(Column1.ToString());
                       
                        
                           
                            ReportCard1 r1 = new ReportCard1();
                            r1.id = id;
                            r1.Show();
                            
                       
                    }
                }
                else
                {
                    int id = int.Parse(textBox2.Text.ToString());
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete student with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ReportCard1 r1 = new ReportCard1();
                        r1.id = id;
                        r1.Show();
                        System.Windows.Forms.MessageBox.Show("Data Deleted", "Done");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception er) { System.Windows.Forms.MessageBox.Show(er.Message); }
        }
    }
}
