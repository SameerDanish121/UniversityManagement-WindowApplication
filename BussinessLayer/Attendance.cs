using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Attendance
    {
        public String SubjectName { get; set; }
        public int totalClasses{get;set; }
        public int Present { get;set; }
        public int Absents { get; set; }
        public double Percentage { get; set; }
       
        
    }
}
