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
    public class AddressService //: IAddressService
    {
        private IUnitOfWork Database { get; set; }

        public AddressService(IUnitOfWork uow)
        {
            Database = uow;
            // Настройка AutoMapper
            // применяем автомаппер для проекции одной коллекции на другую
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Address, AddressDTO>()
            //        .ForMember("FullAddress", opt => opt.MapFrom(c => c.FullAddress))
            //        .ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City.Name));
            //        //.ReverseMap()
            //        //.ForPath(s => s.Customer.Name, opt => opt.Ignore());
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

        public IEnumerable<AddressDTO> GetAll()
        {
            // Настройка AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<Address, AddressDTO>());

            //IEnumerable<AddressDTO> Addresses = Database.Addresses.GetAll().Select(a => new AddressDTO
            //{
            //    Id = a.Id,
            //    FullAddress = a.FullAddress,
            //    City = a.City.Name
            //});
            // Выполняем сопоставление
            //return Addresses;
            var all = Database.Addresses.GetAll();
            // Выполняем сопоставление, применяем автомаппер для проекции одной коллекции на другую
            return Mapper.Map<IEnumerable<Address>, List<AddressDTO>>(all);
        }

        public AddressDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException(Resource.Exception_ADDRESS_NO_SET_ID, "");
            var address = Database.Addresses.Get(id.Value);
            if (address == null)
                throw new ValidationException(Resource.Exception_ADDRESS_NOT_FOUND, "");

            return new AddressDTO { Id = address.Id, FullAddress = address.FullAddress};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}