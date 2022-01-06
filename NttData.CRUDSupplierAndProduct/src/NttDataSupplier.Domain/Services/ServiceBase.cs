using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : Entity
    {        

        public async Task<T> Find(Expression<Func<T, bool>> expression)
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
