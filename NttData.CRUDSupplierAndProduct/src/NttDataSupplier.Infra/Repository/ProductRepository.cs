using Microsoft.EntityFrameworkCore;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NttDataSupplier.Infra.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NttDataContext context) : base(context)
        {
        }

        public override async Task<Product> FindById(Guid id)
        {
            return await _dbSet.Where(X => X.Id == id)
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .Include(x => x.Images)
                .FirstOrDefaultAsync();
        }

        public async Task InsertImageRanger(IReadOnlyCollection<Image> images)
        {
            await _context.Image.AddRangeAsync(images);
        }

        public async Task RemoveRangeImage(List<Image> images)
        {
            _context.Image.RemoveRange(images);
            await Task.CompletedTask;
        }
    }
}
