using MelikCirak.EntityLayer.Concrete.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelikCirak.EntityLayer.Concrete
{
    public class Question : BaseEntity
    {
        public string QuestionContent { get; set; }
        public int RightOptionId { get; set; }

        public ICollection<Option> Options { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        [NotMapped]
        public int RightOptionIndex { get; set; }


    }
}
