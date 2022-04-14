using MelikCirak.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;

namespace MelikCirak.EntityLayer.Concrete
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Question> Questions { get; set; }


    }
}
