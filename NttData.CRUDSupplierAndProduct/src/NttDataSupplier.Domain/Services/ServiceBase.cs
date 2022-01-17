using FluentValidation;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : Entity
    {
        private readonly INotificationService _notificationService;

        protected ServiceBase(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public virtual async Task<T> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PaginationModel<T>> Pagination(int page, int size, string query)
        {
            throw new NotImplementedException();
        }

        protected bool RunValidation<Tv, Te>(Tv validacao, Te entidade) where Tv : AbstractValidator<Te> where Te : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            foreach (var item in validator.Errors)
            {
                Notify(item.ErrorMessage);
            }

            return false;
        }

        protected bool OperationValid() => _notificationService.HasError();

        protected void Notify(string error)
        {
            _notificationService.AddErro(error);
        }

        public void Dispose() { }
    }
}
