using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }

        protected SupplierPhysical() { }

        public SupplierPhysical(string fullName, string cpf, bool active, string fantasyName, Address address, Email email, Phone phone) 
            : base(active, fantasyName, address, email, phone)
        {
            SetFullName(fullName);
            SetCpf(cpf);
        }

        public void SetFullName(string value)
        {
            Validation.ValidateIsNullOrEmpty(value, "O nome é obrigatorio.");
            FullName = value;
        }
        public void SetCpf(string value)
        {
            Validation.ValidateIfFalse(value.IsCpf(), "O Cpf informado é inválido.");
            Cpf = value;
        }
        public void SetBirthDate(DateTime value)
        {
            Validation.ValidateIfTrue(value.Date == DateTime.Now.Date, "A data de nascimento não pode ser igual a hoje");
            BirthDate = value;
        }
    }
}
