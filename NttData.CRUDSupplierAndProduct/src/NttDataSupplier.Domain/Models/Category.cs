using NttDataSupplier.Domain.Tools;
using System.Collections.Generic;

namespace NttDataSupplier.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        private List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products;

        protected Category() { }

        public Category(string name)
        {            
            SetName(name);
        }

        public void SetName(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "O nome é obrigatorio");
            Name = value;
        }
    }
}
