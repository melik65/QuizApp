using MelikCirak.BusinessLayer.Abstract;
using MelikCirak.BusinessLayer.Concrete.Base;
using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.BusinessLayer.Concrete
{
    public class OptionManager : Manager<Option>, IOptionService
    {
        IOptionDal dal;
        public OptionManager(IOptionDal dal) : base(dal)
        {
            this.dal = dal;
        }
    }
}
