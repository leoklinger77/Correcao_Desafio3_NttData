using NttDataSupplier.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<T> : IDisposable where T : Entity
    {
        Task<PaginationModel<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression);

        Task Insert(T entity);
        Task Update(T entity);
        Task<T> Find(Expression<Func<T, bool>> expression);

        Task<int> SaveChanges();
    }
}
