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
        public ActionResult Index(int ownerId = 0)
        {
            ViewBag.OwnerId = ownerId;
            IQueryable<LedDisplay> ledDisplays 
                = db.LedDisplays
                .Include(p => p.Owner)
                .Include(p => p.Address)
                .Include(p => p.Address.City);
            if (ownerId > 0)
            {
                ledDisplays = ledDisplays.Where(p => p.OwnerId == ownerId);
            }
            return View(ledDisplays);
        }

        // GET: LedDisplay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Index");
            }
            var ledDisplays
                = db.LedDisplays
                .Include(ow => ow.Owner)
                .Include(ad => ad.Address)
                .Include(ci => ci.Address.City)
                .Include(im => im.Image);

            LedDisplay ledDisplay = ledDisplays.First(ld => ld.Id == id);

            if (ledDisplay != null)
            {
                // TODO: Получить количество роликов

                return View(ledDisplay);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // Заполняем ViewBag для метода Create
        private void Init_ViewBag_for_Create()
        {
            SelectList owners = new SelectList(db.Owners, "Id", "Name");
            ViewBag.Owners = owners;

            SelectList cities = new SelectList(db.Cities, "Id", "Name");
            ViewBag.Cities = cities;
        }

        // GET: LedDisplay/Create
        public ActionResult Create(int ownerId = 0)
        {
            Init_ViewBag_for_Create();

            if (ownerId > 0)
            {
                Owner owner = db.Owners.FirstOrDefault(o => o.Id == ownerId);
                LedDisplay ledDisplay = new LedDisplay() { Owner = owner };
                return View(ledDisplay);
            }
            return View();
        }

        // POST: LedDisplay/Create
        [HttpPost]
        public ActionResult Create(LedDisplay ledDisplay, int Owner_Id, int City_Id, int Image_Id = 1)
        {
            Init_ViewBag_for_Create();

            ledDisplay.Owner = db.Owners.FirstOrDefault(o => o.Id == Owner_Id);
            ledDisplay.Address.City = db.Cities.FirstOrDefault(c => c.Id == City_Id);

            if (ModelState.IsValid)
            {
                //try
                {
                    db.Addresses.Add(ledDisplay.Address);
                    db.SaveChanges();

                    ledDisplay.Image = db.Images.FirstOrDefault(i => i.Id == Image_Id);

                    db.LedDisplays.Add(ledDisplay);
                    db.SaveChanges();

                    
                }
                //catch
                {
                    //return View();
                }
                return RedirectToAction("Index", new { ownerId = Owner_Id });
            }
            return View(ledDisplay);
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
