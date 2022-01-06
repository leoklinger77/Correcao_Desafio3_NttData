using FluentValidation;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
                .Length(2, 256)
                .WithMessage("O nome deve conter entre 2 e 256 caracteres");
        }
    }
}
