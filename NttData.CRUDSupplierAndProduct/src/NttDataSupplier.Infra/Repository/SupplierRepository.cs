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
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NttDataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Supplier>> FindAllAndProduct()
        {
            return await _dbSet.Include(x => x.Products).AsNoTracking().ToListAsync();
        }

        public override async Task<Supplier> FindById(Guid id)
        {
            return await _dbSet
                .Include(x => x.Email)
                .Include(x => x.Phones)
                .Include(x => x.Address)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task InsertAddress(Address address)
        {
            await _context.Address.AddAsync(address);
        }

        public async Task InsertEmail(Email email)
        {
            await _context.Email.AddAsync(email);
        }

        public async Task InsertJu(SupplierJuriDical juriDical)
        {
            await _context.SupplierJurifical.AddAsync(juriDical);
        }

        public async Task InsertPh(SupplierPhysical physical)
        {
            await _context.SupplierPhysical.AddAsync(physical);
        }

        public async Task InsertPhoneRanger(IEnumerable<Phone> phones)
        {
            await _context.Phone.AddRangeAsync(phones);
        }
    }
}
