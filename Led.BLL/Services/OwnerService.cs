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
        private IUnitOfWork Database { get; set; }

        public OwnerService(IUnitOfWork uow)
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

        public IEnumerable<OwnerDTO> GetAll()
        {
            // Настройка AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<Owner, OwnerDTO>());

            var all = Database.Owners.GetAll();//.UseAsDataSource<OwnerDTO>();
            // Выполняем сопоставление, применяем автомаппер для проекции одной коллекции на другую
            return Mapper.Map<IEnumerable<Owner>, List<OwnerDTO>>(all);
            //return all;
        }

        public OwnerDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException(Resource.Exception_OWNER_NO_SET_ID, "");

            //Mapper.Initialize(cfg => cfg.CreateMap<Owner, OwnerDTO>());
            var owner = Mapper.Map<Owner, OwnerDTO>(Database.Owners.Get(id.Value));

            if (owner == null)
                throw new ValidationException(Resource.Exception_OWNER_NOT_FOUND, "");

            return new OwnerDTO { Id = owner.Id, Name = owner.Name};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}