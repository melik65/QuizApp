using MelikCirak.BusinessLayer.Abstract;
using MelikCirak.BusinessLayer.Concrete.Base;
using MelikCirak.DataAcessLayer.Abstract;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.BusinessLayer.Concrete
{
    public class TestManager : Manager<Test>, ITestService
    {
        ITestDal dal;
        public TestManager(ITestDal dal) : base(dal)
        {
            this.dal = dal;
        }
    }
}
