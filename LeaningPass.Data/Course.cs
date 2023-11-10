using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string Skills { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}
