using FluentValidation;
using MelikCirak.EntityLayer.Concrete;

namespace MelikCirak.BusinessLayer.Validations
{
    public class TestValidator : AbstractValidator<Test>
    {
        public TestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("isim alanı boş olamaz");
        }
    }
}
