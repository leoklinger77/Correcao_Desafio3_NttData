using NttDataSupplier.Domain.Models;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface IServiceBase<T> : IDisposable where T : Entity
    {
        Task<PaginationModel<T>> Pagination(int page, int size, string query);
        Task<T> FindById(Guid id);
    }
}
