using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Service;

namespace Sina_CSC_Project.Repository
{
    public class CountryRepository:ICountryRepository
    {
        private readonly ApplicationDbContext _db;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Country> FindAll()
        {
            var countries = _db.Countries.ToList();
            return countries;
        }

        public Country FindById(int id)
        {
            var country = _db.Countries.Find(id);
            return country;
        }

        public bool isExists(int id)
        {
            var exists = _db.Countries.Any(c => c.CountryId == id);
            return exists;
        }

        public bool Create(Country entity)
        {
            _db.Countries.Add(entity);
            return Save();
        }

        public bool Update(Country entity)
        {
            _db.Countries.Update(entity);
            return Save();
        }

        public bool Delete(Country entity)
        {
            _db.Countries.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var change = _db.SaveChanges();
            return change > 0;
        }
    }
}
