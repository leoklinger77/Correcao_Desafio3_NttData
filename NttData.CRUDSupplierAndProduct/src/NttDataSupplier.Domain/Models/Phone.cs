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

        public Phone() { }

        public Phone(Guid supplierId, string ddd, string number, PhoneType phoneType)
        {
            SupplierId = supplierId;
            SetPhone(ddd, number, phoneType);
        }

        public void SetPhone(string ddd, string number, PhoneType phoneType)
        {
            Validation.ValidateIsNullOrEmpty(ddd, "O ddd é obrigatorio");
            Validation.CharactersValidate(ddd, 2, 2, "O ddd deve conter 2 caracteres");
            Validation.ValidateIsNullOrEmpty(number, "O número é obrigatorio");
            Validation.CharactersValidate(number, 9, 8, "O número deve conter entre 8 e 9 caracteres");

            Validation.ValidateIfFalse(phoneType.IsEnum<PhoneType>(), "O tipo de telefone informado é invalido");
            
            Ddd = ddd;
            Number = number;
            PhoneType = phoneType;
        }
    }
}
