using MelikCirak.BusinessLayer.Abstract;
using MelikCirak.BusinessLayer.Concrete.Base;
using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.BusinessLayer.Concrete
{
    public class QuizManager : Manager<Quiz>, IQuizService
    {
        IQuizDal dal;
        public QuizManager(IQuizDal dal) : base(dal)
        {
            this.dal = dal;
        }
    }
}
