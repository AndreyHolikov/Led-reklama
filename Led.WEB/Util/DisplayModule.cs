using Led.BLL.Interfaces;
using Led.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Util
{
    public class DisplayModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDisplayService>().To<DisplayService>();
        }
    }
}