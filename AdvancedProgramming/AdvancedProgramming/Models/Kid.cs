using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedProgramming.Enums;

namespace AdvancedProgramming.Models
{
    public class Kid: Person
    {
        public SchoolType SchoolType { get; set; }
        public string NameClass { get; set; }
        public double PocketMonetValue { get; set; }
    }
}
