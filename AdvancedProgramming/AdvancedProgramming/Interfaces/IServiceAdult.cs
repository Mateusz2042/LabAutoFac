using AdvancedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Enums;

namespace AdvancedProgramming.Interfaces
{
    public interface IServiceAdult
    {
        List<Adult> DisplayAdults();
        Task<bool> CreateAdult(string firstName, string lastName, int age, string job, Singiel singiel, double salary);
        Task<bool> EditAdult(Adult adult);
        Task<bool> DeleteAdult(Guid id);
        Task<Adult> DetailsAdult(Guid id);
    }
}
