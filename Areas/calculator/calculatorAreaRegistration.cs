using System.Web.Mvc;

namespace Led.Areas.calculator
{
    public class calculatorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "calculator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "calculator_default",
                "calculator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}