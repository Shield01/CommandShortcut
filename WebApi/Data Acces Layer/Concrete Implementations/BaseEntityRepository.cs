using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data_Acces_Layer.Abstractions;
using WebApi.Models;

namespace WebApi.Data_Acces_Layer.Concrete_Implementations
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        public BaseEntityRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(T newObject)
        {
            _db.Add(newObject);
        }

        public T AddAndReturn(T newObject)
        {
            var result = newObject;
            _db.Add(result);
            return result;
        }

        public List<T> CreateMultiple(List<T> newObject)
        {
            _db.AddRange(newObject); 
            return newObject;
        }

        public T Delete(int id)
        {
            return null;
        }

        public T Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T newObject)
        {
            throw new NotImplementedException();
        }
    }
}
