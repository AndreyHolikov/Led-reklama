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
    class OwnerRepository : IRepository<Owner>
    {
        private readonly LedContext db;

        public OwnerRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            return db.Owners.Include(ld => ld.LedDisplays);
        }

        public Owner Get(int id)
        {
            return db.Owners.Find(id);
        }

        public void Create(Owner Owner)
        {
            db.Owners.Add(Owner);
        }

        public void Update(Owner Owner)
        {
            db.Entry(Owner).State = EntityState.Modified;
        }

        public IEnumerable<Owner> Find(Func<Owner, Boolean> predicate)
        {
            return db.Owners.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Owner Owner = db.Owners.Find(id);
            if (Owner != null)
                db.Owners.Remove(Owner);
        }
    }
}
