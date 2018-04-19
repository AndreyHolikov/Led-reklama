using Led.BLL.DTO;
using Led.BLL.Interfaces;
using Led.DAL.Entities;
using Led.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Led.BLL.Infrastructure;
using AutoMapper;

namespace Led.BLL.Services
{
    public class OwnerService : IOwnerService
    {
        IUnitOfWork Database { get; set; }

        public OwnerService(IUnitOfWork uow)
        {
            Database = uow;
            // Настройка AutoMapper
            // применяем автомаппер для проекции одной коллекции на другую
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Address, AddressDTO>()
            //        .ForMember("FullAddress", opt => opt.MapFrom(c => c.FullAddress))
            //        .ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City.Name));
            //    cfg.CreateMap<City, CityDTO>();
            //    cfg.CreateMap<Display, DisplayDTO>();
            //    //cfg.CreateMap<PairDTO, Pair>();
            //});
        }

        //public void AddOrder(CityDTO cityDto)
        //{
        //    City city = Database.Cities.Get(cityDto.Id);

        //    // валидация
        //    if (phone == null)
        //        throw new ValidationException("Телефон не найден", "");
        //    // применяем скидку
        //    decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
        //    Order order = new Order
        //    {
        //        Date = DateTime.Now,
        //        Address = orderDto.Address,
        //        PhoneId = phone.Id,
        //        Sum = sum,
        //        PhoneNumber = orderDto.PhoneNumber
        //    };
        //    Database.Orders.Create(order);
        //    Database.Save();
        //}

        public IEnumerable<OwnerDTO> GetAll()
        {
            IEnumerable<Owner> Owners = Database.Owners.GetAll();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Owner, OwnerDTO>()
                    .ForMember(opt => opt.CountLedDisplays, opt => opt.MapFrom(src => src.LedDisplays.ToList().Count));
            });
            // Выполняем сопоставление
            IEnumerable<OwnerDTO> OwnerDTOs = Mapper.Map<IEnumerable<Owner>, List<OwnerDTO>>(Owners);
            return OwnerDTOs;
        }

        public OwnerDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException(
                    ValidationExceptionMessage.OWNER_NO_SET_ID, "");
            var owner = Database.Owners.Get(id.Value);
            if (owner == null)
                throw new ValidationException(
                    ValidationExceptionMessage.OWNER_NOT_FOUND, "");

            return new OwnerDTO { Id = owner.Id, Name = owner.Name};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}