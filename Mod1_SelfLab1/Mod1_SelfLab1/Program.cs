using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_SelfLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalStudents = Student.CountStudents();
            UProgram IT = new UProgram("Information Technology");

            Console.WriteLine($"The name of the program is called, {IT.Bachelor.DegreeName} of {IT.ProgramName}.");
            Console.WriteLine($"The course in the degree is, {IT.Bachelor.Programming.CourseName}");
            Console.WriteLine($"The total number of students is, {Student.CountStudents()}");
        }
    }
}
