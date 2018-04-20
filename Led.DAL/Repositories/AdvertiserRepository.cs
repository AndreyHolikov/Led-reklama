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
    class AdvertiserRepository : IRepository<Advertiser>
    {
        private readonly LedContext db;

        public AdvertiserRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<Advertiser> GetAll()
        {
            return db.Advertisers;
        }

        public Advertiser Get(int id)
        {
            return db.Advertisers.Find(id);
        }

        public void Create(Advertiser Advertiser)
        {
            db.Advertisers.Add(Advertiser);
        }

        public void Update(Advertiser Advertiser)
        {
            db.Entry(Advertiser).State = EntityState.Modified;
        }

        public IEnumerable<Advertiser> Find(Func<Advertiser, Boolean> predicate)
        {
            return db.Advertisers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Advertiser Advertiser = db.Advertisers.Find(id);
            if (Advertiser != null)
                db.Advertisers.Remove(Advertiser);
        }
    }
}
