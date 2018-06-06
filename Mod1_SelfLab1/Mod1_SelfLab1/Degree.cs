using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_SelfLab1
{
    class Degree
    {
        public string DegreeName { get; set; }
        public Course Programming = new Course("C#");

        public Degree(string name)
        {
            this.DegreeName = name;
        }
    }
}
