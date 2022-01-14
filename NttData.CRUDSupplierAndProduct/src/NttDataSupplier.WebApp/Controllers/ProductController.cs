using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.WebApp.Extensions;
using NttDataSupplier.WebApp.Models;
using NttDataSupplier.WebApp.Models.Category;
using NttDataSupplier.WebApp.Models.Product;
using NttDataSupplier.WebApp.Models.Supplier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Controllers
{
    [Route("produtos")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        public ProductController(INotificationService notificationService,
                                    IMapper mapper,
                                    IProductService productService,
                                    ISupplierService supplierService,
                                    ICategoryService categoryService, 
                                    IImageService imageService)
                                    : base(notificationService, mapper)
        {
            _productService = productService;
            _supplierService = supplierService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        [AllowAnonymous]
        [HttpGet("todos-os-produtos")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 1, string query = null)
        {
            var result = await _productService.Pagination(pageIndex, pageSize, query);

            result.Query = query;
            result.ReferenceAction = "Index";

            return View(_mapper.Map<PaginationViewModel<ProductViewModel>>(result));
        }

        [AllowAnonymous]
        [HttpGet("novo-produto")]
        public async Task<IActionResult> New()
        {

            return View(await PopulationSupplierAndCategory(new NewProductViewModel()));
        }

        [AllowAnonymous]
        [HttpPost("novo-produto")]
        public async Task<IActionResult> New(NewProductViewModel viewModel)
        {
            if (viewModel.Images.Count == 0)
                _imageService.StoreImageTemporary(viewModel.ImageOne, viewModel.ImageTwo, viewModel.ImageTree, viewModel.ImageFor, viewModel.ImageFive)
                    .ForEach(x => viewModel.Images.Add(new NewImageViewModel() { ImagePath = x }));

            if (!ModelState.IsValid) return View(await PopulationSupplierAndCategory(viewModel));

            await _productService.Insert(_mapper.Map<Product>(viewModel));

            if (!OperationValid()) return View(await PopulationSupplierAndCategory(viewModel));

            return RedirectToAction(nameof(Index));
        }

        private async Task<NewProductViewModel> PopulationSupplierAndCategory(NewProductViewModel viewModel)
        {
            viewModel.ListSupplier = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierService.ToList());
            viewModel.ListCategory = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.ToList());

            return viewModel;
        }
    }
}
