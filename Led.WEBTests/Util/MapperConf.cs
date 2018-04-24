using AutoMapper;
using Led.BLL.Mapping;
using Led.WEB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.WEB.Tests.Util
{
    public class MapperConf
    {
        public MapperConfiguration CreateConfiguration()
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
}
