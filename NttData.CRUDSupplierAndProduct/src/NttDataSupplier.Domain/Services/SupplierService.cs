using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Models.Validation;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Services
{
    public class SupplierService : ServiceBase<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(INotificationService notificationService, ISupplierRepository supplierRepository) : base(notificationService)
        {
            _supplierRepository = supplierRepository;
        }

        public override async Task<PaginationModel<Supplier>> Pagination(int page, int size, string query)
        {
            if (string.IsNullOrEmpty(query))
                return await _supplierRepository.Pagination(page, size, null);
            else
                return await _supplierRepository.Pagination(page, size, x => x.FantasyName.Contains(query));
        }

        public override async Task<Supplier> FindById(Guid id)
        {
            var result = await _supplierRepository.Find(x => x.Id == id);

            if (result == null) Notify("Fornecedor não localizada");

            return result;
        }

        public async Task Insert(Supplier supplier)
        {
            if (supplier is SupplierJuriDical) RunValidation(new SupplierJuridicalValidation(), (SupplierJuriDical)supplier);
            else RunValidation(new SupplierPhysicalValidation(), (SupplierPhysical)supplier);

            if (supplier.Address == null) Notify("");
            else RunValidation(new AddressValidation(), supplier.Address);

            if (supplier.Email == null) Notify("");
            else RunValidation(new EmailValidation(), supplier.Email);

            if (supplier.Phones.Count < 1) Notify("");
            else foreach (var item in supplier.Phones)
                    RunValidation(new PhoneValidation(), item);

            //Validar Nome e CPF ou CPF repetido no banco


            await _supplierRepository.Insert(supplier);

            await _supplierRepository.SaveChanges();
        }
    }
}
