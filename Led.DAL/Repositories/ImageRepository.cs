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
    class ImageRepository : IRepository<Image>
    {
        private LedContext db;

        public ImageRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<Image> GetAll()
        {
            return db.Images;
        }

        public Image Get(int id)
        {
            return db.Images.Find(id);
        }

        public void Create(Image Image)
        {
            db.Images.Add(Image);
        }

        public void Update(Image Image)
        {
            db.Entry(Image).State = EntityState.Modified;
        }

        public IEnumerable<Image> Find(Func<Image, Boolean> predicate)
        {
            return db.Images.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Image Image = db.Images.Find(id);
            if (Image != null)
                db.Images.Remove(Image);
        }
    }
}
