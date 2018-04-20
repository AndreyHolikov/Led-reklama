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
    public class CityService : ICityService
    {
        private IUnitOfWork Database { get; set; }

        public CityService(IUnitOfWork uow)
        {
            Database = uow;
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

        public IEnumerable<CityDTO> GetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<City>, List<CityDTO>>(Database.Cities.GetAll());
        }

        public CityDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id города", "");
            var city = Database.Cities.Get(id.Value);
            if (city == null)
                throw new ValidationException("Город не найден", "");

            return new CityDTO { Id = city.Id, Name = city.Name};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}