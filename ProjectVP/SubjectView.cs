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

namespace ProjectVP
{
    public partial class SubjectView : Form
    {
        LinqLogic l1=new LinqLogic();
        public SubjectView()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubjectView_Load(object sender, EventArgs e)
        {
            List<Subject> subjects = new List<Subject>();
            subjects = l1.AllSubject();
            foreach (var j in subjects)
            {
                dataGridViewAttendace.Rows.Add(j.Id, j.Name, j.creditHours, j.TotalMarks, j.TeacherId);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                if (comboBox1.SelectedItem.ToString() == null)
                {
                    System.Windows.Forms.MessageBox.Show("Please Select a Option to Filter Data", "Required");
                    return;

                }
                List<Subject> subjects = new List<Subject>();
                if (comboBox1.SelectedItem.ToString() == "All")
                {
                    subjects = l1.AllSubject();

                }
                else if (comboBox1.SelectedItem.ToString() == "ID")
                {
                    if (textBox1.Text == String.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("Please Enter  a Id  to Filter Data", "Required");
                    }
                    subjects = l1.SubjectByIDName(textBox1.Text, "ID");
                }
                else if (comboBox1.SelectedItem.ToString() == "Name")
                {

                    if (textBox1.Text == String.Empty)
                    {
                        System.Windows.Forms.MessageBox.Show("Please Enter  a Name to Filter Data", "Required");
                    }

                    subjects = l1.SubjectByIDName(textBox1.Text, "Name");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please Select a Option to Filter Data", "Required");
                    return;

                }
                dataGridViewAttendace.Rows.Clear();
                foreach (var j in subjects)
                {
                    dataGridViewAttendace.Rows.Add(j.Id, j.Name, j.creditHours, j.TotalMarks, j.TeacherId);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == String.Empty)
                {
                    if (dataGridViewAttendace.SelectedRows.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Select Rows to Delete Course Or Enter Id in Text Box", "Required");
                        return;
                    }
                    else
                    {
                        var Data = dataGridViewAttendace.SelectedRows[0];
                        var Column1 = Data.Cells[0].Value;
                        int id = int.Parse(Column1.ToString());
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete Subject with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            l1.DeleteSubjectByID(id);
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
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete Subject with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        l1.DeleteSubjectByID(id);
                        System.Windows.Forms.MessageBox.Show("Data Deleted", "Done");
                    }
                    else
                    {
                        return;
                    }
                }
            }catch(Exception er) { System.Windows.Forms.MessageBox.Show(er.Message); }
            
        }
    }
}
