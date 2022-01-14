using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await _supplierRepository.FindById(id);

            if (result == null) Notify("Fornecedor não localizada");

            return result;
        }

        public async Task Insert(Supplier supplier)
        {
            if (supplier is SupplierJuriDical) RunValidation(new SupplierJuridicalValidation(), (SupplierJuriDical)supplier);
            else if (RunValidation(new SupplierPhysicalValidation(), (SupplierPhysical)supplier)) return;

            if (supplier.Address == null) Notify("");
            else if (RunValidation(new AddressValidation(), supplier.Address)) return;

            if (supplier.Email == null) Notify("");
            else if (RunValidation(new EmailValidation(), supplier.Email)) return;

            if (supplier.Phones.Count < 1) Notify("");
            else foreach (var item in supplier.Phones)
                    if (RunValidation(new PhoneValidation(), item)) return;


            //Validar Nome e CPF ou CPF repetido no banco


            if (supplier is SupplierJuriDical)
            {
                var viewModel = (SupplierJuriDical)supplier;
                var phone = supplier.Phones.Where(x => x.PhoneType == Models.enums.PhoneType.Celular).FirstOrDefault();
                SupplierJuriDical model = new SupplierJuriDical(viewModel.CompanyName, viewModel.Cnpj, viewModel.Active, viewModel.FantasyName,
                                                                    viewModel.Address.ZipCode, viewModel.Address.Street, viewModel.Address.Number, viewModel.Address.Neighborhood, viewModel.Address.City,
                                                                    viewModel.Address.State, viewModel.Address.Complement, viewModel.Address.Reference,
                                                                    viewModel.Email.EmailAddress,
                                                                    phone.Ddd, phone.Number);
                foreach (var item in supplier.Phones.Where(x => x.PhoneType != Models.enums.PhoneType.Celular).ToList())
                {
                    model.AddPhone(new Phone(model.Id, item.Ddd, item.Number, item.PhoneType));
                }

                await _supplierRepository.InsertJu(model);
            }
            else
            {
                var viewModel = (SupplierPhysical)supplier;
                var phone = supplier.Phones.Where(x => x.PhoneType == Models.enums.PhoneType.Celular).FirstOrDefault();
                SupplierPhysical model = new SupplierPhysical(viewModel.FullName, viewModel.Cpf, viewModel.Active, viewModel.FantasyName,
                                                                    viewModel.Address.ZipCode, viewModel.Address.Street, viewModel.Address.Number, viewModel.Address.Neighborhood, viewModel.Address.City,
                                                                    viewModel.Address.State, viewModel.Address.Complement, viewModel.Address.Reference,
                                                                    viewModel.Email.EmailAddress,
                                                                    phone.Ddd, phone.Number);

                foreach (var item in supplier.Phones.Where(x => x.PhoneType != Models.enums.PhoneType.Celular).ToList())
                {
                    model.AddPhone(new Phone(model.Id, item.Ddd, item.Number, item.PhoneType));
                }

                await _supplierRepository.InsertPh(model);

            }

            await _supplierRepository.SaveChanges();
        }

        public async Task<IEnumerable<Supplier>> ToList()
        {
            return await _supplierRepository.FindAll();
        }

        public async Task<IEnumerable<Supplier>> ToListAndProduct()
        {
            return await _supplierRepository.FindAllAndProduct();
        }
    }
}
