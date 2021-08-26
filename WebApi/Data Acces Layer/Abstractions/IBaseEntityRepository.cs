using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data_Acces_Layer.Abstractions
{
    public interface IBaseEntityRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int Id);

        void Add(T newObject);

        T Update(T newObject);

        T Delete(int id);

        List<T> CreateMultiple(List<T> newObject);

        T AddAndReturn(T newObject);
    }
}
