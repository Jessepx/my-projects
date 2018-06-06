using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_SelfLab1
{
    class Student
    {
        private static int studentCount = 0;
        public string StudentName { get; set; }

        public Student(string name)
        {
            this.StudentName = name;
            studentCount++;
        }

        public static int CountStudents()
        {
            return studentCount;
        }
    }
}
