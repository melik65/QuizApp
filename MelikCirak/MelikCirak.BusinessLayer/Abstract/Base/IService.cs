using MelikCirak.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MelikCirak.BusinessLayer.Abstract.Base
{
    public interface IService<T> where T : BaseEntity
    {
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);

        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        void AddRange(List<T> items);
        void DeleteRange(List<T> items);
    }
}
