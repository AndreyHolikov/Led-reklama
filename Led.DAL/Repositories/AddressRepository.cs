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
    class AddressRepository : IRepository<Address>
    {
        private readonly LedContext db;

        public AddressRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<Address> GetAll()
        {
            //var addresses = db.Database.SqlQuery<Address>(
            //  
            //    "SELECT Addresses.Id, Addresses.FullAddress, City.Name as City.Name, City.ID as City.Id FROM Addresses, Cities WHERE Address.CityId=City.ID");
            //return addresses;
            return db.Addresses.Include(a=>a.City);
        }

        public Address Get(int id)
        {
            return db.Addresses.Find(id);
        }

        public void Create(Address Address)
        {
            db.Addresses.Add(Address);
        }

        public void Update(Address Address)
        {
            db.Entry(Address).State = EntityState.Modified;
        }

        public IEnumerable<Address> Find(Func<Address, Boolean> predicate)
        {
            return db.Addresses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Address Address = db.Addresses.Find(id);
            if (Address != null)
                db.Addresses.Remove(Address);
        }
    }
}
