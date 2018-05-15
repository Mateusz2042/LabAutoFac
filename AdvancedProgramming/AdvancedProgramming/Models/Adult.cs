using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedProgramming.Enums;

namespace AdvancedProgramming.Models
{
    public class Adult: Person
    {
        public string Job { get; set; }
        public Singiel Singiel { get; set; }
        public double Salary { get; set; }
    }
}
