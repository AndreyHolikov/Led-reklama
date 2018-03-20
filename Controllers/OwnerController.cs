using Led.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.Controllers
{
    public class OwnerController : Controller
    {
        LedContext db = new LedContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET: Owner
        public ActionResult Index()
        {
            return View(db.Owners.Include(ld => ld.LedDisplays));
        }

        // GET: Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return HttpNotFound(); 
            }
            var owner = db.Owners.Find(id);
            
            if (owner != null)
            {
                // TODO: Получить количество экранов
                ViewBag.LedDisplaysCount 
                    = db.Owners.Include(ld => ld.LedDisplays)
                    .FirstOrDefault<Owner>( o =>o.Id == id)
                    .LedDisplays.Count();
                return View(owner);
            } else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            try
            {
                db.Owners.Add(owner);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if( id == null )
            {
                return HttpNotFound();
            }
            Owner owner = db.Owners.Find(id);

            if ( owner != null)
            {
                return View(owner);
            } 
            return RedirectToAction("Index");
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public ActionResult Edit(Owner owner)
        {
            db.Entry(owner).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = db.Owners.Find(id);
            if(owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = db.Owners.Find(id);
            if(owner == null)
            {
                return HttpNotFound();
            }
            db.Owners.Remove(owner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
