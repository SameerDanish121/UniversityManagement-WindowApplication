using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using DataLayer;

namespace ADO
{
    public class LinqLogic
    {
            public DBManager dob = new DBManager();
            public Student s1;
            public Admin ase;
            public Teacher t1;
        //-------------------------------------------------------STARTING---------------------------------------------------
        public List<MessageBoxList> AllMessage()
        {
            List<MessageBoxList> m = new List<MessageBoxList>();
            dob.opencon();
            String query = "Select *from MessageBox";
            SqlDataReader sdr = dob.select(query);
            while (sdr.Read())
            {
                MessageBoxList m1 = new MessageBoxList();
                m1.id = (int)sdr["id"];
                m1.type = (String)sdr["Sender"];
                m1.message = (String)sdr["Mail"];
                m1.ReciverId = (int)sdr["RciverId"];
                m1.ReciveType = (String)sdr["Reciver"];
                m.Add(m1);
            }
            sdr.Close();
            return m;
        }
        public List<StudentAttendance> AllStudentAttendances()
        {
            List<StudentAttendance> a=new List<StudentAttendance> ();
            dob.opencon();
            String query = "Select *from StudentAttendance";
            SqlDataReader sm=dob.select(query);
            while (sm.Read())
            {
                StudentAttendance sk=new StudentAttendance ();
                sk.StudentId = (int)sm["St_Id"];
                sk.Section = (String)sm["St_Section"];
                sk.SubjectId = (int)sm["Su_Id"];
                sk.status = (String)sm["Status"];
                sk.date = (DateTime)sm["DateOfClass"];

                a.Add(sk);
            }
            sm.Close();
            dob.closecon();
            return a;
        }
        public List<StudentResult> AllStudentResult()
        {
            List<StudentResult> a = new List<StudentResult>();
            dob.opencon();
            String query = "Select *from StudentResult";
            SqlDataReader sm = dob.select(query);
            while (sm.Read())
            {
                StudentResult sk = new StudentResult();
                sk.StudentId = (int)sm["St_Id"];
                sk.SubjectId = (int)sm["Su_Id"];
                sk.Mid= (int)sm["Mid"];
                sk.Internal = (int)sm["Internal"];
                sk.Final = (int)sm["Final"];
                sk.Reamrks= (String)sm["Remarks"];
                sk.Grade= (String)sm["Grade"];
                if (sm["Lab"]!=DBNull.Value)
                {
                    sk.Lab = (int)sm["Lab"];
                }

                a.Add(sk);
            }
            sm.Close();
            dob.closecon();
            return a;
        }
        public List<Teacher> AllTeacher()
        {
            List<Teacher> teacher = new List<Teacher>();
            dob.opencon();
            String query = "select *from Teacher";
            SqlDataReader sdr = dob.select(query);
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
            SqlDataReader sdr = dob.select(query);
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
                sr.Username = (String)sdr["UserName"];
                students.Add(sr);
            }
            dob.closecon();
            sdr.Close();
            return students;
        }
        public List<Subject> AllSubject()
        {
            List<Subject> t = new List<Subject>();
            dob.opencon();
            String query = "select *from Subject";
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
        public List<Admin> AllAdmin()
        {
            dob.opencon();
            List<Admin> a = new List<Admin>();
            String query = "select * from Admin";
            dob.sdr = dob.select(query);
                while (dob.sdr.Read())
                {   Admin an=new Admin();
                    an.Id = (int)dob.sdr["Id"];
                    an.Designation = (String)dob.sdr["Designation"];
                    an.Username = (String)dob.sdr["Username"];
                    an.Password = (int)dob.sdr["Password"];
                    a.Add(an);
                }
            dob.sdr.Close();
            dob.closecon();
            return a;
        }
        public List<StudentSubject> AllStudentSubject()
        {
            List<StudentSubject> srt=new List<StudentSubject> ();
            dob.opencon();
            String query = "Select *from StudentSubject";
            SqlDataReader reader= dob.select(query);
            while (reader.Read())
            {
                StudentSubject s = new StudentSubject();
                s.Id = (int)reader["Id"];
                s.sid = (int)reader["sid"];
                srt.Add(s);
            }
            reader.Close();
            dob.closecon();
            return srt;
        }
        //-------------------------------------------------------ENDING---------------------------------------------------

        public List<Teacher> SearchTeacher(String id, String type)
            {
                List<Teacher> tr = new List<Teacher>();
                List<Teacher> te= AllTeacher(); 
                if (type == "ID")
                {
                    int y = int.Parse(id);
                   tr=te.Where(g=>g.id==y).Select(n=>n).ToList();
                }
                else if (type == "Name")
                {
                  tr = te.Where(g => g.Name == id).Select(n => n).ToList();
                }
                else if (type == "Experience")
                {
                    int y = int.Parse(id);
                  tr = te.Where(g => g.Experience == y).Select(n => n).ToList();
                }
                return tr;
            }
        public int ForgetPassword(String user,String name,String typeData)
        {
            int pass = 0;
            if (user=="Student")
            {
                List<Student> st = AllStudent();
                pass = st.Where(n => n.name == name && n.Guardian == typeData).Select(n => n.Password).FirstOrDefault();
            }else if (user == "Teacher")
            {
                List<Teacher> tr = AllTeacher();
                pass = tr.Where(n => n.Name == name && n.Qualification == typeData).Select(Y => Y.Pass).FirstOrDefault();
            }else if (user == "Admin")
            {
                List<Admin> ar = AllAdmin();
                pass = ar.Where(N => N.Username == typeData).Select(y => y.Password).FirstOrDefault();
            }


            return pass;
        }
        //-------------------------------------------------------------LOGINCODE-----------------------------------------------         
        public String Login(String username, int pass)
        {
            if (StudentCheck(username, pass) == 1)
            {
                return "Student";
            }
            else if (TeacherCheck(username, pass) == 1)
            {
                return "Teacher";
            }
            else if (AdminCheck(username, pass) == 1)
            { 
                    return "Admin";
            }
                return null;
            }
        public int StudentCheck(String u, int p)
        {
            List<Student> students = AllStudent();
            s1 = students.Where(n => n.Username == u && n.Password == p).Select(n => n).FirstOrDefault();
                
            if (s1!=null)
            {
                
                s1.Subjects = FindSubject(s1.Id);
                s1.attendances = CollectAttendance(s1.Id);
                s1.results = CollectResult(s1.Id);
                dob.closecon();
                return 1;
            }
            else
            {
                return 0;
            }
          
        }
        public int AdminCheck(String u, int p)
        {
            List<Admin> a = AllAdmin();
            ase = a.Where(n => n.Username == u && n.Password == p).Select(n => n).FirstOrDefault();
            if (ase != null)
            {
                return 1;
            }
            return 0;
        }
        public int TeacherCheck(String u, int p)
        {
            List<Teacher> teachers = AllTeacher();
            t1 = teachers.Where(n => n.UserName == u && n.Pass == p).Select(n=>n).FirstOrDefault();
            if (t1!=null)
            {
                return 1;
            }
            return 0;
        }
        //-------------------------------------------------------------LOGINCODE ending-----------------------------------------------  

             public List<int> userSubject;
            public List<Subject> FindSubject(int sid)
            {
                List<Subject> se = new List<Subject>();
                List<StudentSubject> t = AllStudentSubject();
                List<int> SubjectList =t.Where(n=>n.sid==sid).Select(n=>n.Id).ToList();
                userSubject = SubjectList;
                List<Subject> st = AllSubject();
                foreach (int a in SubjectList)
                {
                    Subject sr = st.Where(n => n.Id == a).Select(n => n).First();
                    if (sr!=null)
                    {
                    se.Add(sr);
                    }
                }
                return se;
            }
            public List<Attendance> CollectAttendance(int sid)
            {
                dob.opencon();
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

                    String query2 = "Select Count(*) from StudentAttendance where St_Id='" + s1.Id + "' and Su_Id='" + j + "' and status='p'";
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
                    a.totalClasses = a.Absents + a.Present;
                //a.Percentage = (a.Present / a.totalClasses) * 100;
                if (a.totalClasses==0)
                {
                    a.Percentage = 0;
                }
                else {
                    a.Percentage = (int)Math.Round(((double)a.Present / (double)a.totalClasses) * 100);
                }
                   
                    se.Add(a);
                }
                return se;
            }
            public List<Result> CollectResult(int sid)
            {
            dob.opencon();
            List<Result> se = new List<Result>();
                foreach (int j in userSubject)
                {
                    Result a = new Result();
                    String b = "select Name from Subject where Id='" + j + "'";
                    SqlDataReader r = dob.select(b);
                    while (r.Read())
                    {
                        a.Name = r[0].ToString();
                    }
                    r.Close();
                    String query2 = "select Mid,Internal,Grade,Remarks,Lab,Final from StudentResult where St_Id='" + sid + "' and Su_Id='" + j + "'";
                    SqlDataReader reader1 = dob.select(query2);
                    while (reader1.Read())
                    {
                        a.Mid = (int)reader1["Mid"];
                        a.Final = (int)reader1["Final"];
                        a.Grade = (String)reader1["Grade"];
                        a.Internal = (int)reader1["Internal"];
                        a.Reamrks = (String)reader1["Remarks"];
                        if (reader1["Lab"] != DBNull.Value)
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
           
          
          
            public String VerifySubject(int id)
            {               
                List<Subject> st = AllSubject();
                String SubjectName=st.Where(n=>n.Id==id).Select(j=>j.Name).First();
                return SubjectName;
            }
            public List<Student> SearchStudent(String id, String type)
            {
                List<Student> sr = AllStudent();
                List<Student> st = new List<Student>();
                if (type == "ID")
                {
                    int y = int.Parse(id);
                    st = sr.Where(n => n.Id == y).Select(n => n).ToList();
                    
                }
                else if (type == "Name")
                {
                  st = sr.Where(n => n.name== id).Select(n => n).ToList();
                }
                else if (type == "Section")
                {
                    st = sr.Where(n => n.Section == id).Select(n => n).ToList();
                }
                else if (type == "Semester")
                {
                    st = sr.Where(n => n.Semeseter == id).Select(n => n).ToList();
                }
                else if (type == "All")
                {
                   st = sr;
                }
                return st;
            }
          
            
            public List<Subject> SubjectByIDName(String id, String type)
            {
                List<Subject> t = new List<Subject>();
                List<Subject> tr = AllSubject();
                
                if (type == "ID")
                {
                    int id1 = int.Parse(id);
                    t = tr.Where(n => n.Id == id1).Select(n => n).ToList();
                }
                else if (type == "Name")
                {
                   t = tr.Where(n => n.Name == id).Select(n => n).ToList();
                }
                return t;
            }
           
            public List<Sheet> AttendanceSheet(int tid)
            {
                List<Sheet> sheet = new List<Sheet>();

                dob.opencon();
                String query = "select Id from Subject where TeacherId='" + tid + "'";
                SqlDataReader sdr = dob.select(query);
                int SName = 0;
                while (sdr.Read())
                {
                    SName = (int)sdr[0];
                }
                sdr.Close();
                if (SName == 0)
                {
                    return null;
                }
                String query1 = " SELECT DISTINCT(sid) from StudentSubject where Id='" + SName + "' ";
                SqlDataReader sd = dob.select(query1);
                List<int> ids = new List<int>();
                while (sd.Read())
                {
                    int i = (int)sd[0];
                    ids.Add(i);
                }
                sd.Close();


                foreach (int y in ids)
                {
                    Sheet a = new Sheet();
                    String query2 = "Select Count(*) from StudentAttendance where St_Id='" + y + "' and Su_Id='" + SName + "' and status='p'";
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
                    SqlDataReader f = dob.select(query45);
                    while (f.Read())
                    {
                        a.Sname = (String)f[0];
                    }
                    f.Close();

                    String query95 = "select Distinct(DateOfClass) FROM StudentAttendance where Su_Id ='" + SName + "'";
                    SqlDataReader dr = dob.select(query95);
                    int J = 0;
                    while (dr.Read())
                    {
                        J = J + 1;
                    }
                    dr.Close();
                    
                    a.Total = J;
                a.Total = a.Absents + a.Presents;
                    if (a.Total==0)
                    {
                      a.per = 0;
                    }
                    else
                    {
                    a.per = (int)Math.Round(((double)a.Presents / (double)a.Total) * 100);
                    }
                   

                  
                    sheet.Add(a);
                }


                return sheet;
            }
            public List<int> StudentSubject(int cid)
            {
                List<int> i = new List<int>();
                dob.opencon();
                String query = "Select  sid from StudentSubject where Id='" + cid + "'";
                SqlDataReader f = dob.select(query);
                while (f.Read())
                {
                    i.Add((int)f[0]);
                }
                f.Close();
                return i;
            }
            public List<AttendanceMark> AttendanceMark(String Section, String Date, int tid)
            {
                List<Subject> subjects = AllSubject();
                int courceId = subjects.Where(n => n.TeacherId == tid).Select(x => x.Id).FirstOrDefault();



                List<int> ints = StudentSubject(courceId);
                List<Student> stu = AllStudent();
                List<AttendanceMark> a = new List<AttendanceMark>();
                foreach (int y in ints)
                {

                    String name = stu.Where(n => n.Section == Section && n.Id == y).Select(n => n.name).FirstOrDefault();
                    AttendanceMark ar = new AttendanceMark();
                    ar.name = name;
                    ar.id = y;
                    a.Add(ar);
                }


                return a;
            }

        //--------------------------------------------------------InserTion------------------------------------------------
       public void MessageInsert(String SenderType,String RecieveType,int SenderId,int ReciverId,String dataofMessage)
        {
            dob.opencon();
            String query = "insert into MessageBox values('"+SenderId+"','"+SenderType+"','"+dataofMessage+"','"+RecieveType+"','"+ReciverId+"')";
            dob.IUD(query);
            dob.closecon();
        }
        public void Mark(String date, String section, AttendanceMark a, int sid)
        {
            dob.opencon();
            String query = "insert into StudentAttendance values('" + a.id + "','" + section + "','" + sid + "','" + a.status + "','" + date + "')";
            dob.IUD(query);
            dob.closecon();
        }
        public void AddTeacher(Teacher t)
        {
            dob.opencon();
            String query = "insert into Teacher values('" + t.Name + "','" + t.Qualification + "','" + t.Salary + "','" + t.Experience + "','" + t.Pass + "','" + t.UserName + "')";
            dob.IUD(query);
            dob.closecon();
        }
        public void AddStudent(Student s)
        {
            dob.opencon();
            String query = "insert into Students values('" + s.name + "','" + s.age + "','" + s.Gender + "','" + s.Semeseter + "','" + s.Section + "','" + s.Guardian + "','" + s.Password + "','" + s.Username + "')";
            dob.IUD(query);
            dob.closecon();
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
        public void PasswordUpdate(int a, String user, int pass)
        {
            dob.opencon();
            if (user == "Student")
            {
                String query = "Update Students set Pass='" + pass + "' where sid='" + a + "'";
                dob.IUD(query);
            }
            else if (user == "Teacher")
            {
                String query = "Update Teacher set Pass='" + pass + "' where tid='" + a + "'";
                dob.IUD(query);
            }
            else if (user == "Admin")
            {
                String query = "Update Admin set Password='" + pass + "' where Id ='" + a + "'";
                dob.IUD(query);
            }

            dob.closecon();
        }
        public void AddSubject(Subject st)
        {
            dob.opencon();
            String query = "insert into Subject values('" + st.Name + "','" + st.creditHours + "','" + st.TeacherId + "','" + st.TotalMarks + "')";
            dob.IUD(query);
            dob.closecon();
        }
        public void ResultInsert(int tid,int sid,String mid,String Internal,String Final,String Lab,String Grade,String Feedback)
        {
            dob.opencon();
            String query = "insert into StudentResult values('"+sid+"','"+tid+"','"+mid+"','"+Internal+"','"+Final+"','"+Grade+"','"+Feedback+"','"+Lab+"')";
            dob.IUD(query);
            dob.closecon();

        }
        //--------------------------------------------------------InserTion End------------------------------------------------
        public void UpdateStudent(Student s)
        {

            dob.opencon();
            String q = "update Students set Name='" + s.name + "',Age='" + s.age + "',Gender='"+s.Gender+"',Semester='"+s.Semeseter+"',Section='"+s.Section+"',Guardian='"+s.Guardian+"',Pass='"+s.Password+"',UserName='"+s.Username+"' where sid='"+s.Id+"'";
            dob.IUD(q);
            String q1 = "delete from StudentSubject where sid='" + s.Id + "'";
            dob.IUD(q1);
            foreach (var j in s.Subjects)
            {
                String query = "insert into StudentSubject values('" + s.Id + "','" + j.Id + "')";
                dob.IUD(query);
            }
            dob.closecon();
        }
        public void UpdateTeacher(Teacher tr)
        {
            String query= "Update Teacher set Name='"+tr.Name+"',Qualification='"+tr.Qualification+ "',Salary='"+tr.Salary+ "',Experience='"+tr.Experience+ "',Pass='"+tr.Pass+ "',UserName='" + tr.UserName+"' where tid='"+tr.id+"'";
            dob.opencon();
            dob.IUD(query);
            dob.closecon();
        }
    }
}
