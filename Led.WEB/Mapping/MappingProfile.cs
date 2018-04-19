using AutoMapper;
using Led.BLL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Mapping
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMappingProfile());  //mapping between Web and Business layer objects
                cfg.AddProfile(new BLMappingProfile());  // mapping between Business and DB layer objects
            });

            return config;
        }
    }
}