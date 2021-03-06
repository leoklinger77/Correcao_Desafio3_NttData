using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Models.Validation;
using NttDataSupplier.Domain.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(INotificationService notificationService, ICategoryRepository categoryRepository) : base(notificationService)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<Category> FindById(Guid id)
        {
            var result = await _categoryRepository.Find(x => x.Id == id);

            if (result == null) Notify("categoria não localizada");

            return result;
        }

        public override async Task<PaginationModel<Category>> Pagination(int page, int size, string query = null)
        {
            if (string.IsNullOrEmpty(query))
                return await _categoryRepository.Pagination(page, size, null);
            else
                return await _categoryRepository.Pagination(page, size, x => x.Name.Contains(query));
        }

        public async Task Insert(Category category)
        {
            if (!RunValidation(new CategoryValidation(), category)) return;

            if (_categoryRepository.Find(x => x.Name.Contains(category.Name)).Result != null)
            {
                Notify("O nome já existe para outra categoria");
                return;
            }

            await _categoryRepository.Insert(category);

            await _categoryRepository.SaveChanges();
        }

        public async Task Update(Category category)
        {
            if (!RunValidation(new CategoryValidation(), category)) return;

            var validDb = await _categoryRepository.Find(x => x.Name.Contains(category.Name));
            if (validDb != null && validDb.Id != category.Id)
            {
                Notify("O nome já existe para outra categoria");
                return;
            }
            var result = await FindById(category.Id);

            if (result == null) return;

            result.SetName(category.Name);

            await _categoryRepository.Update(result);
            await _categoryRepository.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty) throw new DomainException("Id invalido");

            var result = await FindById(id);

            if (result == null)
            {
                throw new DomainException("Categoria não localizada para remoção");
            }

            await _categoryRepository.Remove(result);
            await _categoryRepository.SaveChanges();
        }

        public async Task<IEnumerable<Category>> ToList()
        {
            return await _categoryRepository.FindAll();
        }
    }
}
