using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class TeacherCoursesDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Course Course { get; set;}
        //public int CourseId { get; set; }
        //public string Name { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime FinishedDate { get; set; }
    }

}
