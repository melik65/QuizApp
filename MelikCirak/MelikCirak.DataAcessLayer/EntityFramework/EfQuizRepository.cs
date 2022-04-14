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
    public class EfQuizRepository : EfGenericRepository<Quiz>, IQuizDal
    {
        public override Quiz Get(int id)
        {
            return table.Where(x => x.Id == id)
                .Include(x => x.Questions)
                .Include(x => x.User)
                .FirstOrDefault();
        }

        public override Quiz Get(Expression<Func<Quiz, bool>> filter)
        {
            return table.Where(filter)
                .Include(x => x.Questions)
                .Include(x => x.User)
                .FirstOrDefault();
        }

        public override IEnumerable<Quiz> GetAll()
        {
            return table
                .Include(x => x.Questions)
                .Include(x => x.User)
                .ToList();
        }

        public override IQueryable<Quiz> GetAll(Expression<Func<Quiz, bool>> filter)
        {
            return table.Where(filter)
                .Include(x => x.Questions)
                .Include(x => x.User)
                .AsQueryable();
        }

    }
}
