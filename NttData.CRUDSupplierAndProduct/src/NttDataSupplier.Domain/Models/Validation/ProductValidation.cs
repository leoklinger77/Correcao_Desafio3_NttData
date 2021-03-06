using FluentValidation;

namespace NttDataSupplier.Domain.Models.Validation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name)
                .Length(2, 256)
                .WithMessage("O nome deve conter entre 9 e 256 caracteres");

            RuleFor(x => x.BarCode)
                .Length(12, 14)
                .WithMessage("O código de barras deve conter entre 12 e 14 caracteres");

            RuleFor(x => ValiditPriceSales(x.PriceSales, x.PricePurchase))
                .NotEqual(true)
                .WithMessage("O preço de venda não pode ser menor ou igual que o preço de compra");
        }

        private bool ValiditPriceSales(decimal sales, decimal purchase)
        {
            return sales <= purchase;
        }
    }
}
