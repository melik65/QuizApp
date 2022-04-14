using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.DataAcessLayer.EntityFramework.Base;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.DataAcessLayer.EntityFramework
{
    public class EfUserRepository : EfGenericRepository<User>, IUserDal
    {
    }
}
