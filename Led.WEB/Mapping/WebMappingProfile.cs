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
            CreateMap<OwnerDTO, OwnerViewModel>();
            CreateMap<OwnerViewModel, OwnerDTO>();

            CreateMap<AddressDTO, AddressViewModel>()
                .ForMember(opt => opt.FullAddress, opt => opt.MapFrom(c => c.FullAddress))
                .ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City)); 
            CreateMap<AddressViewModel, AddressDTO>()
                .ForMember(opt => opt.FullAddress, opt => opt.MapFrom(c => c.FullAddress))
                .ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City));

            CreateMap<CityDTO, CityViewModel>();
            CreateMap<CityViewModel, CityDTO>();

            CreateMap<CalculatorDTO, CalculatorViewModel>();
            CreateMap<CalculatorViewModel, CalculatorDTO>();
            /*etc...*/
        }
    }
}