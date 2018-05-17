using AdvancedProgramming.Enums;
using AdvancedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AdvancedProgramming.Interfaces
{
    public interface IServiceKid: IDependency
    {
        List<Kid> DisplayKids();
        Task<bool> CreateKid(string firstName, string lastName, int age, SchoolType schoolType, string nameClass, double pocketMonetValue);
        Task<bool> EditKid(Kid kid);
        Task<bool> DeleteKid(Guid id);
        Task<Kid> DetailsKid(Guid id);
    }
}