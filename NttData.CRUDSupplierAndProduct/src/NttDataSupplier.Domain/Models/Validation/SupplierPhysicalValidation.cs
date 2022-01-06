using FluentValidation;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class SupplierPhysicalValidation : AbstractValidator<SupplierPhysical>
    {
        public SupplierPhysicalValidation()
        {
            RuleFor(x => x.FantasyName)
                .Length(10, 256)
                .WithMessage("O nome fantasia deve conter entre 10 e 256 caracteres");

            RuleFor(x => x.Cpf)
                .Length(10, 256)
                .WithMessage("O nome fantasia deve conter entre 10 e 256 caracteres");
        }
    }
}
