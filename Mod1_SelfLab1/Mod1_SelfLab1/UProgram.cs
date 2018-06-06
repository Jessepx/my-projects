using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_SelfLab1
{
    class UProgram
    {
        public string ProgramName { get; set; }
        public Degree Bachelor = new Degree("Bachelor's");

        public UProgram(string name)
        {
            this.ProgramName = name;
        }
    }
}
