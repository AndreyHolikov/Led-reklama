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
    class LedDisplayPropertyRepository : IRepository<LedDisplayProperty>
    {
        private LedContext db;

        public LedDisplayPropertyRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<LedDisplayProperty> GetAll()
        {
            return db.LedDisplayProperties;
        }

        public LedDisplayProperty Get(int id)
        {
            return db.LedDisplayProperties.Find(id);
        }

        public void Create(LedDisplayProperty LedDisplayProperty)
        {
            db.LedDisplayProperties.Add(LedDisplayProperty);
        }

        public void Update(LedDisplayProperty LedDisplayProperty)
        {
            db.Entry(LedDisplayProperty).State = EntityState.Modified;
        }

        public IEnumerable<LedDisplayProperty> Find(Func<LedDisplayProperty, Boolean> predicate)
        {
            return db.LedDisplayProperties.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            LedDisplayProperty LedDisplayProperty = db.LedDisplayProperties.Find(id);
            if (LedDisplayProperty != null)
                db.LedDisplayProperties.Remove(LedDisplayProperty);
        }
    }
}
