using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_SelfLab1
{
    class Course
    {
        public Student Cort = new Student("Cort");
        public Student Patsy = new Student("Patsy");
        public Student George = new Student("George");
        public Teacher MrPlant = new Teacher("Mr. Plant");

        public string CourseName { get; set; }

        public Course(string name)
        {
            this.CourseName = name;
        }
    }
}
