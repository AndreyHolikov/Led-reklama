using Led.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.BLL.Interfaces
{
    public interface ICityService : IModelService<CityDTO>, IDisposable
    {
        ////void AddCity(CityDTO cityDto);
        //AddressDTO Find(int? id);
        //IEnumerable<AddressDTO> GetAll();
        //void Dispose();
    }
}
