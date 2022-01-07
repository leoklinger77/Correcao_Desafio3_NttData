using Microsoft.EntityFrameworkCore;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Infra.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace NttDataSupplier.Infra.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly NttDataContext _context;
        protected DbSet<T> _dbSet;

        public RepositoryBase(NttDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<PaginationModel<T>> Pagination(int page, int size, Expression<Func<T, bool>> expression)
        {
            IPagedList<T> pagedList = await _dbSet.Where(expression).AsNoTracking().ToPagedListAsync(page, size);

            return new PaginationModel<T>()
            {
                List = pagedList.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = null,
                TotalResult = pagedList.TotalItemCount
            };
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }        
    }
}
