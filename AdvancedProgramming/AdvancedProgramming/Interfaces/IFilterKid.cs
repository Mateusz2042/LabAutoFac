using AdvancedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Interfaces
{
    public interface IFilterKid: IDependency
    {
        List<Kid> Filter(string text);
    }
}
