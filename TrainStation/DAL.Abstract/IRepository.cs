using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetByID(int Id);
        void Insert(T entity);
        void Delete(int Id);
        void Update(T student);
        void Save();
    }
}
