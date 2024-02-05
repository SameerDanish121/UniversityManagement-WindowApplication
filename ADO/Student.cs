using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BussinessLayer;

namespace DataLayer
{
    public class Student
    {
        public int Id { get; set; }
        public String name { get; set; }
        public int age { get; set; }
        public String Username { get; set; }
        public int Password { get; set; }
        public String Guardian { get; set; }
        public String Gender { get; set; }
        public String Semeseter { get; set; }
        public String Section { get; set; }
        public List<Subject> Subjects = new List<Subject>();
        public List<Attendance> attendances = new List<Attendance>();
        public List<Result> results = new List<Result>();
    }
}
