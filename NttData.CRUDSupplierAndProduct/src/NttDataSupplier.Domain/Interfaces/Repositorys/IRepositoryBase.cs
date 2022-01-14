using NttDataSupplier.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<T> : IDisposable where T : Entity
    {
        Task<PaginationModel<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> FindAll();

        Task Insert(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<T> FindById(Guid id);
        Task<T> Find(Expression<Func<T, bool>> expression);

        Task<int> SaveChanges();
    }
}
