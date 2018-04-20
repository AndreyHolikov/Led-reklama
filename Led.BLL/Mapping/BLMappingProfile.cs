using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Led.BLL.DTO;
using Led.DAL.Entities;

namespace Led.BLL.Mapping
{
    //Profile number two save in Business layer
    public class BLMappingProfile : Profile
    {
        public BLMappingProfile()
        {
            CreateMap<Owner, OwnerDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>()
                .ForMember(opt => opt.FullAddress, opt => opt.MapFrom(c => c.FullAddress))
                //.ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(opt => opt.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ReverseMap()
                .ForPath(s => s.City.Name, opt => opt.MapFrom(src => src.CityName));
            // .ForPath(s => s.Customer.Name, opt => opt.Ignore());


            CreateMap<City, CityDTO>().ReverseMap();


            CreateMap<Calculator, CalculatorDTO>().ReverseMap();


            CreateMap<Owner, OwnerDTO>().ReverseMap();
            /*etc....*/
        }
    }
}
