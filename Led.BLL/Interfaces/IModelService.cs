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
        IEnumerable<T> GetAll();
        T Get(int? id);

        void Add(T item);
        void Update(T item);
        T Delete(int id);
        void Remove(int id);

        void Dispose();
    }
}
