using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Services
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T model);
        void Update(int id, T model);
        void Delete(int id);
        List<T> Search(string name);
    }
}
