using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class Image : Entity
    {
        public Guid ProductId { get; private set; }
        
        public string ImagePath { get; private set; }

        public Product Product { get; private set; }
        
        protected Image() { }
        public Image(Guid productId, string imagePath)
        {
            ProductId = productId;
            SetImage(imagePath);
        }

        public void SetImage(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "A imagem informada é invalida");
            ImagePath = value;
        }
    }
}
