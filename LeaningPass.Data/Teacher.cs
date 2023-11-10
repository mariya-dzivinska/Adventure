using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Teacher
    {
        public Teacher()
        {
            Students = new List<StudentDto>();
        }

        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Skills { get; set; }

        public List<StudentDto> Students { get; set; }
    }
}
