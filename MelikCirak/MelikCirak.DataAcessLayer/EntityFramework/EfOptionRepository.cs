using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.DataAcessLayer.EntityFramework.Base;
using MelikCirak.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MelikCirak.DataAcessLayer.EntityFramework
{
    public class EfOptionRepository : EfGenericRepository<Option>, IOptionDal
    {
        public override Option Get(int id)
        {
            return table.Where(x => x.Id == id)
                .Include(x => x.Question)
                .FirstOrDefault();
        }
        public override Option Get(Expression<Func<Option, bool>> filter)
        {
            return table.Where(filter)
                .Include(x => x.Question)
                .FirstOrDefault();
        }
        public override IEnumerable<Option> GetAll()
        {
            return table
                .Include(x => x.Question)
                .ToList();
        }
        public override IQueryable<Option> GetAll(Expression<Func<Option, bool>> filter)
        {
            return table
                .Include(x => x.Question)
                .AsQueryable();
        }
    }
}
