using MelikCirak.BusinessLayer.Abstract;
using MelikCirak.BusinessLayer.Concrete.Base;
using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.BusinessLayer.Concrete
{
    public class UserManager : Manager<User>, IUserService
    {
        IUserDal dal;
        public UserManager(IUserDal dal) : base(dal)
        {
            this.dal = dal;
        }
    }
}
