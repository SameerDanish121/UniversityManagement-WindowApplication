using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public  class StudentResult
    {
        public int  StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Mid { get; set; }
        public int Final { get; set; }
        public int Internal { get; set; }
        public String Grade { get; set; }
        public String Reamrks { get; set; }
        public int Lab { get; set; }
    }
}
