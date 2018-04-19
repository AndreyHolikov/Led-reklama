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
    class CalculatorRepository : IRepository<Calculator>
    {
        private LedContext db;

        public CalculatorRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<Calculator> GetAll()
        {
            return db.Calculators;
        }

        public Calculator Get(int id)
        {
            return db.Calculators.Find(id);
        }

        public void Create(Calculator Calculator)
        {
            db.Calculators.Add(Calculator);
        }

        public void Update(Calculator Calculator)
        {
            db.Entry(Calculator).State = EntityState.Modified;
        }

        public IEnumerable<Calculator> Find(Func<Calculator, Boolean> predicate)
        {
            return db.Calculators.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Calculator Calculator = db.Calculators.Find(id);
            if (Calculator != null)
                db.Calculators.Remove(Calculator);
        }
    }
}
