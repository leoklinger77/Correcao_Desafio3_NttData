using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }

        protected SupplierPhysical() { }

        public SupplierPhysical(string fullName, string cpf, bool active, string fantasyName, Address address, Email email) 
            : base(active, fantasyName, address, email)
        {
            SetFullName(fullName);
            SetCpf(cpf);
        }

        public void SetFullName(string value)
        {
            FullName = value;
        }
        public void SetCpf(string value)
        {
            Cpf = value;
        }
        public void SetBirthDate(DateTime value)
        {
            BirthDate = value;
        }
    }
}
