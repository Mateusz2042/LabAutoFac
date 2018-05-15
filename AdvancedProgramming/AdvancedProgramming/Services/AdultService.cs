using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AdvancedProgramming.DbContext;
using AdvancedProgramming.Enums;
using AdvancedProgramming.Interfaces;
using AdvancedProgramming.Models;

namespace AdvancedProgramming.Services
{
    public class AdultService : IServiceAdult
    {
        private DatabaseContext _db;

        public AdultService()
        {
        }

        public AdultService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateAdult(string firstName, string lastName, int age, string job, Singiel singiel, double salary)
        {
            try
            {
                if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName)
                                                    || String.IsNullOrEmpty(age.ToString()) || String.IsNullOrEmpty(job)
                                                    || String.IsNullOrEmpty(singiel.ToString()) || String.IsNullOrEmpty(salary.ToString()))
                {
                    return false;
                }
                else
                {
                    Adult adult = new Adult()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Job = job,
                        Singiel = singiel,
                        Salary = salary
                    };

                    _db.Adults.Add(adult);

                    await _db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAdult(Guid id)
        {
            try
            {
                Adult adult = await _db.Adults.FindAsync(id);
                _db.Adults.Remove(adult);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Adult> DetailsAdult(Guid id)
        {
            try
            {
                var adult = await _db.Adults.FindAsync(id);
                return adult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Adult> DisplayAdults()
        {
            return _db.Adults.ToList();
        }

        public async Task<bool> EditAdult(Adult adult)
        {
            try
            {
                var eadult = await _db.Adults.FindAsync(adult.Id);

                eadult.Id = adult.Id;
                eadult.FirstName = adult.FirstName;
                eadult.LastName = adult.LastName;
                eadult.Age = adult.Age;
                eadult.Job = adult.Job;
                eadult.Singiel = adult.Singiel;
                eadult.Salary = adult.Salary;

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}