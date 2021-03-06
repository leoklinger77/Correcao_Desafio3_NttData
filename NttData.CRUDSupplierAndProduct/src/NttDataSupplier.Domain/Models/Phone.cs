using NttDataSupplier.Domain.Models.enums;
using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class Phone : Entity
    {
        public Guid SupplierId { get; private set; }
        
        public string Ddd { get; private set; }
        public string Number { get; private set; }
        public PhoneType PhoneType { get; private set; }

        public Supplier Supplier { get; private set; }

        protected Phone() { }

        public Phone(Guid supplierId, string ddd, string number, PhoneType phoneType)
        {
            SupplierId = supplierId;
            SetPhone(ddd, number, phoneType);
        }

        public void SetPhone(string ddd, string number, PhoneType phoneType)
        {
            DomainValidation.ValidateIsNullOrEmpty(ddd, "O ddd é obrigatorio");            
            DomainValidation.ValidateIsNullOrEmpty(number, "O número é obrigatorio");

            Ddd = ddd;
            Number = number;
            PhoneType = phoneType;
        }
    }
}
