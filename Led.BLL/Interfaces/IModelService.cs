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
}
