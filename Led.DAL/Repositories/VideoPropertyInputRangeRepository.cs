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
    class VideoPropertyInputRangeRepository : IRepository<VideoPropertyInputRange>
    {
        private readonly LedContext db;

        public VideoPropertyInputRangeRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<VideoPropertyInputRange> GetAll()
        {
            return db.VideoPropertyInputRanges;
        }

        public VideoPropertyInputRange Get(int id)
        {
            return db.VideoPropertyInputRanges.Find(id);
        }

        public void Create(VideoPropertyInputRange VideoPropertyInputRange)
        {
            db.VideoPropertyInputRanges.Add(VideoPropertyInputRange);
        }

        public void Update(VideoPropertyInputRange VideoPropertyInputRange)
        {
            db.Entry(VideoPropertyInputRange).State = EntityState.Modified;
        }

        public IEnumerable<VideoPropertyInputRange> Find(Func<VideoPropertyInputRange, Boolean> predicate)
        {
            return db.VideoPropertyInputRanges.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            VideoPropertyInputRange VideoPropertyInputRange = db.VideoPropertyInputRanges.Find(id);
            if (VideoPropertyInputRange != null)
                db.VideoPropertyInputRanges.Remove(VideoPropertyInputRange);
        }
    }
}
