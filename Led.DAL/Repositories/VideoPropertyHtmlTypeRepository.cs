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
    class VideoPropertyHtmlTypeRepository : IRepository<VideoPropertyHtmlType>
    {
        private readonly LedContext db;

        public VideoPropertyHtmlTypeRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<VideoPropertyHtmlType> GetAll()
        {
            return db.VideoPropertyHtmlTypes;
        }

        public VideoPropertyHtmlType Get(int id)
        {
            return db.VideoPropertyHtmlTypes.Find(id);
        }

        public void Create(VideoPropertyHtmlType VideoPropertyHtmlType)
        {
            db.VideoPropertyHtmlTypes.Add(VideoPropertyHtmlType);
        }

        public void Update(VideoPropertyHtmlType VideoPropertyHtmlType)
        {
            db.Entry(VideoPropertyHtmlType).State = EntityState.Modified;
        }

        public IEnumerable<VideoPropertyHtmlType> Find(Func<VideoPropertyHtmlType, Boolean> predicate)
        {
            return db.VideoPropertyHtmlTypes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            VideoPropertyHtmlType VideoPropertyHtmlType = db.VideoPropertyHtmlTypes.Find(id);
            if (VideoPropertyHtmlType != null)
                db.VideoPropertyHtmlTypes.Remove(VideoPropertyHtmlType);
        }
    }
}
