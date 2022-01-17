using NttDataSupplier.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Repositorys
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        Task<SupplierJuriDical> Find(Expression<Func<SupplierJuriDical, bool>> expression);
        Task<SupplierPhysical> Find(Expression<Func<SupplierPhysical, bool>> expression);
        Task InsertJu(SupplierJuriDical juriDical);
        Task InsertPh(SupplierPhysical physical);

        Task InsertAddress(Address address);
        Task InsertEmail(Email email);
        Task InsertPhone(Phone newPhone);
        Task InsertPhoneRanger(IEnumerable<Phone> phones);

        Task<IEnumerable<Supplier>> FindAllAndProduct();
        
        Task RemovePhone(Phone phoneRemove);
        Task RemoveRangePhone(List<Phone> list);
        Task RemoveEmail(Email email);
        Task RemoveAddress(Address address);
    }
}
