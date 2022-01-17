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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Controllers
{
    [Route("fornecedores")]
    public class SupplierController : MainController
    {
        private readonly ISupplierService _supplierService;
        private readonly Report _report;
        public SupplierController(INotificationService notificationService,
                                    IMapper mapper,
                                    ISupplierService supplierService,
                                    Report report)
                                    : base(notificationService, mapper)
        {
            _supplierService = supplierService;
            _report = report;
        }

        [AllowAnonymous]
        [HttpGet("todos-os-fornecedores")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 1, string query = null)
        {
            var result = await _supplierService.Pagination(pageIndex, pageSize, query);

            ICollection<SupplierViewModel> listViewModel = new List<SupplierViewModel>();
            foreach (var item in result.List)
            {
                listViewModel.Add(_mapper.Map<SupplierViewModel>(item));
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

        [ClaimsAuthorizeAttribute("Supplier", "Delete")]
        [HttpGet("novo-fornecedor")]
        public IActionResult New()
        {
            return View(new NewOrEditSupplierViewModel());
        }

        [ClaimsAuthorizeAttribute("Supplier", "Delete")]
        [HttpPost("novo-fornecedor")]
        public async Task<IActionResult> New(NewOrEditSupplierViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            viewModel = RemoveMask(viewModel);
            viewModel = MappingPhone(viewModel);

            await _supplierService.Insert(MappingSupplier(viewModel));

            if (OperationValid()) return View(viewModel);

            TempData["Success"] = "Cadastro realizado com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorizeAttribute("Supplier", "Delete")]
        [HttpGet("novo-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = _mapper.Map<NewOrEditSupplierViewModel>(await _supplierService.FindById(id));

            result.SetPhones();

            return View(result);
        }

        [ClaimsAuthorizeAttribute("Supplier", "Delete")]
        [HttpPost("novo-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, NewOrEditSupplierViewModel viewModel)
        {
            if (id == Guid.Empty || id != viewModel.Id) return BadRequest();

            ModelState.Remove("SupplierType");
            if (!ModelState.IsValid) return View(viewModel);

            viewModel = RemoveMask(viewModel);
            viewModel = MappingPhone(viewModel);

            await _supplierService.Update(MappingSupplier(viewModel));

            if (OperationValid()) return View(viewModel);

            TempData["Success"] = "Cadastro editado com sucesso";
            return RedirectToAction(nameof(Edit));
        }

        [AllowAnonymous]
        [HttpGet("detalhes-fornecedor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = _mapper.Map<SupplierViewModel>(await _supplierService.FindById(id));

            if (OperationValid()) return RedirectToAction(nameof(Index));
            result.SetPhones();
            result.SetTypePerson();
            return View(result);
        }

        [ClaimsAuthorizeAttribute("Supplier", "Delete")]
        [HttpGet("deletar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = _mapper.Map<SupplierViewModel>(await _supplierService.FindById(id));

            if (OperationValid()) return RedirectToAction(nameof(Index));
            result.SetPhones();
            result.SetTypePerson();
            return View(result);
        }

        [ClaimsAuthorizeAttribute("Supplier", "Delete")]
        [HttpPost("deletar-fornecedor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            await _supplierService.Delete(id);

            if (OperationValid())
            {
                var result = _mapper.Map<SupplierViewModel>(await _supplierService.FindById(id));
                result.SetPhones();
                result.SetTypePerson();
                return View(nameof(Delete), result);
            }

            TempData["Success"] = "Cadastro excluido com sucesso";
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<FileResult> Report()
        {
            return File(await _report.GeneratorReport(), "application/xlsx", "relatorio.xlsx");
        }

        private Supplier MappingSupplier(NewOrEditSupplierViewModel viewModel)
        {
            Supplier supplier;
            if (!string.IsNullOrEmpty(viewModel.Cnpj))
                supplier = _mapper.Map<SupplierJuriDical>(viewModel);
            else
                supplier = _mapper.Map<SupplierPhysical>(viewModel);

            return supplier;
        }
        private NewOrEditSupplierViewModel MappingPhone(NewOrEditSupplierViewModel viewModel)
        {
            viewModel.Phones.Add(new PhoneViewModel() { Ddd = viewModel.TelCelular[..2], Number = viewModel.TelCelular[2..], PhoneType = PhoneType.Celular });

            if (!string.IsNullOrEmpty(viewModel.TelComercial))
                viewModel.Phones.Add(new PhoneViewModel() { Ddd = viewModel.TelComercial[..2], Number = viewModel.TelComercial[2..], PhoneType = PhoneType.Comercial });

            if (!string.IsNullOrEmpty(viewModel.TelHome))
                viewModel.Phones.Add(new PhoneViewModel() { Ddd = viewModel.TelHome[..2], Number = viewModel.TelHome[2..], PhoneType = PhoneType.Fixo });

            return viewModel;
        }
        private NewOrEditSupplierViewModel RemoveMask(NewOrEditSupplierViewModel viewModel)
        {
            viewModel.Cnpj = viewModel.Cnpj?.Replace(".", "").Replace("-", "").Replace("/", "");
            viewModel.Cpf = viewModel.Cpf?.Replace(".", "").Replace("-", "");
            viewModel.TelCelular = viewModel.TelCelular?.Replace(".", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            viewModel.TelHome = viewModel.TelHome?.Replace(".", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""); ;
            viewModel.TelComercial = viewModel.TelComercial?.Replace(".", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            viewModel.Address.ZipCode = viewModel.Address.ZipCode?.Replace("-", "");

            return viewModel;
        }

    }
}
