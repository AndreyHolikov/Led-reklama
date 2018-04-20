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
        private IUnitOfWork Database { get; set; }
        private IMapper mapper { get; set; }

        public DisplayService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            this.mapper = mapper;
            //Mapper.Initialize(cfg => cfg.CreateMap<Display, DisplayDTO>());
        }

        public IEnumerable<DisplayDTO> GetAll()
        {
            // Настройка AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<Display, DisplayDTO>());
            // Выполняем сопоставление
            // применяем автомаппер для проекции одной коллекции на другую
            return mapper.Map<IEnumerable<Display>, List<DisplayDTO>>(Database.Displays.GetAll());
        }

        public DisplayDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException( Resource.Exception_DISPLAY_NO_SET_ID, "");

            Mapper.Initialize(cfg => cfg.CreateMap<Display, DisplayDTO>());
            var item = Mapper.Map<Display, DisplayDTO>(Database.Displays.Get(id.Value));

            if (item == null)
                throw new ValidationException( Resource.Exception_DISPLAY_NOT_FOUND, "");

            return new DisplayDTO { Id = item.Id, Name = item.Name};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}