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
            CreateMap<Owner, OwnerDTO>();
            CreateMap<OwnerDTO, Owner>();

            CreateMap<Address, AddressDTO>()
                .ForMember(opt => opt.FullAddress, opt => opt.MapFrom(c => c.FullAddress))
                //.ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City.Name))
                .ReverseMap()
                .ForPath(s => s.City.Name, opt => opt.MapFrom(src => src.City));
            CreateMap<AddressDTO, Address>()
                .ForMember(opt => opt.FullAddress, opt => opt.MapFrom(c => c.FullAddress))
                .ReverseMap()
                .ForPath(s => s.City, opt => opt.MapFrom(src => src.City.Name));

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Calculator, CalculatorDTO>();
            CreateMap<CalculatorDTO, Calculator>();
            /*etc....*/
        }
    }
}
