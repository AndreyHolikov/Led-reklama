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
    class OfferVideoPropertyRepository : IRepository<OfferVideoProperty>
    {
        private readonly LedContext db;

        public OfferVideoPropertyRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<OfferVideoProperty> GetAll()
        {
            return db.OfferVideoProperties;
        }

        public OfferVideoProperty Get(int id)
        {
            return db.OfferVideoProperties.Find(id);
        }

        public void Create(OfferVideoProperty OfferVideoProperty)
        {
            db.OfferVideoProperties.Add(OfferVideoProperty);
        }

        public void Update(OfferVideoProperty OfferVideoProperty)
        {
            db.Entry(OfferVideoProperty).State = EntityState.Modified;
        }

        public IEnumerable<OfferVideoProperty> Find(Func<OfferVideoProperty, Boolean> predicate)
        {
            return db.OfferVideoProperties.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            OfferVideoProperty OfferVideoProperty = db.OfferVideoProperties.Find(id);
            if (OfferVideoProperty != null)
                db.OfferVideoProperties.Remove(OfferVideoProperty);
        }
    }
}
