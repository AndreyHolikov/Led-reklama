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
    public class DisplayService : IDisplayService
    {
        IUnitOfWork Database { get; set; }

        public DisplayService(IUnitOfWork uow)
        {
            Database = uow;
            // Настройка AutoMapper
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Address, AddressDTO>()
                //    .ForMember("FullAddress", opt => opt.MapFrom(c => c.FullAddress))
                //    .ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City.Name));
                cfg.CreateMap<Display, DisplayDTO>();
                cfg.CreateMap<DisplayDTO, Display>();
            });
        }

        public IEnumerable<DisplayDTO> GetAll()
        {
            var displays = Database.Displays.GetAll();
            // Выполняем сопоставление
            return Mapper.Map<IEnumerable<Display>, List<DisplayDTO>>(displays);
        }

        public DisplayDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException(
                    ValidationExceptionMessage.DISPLAY_NO_SET_ID, "");
            var display = Database.Displays.Get(id.Value);
            if (display == null)
                throw new ValidationException(
                    ValidationExceptionMessage.DISPLAY_NOT_FOUND, "");

            return new DisplayDTO { Id = display.Id, Name = display.Name};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}