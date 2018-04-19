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
    class PromotionalVideoPropertyRepository : IRepository<PromotionalVideoProperty>
    {
        private LedContext db;

        public PromotionalVideoPropertyRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<PromotionalVideoProperty> GetAll()
        {
            return db.PromotionalVideoProperties;
        }

        public PromotionalVideoProperty Get(int id)
        {
            return db.PromotionalVideoProperties.Find(id);
        }

        public void Create(PromotionalVideoProperty PromotionalVideoProperty)
        {
            db.PromotionalVideoProperties.Add(PromotionalVideoProperty);
        }

        public void Update(PromotionalVideoProperty PromotionalVideoProperty)
        {
            db.Entry(PromotionalVideoProperty).State = EntityState.Modified;
        }

        public IEnumerable<PromotionalVideoProperty> Find(Func<PromotionalVideoProperty, Boolean> predicate)
        {
            return db.PromotionalVideoProperties.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PromotionalVideoProperty PromotionalVideoProperty = db.PromotionalVideoProperties.Find(id);
            if (PromotionalVideoProperty != null)
                db.PromotionalVideoProperties.Remove(PromotionalVideoProperty);
        }
    }
}
