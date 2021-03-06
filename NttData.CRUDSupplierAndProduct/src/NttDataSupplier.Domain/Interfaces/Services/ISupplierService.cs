using NttDataSupplier.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{

    public interface ISupplierService : IServiceBase<Supplier>
    {
        Task Insert(Supplier supplier);
        Task Update(Supplier supplier);

        Task<IEnumerable<Supplier>> ToList();
        Task<IEnumerable<Supplier>> ToListAndProduct();
        Task Delete(Guid id);
    }


}
