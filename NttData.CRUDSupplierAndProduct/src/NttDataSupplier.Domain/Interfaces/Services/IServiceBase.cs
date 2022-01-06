using NttDataSupplier.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface IServiceBase<T> : IDisposable where T : Entity
    {
        Task<PaginationModel<T>> Pagination(int page, int size, string query);
        Task<T> Find(Expression<Func<T, bool>> expression);
    }

    
}
