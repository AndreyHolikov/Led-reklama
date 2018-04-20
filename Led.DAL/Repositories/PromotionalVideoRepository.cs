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
    class PromotionalVideoRepository : IRepository<PromotionalVideo>
    {
        private readonly LedContext db;

        public PromotionalVideoRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<PromotionalVideo> GetAll()
        {
            return db.PromotionalVideos;
        }

        public PromotionalVideo Get(int id)
        {
            return db.PromotionalVideos.Find(id);
        }

        public void Create(PromotionalVideo PromotionalVideo)
        {
            db.PromotionalVideos.Add(PromotionalVideo);
        }

        public void Update(PromotionalVideo PromotionalVideo)
        {
            db.Entry(PromotionalVideo).State = EntityState.Modified;
        }

        public IEnumerable<PromotionalVideo> Find(Func<PromotionalVideo, Boolean> predicate)
        {
            return db.PromotionalVideos.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PromotionalVideo PromotionalVideo = db.PromotionalVideos.Find(id);
            if (PromotionalVideo != null)
                db.PromotionalVideos.Remove(PromotionalVideo);
        }
    }
}
