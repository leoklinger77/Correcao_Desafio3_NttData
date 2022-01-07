using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : Entity
    {
        public Task<T> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginationModel<T>> Pagination(int page, int size, string query)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
