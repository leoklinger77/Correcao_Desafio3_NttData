using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.WebApp.Extensions;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Category;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Controllers
{
    [Route("Categorias")]
    public class CategoryController : MainController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(INotificationService notificationService,
                                    IMapper mapper,
                                    ICategoryService categoryService)
                                    : base(notificationService, mapper)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("todas-as-categorias")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 1, string query = null)
        {
            var result = await _categoryService.Pagination(pageIndex, pageSize, query);

            result.Query = query;
            result.ReferenceAction = "Index";

            return View(_mapper.Map<PaginationViewModel<CategoryViewModel>>(result));
        }

        [AllowAnonymous]
        [HttpGet("nova-cagetoria")]
        public IActionResult New()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("nova-cagetoria")]
        public async Task<IActionResult> New(NewCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            await _categoryService.Insert(_mapper.Map<Category>(viewModel));

            if (OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet("editar-cagetoria/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _categoryService.FindById(id);

            return View(_mapper.Map<EditCategoryViewModel>(result));
        }

        [AllowAnonymous]
        [HttpPost("editar-cagetoria/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, EditCategoryViewModel viewModel)
        {
            if (id == Guid.Empty || id != viewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return View(viewModel);

            await _categoryService.Update(_mapper.Map<Category>(viewModel));

            if (OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet("detalhe-cagetoria/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _categoryService.FindById(id);

            return View(_mapper.Map<DetailsCategoryViewModel>(result));
        }

        [AllowAnonymous]
        [HttpGet("deletar-cagetoria/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _categoryService.FindById(id);

            return View(_mapper.Map<DeleteCategoryViewModel>(result));
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost("editar-cagetoria")]
        public async Task<IActionResult> DeleteConfirmation(DeleteCategoryViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty) return BadRequest();

            await _categoryService.Delete(viewModel.Id);

            return RedirectToAction(nameof(Index));
        }

    }
}
