using MelikCirak.EntityLayer.Concrete.Base;
using System.Collections.Generic;

namespace MelikCirak.EntityLayer.Concrete
{
    public class User : BaseEntity
    {
        public string FulllName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }

    }
}
