using FluentValidation;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class SupplierJuridicalValidation : AbstractValidator<SupplierJuriDical>
    {
        public SupplierJuridicalValidation()
        {
            RuleFor(x => x.FantasyName)
                .Length(10, 256)
                .WithMessage("O nome fantasia deve conter entre 10 e 256 caracteres");

            RuleFor(x => x.CompanyName)
                .Length(10, 256)
                .WithMessage("O razão social deve conter entre 10 e 256 caracteres");
        }
    }
}
