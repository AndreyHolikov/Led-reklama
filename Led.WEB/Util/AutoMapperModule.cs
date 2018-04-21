using AutoMapper;
using AutoMapper.Configuration;
using Led.BLL.DTO;
using Led.DAL.Entities;
using Led.BLL.Interfaces;
using Led.BLL.Mapping;
using Led.BLL.Services;
using Led.WEB.Mapping;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Led.WEB.Util
{
    /// <summary>
    /// http://docs.automapper.org/en/latest/Dependency-injection.html?highlight=Ninject%20#ninject
    /// </summary>
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            // В данном случае интерфейс IOrderService сопоставляется с классом OrderService.
            //
            //Bind<IValueResolver<SourceEntity, DestModel, bool>>().To<MyResolver>();
            // Custom Type Converters http://docs.automapper.org/en/latest/Custom-type-converters.html

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfiles(GetType().Assembly);
                cfg.AddProfile(new WebMappingProfile());  //mapping between Web and Business layer objects
                cfg.AddProfile(new BLMappingProfile());  // mapping between Business and DB layer objects
            });

            return config;
        }
    }

    //public class AutoMapperModule : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
    //    }

    //    private IMapper AutoMapper(Ninject.Activation.IContext context)
    //    {
    //        Mapper.Initialize(config =>
    //        {
    //            config.ConstructServicesUsing(type => context.Kernel.Get(type));

    //            config.CreateMap<City, CityDTO>();
    //            // .... other mappings, Profiles, etc.              

    //        });

    //        Mapper.AssertConfigurationIsValid(); // optional
    //        return Mapper.Instance;
    //    }
    //}
}