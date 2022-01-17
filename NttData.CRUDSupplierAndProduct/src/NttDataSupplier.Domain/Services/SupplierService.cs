using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Models.enums;
using NttDataSupplier.Domain.Models.Validation;
using NttDataSupplier.Domain.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (!ValidatiSupplier(supplier)) return;

            if (supplier is SupplierJuriDical)
            {
                var viewModel = (SupplierJuriDical)supplier;
                var result = await _supplierRepository.Find(x => x.Cnpj.Contains(viewModel.Cnpj) || x.FantasyName.Contains(viewModel.FantasyName));
                if (result != null)
                {
                    if (result.Cnpj == viewModel.Cnpj)
                    {
                        Notify("Cnpj já cadastrado para outro fornecedor");
                    }
                    if (result.FantasyName == viewModel.FantasyName)
                    {
                        Notify("Nome fantasia já cadastrado para outro fornecedor");
                    }
                    return;
                }


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
                var result = await _supplierRepository.Find(x => x.Cpf.Contains(viewModel.Cpf) || x.FantasyName.Contains(viewModel.FantasyName));
                if (result != null)
                {
                    if (result.Cpf == viewModel.Cpf)
                    {
                        Notify("Cpf já cadastrado para outro fornecedor");
                    }
                    if (result.FantasyName == viewModel.FantasyName)
                    {
                        Notify("Nome fantasia já cadastrado para outro fornecedor");
                    }
                    return;
                }


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
        public async Task Update(Supplier supplier)
        {
            if (!ValidatiSupplier(supplier)) return;

            var modelDb = await _supplierRepository.FindById(supplier.Id);

            if (modelDb == null)
            {
                Notify("Fornecedor não encontrado");
                return;
            }

            if (modelDb.Email.EmailAddress != supplier.Email.EmailAddress)
                modelDb.UpdateEmail(supplier.Email.EmailAddress);

            if (modelDb.Address.ZipCode != supplier.Address.ZipCode)
                modelDb.UpdateAddress(supplier.Address.ZipCode, supplier.Address.Street, supplier.Address.Number,
                                                supplier.Address.Neighborhood, supplier.Address.City, supplier.Address.State,
                                                supplier.Address.Complement, supplier.Address.Reference);

            var celViewModel = supplier.Phones.Where(x => x.PhoneType == PhoneType.Celular).FirstOrDefault();
            var fixoViewModel = supplier.Phones.Where(x => x.PhoneType == PhoneType.Fixo).FirstOrDefault();
            var comercialViewModel = supplier.Phones.Where(x => x.PhoneType == PhoneType.Comercial).FirstOrDefault();

            if (celViewModel != null)
            {
                if (!modelDb.PhoneExist(PhoneType.Celular))
                    modelDb.UpdatePhone(celViewModel.Ddd, celViewModel.Number, PhoneType.Celular);
            }
            else
            {
                Notify("É obrigatorio informar o telefone celular");
                return;
            }

            if (fixoViewModel != null)
            {

                if (!modelDb.PhoneExist(PhoneType.Fixo))
                    modelDb.UpdatePhone(fixoViewModel.Ddd, fixoViewModel.Number, PhoneType.Fixo);
                else
                {
                    var newPhone = new Phone(modelDb.Id, fixoViewModel.Ddd, fixoViewModel.Number, PhoneType.Fixo);
                    modelDb.AddPhone(newPhone);
                    await _supplierRepository.InsertPhone(newPhone);
                }

            }
            else
            {
                if (!modelDb.PhoneExist(PhoneType.Fixo))
                {
                    var phoneRemove = modelDb.Phones.Where(x => x.PhoneType == PhoneType.Fixo).First();
                    modelDb.RemovePhone(PhoneType.Fixo);
                    await _supplierRepository.RemovePhone(phoneRemove);
                }

            }

            if (comercialViewModel != null)
            {
                if (!modelDb.PhoneExist(PhoneType.Comercial))
                    modelDb.UpdatePhone(comercialViewModel.Ddd, comercialViewModel.Number, PhoneType.Comercial);
                else
                {
                    var newPhone = new Phone(modelDb.Id, comercialViewModel.Ddd, comercialViewModel.Number, PhoneType.Comercial);
                    modelDb.AddPhone(newPhone);
                    await _supplierRepository.InsertPhone(newPhone);
                }
            }
            else
            {
                if (!modelDb.PhoneExist(PhoneType.Comercial))
                {
                    var phoneRemove = modelDb.Phones.Where(x => x.PhoneType == PhoneType.Comercial).First();
                    modelDb.RemovePhone(PhoneType.Comercial);
                    await _supplierRepository.RemovePhone(phoneRemove);
                }
            }

            if (supplier is SupplierJuriDical)
            {
                var modelDbJuridical = (SupplierJuriDical)modelDb;
                var view = (SupplierJuriDical)supplier;
                modelDbJuridical.SetFantasyName(view.FantasyName);
                modelDbJuridical.SetCompanyName(view.CompanyName);
                modelDbJuridical.SetOpenDate(view.OpenDate);

                await _supplierRepository.Update(modelDbJuridical);
            }
            if (supplier is SupplierPhysical)
            {
                var modelDbPhysical = (SupplierPhysical)modelDb;
                var view = (SupplierPhysical)supplier;
                modelDbPhysical.SetFantasyName(view.FantasyName);
                modelDbPhysical.SetFullName(view.FullName);
                modelDbPhysical.SetBirthDate(view.BirthDate);

                await _supplierRepository.Update(modelDbPhysical);
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
        private bool ValidatiSupplier(Supplier supplier)
        {
            if (supplier is SupplierJuriDical) RunValidation(new SupplierJuridicalValidation(), (SupplierJuriDical)supplier);
            else RunValidation(new SupplierPhysicalValidation(), (SupplierPhysical)supplier);

            if (supplier.Address == null) Notify("Endereço é obrigatorio");
            else RunValidation(new AddressValidation(), supplier.Address);

            if (supplier.Email == null) Notify("Email é obrigatorio");
            else RunValidation(new EmailValidation(), supplier.Email);

            if (supplier.Phones.Count < 1) Notify("Um telefone é obrigatorio");
            else foreach (var item in supplier.Phones)
                    RunValidation(new PhoneValidation(), item);

            if (!OperationValid())
                return true;
            else
                return false;
        }

        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty) throw new DomainException("Id not found");

            var resultDb = await FindById(id);

            if (resultDb == null) throw new DomainException("Id not found");

            await _supplierRepository.RemoveAddress(resultDb.Address);
            await _supplierRepository.RemoveEmail(resultDb.Email);
            await _supplierRepository.RemoveRangePhone((List<Phone>)resultDb.Phones);
            await _supplierRepository.Remove(resultDb);

            try
            {
                await _supplierRepository.SaveChanges();
            }
            catch
            {
                Notify("Não é possivel excluir esse fornecedor, o mesmo possui produtos atrelados. Exclusa os produtos primeiro e tente novamente.");
            }
        }
    }
}
