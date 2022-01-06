using NttDataSupplier.Domain.Models.enums;
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

        public Phone() { }

        public Phone(Guid supplierId, string ddd, string number, PhoneType phoneType)
        {
            SupplierId = supplierId;
            SetPhone(ddd, number, phoneType);
        }

        public void SetPhone(string ddd, string number, PhoneType phoneType)
        {
            Ddd = ddd;
            Number = number;
            PhoneType = phoneType;
        }
    }
}
