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

namespace ProjectVP
{
    public partial class TeacherView : Form
    {
        LinqLogic l = new LinqLogic();
        public TeacherView()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "All")
                {
                    dataGridViewAttendace.Rows.Clear();
                    List<Teacher> R = l.AllTeacher();
                    foreach (var j in R)
                    {
                        dataGridViewAttendace.Rows.Add(j.id, j.Name, j.Qualification, j.Experience, j.UserName, j.Pass, j.Salary);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "ID")
                {
                    dataGridViewAttendace.Rows.Clear();
                    List<Teacher> R = l.SearchTeacher(textBox1.Text, "ID");
                    foreach (var j in R)
                    {
                        dataGridViewAttendace.Rows.Add(j.id, j.Name, j.Qualification, j.Experience, j.UserName, j.Pass, j.Salary);
                    }

                }
                else if (comboBox1.SelectedItem.ToString() == "Experience")
                {
                    dataGridViewAttendace.Rows.Clear();
                    List<Teacher> R = l.SearchTeacher(textBox1.Text, "Experience");
                    foreach (var j in R)
                    {
                        dataGridViewAttendace.Rows.Add(j.id, j.Name, j.Qualification, j.Experience, j.UserName, j.Pass, j.Salary);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Name")
                {
                    dataGridViewAttendace.Rows.Clear();
                    List<Teacher> R = l.SearchTeacher(textBox1.Text, "Name");
                    foreach (var j in R)
                    {
                        dataGridViewAttendace.Rows.Add(j.id, j.Name, j.Qualification, j.Experience, j.UserName, j.Pass, j.Salary);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void TeacherView_Load(object sender, EventArgs e)
        {
           
          List<Teacher> R = l.AllTeacher();
            foreach (var j in R)
            {
                dataGridViewAttendace.Rows.Add(j.id,j.Name,j.Qualification,j.Experience,j.UserName,j.Pass,j.Salary);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == String.Empty)
                {
                    if (dataGridViewAttendace.SelectedRows.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Select Rows to Delete Teacher Or Enter Id in Text Box", "Required");
                        return;
                    }
                    else
                    {
                        var Data = dataGridViewAttendace.SelectedRows[0];
                        var Column1 = Data.Cells[0].Value;
                        int id = int.Parse(Column1.ToString());
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete Teacher with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            l.DeleteTeacherByID(id);
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
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete Teacher with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        l.DeleteTeacherByID(id);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == String.Empty)
                {
                    if (dataGridViewAttendace.SelectedRows.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Select Rows to Update Teacher Or Enter Id in Text Box", "Required");
                        return;
                    }
                    else
                    {
                        var Data = dataGridViewAttendace.SelectedRows[0];
                        var Column1 = Data.Cells[0].Value;
                        int id = int.Parse(Column1.ToString());
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Update Teacher with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {

                            AddTeacher tp = new AddTeacher();
                            tp.user = "Update";
                            tp.eid = id;
                            tp.Show();
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
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Are you Sure to Delete Teacher with Id '" + id + "' ", "Required", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        AddTeacher tp = new AddTeacher();
                        tp.user = "Update";
                        tp.eid = id;
                        tp.Show();
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
