using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Service;

namespace Sina_CSC_Project.Repository
{
    public class StateRepository:IStateRepository
    {
        private readonly ApplicationDbContext _db;

        public StateRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<State> FindAll()
        {
            var state = _db.States
                .Include(c => c.Country)
                .ToList();

            return state;
        }

        public State FindById(int id)
        {
            var state = _db.States
                .Include(c => c.Country)
                .FirstOrDefault(s => s.StateId == id);

            return state;
        }

        public bool isExists(int id)
        {
            var exists = _db.States.Any(s => s.StateId == id);
            return exists;
        }

        public bool Create(State entity)
        {
            _db.States.Add(entity);
            return Save();
        }

        public bool Update(State entity)
        {
            _db.States.Update(entity);
            return Save();
        }

        public bool Delete(State entity)
        {
            _db.States.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var change = _db.SaveChanges();
            return change > 0;
        }

        public ICollection<State> LoadStates(int CountryId)
        {
            var states = FindAll()
                .Where(c => c.CountryId == CountryId)
                .ToList();

            return states;
        }
    }
}
