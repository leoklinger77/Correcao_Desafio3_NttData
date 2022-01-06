using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class Email : Entity
    {
        public Guid SupplierId { get; private set; }

        public string EmailAddress { get; private set; }

        public Supplier Supplier { get; private set; }

        public Email() { }

        public Email(Guid supplierId, string emailAddress)
        {
            SupplierId = supplierId;
            SetEmail(emailAddress);            
        }

        public void SetEmail(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "O e-mail é obrigatorio");
            EmailAddress = value;
        }
    }
}
