using AutoMapper;
using Led.BLL.DTO;
using Led.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Led.WEB.Mapping
{
    //Profile number one saved in Web layer
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<OwnerDTO, OwnerViewModel>().ReverseMap();

            CreateMap<AddressDTO, AddressViewModel>().ReverseMap();

            CreateMap<CityDTO, CityViewModel>().ReverseMap();

            CreateMap<CalculatorDTO, CalculatorViewModel>().ReverseMap();

            CreateMap<OwnerDTO, OwnerViewModel>().ReverseMap();
            /*etc...*/
        }
    }
}