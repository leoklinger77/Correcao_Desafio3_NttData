using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Models.enums;
using NttDataSupplier.WebApp.Extensions;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Supplier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Controllers
{
    [Route("fornecedores")]
    public class SupplierController : MainController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(INotificationService notificationService, IMapper mapper, ISupplierService supplierService) : base(notificationService, mapper)
        {
            _supplierService = supplierService;
        }

        [AllowAnonymous]
        [HttpGet("todos-os-fornecedores")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 1, string query = null)
        {
            var result = await _supplierService.Pagination(pageIndex, pageSize, query);

            ICollection<SupplierViewModel> listViewModel = new List<SupplierViewModel>();
            foreach (var item in result.List)
            {
                if (item is SupplierJuriDical)
                    listViewModel.Add(_mapper.Map<SupplierViewModel>((SupplierJuriDical)item));
                else if (item is SupplierPhysical)
                    listViewModel.Add(_mapper.Map<SupplierViewModel>((SupplierPhysical)item));
            }

            return View(new PaginationViewModel<SupplierViewModel>()
            {
                List = listViewModel,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query,
                ReferenceAction = "Index",
                TotalResult = result.TotalResult
            });
        }

        [AllowAnonymous]
        [HttpGet("novo-forncedor")]
        public IActionResult New()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("novo-forncedor")]
        public async Task<IActionResult> New(NewSupplierViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            viewModel.Phones.Add(new PhoneViewModel() { Ddd = viewModel.TelCelular[..2], Number = viewModel.TelCelular[2..], PhoneType = PhoneType.Celular });
            
            if(!string.IsNullOrEmpty(viewModel.TelComercial))
                viewModel.Phones.Add(new PhoneViewModel() { Ddd = viewModel.TelComercial[..2], Number = viewModel.TelComercial[2..], PhoneType = PhoneType.Comercial });

            if (!string.IsNullOrEmpty(viewModel.TelHome))
                viewModel.Phones.Add(new PhoneViewModel() { Ddd = viewModel.TelHome[..2], Number = viewModel.TelHome[2..], PhoneType = PhoneType.Fixo });

            Supplier supplier;
            if (!string.IsNullOrEmpty(viewModel.Cnpj))
                supplier = _mapper.Map<SupplierJuriDical>(viewModel);
            else
                supplier = _mapper.Map<SupplierPhysical>(viewModel);

            await _supplierService.Insert(supplier);

            if (OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

    }
}
