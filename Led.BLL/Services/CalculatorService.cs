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
    public class CalculatorService //: ICalculatorService
    {
        private IUnitOfWork Database { get; set; }

        public CalculatorService(IUnitOfWork uow)
        {
            Database = uow;
            // Настройка AutoMapper
            // применяем автомаппер для проекции одной коллекции на другую
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Calculator, CalculatorDTO>();
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

        public IEnumerable<CalculatorDTO> GetAll()
        {
            // Выполняем сопоставление
            return Mapper.Map<IEnumerable<Calculator>, List<CalculatorDTO>>(Database.Calculators.GetAll());
        }

        public CalculatorDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id калькулятора", "");
            var display = Database.Displays.Get(id.Value);
            if (display == null)
                throw new ValidationException("Калькулятор не найден", "");

            return new CalculatorDTO { Id = display.Id, Name = display.Name};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}