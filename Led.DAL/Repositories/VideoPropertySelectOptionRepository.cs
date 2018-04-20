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
    class VideoPropertySelectOptionRepository : IRepository<VideoPropertySelectOption>
    {
        private readonly LedContext db;

        public VideoPropertySelectOptionRepository(LedContext context)
        {
            this.db = context;
        }

        public IEnumerable<VideoPropertySelectOption> GetAll()
        {
            return db.VideoPropertySelectOptions;
        }

        public VideoPropertySelectOption Get(int id)
        {
            return db.VideoPropertySelectOptions.Find(id);
        }

        public void Create(VideoPropertySelectOption VideoPropertySelectOption)
        {
            db.VideoPropertySelectOptions.Add(VideoPropertySelectOption);
        }

        public void Update(VideoPropertySelectOption VideoPropertySelectOption)
        {
            db.Entry(VideoPropertySelectOption).State = EntityState.Modified;
        }

        public IEnumerable<VideoPropertySelectOption> Find(Func<VideoPropertySelectOption, Boolean> predicate)
        {
            return db.VideoPropertySelectOptions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            VideoPropertySelectOption VideoPropertySelectOption = db.VideoPropertySelectOptions.Find(id);
            if (VideoPropertySelectOption != null)
                db.VideoPropertySelectOptions.Remove(VideoPropertySelectOption);
        }
    }
}
