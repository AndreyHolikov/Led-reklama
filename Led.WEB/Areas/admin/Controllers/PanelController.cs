using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.WEB.Areas.Admin.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: admin/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}