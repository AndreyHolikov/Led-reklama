using Led.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.Controllers
{
    public class AdvertiserController : Controller
    {
        LedContext db = new LedContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET: Advertiser
        public ActionResult Index()
        {
            return View(db.Advertisers);
        }

        // GET: Advertiser/Details/5
        public ActionResult Details(int? id)
        {
            if( id ==0 )
            {
                return HttpNotFound();
            }
            Advertiser advertiser = db.Advertisers.Find(id);
            if (advertiser != null)
            {
                return View(advertiser);
            } else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Advertiser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertiser/Create
        [HttpPost]
        public ActionResult Create(Advertiser advertiser)
        {
            try
            {
                db.Advertisers.Add(advertiser);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Advertiser/Edit/5
        public ActionResult Edit(int? id)
        {
            if( id == null)
            {
                return HttpNotFound();
            }
            Advertiser advertiser = db.Advertisers.Find(id);

            if( advertiser != null)
            {
                return View(advertiser);
            }
            return RedirectToAction("Index");
        }

        // POST: Advertiser/Edit/5
        [HttpPost]
        public ActionResult Edit(Advertiser advertiser)
        {
            db.Entry(advertiser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Advertiser/Delete/5
        public ActionResult Delete(int id)
        {
            Advertiser advertiser = db.Advertisers.Find(id);
            if(advertiser == null)
            {
                return HttpNotFound();
            }
            return View(advertiser);
        }

        // POST: Advertiser/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertiser advertiser = db.Advertisers.Find(id);
            if(advertiser == null)
            {
                return HttpNotFound();
            }
            db.Advertisers.Remove(advertiser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
