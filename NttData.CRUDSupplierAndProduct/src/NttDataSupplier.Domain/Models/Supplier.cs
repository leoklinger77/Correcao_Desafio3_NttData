using NttDataSupplier.Domain.Models.enums;
using System.Collections.Generic;
using System.Linq;

namespace NttDataSupplier.Domain.Models
{
    public abstract class Supplier : Entity
    {
        public bool Active { get; private set; }
        public string FantasyName { get; private set; }

        public Address Address { get; private set; }
        public Email Email { get; private set; }

        private List<Phone> _phones = new List<Phone>();
        public IReadOnlyCollection<Phone> Phones => _phones;

        protected Supplier() { }
        protected Supplier(bool active, string fantasyName, Address address, Email email, Phone phone)
        {
            Active = active;
            FantasyName = fantasyName;
            Address = address;
            Email = email;
        }

        public void AddPhone(Phone phone)
        {
            if(_phones.Count >= 3)
            {
                //Retornar Erro
            }
            _phones.Add(phone);
        }
        public void UpdatePhone(string ddd, string phone, PhoneType phoneType)
        {

            if (!PhoneExist(phoneType))
            {
                //Retornar Erro
            }

            var phoneExist = _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault();
            phoneExist.SetPhone(ddd, phone, phoneType);

        }
        public void RemovePhone(PhoneType phoneType)
        {
            if (!PhoneExist(phoneType))
            {
                //Retornar Erro
            }
            var phoneExist = _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault();
            _phones.Remove(phoneExist);

        }
        private bool PhoneExist(PhoneType phoneType)
        {
            return _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault() == null;
        }

        public void SetAddress(string zipCode, string street, string number, string neighborhood, string city, string state,
                        string complement = null, string reference = null)
        {
            if (Address == null)
            {
                //Retornar Erro
            }
            Address.SetAddress(zipCode, street, number, neighborhood, city, state,
                         complement, reference);
        }
        public void SetEmail(string email)
        {
            if (Email == null)
            {
                //Retornar Erro
            }
            Email.SetEmail(email);
        }
    }
}
