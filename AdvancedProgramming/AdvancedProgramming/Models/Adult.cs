using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedProgramming.Models
{
    public class Adult: Person
    {
        public string Job { get; set; }
        public bool Singiel { get; set; }
        public double Salary { get; set; }
    }
}
