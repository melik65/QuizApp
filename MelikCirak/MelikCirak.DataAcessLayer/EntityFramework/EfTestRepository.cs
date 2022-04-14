using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.DataAcessLayer.EntityFramework.Base;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.DataAcessLayer.EntityFramework
{
    public class EfTestRepository : EfGenericRepository<Test>, ITestDal
    {
    }
}
