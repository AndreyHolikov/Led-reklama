using Led.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Led.DAL.Repositories;
using System.Configuration;
using Led.BLL.Services;
using Led.WEB.Models;
using Led.DAL.Interfaces;
using AutoMapper;
using Led.BLL.DTO;

namespace Led.WEB.Areas.Admin.Controllers
{
    //[Authorize]
    public class OwnerController : Controller
    {
        #region comment
        //EFUnitOfWork unitOfWork;
        //public OwnerController()
        //{
        //    string ConnectionString = ConfigurationManager.ConnectionStrings["LedContextLocalhost"].ConnectionString;
        //    unitOfWork = new EFUnitOfWork(ConnectionString);
        //    //IOwnerService ownerService = new 
        //}

        //public OwnerController(IUnitOfWork unitOfWork)
        //{
        //    //string ConnectionString = ConfigurationManager.ConnectionStrings["LedContextLocalhost"].ConnectionString;
        //    this.unitOfWork = (EFUnitOfWork)unitOfWork;
        //}
        #endregion

        private readonly IOwnerService dbService;
        private readonly IMapper mapperService;

        public OwnerController(IOwnerService serv, IMapper mapper)
        {
            dbService = serv;
            this.mapperService = mapper;
        }

        // GET: Owner
        public ActionResult Index()
        {
            var owners = dbService.GetAll();
            //var list = new MapperConfiguration(cfg => cfg.CreateMap<OwnerDTO, OwnerViewModel>()).CreateMapper();
            return View(mapperService.Map<IEnumerable<OwnerDTO>, List<OwnerViewModel>>(owners));
        }

        // GET: Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            //IOwnerService db = new OwnerService(unitOfWork);
                var owner = dbService.Get(id);

                if (owner != null)
                {
                    return View(Mapper.Map<OwnerDTO, OwnerViewModel>(owner));
                }
                else
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
        public ActionResult Create(OwnerViewModel owner)
        {
            try
            {
                //IOwnerService db = new OwnerService(unitOfWork);

                    //dbService.Owners.Add(owner);
                    //db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Owner/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Owner owner = db.Owners.Find(id);

        //    if (owner != null)
        //    {
        //        return View(owner);
        //    }
        //    return RedirectToAction("Index");
        //}

        //// POST: Owner/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Owner owner)
        //{
        //    db.Entry(owner).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //// GET: Owner/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    Owner owner = db.Owners.Find(id);
        //    if (owner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(owner);
        //}

        //// POST: Owner/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Owner owner = db.Owners.Find(id);
        //    if (owner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    db.Owners.Remove(owner);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
