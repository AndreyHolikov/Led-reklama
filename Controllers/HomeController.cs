using Led.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.Controllers
{
    public class HomeController : Controller
    {
        double priceOneSecond = 0.6;

        [HttpGet]
        public ActionResult Index()
        {
            Dictionary<string, int> elements = ElementsMapper.GetElements();
            VideoCalculator videoCalculator = new VideoCalculator("", priceOneSecond, elements);
            SetViewBagData(videoCalculator.Elements);

            ViewData["summ"] = 0;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string formula, int durationVideo, int durationPeriod, int numberScreens, int numberOutputsIn6Min)
        {
            Dictionary<string, int> elements = ElementsMapper.GetElements(formula, durationVideo, durationPeriod, numberScreens, numberOutputsIn6Min);

            VideoCalculator videoCalculator = new VideoCalculator(formula, priceOneSecond, elements);

            SetViewBagData(videoCalculator.Elements);

            ViewData["summ"] = videoCalculator.Calculate();
            return View();
        }



        private void SetViewBagData(List<Element> elements)
        {
            ViewBag.Elements = new Element[] {
                elements.Find(x => x.Name.Contains(ElementsMapper.DURATION_VIDEO)),
                elements.Find(x => x.Name.Contains(ElementsMapper.DURATIO_PERIOD)),
                elements.Find(x => x.Name.Contains(ElementsMapper.NUMBER_SCREENS)),
                elements.Find(x => x.Name.Contains(ElementsMapper.NUMBER_OUTPUTS_IN_6_MIN))
            };

            ViewBag.formula = "";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}