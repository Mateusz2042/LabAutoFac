using AdvancedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Interfaces
{
    public interface IFilterAdult: IDependency
    {
        List<Adult> Filter(string text);
    }
}
