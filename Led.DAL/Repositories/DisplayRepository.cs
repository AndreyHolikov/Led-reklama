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
    class DisplayRepository : IRepository<Display>
    {
        private readonly LedContext db;

        public DisplayRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<Display> GetAll()
        {
            return db.Displays;
        }

        public Display Get(int id)
        {
            return db.Displays.Find(id);
        }

        public void Create(Display Display)
        {
            db.Displays.Add(Display);
        }

        public void Update(Display Display)
        {
            db.Entry(Display).State = EntityState.Modified;
        }

        public IEnumerable<Display> Find(Func<Display, Boolean> predicate)
        {
            return db.Displays.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Display Display = db.Displays.Find(id);
            if (Display != null)
                db.Displays.Remove(Display);
        }
    }
}
