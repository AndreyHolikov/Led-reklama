using AutoMapper;
using Led.BLL.Infrastructure;
using Led.DAL.EF;
using Led.WEB.Mapping;
using Led.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Led.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<LedContext>(new LedDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //MappingProfile.InitializeAutoMapper();


            // внедрение зависимостей
            NinjectModule autoMapperModule = new AutoMapperModule();
            NinjectModule cityModule = new CityModule();
            NinjectModule ownerModule = new OwnerModule();
            NinjectModule displayModule = new DisplayModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");

            var kernel = new StandardKernel(autoMapperModule, cityModule, ownerModule, displayModule, serviceModule);

            //kernel.Get<CustomMapper>("Custom1Mapper").Initialize(x => x.AddProfile<AutoMapperCustom1Profile>());

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
