using Led.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.Controllers
{
    public class LedDisplayController : Controller
    {
        LedContext db = new LedContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET: LedDisplay
        public ActionResult Index(int? ownerId)
        {
            IQueryable<LedDisplay> ledDisplays = db.LedDisplays.Include(p => p.Owner);
            if (ownerId != null && ownerId != 0)
            {
                ledDisplays = ledDisplays.Where(p => p.OwnerId == ownerId);
            }
            return View(ledDisplays);
        }

        // GET: LedDisplay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var LedDisplays = db.LedDisplays.Find(id);

            if (LedDisplays != null)
            {
                // TODO: Получить количество роликов

                return View(LedDisplays);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: LedDisplay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LedDisplay/Create
        [HttpPost]
        public ActionResult Create(LedDisplay ledDisplay)
        {
            try
            {
                db.LedDisplays.Add(ledDisplay);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LedDisplay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            LedDisplay ledDisplay = db.LedDisplays.Find(id);

            if (ledDisplay != null)
            {
                return View(ledDisplay);
            }
            return RedirectToAction("Index");
        }

        // POST: LedDisplay/Edit/5
        [HttpPost]
        public ActionResult Edit(LedDisplay ledDisplay)
        {
            db.Entry(ledDisplay).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LedDisplay/Delete/5
        public ActionResult Delete(int id)
        {
            LedDisplay ledDisplay = db.LedDisplays.Find(id);
            if (ledDisplay == null)
            {
                return HttpNotFound();
            }
            return View(ledDisplay);
        }

        // POST: LedDisplay/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LedDisplay ledDisplay = db.LedDisplays.Find(id);
            if (ledDisplay == null)
            {
                return HttpNotFound();
            }
            db.LedDisplays.Remove(ledDisplay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
