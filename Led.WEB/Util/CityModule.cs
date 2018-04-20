using Led.BLL.Interfaces;
using Led.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Util
{
    public class CityModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICityService>().To<CityService>();
            //Bind<CustomMapper>().ToSelf().InSingletonScope().Named("Custom1Mapper");
        }
    }
}