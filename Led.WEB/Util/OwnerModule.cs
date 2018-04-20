using Led.BLL.Interfaces;
using Led.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Util
{
    //класс сопоставителя зависимостей:
    public class OwnerModule : NinjectModule
    {
        public override void Load()
        {
            // В данном случае интерфейс IOrderService сопоставляется с классом OrderService.
            Bind<IOwnerService>().To<OwnerService>();
        }
    }
}