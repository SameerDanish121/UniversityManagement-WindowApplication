using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataLayer;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using static System.Collections.Specialized.BitVector32;

namespace BussinessLayer
{
    public class Logic
    {
        
       public  DBManager dob = new DBManager();
        public Student s1 = new Student();
        public Admin ase=new Admin();
        public Teacher t1=new Teacher();
        public List<Teacher> SearchTeacher(String id,String type)
        {
           
            dob.opencon();
            String query = "select *from Teacher";
            if (type=="ID")
            {
                int y = int.Parse(id);
                query = "select *from Teacher where tid='" + y+ "'";
            }else if (type == "Name")
            {
                query = "select *from Teacher where Name='" + id + "'";
            }
            else if (type== "Experience")
            {

                int y = int.Parse(id);
                query = "select *from Teacher where Experience='" + id + "'";
            }
            
            SqlDataReader sdr = dob.select(query);
            List<Teacher> r = new List<Teacher>();
            while (sdr.Read())
            {
                Teacher sr = new Teacher();
                sr.id = (int)sdr["tid"];
                sr.Name = (String)sdr["Name"];
                sr.Qualification = (String)sdr["Qualification"];
                sr.Salary = double.Parse(sdr["Salary"].ToString());
                sr.Experience = (int)sdr["Experience"];
                sr.Pass = (int)sdr["Pass"];
                sr.UserName = (String)sdr["UserName"];

                r.Add(sr);
            }
            dob.conn.Close();
            sdr.Close();
            return r;
        }
        public List<Teacher> AllTeacher()
        {
            List<Teacher> teacher=new List<Teacher> ();
            dob.opencon();
            String query = "select *from Teacher";
            SqlDataReader sdr = dob.select(query);
            while (sdr.Read())
            {
                Teacher sr = new Teacher();
                sr.id = (int)sdr["tid"];
                sr.Name = (String)sdr["Name"];
                sr.Qualification = (String)sdr["Qualification"];
                sr.Salary =double.Parse( sdr["Salary"].ToString());
                sr.Experience = (int)sdr["Experience"];
                sr.Pass = (int)sdr["Pass"];
                sr.UserName = (String)sdr["UserName"];

              
               teacher.Add(sr);
            }
            dob.closecon();
            sdr.Close();
            return teacher;
        }
        public List<Student> AllStudent()
        {
            List<Student> students = new List<Student>();
            dob.opencon();
            String query = "select *from Students";
            SqlDataReader sdr=dob.select(query);
            while (sdr.Read())
            {
                Student sr = new Student();
                sr.Id = (int)sdr["sid"];
                sr.name = (String)sdr["Name"];
                sr.age = (int)sdr["Age"];
                sr.Section = (String)sdr["Section"];
                sr.Guardian = (String)sdr["Guardian"];
                sr.Password = (int)sdr["Pass"];
                sr.Semeseter = (String)sdr["Semester"];
                sr.Gender = (String)sdr["Gender"];
                students.Add(sr);
            }
            dob.closecon();
            sdr.Close();
            return students;
        }
        public String Login(String username, int pass)
        {
            dob.opencon();
            if (StudentCheck(username, pass) == 1)
            {
                dob.conn.Close();
                return "Student";
            }
            else if (TeacherCheck(username, pass) == 1)
            {

                dob.conn.Close();
                return "Teacher";
            }

            else if (AdminCheck(username, pass) == 1)
            {

                dob.conn.Close();
                return "Admin";
            }
            dob.conn.Close();
            dob.sdr.Close();
            dob.closecon();
            return null;
        }
        List<int> userSubject;
        public List<Subject> FindSubject(int sid)
        {
            List<Subject> se=new List<Subject> ();
            
            String query2 = "Select Id from StudentSubject where sid='" + s1.Id + "'";
            SqlDataReader reader1= dob.select(query2);
            List<int> SubjectList = new List<int>();

            while (reader1.Read())
            {
                SubjectList.Add((int)reader1["Id"]);
            }
            userSubject = SubjectList;
            reader1.Close();
            foreach (int a in SubjectList)
            {
                String query1 = "select Id,Name,CreditHour,TeacherId,TotalMarks from Subject where Id='" + a + "'";
               SqlDataReader data = dob.select(query1);
                while (data.Read())
                {
                    Subject sr = new Subject();
                    sr.Id = (int)data["Id"];
                    sr.Name = (String)data["Name"];
                    sr.creditHours = (int)data["CreditHour"];
                    sr.TeacherId = (int)data["TeacherId"];
                    sr.TotalMarks = (int)data["TotalMarks"];
                    se.Add(sr);

                }
                data.Close();
                
            }
            return se;
        }
        public List<Attendance> CollectAttendance(int sid)
        {
            List<Attendance> se = new List<Attendance>();
            foreach (int j in userSubject)
            {
                Attendance a = new Attendance();
                String b = "select Name from Subject where Id='" + j + "'";
                SqlDataReader r = dob.select(b);
                while (r.Read())
                {
                    a.SubjectName = r[0].ToString();
                }
                r.Close();

                String query2 = "Select Count(*) from StudentAttendance where St_Id='" + s1.Id + "' and Su_Id='"+j+"' and status='p'";
                SqlDataReader reader1 = dob.select(query2);
                while (reader1.Read())
                {
                    a.Present = (int)reader1[0];
                }
                reader1.Close();

                String query3 = "Select Count(*) from StudentAttendance where St_Id='" + s1.Id + "' and Su_Id='" + j + "' and status='a'";
                SqlDataReader reader2 = dob.select(query3);
                while (reader2.Read())
                {
                    a.Absents = (int)reader2[0];
                }
                

                reader2.Close();
                a.Percentage = (int)Math.Round(((double)a.Present / (double)a.totalClasses) * 100);
               
                a.totalClasses = a.Absents + a.Present;
                se.Add(a);
            }
            return se;

        }
           
           

            
        public List<Result> CollectResult(int sid)
        {
            List<Result> se=new List<Result>();
            foreach (int j in userSubject)
            {
                Result a = new Result();
                String b = "select Name from Subject where Id='" + j + "'";
                SqlDataReader r=dob.select(b);
                while (r.Read())
                {
                    a.Name = r[0].ToString();
                }
                r.Close();
                String query2 = "select Mid,Internal,Grade,Remarks,Lab,Final from StudentResult where St_Id='"+sid+"' and Su_Id='"+j+"'";
                SqlDataReader reader1 = dob.select(query2);
                while (reader1.Read())
                {
                    a.Mid = (int)reader1["Mid"];
                    a.Final = (int)reader1["Final"];
                    a.Grade = (String)reader1["Grade"];
                    a.Internal = (int)reader1["Internal"];
                    a.Reamrks = (String)reader1["Remarks"];
                    if (reader1["Lab"]!=DBNull.Value)
                    {
                        a.Lab = (int)reader1["Lab"];

                    }
                    else
                    {
                        a.Lab = 0;
                    }
                   
                    
                    
                    se.Add(a);
                }
                reader1.Close();

            }
            return se;
        }
        public int StudentCheck(String u, int p)
        {
            String query = "select sid,Name,Age,Section,Guardian,Pass,UserName,Semester,Gender from Students where Pass='" + p + "' and UserName='" + u + "'";
                dob.sdr = dob.select(query);
                if (dob.sdr.HasRows)
                {
                    while (dob.sdr.Read())
                    {
                        s1.Id = (int)dob.sdr["sid"];
                        s1.name = (String)dob.sdr["Name"];
                        s1.age = (int)dob.sdr["Age"];
                        s1.Section = (String)dob.sdr["Section"];
                        s1.Guardian = (String)dob.sdr["Guardian"];
                        s1.Password = (int)dob.sdr["Pass"];
                        s1.Username = (String)dob.sdr["UserName"];
                        s1.Semeseter = (String)dob.sdr["Semester"];
                        s1.Gender = (String)dob.sdr["Gender"];

                    }
                dob.sdr.Close();
                s1.Subjects = FindSubject(s1.Id);
                s1.attendances = CollectAttendance(s1.Id);
                s1.results = CollectResult(s1.Id);


                   
                    dob.closecon();
                    return 1;
                }
                dob.sdr.Close();
                dob.closecon();
           

            return 0;
        }
        public int AdminCheck(String u, int p)
        {
            dob.opencon();
            String query = "select * from Admin Where Username='" + u + "' and  Password='"+ p+"' ";
            dob.sdr = dob.select(query);
            if (dob.sdr.HasRows)
            {
                while (dob.sdr.Read())
                {
                    ase.Id = (int)dob.sdr["Id"];
                    ase.Username = u;
                    ase.Password = p;
                    ase.Designation = (String)dob.sdr["Designation"];
                }
                dob.sdr.Close();
                dob.closecon();
                return 1;
            }
            dob.sdr.Close();
            dob.closecon();
            return 0;
        }
        public int TeacherCheck(String u, int p)
        {
            dob.opencon();
            String query = "select *from Teacher where Pass='" + p + "' and UserName='" + u + "'";
            dob.sdr = dob.select(query);
            if (dob.sdr.HasRows)
            {
                while (dob.sdr.Read())
                {
                   
                    t1.id = (int)dob.sdr["tid"];
                    t1.Name = (String)dob.sdr["Name"];
                    t1.Qualification = (String)dob.sdr["Qualification"];
                    t1.Salary = double.Parse(dob.sdr["Salary"].ToString());
                    t1.Experience = (int)dob.sdr["Experience"];
                    t1.Pass = (int)dob.sdr["Pass"];
                    t1.UserName = (String)dob.sdr["UserName"];
                }
                dob.sdr.Close();
                dob.closecon();
                return 1;
            }
            dob.sdr.Close();
            dob.closecon();
            return 0;
        }
        public void PasswordUpdate(int a,String user,int pass)
        {
            dob.opencon();
            if (user == "Student")
            {
                String query = "Update Students set Pass='" + pass + "' where sid='"+a+"'";
                dob.IUD(query);
            }
            else if (user == "Teacher")
            {
                String query = "Update Teacher set Pass='" + pass + "' where tid='"+a+"'";
                dob.IUD(query);
            }
            else if (user == "Admin")
            {
                String query = "Update Admin set Password='" + pass + "' where Id ='"+a+"'";
                dob.IUD(query);
            }

            dob.closecon();
        }      
        public void AddTeacher(Teacher t)
        {
            dob.opencon();
            String query = "insert into Teacher values('"+t.Name+"','"+t.Qualification+"','"+t.Salary+"','"+t.Experience+"','"+t.Pass+"','"+t.UserName+"')";
            dob.IUD(query);
            dob.closecon();
        }
        public void AddStudent(Student s)
        {
            dob.opencon();
            String query = "insert into Students values('" + s.name + "','" + s.age + "','" + s.Gender+ "','" + s.Semeseter + "','" + s.Section + "','" + s.Guardian + "','"+s.Password+"','"+s.Username+"')";
            dob.IUD(query);
            dob.closecon();
        }
        public String VerifySubject(int id)
        {
            String SubjectName = null;
            dob.opencon();
            String b = "select Name from Subject where Id='" + id + "'";
            SqlDataReader r = dob.select(b);
            if (r.Read())
            {
                SubjectName = r[0].ToString();
            }
            r.Close();
            dob.closecon();
            return SubjectName;
        }
        public List<Student> SearchStudent(String id, String type)
        {

            dob.opencon();
            String query = "select *from Students";
            if (type == "ID")
            {
                int y = int.Parse(id);
                query = "select *from Students where sid='" + y + "'";
            }
            else if (type == "Name")
            {
                query = "select *from Students where Name='" + id + "'";
            }
            else if (type == "Section")
            {

               
                query = "select *from Students where Section='" + id + "'";
            }else if (type == "Semester")
            {
                query = "select *from Students where Semester='" + id + "'";
            }
            else if(type=="All")
            {
                 query = "select *from Students";
            }

            SqlDataReader sdr = dob.select(query);
            List<Student> r = new List<Student>();
            while (sdr.Read())
            {
                Student sr = new Student();
                sr.Id= (int)sdr["sid"];
                sr.name = (String)sdr["Name"];
                sr.age= (int)sdr["Age"];
                sr.Section = (String)sdr["Section"].ToString();
                sr.Semeseter= (String)sdr["Semester"];
                sr.Password= (int)sdr["Pass"];
                sr.Username = (String)sdr["UserName"];
                sr.Gender= (String)sdr["Gender"];
                sr.Guardian= (String)sdr["Guardian"];

                r.Add(sr);
            }
            dob.conn.Close();
            sdr.Close();
            return r;
        }
        public  void AddSubject(Subject st)
        {
            dob.opencon();
            String query = "insert into Subject values('" + st.Name + "','" + st.creditHours + "','" + st.TeacherId + "','" + st.TotalMarks + "')";
            dob.IUD(query);
            dob.closecon();
        }
        public List<Subject> AllSubject()
        {
            List<Subject> t= new List<Subject>();
            dob.opencon();
            String query = "select *from Subject";
           SqlDataReader data= dob.select(query);
            while (data.Read())
            {
                Subject sr = new Subject();
                sr.Id = (int)data["Id"];
                sr.Name = (String)data["Name"];
                sr.creditHours = (int)data["CreditHour"];
                sr.TeacherId = (int)data["TeacherId"];
                sr.TotalMarks = (int)data["TotalMarks"];
                t.Add(sr);
            }
            data.Close();
            dob.closecon();
            return t;
        }
        public List<Subject> SubjectByIDName(String id,String type)
        {
            List<Subject> t = new List<Subject>();
            dob.opencon();
            String query = "select *from Subject";
            if (type=="ID")
            {
                int id1 = int.Parse(id);
                query = "select *from Subject where Id='"+id1+"'";
            }else if (type=="Name")
            {
                query = "select *from Subject where Name='" + id + "'";
            }
            SqlDataReader data = dob.select(query);
            while (data.Read())
            {
                Subject sr = new Subject();
                sr.Id = (int)data["Id"];
                sr.Name = (String)data["Name"];
                sr.creditHours = (int)data["CreditHour"];
                sr.TeacherId = (int)data["TeacherId"];
                sr.TotalMarks = (int)data["TotalMarks"];
                t.Add(sr);
            }
            data.Close();
            dob.closecon();
            return t;
        }
        public void DeleteSubjectByID(int id)
        {
            dob.opencon();
            String query = "delete from Subject where Id='" + id + "'";
            dob.IUD(query);
            dob.closecon();


        }
        public void DeleteStudentByID(int id)
        {
            dob.opencon();
            String query = "delete from Students where sid='" + id + "'";
            dob.IUD(query);
            dob.closecon();


        }
        public void DeleteTeacherByID(int id)
        {
            dob.opencon();
            String query = "delete from Teacher where tid='" + id + "'";
            dob.IUD(query);
            dob.closecon();


        }
        public List<Sheet> AttendanceSheet(int tid)
        {
            List<Sheet> sheet=new List<Sheet>();

            dob.opencon();
            String query="select Id from Subject where TeacherId='"+tid+"'";
            SqlDataReader sdr= dob.select(query);
            int SName = 0;
            while (sdr.Read())
            {
                SName = (int)sdr[0];
            }
            sdr.Close();
            if (SName==0)
            {
                return null;
            }
            String query1 = " SELECT DISTINCT(sid) from StudentSubject where Id='" + SName + "' ";
           SqlDataReader sd= dob.select(query1);
            List<int> ids = new List<int>();
            while (sd.Read())
            {
                int i = (int)sd[0];
                ids.Add(i);
            }
            sd.Close();


            foreach (int y in ids)
            {
                Sheet a=new Sheet();
                String query2 = "Select Count(*) from StudentAttendance where St_Id='" +y + "' and Su_Id='" + SName + "' and status='p'";
                SqlDataReader reader1 = dob.select(query2);
                while (reader1.Read())
                {
                    a.Presents = (int)reader1[0];
                }
                reader1.Close();

                String query3 = "Select Count(*) from StudentAttendance where St_Id='" + y + "' and Su_Id='" + SName + "' and status='a'";
                SqlDataReader reader2 = dob.select(query3);
                while (reader2.Read())
                {
                    a.Absents = (int)reader2[0];
                }


                reader2.Close();
                String query45 = "select Name from Students where sid='" + y + "'";
                SqlDataReader f= dob.select(query45);
                while (f.Read())
                {
                    a.Sname = (String)f[0];
                }
                f.Close();

                String query95 = "select Distinct(DateOfClass) FROM StudentAttendance where Su_Id ='"+SName+"'";
                SqlDataReader dr = dob.select(query95);
                int J = 0;
                while (dr.Read())
                {
                    J = J + 1;
                }
                dr.Close();
                a.Total = J;

                a.per = a.Presents / a.Total; 
                
                a.per = a.per * 100;
                sheet.Add(a);
            }


            return sheet;
        }
        public List<int> StudentSubject(int cid)
        {
            List<int> i = new List<int>();
            dob.opencon();
            String query = "Select  sid from StudentSubject where Id='"+cid+"'";
            SqlDataReader f=dob.select(query);
            while (f.Read())
            {
                i.Add((int)f[0]);
            }
            f.Close();
            return i;
        }
        public List<AttendanceMark> AttendanceMark(String Section,String Date,int tid)
        {
            List<Subject> subjects = AllSubject();
            int courceId = subjects.Where(n => n.TeacherId == tid).Select(x=>x.Id).FirstOrDefault();



            List<int> ints = StudentSubject(courceId);
            List<Student> stu= AllStudent();
            List<AttendanceMark> a = new List<AttendanceMark>();
            foreach (int y in ints)
            {
                
                String name= stu.Where(n => n.Section == Section && n.Id ==y).Select(n=>n.name).FirstOrDefault();
                AttendanceMark ar = new AttendanceMark();
                ar.name = name;
                ar.id = y;
                a.Add(ar);
            }
           

            return a;
        }
        public void  Mark(String date, String section, AttendanceMark a,int sid)
        {
            dob.opencon();
            String query = "insert into StudentAttendance values('"+a.id+"','"+section+"','"+sid+"','"+a.status+"','"+date+"')";
            dob.IUD(query);
            dob.closecon();



        }
    }
}
