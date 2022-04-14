using MelikCirak.EntityLayer.Concrete.Base;

namespace MelikCirak.EntityLayer.Concrete
{
    public class Option : BaseEntity
    {
        public string OptionContent { get; set; }
        public bool IsAnswer { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }


    }
}
