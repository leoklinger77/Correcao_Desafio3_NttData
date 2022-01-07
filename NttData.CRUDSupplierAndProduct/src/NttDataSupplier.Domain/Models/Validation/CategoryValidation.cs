using FluentValidation;
using System;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Id)
                .Equal(Guid.Empty)
                .WithMessage("Id inválido");

            RuleFor(x => x.Name)
                .Length(2, 100)
                .WithMessage("O nome deve conter entre 2 e 256 caracteres");
        }
    }
}
