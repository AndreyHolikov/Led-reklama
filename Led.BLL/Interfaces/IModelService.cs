using Led.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.BLL.Interfaces
{
    public interface IModelService<T> where T : class
    {
        //void AddCity(CityDTO cityDto);
        T Get(int? id);
        IEnumerable<T> GetAll();
        void Dispose();
    }


    public interface ICityService : IModelService<CityDTO>, IDisposable
    {
        ////void AddCity(CityDTO cityDto);
        //AddressDTO Find(int? id);
        //IEnumerable<AddressDTO> GetAll();
        //void Dispose();
    }

    public interface IAddressService : IModelService<AddressDTO>, IDisposable { }

    public interface IDisplayService : IModelService<DisplayDTO>, IDisposable { }

    public interface ICalculatorService : IModelService<CalculatorDTO>, IDisposable { }

    public interface IOwnerService : IModelService<OwnerDTO>, IDisposable { }
}
