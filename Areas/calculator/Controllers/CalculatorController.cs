using Led.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        double priceOneSecond = 0.6;

        [HttpGet]
        public ActionResult Index()
        {
            Dictionary<string, int> elements = GetElements();
            VideoCalculator videoCalculator = new VideoCalculator("", priceOneSecond, elements);
            GetViewBagCalculation(videoCalculator.Elements);

            ViewData["summ"] = 0;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string formula, int durationVideo, int durationPeriod, int numberScreens, int numberOutputsIn6Min)
        {
            Dictionary<string, int> elements = GetElements(formula, durationVideo, durationPeriod, numberScreens, numberOutputsIn6Min);

            VideoCalculator videoCalculator = new VideoCalculator(formula, priceOneSecond, elements);

            GetViewBagCalculation(videoCalculator.Elements);

            ViewData["summ"] = videoCalculator.Calculate();
            return View();
        }

        private Dictionary<string, int> GetElements(
            string formula = "", 
            int durationVideo = 25, 
            int durationPeriod = 60, 
            int numberScreens = 4, 
            int numberOutputsIn6Min  = 1)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>
            {
                { "durationVideo", durationVideo },
                { "durationPeriod", durationPeriod },
                { "numberScreens", numberScreens },
                { "numberOutputsIn6Min", numberOutputsIn6Min }
            };
            return elements;
        }

        private void GetViewBagCalculation(List<Element> elements)
        {
            ViewBag.Elements = new Element[] {
                elements.Find(x => x.Name.Contains("durationVideo")),
                elements.Find(x => x.Name.Contains("durationPeriod")),
                elements.Find(x => x.Name.Contains("numberScreens")),
                elements.Find(x => x.Name.Contains("numberOutputsIn6Min"))
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