using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }

        protected SupplierPhysical() { }

        public SupplierPhysical(string fullName, string cpf)
        {
            FullName = fullName;
            Cpf = cpf;
        }
    }
}
