using FluentValidation;
using NttDataSupplier.Domain.Models.enums;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class PhoneValidation : AbstractValidator<Phone>
    {
        public PhoneValidation()
        {
            RuleFor(x => x.Ddd)
                .Length(2, 2)
                .WithMessage("");

            When(x => x.PhoneType == PhoneType.Celular, () =>
            {
                RuleFor(x => x.Number)
                    .Length(9, 9)
                    .WithMessage("O telefone celular deve conter 9 caracteres");
            });

            When(x => x.PhoneType == PhoneType.Comercial, () =>
            {
                RuleFor(x => x.Number)
                    .Length(8, 9)
                    .WithMessage("O telefone comercial deve conter entre 8 e 9 caracteres");

            });

            When(x => x.PhoneType == PhoneType.Fixo, () =>
            {
                RuleFor(x => x.Number)
                    .Length(8, 8)
                    .WithMessage("O telefone fixo deve conter 8 caracteres");
            });
        }
    }
}
