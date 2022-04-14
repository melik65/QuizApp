using MelikCirak.BusinessLayer.Abstract;
using MelikCirak.BusinessLayer.Concrete.Base;
using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.BusinessLayer.Concrete
{
    public class QuestionManager : Manager<Question>, IQuestionService
    {
        IQuestionDal dal;
        public QuestionManager(IQuestionDal dal) : base(dal)
        {
            this.dal = dal;
        }
    }
}
