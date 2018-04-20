using Led.DAL.EF;
using Led.DAL.Entities;
using Led.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.DAL.Repositories
{
    class LedDisplayPropertyValueRepository : IRepository<LedDisplayPropertyValue>
    {
        private readonly LedContext db;

        public LedDisplayPropertyValueRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<LedDisplayPropertyValue> GetAll()
        {
            return db.LedDisplayPropertyValues;
        }

        public LedDisplayPropertyValue Get(int id)
        {
            return db.LedDisplayPropertyValues.Find(id);
        }

        public void Create(LedDisplayPropertyValue LedDisplayPropertyValue)
        {
            db.LedDisplayPropertyValues.Add(LedDisplayPropertyValue);
        }

        public void Update(LedDisplayPropertyValue LedDisplayPropertyValue)
        {
            db.Entry(LedDisplayPropertyValue).State = EntityState.Modified;
        }

        public IEnumerable<LedDisplayPropertyValue> Find(Func<LedDisplayPropertyValue, Boolean> predicate)
        {
            return db.LedDisplayPropertyValues.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            LedDisplayPropertyValue LedDisplayPropertyValue = db.LedDisplayPropertyValues.Find(id);
            if (LedDisplayPropertyValue != null)
                db.LedDisplayPropertyValues.Remove(LedDisplayPropertyValue);
        }
    }
}
