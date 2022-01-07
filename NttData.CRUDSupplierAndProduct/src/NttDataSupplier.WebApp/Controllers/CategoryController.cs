﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.WebApp.Extensions;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Category;
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

        [HttpGet("nova-cagetoria")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("nova-cagetoria")]
        public async Task<IActionResult> New(NewCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            await _categoryService.Insert(_mapper.Map<Category>(viewModel));

            if(OperationValid()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

    }
}