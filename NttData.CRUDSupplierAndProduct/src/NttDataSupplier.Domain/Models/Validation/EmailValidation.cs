using FluentValidation;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .WithMessage("O endereço de e-mail esta invalido");
        }
    }
}
