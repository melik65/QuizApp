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
    public class EfQuestionRepository : EfGenericRepository<Question>, IQuestionDal
    {
        public override Question Get(int id)
        {
            return table.Where(x => x.Id == id)
                .Include(x => x.Options)
                .Include(x => x.Quiz)
                .FirstOrDefault();
        }

        public override Question Get(Expression<Func<Question, bool>> filter)
        {
            return table.Where(filter)
                .Include(x => x.Options)
                .Include(x => x.Quiz)
                .FirstOrDefault();
        }

        public override IEnumerable<Question> GetAll()
        {
            return table
                .Include(x => x.Options)
                .Include(x => x.Quiz)
                .ToList();
        }

        public override IQueryable<Question> GetAll(Expression<Func<Question, bool>> filter)
        {
            return table.Where(filter)
                .Include(x => x.Options)
                .Include(x => x.Quiz)
                .AsQueryable();
        }
    }
}
