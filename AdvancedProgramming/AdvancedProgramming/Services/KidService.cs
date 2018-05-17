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
    public class KidService : IServiceKid, IFilterKid
    {
        private DatabaseContext _db;

        public KidService()
        {
        }

        public KidService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateKid(string firstName, string lastName, int age, SchoolType schoolType, string nameClass, double pocketMonetValue)
        {
            try
            {
                if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName)
                                                    || String.IsNullOrEmpty(age.ToString()) || String.IsNullOrEmpty(schoolType.ToString())
                                                    || String.IsNullOrEmpty(nameClass.ToString()) || String.IsNullOrEmpty(pocketMonetValue.ToString()))
                {
                    return false;
                }
                else
                {
                    Kid kid = new Kid()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        SchoolType = schoolType,
                        NameClass = nameClass,
                        PocketMonetValue = pocketMonetValue
                    };

                    _db.Kids.Add(kid);

                    await _db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteKid(Guid id)
        {
            try
            {
                Kid kid = await _db.Kids.FindAsync(id);
                _db.Kids.Remove(kid);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Kid> DetailsKid(Guid id)
        {
            try
            {
                var kid = await _db.Kids.FindAsync(id);
                return kid;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kid> DisplayKids()
        {
            return _db.Kids.ToList();
        }

        public async Task<bool> EditKid(Kid kid)
        {
            try
            {
                var ekid = await _db.Kids.FindAsync(kid.Id);

                ekid.Id = kid.Id;
                ekid.FirstName = kid.FirstName;
                ekid.LastName = kid.LastName;
                ekid.Age = kid.Age;
                ekid.SchoolType = kid.SchoolType;
                ekid.NameClass = kid.NameClass;
                ekid.PocketMonetValue = kid.PocketMonetValue;

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Kid> Filter(string text)
        {
            var kidList = _db.Kids.ToList();

            if (!String.IsNullOrEmpty(text))
            {
                kidList = kidList.Where(s => s.FirstName.Contains(text) || s.LastName.Contains(text)).ToList();
            }

            return kidList;
        }
    }
}