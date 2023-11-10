using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvgPoint { get; set; }
        public DateTime Birthday { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
