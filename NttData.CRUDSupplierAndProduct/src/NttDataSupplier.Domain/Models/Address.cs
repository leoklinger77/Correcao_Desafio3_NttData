using System;

namespace NttDataSupplier.Domain.Models
{
    public class Address : Entity
    {
        public Guid SupplierId { get; private set; }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Reference { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Supplier Supplier { get; private set; }

        protected Address() { }

        public Address(Guid supplierId, string zipCode, string street, string number, string neighborhood, string city, string state,
                        string complement = null, string reference = null)
        {
            SupplierId = supplierId;
            SetAddress(zipCode, street, number, neighborhood, city, state,
                         complement, reference);
        }

        public void SetAddress(string zipCode, string street, string number, string neighborhood, string city, string state,
                        string complement = null, string reference = null)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
            Reference = reference;
        }
    }
}
