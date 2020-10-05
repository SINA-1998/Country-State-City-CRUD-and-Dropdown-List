using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Service;

namespace Sina_CSC_Project.Repository
{
    public class CityRepository:ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<City> FindAll()
        {
            var city = _db.Cities
                .Include(s => s.State)
                .Include(ci => ci.State.Country)
                .ToList();

            return city;
        }

        public City FindById(int id)
        {
            var city = _db.Cities
                .Include(s => s.State)
                .Include(c => c.State.Country)
                .FirstOrDefault(ci => ci.CityId == id);

            return city;
        }

        public bool isExists(int id)
        {
            var exists = _db.Cities.Any(ci => ci.CityId == id);
            return exists;
        }

        public bool Create(City entity)
        {
            _db.Cities.Add(entity);
            return Save();
        }

        public bool Update(City entity)
        {
            _db.Cities.Update(entity);
            return Save();
        }

        public bool Delete(City entity)
        {
            _db.Cities.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var change = _db.SaveChanges();
            return change > 0;
        }

        public ICollection<City> GetCitiesByState(int StateId)
        {
            var cities = FindAll()
                .Where(s => s.StateId == StateId)
                .ToList();

            return cities;
        }
    }
}
