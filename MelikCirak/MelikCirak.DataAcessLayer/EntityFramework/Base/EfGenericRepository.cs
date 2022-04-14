using MelikCirak.DataAcessLayer.Abstract.Base;
using MelikCirak.DataAcessLayer.Concrete;
using MelikCirak.EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MelikCirak.DataAcessLayer.EntityFramework.Base
{
    public class EfGenericRepository<T> : IRepositoryDal<T> where T : BaseEntity
    {
        protected DbSet<T> table;
        protected Context db;
        public EfGenericRepository()
        {
            db = new Context();
            table = db.Set<T>();
        }
        public void AddRange(List<T> items)
        {
            table.AddRange(items);
            db.SaveChanges();
        }

        public void Delete(T p)
        {
            table.Remove(p);
            db.SaveChanges();
        }

        public void DeleteRange(List<T> items)
        {
            table.RemoveRange(items);
            db.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return table.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return table.Where(filter).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return table.Where(filter).AsQueryable();
        }

        public void Insert(T p)
        {
            table.Add(p);
            db.SaveChanges();
        }

        public void Update(T p)
        {
            table.Update(p);
            db.SaveChanges();
        }
    }
}
